import os

def read_input(file: str) -> str:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
    
    return inputs

def check_marker(stream: str) -> int:
    """
    Read a stream of chars and return the last index of the first group of 4 consecutive unique chars

    If no group of 4, return -1
    """

    for i in range(len(stream)):
        group = stream[i:i+4]

        if len(group) == len(set(group)):
            return i+4

    return -1

def main() -> None:

    stream = read_input(f"{os.path.dirname(__file__)}/inputs")

    print(check_marker(stream))

if __name__ == "__main__":
    main()