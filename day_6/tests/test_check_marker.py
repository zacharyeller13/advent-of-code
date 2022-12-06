import pytest
from day_6_part_1 import check_marker

def test_check_marker_1() -> None:
    assert check_marker("bvwbjplbgvbhsrlpgdmjqwftvncz") == 5

def test_check_marker_2() -> None:
    assert check_marker("nppdvjthqldpwncqszvftbrmjlhg") == 6

def test_check_marker_3() -> None:
    assert check_marker("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg") == 10

def test_check_marker_4() -> None:
    assert check_marker("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw") == 11