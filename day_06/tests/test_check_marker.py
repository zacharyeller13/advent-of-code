import pytest
from day_6_part_1 import check_marker

def test_check_marker_1() -> None:
    assert check_marker("bvwbjplbgvbhsrlpgdmjqwftvncz", 4) == 5

def test_check_marker_2() -> None:
    assert check_marker("nppdvjthqldpwncqszvftbrmjlhg", 4) == 6

def test_check_marker_3() -> None:
    assert check_marker("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 4) == 10

def test_check_marker_4() -> None:
    assert check_marker("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 4) == 11

def test_check_marker_msg_1() -> None:
    assert check_marker('mjqjpqmgbljsphdztnvjfqwrcgsmlb', 14) == 19

def test_check_marker_msg_2() -> None:
    assert check_marker('bvwbjplbgvbhsrlpgdmjqwftvncz', 14) == 23

def test_check_marker_msg_3() -> None:
    assert check_marker('nppdvjthqldpwncqszvftbrmjlhg', 14) == 23

def test_check_marker_msg_4() -> None:
    assert check_marker('nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg', 14) == 29

def test_check_marker_msg_5() -> None:
    assert check_marker('zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw', 14) == 26
