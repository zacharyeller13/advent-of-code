from enum import Enum

GAME_TYPES = {
    'AX': 3, 
    'AY': 6, 
    'AZ': 0, 
    'BX': 0, 
    'BY': 3, 
    'BZ': 6, 
    'CX': 6, 
    'CY': 0, 
    'CZ': 3
}

CHOICES = {
    'X': 1,
    'Y': 2,
    'Z': 3
}

def read_input(file: str) -> list[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n')
    
    return inputs

def set_games(games: list[str]) -> list[str]:

    return [''.join(values.split(' ')) for values in games]

def run_games(games: list[str]) -> list[int]:
    game_scores = []

    for plays in games:
        game_scores.append(GAME_TYPES[plays] + CHOICES[plays[-1]])

    return game_scores

def main() -> None:
    
    inputs = read_input("inputs")
    games = set_games(inputs)
    print(sum(run_games(games)))

if __name__ == "__main__":

    main()