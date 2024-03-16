class Device:
    def __init__(self, ip, operative_system, cpu_threads, cpu_model):
        self.ip = ip
        self.operative_system = operative_system
        self.cpu_threads = cpu_threads
        self.cpu_model = cpu_model

    def to_string(self):
        return (f"IP: {self.ip}, "
                f"Sistema Operativo: {self.operative_system}, "
                f"Hilos de CPU: {self.cpu_threads}, "
                f"Modelo de CPU: {self.cpu_model}")
