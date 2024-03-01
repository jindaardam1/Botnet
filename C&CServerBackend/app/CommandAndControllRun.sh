#!/bin/bash

# Función para instalar Python si no está instalado
install_python_if_its_not() {
    if ! command -v python3 &> /dev/null; then
        echo "Instalando Python..."
        sudo apt-get install -y python3
    else
        echo "Python está instalado."
    fi
}

# Función para instalar un paquete si no existe
install_package_if_not_exists() {
    if ! pip show "$1" > /dev/null 2>&1; then
        echo "Instalando el paquete $1..."
        sudo pip install "$1"
    else
        echo "El paquete $1 ya está instalado."
    fi
}

# Función para instalar los requisitos de Python
install_python_requirements() {
    echo "Instalando los requisitos de Python..."
    install_package_if_not_exists "pytz"
    install_package_if_not_exists "hashlib"
    install_package_if_not_exists "datetime"
    install_package_if_not_exists "colorama"
    echo "Los requisitos de Python han sido instalados correctamente."
}

# Función para ejecutar el archivo main.py
run_command_and_control_server() {
    echo "Ejecutando el servidor de comando y control..."
    python3 ../src/core/main.py
}

# Establecer la codificación de la terminal a UTF-8
export LANG=en_US.UTF-8

install_python_if_its_not

install_python_requirements

run_command_and_control_server
