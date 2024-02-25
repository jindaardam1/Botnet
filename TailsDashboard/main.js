window.addEventListener('DOMContentLoaded', function () {

});

function encryptCommandToSha512(command) {
    return sha512(command);
}