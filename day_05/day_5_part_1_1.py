CRATE_LEN = 3
CRATE_SPACE = 1

def read_input(file: str) -> list[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n\n')
    
    return inputs

def get_stack_count(stacks: str) -> int:

    return int(stacks[-2])

def parse_stacks(stacks: str) -> dict[int, list[str]]:
    """
    Parse stack diagram into dict with ordered list of crates
    """

    stack_count = get_stack_count(stacks)
    space_count = stack_count-1
    parsed_stacks = {key+1:[] for key in range(stack_count)}

    rows = stacks.split('\n')[:-1]

    for row in rows:
        
        for i, stack_num in zip(
            range(0, stack_count*CRATE_LEN*(CRATE_SPACE*space_count), CRATE_LEN+CRATE_SPACE),
            range(1, stack_count+1)):

            parsed_stacks[stack_num].append(row[i:i+CRATE_LEN])

    return clean_stacks(parsed_stacks)

def remove_empty_crates(stack: list[str]) -> list[str]:
    """
    Remove any crate slots that are empty from list of crates
    """

    for _ in range(stack.count("   ")):
        stack.remove("   ")

    return stack

def clean_stacks(stacks: dict[int, list[str]]) -> dict[int, list[str]]:
    """
    Remove empty crate slots from all stacks
    """

    return {stack_num:remove_empty_crates(crates) for stack_num, crates in stacks.items()}

def parse_instructions(instructions: str) -> list[str]:
    """
    Parse instructions into list of each instruction
    """

    return instructions.split('\n')

def parse_instruction(instruction: str) -> tuple[int, int, int]:
    """
    Parse instruction into count of moves, the start stack, and the end stack
    """

    instruction_list = instruction.split()

    move_count = int(instruction_list[1])
    start = int(instruction_list[3])
    end = int(instruction[-1])

    return move_count, start, end

def move_crate(stacks: dict[int, list[str]], start_stack: int, end_stack: int) -> None:
    """
    Move 1 crate from the `start_stack` to the `end_stack`
    """

    crate = stacks[start_stack].pop(0)
    
    stacks[end_stack].insert(0, crate)

def move_crates(stacks: dict[int, list[str]], move_count: int, start_stack: int, end_stack: int) -> None:
    """
    Move as many crates as passed in `move_count` from the `start_stack` to the `end_stack`
    """

    for _ in range(move_count):
        move_crate(stacks, start_stack, end_stack)

def perform_instructions(stacks: dict[int, list[str]], instructions: list[str]) -> None:
    """
    Perform all crate-moving instructions
    """

    for instruction in instructions:
        move_count, start_stack, end_stack = parse_instruction(instruction)

        move_crates(stacks, move_count, start_stack, end_stack)

def list_top_crates(stacks: dict[int, list[str]]) -> None:
    """
    List the first crate in each stack
    """

    print(''.join(stack[0].strip('[]') for stack in stacks.values()))

def main() -> None:

    stacks, instructions = read_input("inputs")
    
    parsed_stacks = parse_stacks(stacks)
    parsed_instructions = parse_instructions(instructions)

    perform_instructions(parsed_stacks, parsed_instructions)
    # list_top_crates(parsed_stacks)

if __name__ == "__main__":

    main()

