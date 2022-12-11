#!/home/zacheller/.local/share/virtualenvs/Advent_Of_Code-nufrcTGs/bin/python3

import os
import numpy as np

def read_input(file: str) -> list[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n')
    
    return inputs

def create_tree_matrix(inputs: list[str]) -> np.ndarray:

    array = np.array(
        [[int(char) for char in line] for line in inputs], dtype=int
    )

    return array

def calc_xy(matrix_xy: np.ndarray, tree: int, xy_ix: int) -> int:

    left = matrix_xy[:xy_ix][::-1]
    right = matrix_xy[xy_ix+1:]
    left_score, right_score = 1, 1

    for i in range(len(left)-1):
        if left[i] >= tree:
            break
        else:
            left_score += 1

    for i in range(len(right)-1):
        if right[i] >= tree:
            break
        else:
            right_score += 1
        
    return left_score * right_score

def set_tree_scores(tree_matrix: np.ndarray, score_matrix: np.ndarray) -> None:

    for row_ix in range(tree_matrix.shape[0]):
        for col_ix in range(tree_matrix.shape[1]):

            if row_ix in [0, tree_matrix.shape[0]-1] or col_ix in [0, tree_matrix.shape[1]-1]:
                score_matrix[row_ix, col_ix] = 0
            else:
                tree = tree_matrix[row_ix, col_ix]
                row = tree_matrix[row_ix, ...]
                col = tree_matrix[..., col_ix]

                score_matrix[row_ix, col_ix] = calc_xy(row, tree, col_ix) * calc_xy(col, tree, row_ix)

def main() -> None:

    inputs = read_input(f"{os.path.dirname(__file__)}/inputs")

    tree_matrix = create_tree_matrix(inputs)
    scenic_score_matrix = tree_matrix.copy()

    print(tree_matrix)

    set_tree_scores(tree_matrix, scenic_score_matrix)
    print(scenic_score_matrix.max())

if __name__ == "__main__":
    main()