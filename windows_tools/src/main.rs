mod utils;
mod attacks;

fn main() {
    let max_threads = utils::system_resources::SystemResources::calculate_max_threads();
    println!("Max Threads: {}", max_threads);
}
