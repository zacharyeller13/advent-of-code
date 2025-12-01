def read_input(file: str) -> list[str]:
    with open(f"{file}", "r") as f:
        inputs = f.read()
        inputs = inputs.strip().split("\n")

    return inputs
