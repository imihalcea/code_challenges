use std::fs::File;
use std::io::{BufRead, BufReader};
use std::str::FromStr;
use two_sum::brute_force;

#[macro_use] extern crate criterion;
use self::criterion::*;

fn bench_10_000_optimized(c:&mut Criterion){

    let file = File::open("benches/10_000.txt").expect("can't open data set file");
    let reader = BufReader::new(file);
    let mut data_set = vec![];

    for (_,line) in reader.lines().enumerate(){
        let val_str = line.expect("failed to read data set line");
        let input = i32::from_str(&val_str).expect("failed to parse str to i32");
        data_set.push(input);
    }

    let target = data_set[9998]+data_set[9999];
    let input = data_set.as_slice();

    c.bench_function("optimized on 10_000 ints", |b| b.iter(|| two_sum::optimized(input, target)));
}

fn bench_10_000_brute_force(c:&mut Criterion){

    let file = File::open("benches/10_000.txt").expect("can't open data set file");
    let reader = BufReader::new(file);
    let mut data_set = vec![];

    for (_,line) in reader.lines().enumerate(){
        let val_str = line.expect("failed to read data set line");
        let input = i32::from_str(&val_str).expect("failed to parse str to i32");
        data_set.push(input);
    }

    let target = data_set[9998]+data_set[9999];
    let input = data_set.as_slice();

    c.bench_function("brute force on 10_000 ints", |b| b.iter(|| two_sum::brute_force(input, target)));
}

criterion_group!(benches,bench_10_000_brute_force, bench_10_000_optimized);
criterion_main!(benches);




