import os

from tinydb import TinyDB

from src.model.entities.device import Device


def create_db_directory_if_not_exists():
    directory_path = "../../tinydb/"
    if not os.path.exists(directory_path):
        os.makedirs(directory_path)


class DevicesDAO:
    def __init__(self, db_file='../../tinydb/devices.json'):
        create_db_directory_if_not_exists()
        self.db = TinyDB(db_file)

    def create_device(self, device):
        self.db.insert(device.__dict__)

    def get_device_by_id(self, device_id):
        result = self.db.get(doc_id=device_id)
        if result:
            return Device(**result)

    def update_device(self, device_id, new_data):
        self.db.update(new_data, doc_ids=[device_id])

    def delete_device(self, device_id):
        self.db.remove(doc_ids=[device_id])

    def get_all_devices(self):
        devices = []
        for item in self.db.all():
            devices.append(Device(**item))
        return devices
