import timeit

from day_5_part_1 import main as use_reverse
from day_5_part_1_1 import main as for_loop

print("For loop takes: ", timeit.timeit("for_loop()", setup="from __main__ import for_loop", number=100000))
print("Reverse takes: ", timeit.timeit("use_reverse()", setup="from __main__ import use_reverse", number=100000))