import string

PRIORITY_WEIGHTS = {
    char:num for char, num in zip(string.ascii_letters, range(1,53))
}

def read_input(file: str) -> list[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n')
    
    return inputs

def parse_line(line: str) -> set[str]:
    """
    Read line and return intersection of both halves of line
    """

    left_set = set(line[:len(line)//2])
    right_set = set(line[len(line)//2:])

    return left_set.intersection(right_set)

def parse_lines(lines: list[str]) -> list[str]:
    """
    Read list of lines and return list of intersections from each line
    """

    priorities = []

    for line in lines:
        intersection = parse_line(line)

        priorities.extend(intersection)

    return priorities

def sum_priorities(priorities: list[str]) -> int:
    """
    Sum the PRIORITY_WEIGHT of each priority in list
    """

    return sum(PRIORITY_WEIGHTS[char] for char in priorities)

def main() -> None:

    inputs = read_input("inputs")

    priorities = parse_lines(inputs)
    
    print(sum_priorities(priorities))

if __name__ == "__main__":

    main()