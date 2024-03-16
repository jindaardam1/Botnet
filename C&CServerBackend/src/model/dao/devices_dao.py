from tinydb import TinyDB

from src.model.entitis.device import Device


class DevicesDAO:
    def __init__(self, db_file='devices.json'):
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
