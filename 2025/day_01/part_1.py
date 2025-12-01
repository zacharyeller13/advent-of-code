# Dial has 0 - 99 in order,
# sequence of rotations, 1 per line
# L = left/lower nums, R = right/higher nums
# distance value = how many clicks. E.g. L2 = lower 2 clicks
# . e.g. dial at '11', R8 -> dial at 19; next rotaion L19 -> 0
# loops around 0 + L1 = 99 and 99 + R1 = 0
# dial starts at 50
# Solution: # of times d == 0 after any rotation in the sequence
# see example in test1.py
import os
from pathlib import Path


def read_input(file: str) -> list[str]:
    with open(file, "r") as f:
        inputs = f.read()
        inputs = inputs.strip().split("\n")

    return inputs


def part_1(rotations: list[str]) -> int:
    d = 50
    count = 0
    for line in rotations:
        dir, dist = line[0], int(line[1:])
        dist *= -1 if dir == "L" else 1

        d = (d + dist) % 100
        count += int(d == 0)

    return count


if __name__ == "__main__":
    parent = Path(__file__).parent
    inputs = read_input(os.path.join(parent, "input"))

    print(part_1(inputs))
