#!/home/zacheller/.local/share/virtualenvs/Advent_Of_Code-nufrcTGs/bin/python3

# addx V - 2 cycles, adds value V to X register
# noop - 1 cycle, does nothing
# 20th, 60th, 100th, 140th, 180th, and 220th cycle

import os

def read_input(file: str) -> list[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n')
    
    return inputs

def addx(x: int, num_to_add: int) -> int:

    return x + num_to_add

def calc_key_cycles(x: int, inputs: list[str]) -> list[int]:

    cycle_num = 0
    cycles = []
    for inst in inputs:

        inst = inst.split()

        if inst[0] == "addx":
            cycle_num += 1
            if cycle_num in [20, 60, 100, 140, 180, 220]:
                cycles.append(x * cycle_num)

            cycle_num += 1

            if cycle_num in [20, 60, 100, 140, 180, 220]:
                cycles.append(x * cycle_num)

            x = addx(x, int(inst[-1]))
        else:
            cycle_num += 1
            if cycle_num in [20, 60, 100, 140, 180, 220]:
                cycles.append(x * cycle_num)

    return cycles

def main() -> None:

    inputs = read_input(f"{os.path.dirname(__file__)}/inputs")

    x = 1
    cycles = calc_key_cycles(x, inputs)

    print(sum(cycles))

if __name__ == "__main__":
    main()