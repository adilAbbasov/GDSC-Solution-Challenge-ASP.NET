const draggerArea = document.getElementById('dragger');
const inputField = document.getElementById('fileInputField');
const dragText = document.getElementById('drag-text');
const fileDelete = document.getElementById('fileDelete');
const browseFile = document.getElementById('browseFile');
const textarea = document.getElementById('textarea');
const errorMessage = document.getElementById('error-message')

const inputClick = () => {
    inputField.value = ""
    inputField.click();
};

inputField.addEventListener('change', function (e) {
    const file = this.files[0];
    fileHandler(file);
});

draggerArea.addEventListener('dragover', (e) => {
    e.preventDefault()
    dragText.textContent = "Release to upload image"
});

draggerArea.addEventListener('dragleave', () => {
    dragText.textContent = "Drag and drop file"
});

draggerArea.addEventListener('drop', (e) => {
    e.preventDefault()
    file = e.dataTransfer.files[0];
    fileHandler(file)
});

const deleteHandler = () => {
    const draggerElement = `<div class="icon"><i class="fa-solid fa-images"></i></div><h3 id="drag-text">Drag and drop file</h3><button class="browseFile py-1 px-3" id="browseFile" onclick="inputClick()">Browse</button><input type="file" hidden id="fileInputField"/>`;
    draggerArea.innerHTML = draggerElement
    draggerArea.classList.remove('active');
};

function loadImage(file) {
    return new Promise((resolve, reject) => {
        const img = new Image();

        img.onload = function () {
            megapixels = (this.width * this.height) / 1000000
            resolve(megapixels.toFixed(2));
        };

        img.onerror = function () {
            reject(new Error("Failed to calculate megapixels"));
        };

        img.src = URL.createObjectURL(file);
    });
}

const fileHandler = (file) => {
    //const validExt = ["image/jpeg", "image/jpg", "image/png"];
    var fileSize = file.size / (1024 * 1024);
    var megapixelSize = 0

    loadImage(file)
        .then(megapixels => {
            megapixelSize = parseInt(megapixels);

            if (fileSize <= 10 && megapixelSize >= 1) {
                const fileReader = new FileReader();
                fileReader.readAsArrayBuffer(file);

                fileReader.onload = () => {
                    const fileResult = fileReader.result

                    let blob = new Blob([fileResult], { type: file.type });
                    let blobFile = new File([blob], file.name, { type: file.type });

                    const blobReader = new FileReader();
                    blobReader.readAsDataURL(blob);

                    blobReader.onload = () => {
                        const blobResult = blobReader.result

                        let imgTag = `<img src=${blobResult} alt=""/><div id="fileDelete"><i class="fa-solid fa-trash-can" onclick={deleteHandler()}></i></div>`
                        draggerArea.innerHTML = imgTag;

                        let formdData = new FormData();
                        formdData.append('file', blobFile);

                        let fetchAddress = "";

                        if (window.location.href.includes('User')) {
                            fetchAddress = 'https://localhost:7130/User/GetFileName';
                        }
                        else if (window.location.href.includes('Company')) {
                            fetchAddress = 'https://localhost:7130/Company/GetFileName';
                        }

                        fetch(fetchAddress, {
                            method: 'POST',
                            body: formdData
                        })
                            .then(response => {
                                if (!response.ok) {
                                    throw new Error('Network response was not ok');
                                }
                                return response.status;
                            })
                            .then(data => {
                                console.log(data);
                            })
                            .catch(error => {
                                console.error('There was a problem with the fetch operation:', error);
                            });
                    }

                    draggerArea.classList.add('active')
                };
            }
            else {
                draggerArea.classList.remove('active');
                dragText.textContent = "Drag drop file"

                if (fileSize > 10) {
                    $(errorMessage).text("The size of the uploaded file must not exceed 10 megabytes")
                }
                else if (megapixelSize < 3) {
                    $(errorMessage).text("The size of the uploaded file must exceed 3 megapixels")
                }

                $(errorMessage).fadeIn(200);
            }
        })
        .catch(error => {
            console.error(error);
        });
};