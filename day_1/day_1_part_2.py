
from timeit import timeit


def read_input(file: str) -> list[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n\n')
    
    return inputs

def main() -> int:

    input_list = sorted([sum(map(int, item.split('\n'))) for item in read_input("inputs")], reverse=True)

    return sum(input_list[:3])

if __name__ == "__main__":

    print(timeit("main()", setup="from __main__ import main", number=10000))

    print(main())