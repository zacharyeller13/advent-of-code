import os
from typing import Any, List, Tuple

import numpy as np

def read_input(file: str) -> List[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n')
    
    return inputs

def get_coordinates(paths: List) -> List[Tuple]:

    paths = [path.split(' -> ') for path in paths]

    coords = []

    for coord in paths:
        coord_list = []

        for string in coord:
            x, y = string.split(',')
            coord_list.append((int(x), int(y)))
            
        coords.append(coord_list)

    return coords

def main() -> None:

    paths = read_input(f"{os.path.dirname(__file__)}/test_inputs")
    # paths = read_input(f"{os.path.dirname(__file__)}/inputs")

    coordinates = get_coordinates(paths)

    print(coordinates)

    min_x = min([min([x for x, _ in coord]) for coord in coordinates])
    max_x = max([max([x for x, _ in coord]) for coord in coordinates])
    x_range = max_x - min_x + 1
    min_y = 0
    max_y = max([max([y for _, y in coord]) for coord in coordinates])
    y_range = max_y - min_y + 1
    sand_start = (0, 500-min_x)

    array = np.array([['.' for _ in range(x_range)] for _ in range(y_range)])

    for coord in coordinates:
        print(coord)

        i = 0
        while i < len(coord)-1:

            start_x = (min(x for x in [coord[i][0], coord[i+1][0]])) - min_x
            end_x = (max(x for x in [coord[i][0], coord[i+1][0]])) - min_x + 1

            start_y = (min(y for y in [coord[i][1], coord[i+1][1]])) - min_y
            end_y = (max(y for y in [coord[i][1], coord[i+1][1]])) - min_y + 1

            array[start_y:end_y, start_x:end_x] = '#'

            i += 1


    array[sand_start] = '+'
    print(array)

if __name__ == "__main__":

    main()