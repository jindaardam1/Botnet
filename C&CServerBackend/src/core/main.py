from src.model.dao.devices_dao import DevicesDAO
from src.model.entities.device import Device

dao = DevicesDAO()

dao.create_device(Device('a', 'a', 'a', 'a'))
