import hashlib


class CommandReader:
    commands = [
        "find_online_devices",
        "placeholder_command",
        "placeholder_command_"
    ]

    @classmethod
    def recognize(cls, command):
        for c in cls.commands:
            hash_code = hashlib.sha512(c.encode())

            hash_hex = hash_code.hexdigest()

            if hash_hex == command:
                return c

