import os
from day_6_part_1 import read_input, check_marker

def main() -> None:

    stream = read_input(f"{os.path.dirname(__file__)}/inputs")

    print(check_marker(stream, 14))

if __name__ == "__main__":
    main()