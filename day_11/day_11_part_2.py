import math
import os

from day_11_part_1 import read_input, parse_monkey, get_items, get_test, get_ops, get_throws
from monkey import Monkey

def main() -> None:

    # inputs = read_input(f"{os.path.dirname(__file__)}/test_inputs")
    inputs = read_input(f"{os.path.dirname(__file__)}/inputs")

    monkeys = []
    tests = []
    lcm = 1
    for monkey in inputs:

        monkey = parse_monkey(monkey)
        tests.append(get_test(monkey))

    lcm = math.lcm(*tests)

    for monkey in inputs:

        monkey = parse_monkey(monkey)
        items = get_items(monkey)
        ops = get_ops(monkey)
        test = get_test(monkey)
        throws = get_throws(monkey)

        monkeys.append(Monkey(items, ops, test, throws[0], throws[1], lcm))

    for _ in range(10000):
        for monkey in monkeys:
            monkey.check_items()

            while len(monkey.items) > 0:
                item, next_monkey = monkey.throw_item()
                monkeys[next_monkey].items.append(item)

    level = 1
    for monkey in monkeys:
        print(monkey)

    monkeys.sort(key=lambda x : x.check_count, reverse=True)

    for monkey in monkeys[:2]:
        level *= monkey.check_count

    print(level)

if __name__ == "__main__":
    main()