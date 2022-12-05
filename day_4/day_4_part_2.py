from day_4_part_1 import read_input, parse_lines

def check_overlap(pairs: list[set[int]]) -> bool:

    return any(pairs[0].intersection(pairs[1]))

def count_overlaps(lists: list[list[set[int]]]) -> int:

    return sum(check_overlap(pairs) for pairs in lists)

def main() -> None:

    inputs = read_input("inputs")
    lists = parse_lines(inputs)

    print(count_overlaps(lists))

    return

if __name__ == "__main__":

    main()