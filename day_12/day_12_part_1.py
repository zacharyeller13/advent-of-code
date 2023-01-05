import os
from collections import deque

def read_input(file: str) -> list[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n')
    
    return inputs

def set_edges(graph: list[str], rows: int, columns: int) -> list[list[int]]:
    
    edges = [[0 for _ in range(columns)] for _ in range(rows)]

    for r in range(rows):
        for c in range(columns):

            if graph[r][c] == 'S':
                edges[r][c] = 1

            elif graph[r][c] == 'E':
                edges[r][c] = 26

            else:
                edges[r][c] = ord(graph[r][c]) - ord('a') + 1

    return edges

def bfs(graph: list[str], rows: int, columns: int) -> int:
    
    queue = deque()

    for r in range(rows):
        for c in range(columns):
            pass
    
    raise NotImplementedError

def main() -> None:

    graph = read_input(f"{os.path.dirname(__file__)}/test_inputs")
    rows = len(graph)
    columns = len(graph[0])

    edges = set_edges(graph, rows, columns)

    print(graph)
    print(edges)

if __name__ == "__main__":

    main()