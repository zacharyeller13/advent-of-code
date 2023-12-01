import os
from typing import Any

def read_input(file: str) -> list[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n\n')
    
    return inputs

def create_groups(lists: list[str]) -> list[list[Any]]:

    groups = [lst.split('\n') for lst in lists]

    return [[eval(string) for string in group] for group in groups]

def compare(left: Any, right: Any) -> int:

    if isinstance(left, int) and isinstance(right, int):
        if left < right:
            return 1
        elif left > right:
            return -1
        else:
            return 0
        
    elif isinstance(left, list) and isinstance(right, list):
        i = 0
        while i < min(len(left), len(right)):
            comp = compare(left[i], right[i])
            # print(left[i], right[i], f"{comp=}")

            if comp == 1:
                return 1
            elif comp == -1:
                return -1

            i += 1

        if i == len(left) and i < len(right):
            return 1
        elif i == len(right) and i < len(left):
            return -1

    elif isinstance(left, int) and isinstance(right, list):
        return (compare([left], right))

    else:
        return (compare(left, [right]))

    return 0


def main() -> None:

    # lists = read_input(f"{os.path.dirname(__file__)}/test_inputs")
    lists = read_input(f"{os.path.dirname(__file__)}/inputs")

    groups = create_groups(lists)

    valid_sum = 0

    for index, group in enumerate(groups, 1):
        print(group)
        
        c = compare(group[0], group[1])

        print(f"{c=}")

        if c == 1:
            print(f"{index=}")
            valid_sum += index


    print(valid_sum)
if __name__ == "__main__":

    main()