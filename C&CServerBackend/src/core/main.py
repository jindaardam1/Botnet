from flask import Flask, request
from flask_cors import CORS

from src.utils.InputManager import InputManager

app = Flask(__name__)
CORS(app)


@app.route('/recibir-datos', methods=['POST'])
def recibir_datos():
    datos_recibidos = request.data.decode("utf-8")

    print(f"Datos recibidos: {datos_recibidos}")
    InputManager.manage_input_string(datos_recibidos)

    return "Datos recibidos correctamente por el servidor"


if __name__ == '__main__':
    app.run(debug=False)
