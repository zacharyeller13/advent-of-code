import string

from day_3_part_1 import read_input

PRIORITY_WEIGHTS = {
    char:num for char, num in zip(string.ascii_letters, range(1,53))
}

def select_groups(lines: list[str]) -> list[list[str]]:
    """
    Split input lines into list of groups of 3
    """

    groups = []

    for i in range(0,len(lines),3):
        groups.append([lines[i], lines[i+1], lines[i+2]])

    return groups

def parse_group(group: list[str]) -> set[str]:
    """
    Read group and return intersection of all group members
    """

    return set.intersection(*map(set, group))

def parse_groups(groups: list[list[str]]) -> list[str]:
    """
    Read list of groups and return list of intersections from each group
    """

    priorities = []

    for group in groups:
        intersection = parse_group(group)

        priorities.extend(intersection)

    return priorities

def sum_priorities(priorities: list[str]) -> int:
    """
    Sum the PRIORITY_WEIGHT of each priority in list
    """

    return sum(PRIORITY_WEIGHTS[char] for char in priorities)

def main() -> None:

    inputs = read_input("inputs")

    groups = select_groups(inputs)
    priorities = parse_groups(groups)

    print(sum_priorities(priorities))

if __name__ == "__main__":

    main()