#!/home/zacheller/.local/share/virtualenvs/Advent_Of_Code-nufrcTGs/bin/python3

# X -> horizontal position of middle of  sprite
# sprite width = 3px
# CRT width = 40px
# CRT height = 6px
# CRT draws left to right, top to bottom
# ROW positions: 0 -> 39

import os

from day_10_part_1 import read_input

def addx(x: int, num_to_add: int) -> int:

    return x + num_to_add

def draw_pixel(sprite_pos: int, cur_pos: int, crt: list[list[str]]) -> None:
    cur_pos -= 1
    row_pos = cur_pos//40
    col_pos = cur_pos%40

    if abs(sprite_pos - col_pos) <= 1:
        crt[row_pos][col_pos] = '#'

def draw_cycles(x: int, inputs: list[str], crt: list[list[str]]) -> None:

    cycle_num = 0
    for inst in inputs:

        inst = inst.split()

        if inst[0] == "addx":
            cycle_num += 1

            draw_pixel(x, cycle_num, crt)

            cycle_num += 1

            draw_pixel(x, cycle_num, crt)

            x = addx(x, int(inst[-1]))
        else:
            cycle_num += 1
            
            draw_pixel(x, cycle_num, crt)

def main() -> None:

    # inputs = read_input(f"{os.path.dirname(__file__)}/test_inputs")
    inputs = read_input(f"{os.path.dirname(__file__)}/inputs")

    x = 1
    crt = [['.' for _ in range(40)] for _ in range(6)]

    draw_cycles(x, inputs, crt)
    for row in crt:
        print(' '.join(row))

if __name__ == "__main__":
    main()