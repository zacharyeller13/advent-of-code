from dataclasses import dataclass

# 0,6       6,6
#
#
#
# 
# 0,0       6,0

@dataclass
class Point:
    x: int
    y: int

    def move(self: "Point", dir: str) -> None:

        if dir in ('L', 'D'):
            steps = -1
        else:
            steps = 1
        
        if dir in ('L', 'R'):
            self.x += steps
        else:
            self.y += steps