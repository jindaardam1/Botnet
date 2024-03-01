#!/bin/bash

cp * ~/Documents/

cd ~/Documents

if [ -f "index.html" ]; then
    xdg-open index.html
else
    echo "El archivo index.html no se encuentra en la carpeta Documentos."
fi
