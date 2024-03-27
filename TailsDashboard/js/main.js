window.addEventListener('DOMContentLoaded', function () {
    //addTooltipListeners();
    addButtonEnviarComandoListener();
    addBuscadorComandosListener();
    addCommandSelectListener();
    addConectarButtonListener();
});


// Function to add listeners for tooltips
/*
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
*/


// Function to add listener to the send command button
function addButtonEnviarComandoListener() {
    const enviarComandoButton = document.getElementById("buttonEnviarComando");

    enviarComandoButton.addEventListener('click', () => {
        getCommand();
    });
}


// Function to add a listener to the command search
function addBuscadorComandosListener() {
    const inputBusqueda = document.getElementById('busqueda');
    const selectOpciones = document.getElementById('opciones');
    const opciones = selectOpciones.getElementsByTagName('option');

    inputBusqueda.addEventListener('input', function() {

        const filtro = inputBusqueda.value.toLowerCase();

        selectOpciones.style.display = 'block';

        selectOpciones.click();

        for (let opcion of opciones) {
            const texto = opcion.textContent.toLowerCase();
            if (texto.includes(filtro)) {
                opcion.style.display = '';
            } else {
                opcion.style.display = 'none';
            }
        }

        for (let opcion of opciones) {
            if (opcion.style.display !== 'none') {
                opcion.selected = true;
                break;
            }
        }

    });
}


function addCommandSelectListener() {
    document.getElementById("opciones").addEventListener('change', () => {
        updateArgumentsInput();
    });
}


function updateArgumentsInput() {
    const comandoSelectValue = document.getElementById("opciones").value;

    switch (comandoSelectValue) {
        case "find_online_devices":
            loadFindOnlineDevicesInput();
            break;

        case "start_attack":
            loadStartAtackInput();
            break;

        case "placeholder_command":
            loadFindOnlineDevicesInput();
            break;

        case "placeholder_command2":
            loadFindOnlineDevicesInput();
            break;

        default:
            loadFindOnlineDevicesInput();
            break;
    }
}


function loadFindOnlineDevicesInput() {
    const divArgumentos = document.getElementById("divArgumentos");

    divArgumentos.innerHTML = "";

    const label1 = document.createElement("label");
    label1.setAttribute("for", "deviceType");
    label1.textContent = "TIPO DE DISPOSITIVO";

    const input1 = document.createElement("input");
    input1.setAttribute("type", "text");
    input1.setAttribute("id", "deviceType");
    input1.setAttribute("placeholder", "Introduce el tipo de dispositivo");

    const br = document.createElement("br");

    const label2 = document.createElement("label");
    label2.setAttribute("for", "deviceAmount");
    label2.textContent = "CANTIDAD DE DISPOSITIVOS";

    const input2 = document.createElement("input");
    input2.setAttribute("type", "text");
    input2.setAttribute("id", "deviceAmount");
    input2.setAttribute("placeholder", "Introduce la cantidad");

    divArgumentos.appendChild(label1);
    divArgumentos.appendChild(input1);
    divArgumentos.appendChild(br);
    divArgumentos.appendChild(label2);
    divArgumentos.appendChild(input2);
}



function loadStartAtackInput() {
    const divArgumentos = document.getElementById("divArgumentos");

    divArgumentos.innerHTML = "";

    // TODO
}


function addConectarButtonListener() {
    document.getElementById("buttonConexion").addEventListener('click', () => {
        updateConnectionStatus();
    });
}


function updateConnectionStatus() {
    const connected = !(document.getElementById("buttonEnviarComando").disabled);

    if (connected) {
        document.getElementById("buttonEnviarComando").disabled = true;
        document.getElementById("buttonConexion").innerHTML = "CONECTAR";
    } else {
        document.getElementById("buttonEnviarComando").disabled = false;
        document.getElementById("buttonConexion").innerHTML = "DESCONECTAR";
    }
}


// Function to encrypt text to SHA512, such as commands or passwords
function encryptToSha512(text) {
    return sha512(text);
}


// Function that returns formatted datetime and hour to use it like password
function getDateTime() {
    const now = new Date();
    const madridTime = now.toLocaleString('en-US', { timeZone: 'Europe/Madrid', hour12: false });
    const [date, time] = madridTime.split(', ');
    const [month, day, year] = date.split('/');
    const [hour24] = time.split(':');
    return `${day}${month}${year}${hour24}`.replace("0", "");
}


function getArguments() {
    const divArgumentos = document.getElementById("divArgumentos");

    const elementsInput = divArgumentos.getElementsByTagName("input");

    let argumentosString = ";;";

    for (let i = 0; i < elementsInput.length; i++) {
        argumentosString += elementsInput[i].value;
        argumentosString += ";;";
    }

    return argumentosString;
}


// Function to send command to the Command & Control Server
function getCommand() {
    const contraInput = document.getElementById("contra");
    const comandoSelect = document.getElementById("opciones");

    let contraEncrypted = encryptToSha512(contraInput.value);
    let dateTimeEncrypted = encryptToSha512(getDateTime());
    let comandoEncrypted = encryptToSha512(comandoSelect.value);

    const stringToSend = contraEncrypted + ";;" + dateTimeEncrypted + ";;" + comandoEncrypted + getArguments();

    console.log(stringToSend);
    sendCommand(stringToSend);

    buttonSendCommandIsDisabled(true);

    setTimeout(function() {
        buttonSendCommandIsDisabled(false);
    }, 2000);

    let tiempoRestante = 2000;
    const intervalo = 100;

    const intervalID = setInterval(function() {

        tiempoRestante -= intervalo;

        if (tiempoRestante <= 0) {
            clearInterval(intervalID);

            document.getElementById("buttonTimer").textContent = "0.0";
        } else {
            actualizarTiempo(tiempoRestante);
        }
    }, intervalo);
}


function buttonSendCommandIsDisabled(disabled) {
    document.getElementById("buttonEnviarComando").disabled = disabled;

    if (disabled) {
        document.getElementById("buttonTimer").style.visibility = 'visible';
    } else {
        document.getElementById("buttonTimer").style.visibility = 'hidden';
    }
}


function actualizarTiempo(tiempoRestante) {
    const segundos = tiempoRestante / 1000;

    document.getElementById("buttonTimer").textContent = segundos.toFixed(1);
}


function sendCommand(commandString) {
    const xhr = new XMLHttpRequest();

    xhr.open("POST", "http://localhost:5000/recibir-datos", true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.send(commandString);

    console.log("Comando enviado");
}
