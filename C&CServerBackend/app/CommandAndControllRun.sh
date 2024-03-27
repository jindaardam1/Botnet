#!/bin/bash

add_path_to_pythonpath() {
    CURRENT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null 2>&1 && pwd )"

    export PYTHONPATH="$CURRENT_DIR:$PYTHONPATH"

    echo "Añadida la ruta al PYTHONPATH"
}

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
    install_package_if_not_exists "tinydb"
    install_package_if_not_exists "gunicorn"
    echo "Los requisitos de Python han sido instalados correctamente."
}

# Función para ejecutar la aplicación Flask con Gunicorn
run_flask_with_gunicorn() {
    echo "Ejecutando la aplicación Flask con Gunicorn..."
    gunicorn -w 4 -b 127.0.0.1:5000 ../src/core/main:app
}

# Establecer la codificación de la terminal a UTF-8
export LANG=en_US.UTF-8

add_path_to_pythonpath

install_python_if_its_not

install_python_requirements

run_flask_with_gunicorn
