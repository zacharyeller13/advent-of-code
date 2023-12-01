#!/home/zacheller/.local/share/virtualenvs/Advent_Of_Code-nufrcTGs/bin/python3

# Visible if all trees in particular direction are shorter

import os
import numpy as np

def read_input(file: str) -> list[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n')
    
    return inputs

def count_edge_trees(inputs: list[str]) -> int:

    return (len(inputs[0])*2) + ((len(inputs) - 2)*2)

def create_tree_matrix(inputs: list[str]) -> np.ndarray:

    array = np.array(
        [[int(char) for char in line] for line in inputs], dtype=int
    )

    return array

def check_row(matrix_row: np.ndarray, tree: int, col_ix: int) -> bool:

    return all(tree > matrix_row[:col_ix]) or all(tree > matrix_row[col_ix+1:])

def check_column(matrix_col: np.ndarray, tree: int, row_ix: int) -> bool:
    
    return all(tree > matrix_col[:row_ix]) or all(tree > matrix_col[row_ix+1:])

def count_trees(tree_matrix: np.ndarray) -> int:

    visible_count = 0
    for row_ix in range(tree_matrix.shape[0]):
        for col_ix in range(tree_matrix.shape[1]):

            if row_ix in [0, tree_matrix.shape[0]-1] or col_ix in [0, tree_matrix.shape[1]-1]:
                continue
            else:
                tree = tree_matrix[row_ix, col_ix]
                row = tree_matrix[row_ix, ...]
                col = tree_matrix[..., col_ix]

                visible_count += 1 if check_row(row, tree, col_ix) or check_column(col, tree, row_ix) else 0

    return visible_count

def main() -> None:

    inputs = read_input(f"{os.path.dirname(__file__)}/inputs")

    visible_trees = count_edge_trees(inputs)
    print(visible_trees)

    tree_matrix = create_tree_matrix(inputs)
    print(tree_matrix)
    visible_trees += count_trees(tree_matrix)

    print(visible_trees)

if __name__ == "__main__":
    main()