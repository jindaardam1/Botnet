#!/bin/bash

# Copiar archivos de la carpeta actual a la carpeta "Documentos"
cp * ~/Documents/

# Cambiar la ubicación de la consola a la carpeta "Documentos"
cd ~/Documents

# Verificar si existe el archivo "index.html"
if [ -f "index.html" ]; then
    # Abrir el archivo "index.html" en el navegador web predeterminado
    xdg-open index.html
else
    echo "El archivo index.html no se encuentra en la carpeta Documentos."
fi
