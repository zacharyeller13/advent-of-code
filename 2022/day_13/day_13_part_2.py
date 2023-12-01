import os
from typing import Any, List

def read_input(file: str) -> List:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.replace('\n\n', '\n').split('\n')
    
    return [eval(input) for input in inputs]

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

def partition(array: List, low: int, high: int) -> int:

    pivot = array[high]

    i = low - 1

    for j in range(low, high):

        if compare(array[j], pivot) == 1:

            i += 1

            array[i], array[j] = array[j], array[i]

    array[i+1], array[high] = array[high], array[i+1]

    return i + 1

def quicksort(array: List, low: int, high: int) -> None:

    if low < high:

        # Get partitioning index
        pi = partition(array, low, high)

        # Sort left of pivot
        quicksort(array, low, pi - 1)

        # Sort right of pivot
        quicksort(array, pi + 1, high)  

def get_decoder_key(packets: List, packets_to_find: List) -> int:

    x = packets.index(packets_to_find[0]) + 1
    y = packets.index(packets_to_find[1]) + 1

    return x * y

def main() -> None:

    # packets = read_input(f"{os.path.dirname(__file__)}/test_inputs")
    packets = read_input(f"{os.path.dirname(__file__)}/inputs")

    divider_packets = [[[2]], [[6]]]
    packets.extend(divider_packets)

    quicksort(packets, 0, len(packets) - 1)

    for packet in packets:
        print(packet)

    print(get_decoder_key(packets, divider_packets))
    

if __name__ == "__main__":

    main()