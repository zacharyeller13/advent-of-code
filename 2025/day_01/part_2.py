# The dial starts by pointing at 50.
# The dial is rotated L68 to point at 82; during this rotation, it points at 0 once.
# The dial is rotated L30 to point at 52.
# The dial is rotated R48 to point at 0.
# The dial is rotated L5 to point at 95.
# The dial is rotated R60 to point at 55; during this rotation, it points at 0 once.
# The dial is rotated L55 to point at 0.
# The dial is rotated L1 to point at 99.
# The dial is rotated L99 to point at 0.
# The dial is rotated R14 to point at 14.
# The dial is rotated L82 to point at 32; during this rotation, it points at 0 once.
import os
from pathlib import Path


def read_input(file: str) -> list[str]:
    with open(file, "r") as f:
        inputs = f.read()
        inputs = inputs.strip().split("\n")

    return inputs


def part_2(rotations: list[str]) -> int:
    d = 50
    count = 0
    for line in rotations:
        dir, dist = line[0], int(line[1:])

        for _ in range(dist):
            if dir == "L":
                d = (d - 1) % 100
            elif dir == "R":
                d = (d + 1) % 100

            if d == 0:
                count += 1

        # print(dir, dist, d, count)

    return count


if __name__ == "__main__":
    parent = Path(__file__).parent
    inputs = read_input(os.path.join(parent, "input"))

    print(part_2(inputs))
