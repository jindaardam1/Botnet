#!/bin/bash

# Función para instalar un paquete si no existe
install_package_if_not_exists() {
    if ! dpkg -l | grep -q "$1"; then
        echo "Instalando el paquete $1..."
        sudo apt-get install -y "$1"
    else
        echo "El paquete $1 ya está instalado."
    fi
}

# Función para instalar los requisitos de Python
install_python_requirements() {
    echo "Instalando los requisitos de Python..."
    install_package_if_not_exists "python3-pytz"
    install_package_if_not_exists "python3-hashlib"
    install_package_if_not_exists "python3-datetime"
    echo "Los requisitos de Python han sido instalados correctamente."
}

# Función para ejecutar el archivo main.py
run_command_and_control_server() {
    echo "Ejecutando el servidor de comando y control..."
    python3 ../src/core/main.py
}

install_python_requirements
run_command_and_control_server