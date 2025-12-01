# L68
# L30
# R48
# L5
# R60
# L55
# L1
# L99
# R14
# L82
#
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

from day_01.part_2 import part_2, read_input


def test_part_2() -> None:
    parent = Path(__file__).parent
    rotations = read_input(os.path.join(parent, "test_input"))
    ret = part_2(rotations)

    assert len(rotations) == 10
    assert ret == 6
