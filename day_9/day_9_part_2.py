#!/home/zacheller/.local/share/virtualenvs/Advent_Of_Code-nufrcTGs/bin/python3

from point_class import Point
from collections import defaultdict
import os

from day_9_part_1 import read_input, parse_moves

def make_moves(h_point: Point, t_points: list[Point], moves: list[str], move_dict: defaultdict) -> None:

    for move in moves:

        h_point.move(move)
        make_move(h_point, t_points[0])

        move_dict[(t_points[-1].x, t_points[-1].y)] = 1

        for i in range(1, len(t_points)):
            make_move(t_points[i-1], t_points[i])

        move_dict[(t_points[-1].x, t_points[-1].y)] = 1

def make_move(h_point: Point, t_point: Point) -> None:

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

    # inputs = read_input(f"{os.path.dirname(__file__)}/test_inputs_large")
    inputs = read_input(f"{os.path.dirname(__file__)}/inputs")

    moves = parse_moves(inputs)
        
    h_pos = Point(0, 0)
    t_pos = [Point(0, 0) for _ in range(9)]

    t_moves = defaultdict(int)

    make_moves(h_pos, t_pos, moves, t_moves)

    print(sum(t_moves.values()))

    return

if __name__ == "__main__":
    main()