import os
from day_5_part_1 import read_input, parse_stacks, parse_instructions, parse_instruction, list_top_crates

def perform_instructions(stacks: dict[int, list[str]], instructions: list[str]) -> None:
    """
    Perform all crate-moving instructions
    """

    for instruction in instructions:
        move_count, start_stack, end_stack = parse_instruction(instruction)

        move_crates(stacks, move_count, start_stack, end_stack)

def move_crates(stacks: dict[int, list[str]], move_count: int, start_stack: int, end_stack: int) -> None:
    """
    Move as many crates as passed in `move_count` from the `start_stack` to the `end_stack`
    """

    crates = stacks.get(start_stack)[:move_count]
    del stacks.get(start_stack)[:move_count]
    
    crates.reverse()
    stacks[end_stack].reverse()
    stacks[end_stack].extend(crates)
    stacks[end_stack].reverse()

def main() -> None:

    stacks, instructions = read_input(f"{os.path.dirname(__file__)}/inputs")
    
    parsed_stacks = parse_stacks(stacks)
    parsed_instructions = parse_instructions(instructions)

    perform_instructions(parsed_stacks, parsed_instructions)
    list_top_crates(parsed_stacks)

if __name__ == "__main__":

    main()