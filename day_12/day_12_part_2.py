import os
from collections import deque

from day_12_part_1 import read_input, set_edges

def bfs(graph: list[str], edges: list[list[int]], rows: int, columns: int) -> int | str:
    
    queue = deque()
    visited = set()

    for r in range(rows):
        for c in range(columns):
            if edges[r][c] == 1:
                queue.append(((r,c), 0))

    while queue:
        (r,c), dist = queue.popleft()

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
    print(bfs(graph, edges, rows, columns))

if __name__ == "__main__":

    main()