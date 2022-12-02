CHOICES = {
    'A': 1, 
    'B': 2, 
    'C': 3
}

WINNERS = {
    'A': 'C',
    'B': 'A',
    'C': 'B'
}

GAME_OUTCOMES = {
    'X': 0,
    'Y': 3,
    'Z': 6
}

def read_input(file: str) -> list[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n')
    
    return inputs

def run_games(games: list[str]) -> list[int]:

    scores = []
    for game in games:
        score = GAME_OUTCOMES[game[-1]]
        if score == 0:
            score += CHOICES[WINNERS[game[:1]]]
        elif score == 3:
            score += CHOICES[game[:1]]
        else:
            keys = list(WINNERS.keys())
            score += CHOICES[keys[list(WINNERS.values()).index(game[:1])]]
        scores.append(score)

    return scores

def main() -> None:
    
    inputs = read_input("inputs")
    scores = run_games(inputs)
    print(sum(scores))

if __name__ == "__main__":

    main()