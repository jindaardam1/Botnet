use std::io;

extern "system" {
    fn GetPhysicallyInstalledSystemMemory(total_memory_in_kilobytes: *mut i64) -> bool;
}

pub struct SystemResources;

impl SystemResources {
    fn get_thread_count() -> usize {
        num_cpus::get()
    }

    fn get_total_ram_mega_bytes() -> Result<usize, io::Error> {
        unsafe {
            let mut total_memory_in_kilobytes: i64 = 0;
            if GetPhysicallyInstalledSystemMemory(&mut total_memory_in_kilobytes as *mut i64) {
                Ok((total_memory_in_kilobytes / 1024) as usize)
            } else {
                Err(io::Error::new(io::ErrorKind::Other, "No se pudo obtener la memoria RAM instalada."))
            }
        }
    }

    pub fn calculate_max_threads() -> usize {
        let processor_count = Self::get_thread_count();
        let total_ram_mb = match Self::get_total_ram_mega_bytes() {
            Ok(ram) => ram,
            Err(_) => {
                println!("Error al obtener la memoria RAM.");
                return 0;
            }
        };

        const MEMORY_PER_THREAD_MB: usize = 200;

        let remaining_ram_mb = total_ram_mb - (processor_count * MEMORY_PER_THREAD_MB);
        let max_threads = usize::max(30, usize::min(150, remaining_ram_mb / MEMORY_PER_THREAD_MB + processor_count));

        max_threads
    }
}
