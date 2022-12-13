#!/home/zacheller/.local/share/virtualenvs/Advent_Of_Code-nufrcTGs/bin/python3

from point_class import Point
from collections import defaultdict
import os

def read_input(file: str) -> list[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n')
    
    return inputs

def parse_moves(inputs: list[str]) -> list[str]:

    all_moves = []
    for move in inputs:
        moves = move.split()
        all_moves.extend(moves[0]*int(moves[1]))

    return all_moves

def make_moves(h_point: Point, t_point: Point, moves: list[str], move_dict: defaultdict) -> None:

    for move in moves:

        move_dict[(t_point.x, t_point.y)] = 1
        h_point.move(move)

        x_diff = (h_point.x - t_point.x)
        y_diff = (h_point.y - t_point.y)

        if abs(x_diff) >= 2 and abs(y_diff) >= 2:
            t_point.x = h_point.x-1 if x_diff > 0 else h_point.x+1
            t_point.y = h_point.y-1 if y_diff > 0 else h_point.y+1
        elif abs(x_diff) >= 2:
            t_point.x = h_point.x-1 if x_diff > 0 else h_point.x+1
            t_point.y = h_point.y
        elif abs(y_diff) >= 2:
            t_point.x = h_point.x
            t_point.y = h_point.y-1 if y_diff > 0 else h_point.y+1

def main() -> None:

    inputs = read_input(f"{os.path.dirname(__file__)}/inputs")

    moves = parse_moves(inputs)
        
    h_pos = Point(0, 0)
    t_pos = Point(0, 0)

    t_moves = defaultdict(int)

    make_moves(h_pos, t_pos, moves, t_moves)

    print(sum(t_moves.values()))

    return

if __name__ == "__main__":
    main()