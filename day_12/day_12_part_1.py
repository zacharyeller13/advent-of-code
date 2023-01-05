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

def bfs(graph: list[str], edges: list[list[int]], rows: int, columns: int) -> int | str:
    
    queue = deque()
    visited = set()

    for r in range(rows):
        for c in range(columns):
            if graph[r][c] == 'S':
                queue.append(((r,c), 0))
    
    while queue:
        (r,c), dist = queue.popleft()

        print((r,c), dist)
        
        if (r,c) in visited:
            continue
        visited.add((r,c))

        if graph[r][c] == 'E':
            return dist

        for dr, dc in [(-1,0),(0,1),(1,0),(0,-1)]:
            next_r = r + dr
            next_c = c + dc

            if 0 <= next_r < rows and 0 <= next_c < columns and edges[next_r][next_c] <= edges[r][c]+1:
                queue.append(((next_r,next_c), dist+1))

    return "No path found"

def main() -> None:

    # graph = read_input(f"{os.path.dirname(__file__)}/test_inputs")
    graph = read_input(f"{os.path.dirname(__file__)}/inputs")
    rows = len(graph)
    columns = len(graph[0])

    edges = set_edges(graph, rows, columns)

    print(graph)
    print(edges)
    print(bfs(graph, edges, rows, columns))

if __name__ == "__main__":

    main()