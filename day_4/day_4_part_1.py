def read_input(file: str) -> list[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n')
    
    return inputs

def parse_pairs(line: str) -> list[set[int]]:

    pairs = line.split(',')
    lists = []

    for pair in pairs:

        sides = pair.split('-')
        start = int(sides[0])
        stop = int(sides[-1])+1

        lists.append(set(range(start, stop)))

    return lists

def parse_lines(lines: list[str]) -> list[list[set[int]]]:

    return [parse_pairs(line) for line in lines]

def contains_subset(pairs: list[set[int]]) -> bool:

    return pairs[0].issubset(pairs[1]) or pairs[1].issubset(pairs[0])

def count_subsets(lists: list[list[set[int]]]) -> int:

    count = 0

    for pairs in lists:

        count += 1 if contains_subset(pairs) else 0

    return count

def main() -> None:
    
    inputs = read_input("inputs")
    lists = parse_lines(inputs)

    print(count_subsets(lists))

if __name__ == "__main__":

    main()