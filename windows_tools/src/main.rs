mod utils;
mod attacks;

fn main() {
    attacks::layer_7::Layer7::start_attack("google.com", 80, vec![""], 1)
}
