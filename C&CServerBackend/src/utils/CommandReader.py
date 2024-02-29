from src.utils.InputChecker import InputChecker


class CommandReader:
    commands = [
        "find_online_devices",
        "placeholder_command",
        "placeholder_command_"
    ]

    @classmethod
    def recognize(cls, command):
        for c in cls.commands:
            hash_hex = InputChecker.encrypt_text(c)
            if hash_hex == command:
                return c
