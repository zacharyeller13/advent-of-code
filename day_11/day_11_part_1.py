import os

from monkey import Monkey

def read_input(file: str) -> list[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n\n')
    
    return inputs

def parse_monkey(monkey: str) -> list[str]:

    return monkey.split('\n')

def get_items(monkey: list[str]) -> list[int]:

    items = monkey[1].split(':')[-1].split(',')

    return [int(item) for item in items]

def get_ops(monkey: list[str]) -> str:
    
    ops_str = monkey[2].split(':')[-1].split('=')[-1]

    return ops_str[1:]

def get_test(monkey: list[str]) -> int:

    test = monkey[3].split(':')[-1].split(' ')[-1]

    return int(test)

def get_throws(monkey: list[str]) -> tuple[int, int]:

    true = monkey[4].split(':')[-1].split(' ')[-1]
    false = monkey[5].split(':')[-1].split(' ')[-1]

    return int(true), int(false)

def main() -> None:

    # inputs = read_input(f"{os.path.dirname(__file__)}/test_inputs")
    inputs = read_input(f"{os.path.dirname(__file__)}/inputs")

    monkeys = []
    for monkey in inputs:

        monkey = parse_monkey(monkey)

        items = get_items(monkey)
        ops = get_ops(monkey)
        tests = get_test(monkey)
        throws = get_throws(monkey)

        monkeys.append(Monkey(items, ops, tests, throws[0], throws[1]))

    for _ in range(20):
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