#!/home/zacheller/.local/share/virtualenvs/Advent_Of_Code-nufrcTGs/bin/python3

import os
from collections import defaultdict
from pprint import pprint

def read_input(file: str) -> list[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n')
    
    return inputs

def change_dir(path: list[str], next_dir: str) -> list[str]:

    if next_dir == '/':
        path.clear()
        path.append('/')
    elif next_dir == '..':
        if len(path) > 1:
            path.pop()
    else:
        path.append(next_dir)

def parse_command(line: list[str], path: list[str]) -> None:

    if line[1] == 'cd':
        change_dir(path, line[-1])

def parse_lines(inputs: list[str], path: list[str], sizes: defaultdict) -> None:

    for line in inputs:
        line = line.split()

        if line[0] == '$':
            parse_command(line, path)

        else:
            parse_stdout(line, path, sizes)

def parse_stdout(line: list[str], path: list[str], sizes: defaultdict) -> None:
    
    if line[0] != 'dir':
        size = int(line[0])
        for i in range(1, len(path)+1):
            sizes['/'.join(path[:i])] += size

def main() -> None:

    inputs = read_input(f"{os.path.dirname(__file__)}/test_inputs")

    path = ['/']
    sizes = defaultdict(int)

    parse_lines(inputs, path, sizes)
    print(sizes)

    answer = sum(v for _, v in sizes.items() if v <= 100000)
    print(path)
    print(answer)

if __name__ == "__main__":
    main()