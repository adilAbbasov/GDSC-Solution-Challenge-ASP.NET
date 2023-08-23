var page = 0,
    inCallback = false,
    isReachedScrollEnd = false,
    ajaxCallUrl = "";

if (window.location.href.includes('Home') || window.location.href.endsWith('/')) {
    ajaxCallUrl = '/Home/ImageList';
}
else if (window.location.href.includes('Company')) {
    ajaxCallUrl = '/Company/CompanyList';
}

var scrollHandler = function () {
    var height = $(Window).scrollTop();

    if (isReachedScrollEnd == false &&
        (height >= $(document).height() - 1000)) {
        loadProducts(ajaxCallUrl);
    }
}

function loadProducts(ajaxCallUrl) {
    if (page > -1 && !inCallback) {
        inCallback = true;
        page++;

        console.log(localStorage.getItem("searchPattern"), localStorage.getItem("searchType"))

        $.ajax({
            type: 'GET',
            url: ajaxCallUrl,
            data: { "pageNumber": page, "searchPattern": localStorage.getItem("searchPattern"), "searchType": localStorage.getItem("searchType") },
            success: function (data, textstatus) {
                if (data.length > 100) {
                    if (data != '') {
                        data = data.replaceAll('class="card"', 'class="card img-loaded"');
                        data = data.replaceAll('probootstrap-animate', 'probootstrap-animate fadeInUp probootstrap-animated');
                        data = data.replaceAll('<div class="image-column">', ' ');
                        arr = data.split('<br />');

                        var children = $("#divajaxCall").children(".image-column").eq(0);
                        $(arr[0]).appendTo(children);

                        var children = $("#divajaxCall").children(".image-column").eq(1);
                        $(arr[1]).appendTo(children);

                        var children = $("#divajaxCall").children(".image-column").eq(2);
                        $(arr[2]).appendTo(children);
                    }
                    else {
                        page = -1;
                    }

                    inCallback = false;
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.error('An error occurred while loading data.')
            }
        });
    }
}