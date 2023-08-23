const draggerArea = document.getElementById('pp-dragger');
const inputField = document.getElementById('fileInput');
const fileDelete = document.getElementById('fileDelete');
const browseFile = document.getElementById('browse');
const errorMessage = document.getElementById('error-span')

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
});

draggerArea.addEventListener('drop', (e) => {
    e.preventDefault()
    file = e.dataTransfer.files[0];
    fileHandler(file)
});

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
    var fileSize = file.size / (1024 * 1024);
    var megapixelSize = 0

    loadImage(file)
        .then(megapixels => {
            megapixelSize = parseInt(megapixels);

            if (fileSize <= 10 && megapixelSize >= 3) {
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

                        browseFile.textContent = ""
                        draggerArea.style.backgroundColor = "#fff";
                        draggerArea.style.backgroundImage = `url('${blobResult}')`;

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