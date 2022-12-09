#!/home/zacheller/.local/share/virtualenvs/Advent_Of_Code-nufrcTGs/bin/python3

import os
from collections import defaultdict
from day_7_part_1 import read_input, parse_lines

def main() -> None:

    inputs = read_input(f"{os.path.dirname(__file__)}/inputs")

    path = ['/']
    sizes = defaultdict(int)
    
    parse_lines(inputs, path, sizes)

    max_usable = 70000000 - 30000000
    must_free = sizes['/'] - max_usable

    deleted_dir_size = min(size for _, size in sizes.items() if size >= must_free)

    print(deleted_dir_size)

if __name__ == "__main__":
    main()