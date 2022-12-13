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

    for str in [move[0]*int(move[-1]) for move in inputs]:
        all_moves.extend(str)

    return all_moves

def make_moves(h_point: Point, t_point: Point, moves: list[str], move_dict: defaultdict) -> None:

    for move in moves:

        h_point.move(move, 1)

        x_diff = h_point.x - t_point.x
        y_diff = h_point.y - t_point.y
        print(move)
        print("H Moves: ", h_point, t_point)

        if abs(x_diff) >= 2 and h_point.y == t_point.y:
            t_point.x += 1 if x_diff > 0 else -1
        elif abs(y_diff) >= 2 and h_point.x == t_point.x:
            t_point.y += 1 if y_diff > 0 else -1
        elif abs(x_diff) > 1 or abs(y_diff) > 1:
            t_point.x += 1 if x_diff > 0 else -1
            t_point.y += 1 if y_diff > 0 else -1


        print("T Moves: ", h_point, t_point)
        move_dict[(t_point.x, t_point.y)] = 1
        print()

def main() -> None:

    inputs = read_input(f"{os.path.dirname(__file__)}/test_inputs")

    moves = parse_moves(inputs)
        
    print(moves)

    h_pos = Point(0, 0)
    t_pos = Point(0, 0)

    t_moves = defaultdict(int)
    t_moves[(t_pos.x, t_pos.y)] = 1

    make_moves(h_pos, t_pos, moves, t_moves)

    print(h_pos, t_pos)

    print(*t_moves)

    print(sum(t_moves.values()))

    return

if __name__ == "__main__":
    main()