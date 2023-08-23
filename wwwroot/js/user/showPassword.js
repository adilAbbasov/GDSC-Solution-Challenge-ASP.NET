// Toggle password visibility

function togglePasswordVisibility() {
    var passwordInput = document.getElementById("password");
    var showPasswordCheckbox = document.getElementById("show-password");

    if (showPasswordCheckbox.checked) {
        passwordInput.type = "text";
    }
    else {
        passwordInput.type = "password";
    }
}