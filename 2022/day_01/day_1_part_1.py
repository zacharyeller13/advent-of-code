from timeit import timeit

def method_1() -> None:
    with open("inputs", 'r') as f:
        inputs = f.read()
        inputs_list = inputs.split('\n\n')
    
    max_calories = 0
    for input in inputs_list:

        calories = sum(map(int, input.split('\n')))
        max_calories = max(calories, max_calories)

    # print(max_calories)

def method_2() -> None:
    with open("inputs", 'r') as f:
        inputs = f.read()
        inputs_list = inputs.split('\n\n')

    max_calories = max(sum(map(int, input.split('\n'))) for input in inputs_list)

    # print(max_calories)

if __name__ == "__main__":

    print(timeit("method_1()", setup="from __main__ import method_1", number=10000))
    print(timeit("method_2()", setup="from __main__ import method_2", number=10000))