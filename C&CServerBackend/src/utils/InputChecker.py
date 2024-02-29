import hashlib
from datetime import datetime
import pytz


class InputChecker:
    @staticmethod
    def get_date_time():
        now = datetime.now(pytz.timezone('Europe/Madrid'))
        formatted_date_time = now.strftime('%d%m%Y%H').replace("0", "")
        return formatted_date_time

    @staticmethod
    def encrypt_text(text):
        text_bytes = text.encode('utf-8')

        return hashlib.sha512(text_bytes).hexdigest()
