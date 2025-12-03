# ranges separated by ','
# first_id-last_id (separted by '-')
# invalid == made up ONLY of sequence of digits repeated twice
# e.g. 55 (5 x 2), 6464 (64 x 2), 123123 (123 x 2)

# Test case
# 11-22 has two invalid IDs, 11 and 22.
# 95-115 has one invalid ID, 99.
# 998-1012 has one invalid ID, 1010.
# 1188511880-1188511890 has one invalid ID, 1188511885.
# 222220-222224 has one invalid ID, 222222.
# 1698522-1698528 contains no invalid IDs.
# 446443-446449 has one invalid ID, 446446.
# 38593856-38593862 has one invalid ID, 38593859.
# The rest of the ranges contain no invalid IDs.

# Add up invalid ids to get answer
import sys
from typing import Callable


def partition(input: str) -> tuple[str, str]:
    idx = len(input) // 2
    return input[:idx], input[idx:]


def part_1(
    ranges: list[str], print_fn: Callable = lambda *args: None
) -> tuple[int, int]:
    count = 0
    sum = 0
    ids = []
    for rng in ranges:
        before = count
        start, end = (int(i) for i in rng.split("-"))
        print_fn(rng)
        for i in range(start, end + 1):
            str_i = str(i)
            # Impossible to have identical repeating sequence with an odd length
            if len(str_i) % 2 != 0:
                continue

            left, right = partition(str_i)
            count += int(left == right)
            sum += i if left == right else 0
            if left == right:
                ids.append(i)
            print_fn(left, right, count)
        after = count
        print_fn(rng, after - before)
        print_fn()

    print(ids)

    return (count, sum)


def test_rest(seq: str, rest: str) -> bool:
    for c in range(0, len(rest), len(seq)):
        if rest[c : c + len(seq)] != seq:
            return False

    return True


def test_str(input: str) -> bool:
    # We can start at sequence length 2 since we've check the first condition
    idx = 1
    while idx <= (len(input) // 2):
        seq = input[:idx]

        if seq == input[idx : 2 * idx]:
            if test_rest(seq, input[2 * idx :]):
                return True
        idx += 1

    return False


def part_2(
    ranges: list[str], print_fn: Callable[..., None] = lambda *args: None
) -> int:
    """Differs from part 1 in that it is *at least* 2 times rather than *only* 2 times
    E.g.

    - 11-22 still has two invalid IDs, 11 and 22.
    - 95-115 now has two invalid IDs, 99 and 111.
    - 998-1012 now has two invalid IDs, 999 and 1010.
    - 1188511880-1188511890 still has one invalid ID, 1188511885.
    - 222220-222224 still has one invalid ID, 222222.
    - 1698522-1698528 still contains no invalid IDs.
    - 446443-446449 still has one invalid ID, 446446.
    - 38593856-38593862 still has one invalid ID, 38593859.
    - 565653-565659 now has one invalid ID, 565656.
    - 824824821-824824827 now has one invalid ID, 824824824.
    - 2121212118-2121212124 now has one invalid ID, 2121212121.
    """
    ids = []
    for rng in ranges:
        start, end = (int(i) for i in rng.split("-"))
        print_fn(rng)
        for i in range(start, end + 1):
            str_i = str(i)

            if test_str(str_i):
                ids.append(i)
        print_fn()

    print(ids)

    return sum(ids)


if __name__ == "__main__":
    ranges = sys.stdin.read().strip().split(",")

    # 721 too low, duh didn't add up ids
    # print(part_1(ranges))
    print(part_2(ranges))
