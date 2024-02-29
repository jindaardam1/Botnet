window.addEventListener('DOMContentLoaded', function () {
    addTooltipListeners();
    addButtonEnviarComandoListener();
});


// Function to add listeners for tooltips
function addTooltipListeners() {
    const tooltip = document.getElementById('contra');
    const tooltipText = document.querySelector('.tooltiptext');

    tooltip.addEventListener('mouseenter', () => {

        tooltipText.style.visibility = 'visible';
        tooltipText.style.opacity = '1';

    });

    tooltip.addEventListener('mouseleave', () => {

        tooltipText.style.visibility = 'hidden';
        tooltipText.style.opacity = '0';

    });
}


// Function to add listener to the send command button
function addButtonEnviarComandoListener() {
    const enviarComandoButton = document.getElementById("buttonEnviarComando");

    enviarComandoButton.addEventListener('click', () => {
        sendCommand();
    });
}


// Function to encrypt text to SHA512, such as commands or passwords
function encryptToSha512(text) {
    return sha512(text);
}


// Function to send command to the Command & Control Server
function sendCommand() {
    const contraInput = document.getElementById("contra");

    let encriptedContra = encryptToSha512(contraInput.value);

    console.log(encriptedContra);
}
