// searchSuggestions design additions

$('#searchSuggestions').css({
    "width": $('#searchDiv').width()
})

$(window).resize(() => {
    if ($(window).width() <= 768 && $('#searchSuggestions').css('display') == 'block') {
        $("#searchSuggestions").fadeOut(150)
    }
})

$(window).resize(() => {
    $('#searchSuggestions').css({
        "width": $('#searchDiv').width()
    })
})

$('#searchTxtBx').focus(() => {
    $("#searchSuggestions").fadeIn(150)
})

$('#searchTxtBx').on("focusout", function (event) {
    var clickedElement = event.relatedTarget;

    if (!$(this).is(clickedElement) && !$("#searchTxtBx").is(clickedElement) && $(this).has(clickedElement).length === 0) {
        $("#searchSuggestions").fadeOut(150)
    }
});


// notifications design additions

$('#noti-bell').hover(() => {
    $('#noti-bell').find(':first').removeClass('fa-regular').addClass('fa-solid');
}, function () {
    $('#noti-bell').find(':first').removeClass('fa-solid').addClass('fa-regular');
});


function notiClick() {
    $("#noti-count").fadeOut(100);
    $("#notifications").fadeIn(150);
}

$(window).on("click", function (event) {
    var clickedElement = event.target;

    if (!$(this).is(clickedElement) && !$(".fa-bell").is(clickedElement) && !$("#noti-count").is(clickedElement) && !$("#notifications").is(clickedElement) && !$("#noti-header").is(clickedElement) && !$(".fa-check").is(clickedElement) && !$("#notificationsUl").is(clickedElement) && !$(".noti-li").is(clickedElement) && !$(".noti-text").is(clickedElement) && !$(".noti-new").is(clickedElement) && $(this).has(clickedElement).length === 0) {
        $("#notifications").fadeOut(150);
    }
});

function markAsRead() {
    $.ajax({
        type: "POST",
        url: "/Home/MarkAsRead",
    });

    const mark = document.getElementById("mark-read")
    mark.classList.add("disabled");

    var notifications = document.querySelectorAll('.noti-li');

    notifications.forEach(function (item, index) {
        item.children[0].style.opacity = '.5';
        item.children[1].style.visibility = 'hidden';
    })
}


// Animation for like image

var animateButton = function (e) {
    e.preventDefault;
    e.target.classList.remove('animate');

    e.target.classList.add('animate');
    setTimeout(function () {
        e.target.classList.remove('animate');
    }, 700);
};

var bubblyButtons = document.getElementsByClassName("bubbly-button");

for (var i = 0; i < bubblyButtons.length; i++) {
    bubblyButtons[i].addEventListener('click', animateButton, false);
}


// Downloading selected image

var downloadImage = (ele) => {
    download(ele.id, "Image");
    var option = ele.id;

    $.ajax({
        type: "POST",
        url: "/Home/DownloadImage",
        data: { Link: String(option) },
    });

    function download(url, name) {
        fetch(url)
            .then(resp => resp.blob())
            .then(blob => {
                const url = window.URL.createObjectURL(blob);
                const a = document.createElement('a');
                a.style.display = 'none';
                a.href = url;
                a.download = name;
                document.body.appendChild(a);
                a.click();
                window.URL.revokeObjectURL(url);
            })
    }
}


// Like selected image

var likeImage = (obj) => {
    var option = obj.id;

    $.ajax({
        type: "POST",
        url: "/Home/LikeImage",
        data: { link: String(option) },
    });

    obj.classList.toggle("redHeart")
}


// Unlike selected image

var unlikeImage = (obj) => {
    var option = obj.id;

    $.ajax({
        type: "POST",
        url: "/Home/LikeImage",
        data: { link: String(option) },
    });

    var parent = obj.parentNode.parentNode.parentNode.parentNode;
    parent.remove();
}


// Deleting selected image

var deleteImage = (obj) => {
    var option = obj.id;

    $.ajax({
        type: "POST",
        url: "/Home/DeleteImage",
        data: { link: String(option) },
    });

    var parent = obj.parentNode.parentNode.parentNode;
    parent.remove();
}


// Sending  tags to action

function sendData() {
    var items = [];
    $("#tagUl li").map(function () {
        items.push(this.innerText);
    });
    $.ajax({
        type: "POST",
        data: {
            list: items
        },
        url: "/User/AddTag",
    })
}


// Adding search suggestions for particular searchPattern

$(function () {
    $('#searchTxtBx').keyup(function () {
        var searchTerm = $(this).val().toLowerCase();

        $.ajax({
            url: '/Home/SearchTag',
            type: 'POST',
            data: { searchTerm: searchTerm },
            success: function (data) {
                $('#suggestionsUL').empty();
                $.each(data, function (i, item) {
                    var url = '/Home/Search?searchPattern=' + item + '&searchType=tag';
                    var anchor = $('<a>').attr('href', url).attr('onclick', 'sendTagData(this)').text(item);
                    var li = $('<li>').append(anchor);

                    $('#suggestionsUL').append(li);
                });
            }
        });
    });
});


//Sending tag data to the localstorage

function sendTagData(element) {
    var textContent = element.textContent;

    localStorage.setItem("searchPattern", textContent);
    localStorage.setItem("searchType", "tag");
}


// Sending search data to the action

function sendSearchData(event, elem) {
    event.preventDefault();

    if (elem != undefined) {
        var textContent = $(elem).text();
    }
    else {
        var textContent = $('#searchTxtBx').val();
    }

    var currentUrl = window.location.href;
    var https = currentUrl.split('//')[0];
    var hostPort = currentUrl.split('//')[1].split('/')[0];

    if (textContent.length > 0) {
        var newUrl = https + "//" + hostPort + "/Home/Search?searchPattern=" + textContent + "&searchType=tag";
        window.location.href = newUrl;

        localStorage.setItem("searchPattern", textContent);
        localStorage.setItem("searchType", "tag");
    }
    else {
        var newUrl = https + "//" + hostPort;
        window.location.href = newUrl;
    }
}