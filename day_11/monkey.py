class Monkey:
    def __init__(self, items: list[int], op: str, test_val: int, true: int, false: int) -> None:
        self.items = items
        self.op = op
        self.test_val = test_val
        self.true = true
        self.false = false
        self.check_count = 0

    def perform_op(self, item: int) -> int:
        x = lambda old, op : eval(op)

        return x(item, self.op)

    def test(self, item: int) -> bool:

        return item % self.test_val == 0

    def throw_item(self) -> tuple[int, int]:

        item = self.items.pop(0)
        if self.test(item):
            return item, self.true
        else:
            return item, self.false

    def check_items(self) -> None:

        self.items = [self.perform_op(item)//3 for item in self.items]
        self.check_count += len(self.items)

    def __str__(self) -> str:

        return f"items: {self.items}, op: {self.op}, test_val: {self.test_val}, true: {self.true}, false: {self.false}, check_count: {self.check_count}"