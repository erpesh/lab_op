import math
import random


class TBody:
    def __init__(self):
        self.side1 = None
        self.side2 = None
        self.side3 = None

    def countS(self):
        print("Program is not able to count area of this figure!")
        return -1

    def countV(self):
        print("Program is not able to count volume of this figure!")
        return -1


class TBall(TBody):
    def __init__(self, key=False):
        super().__init__()

        self.side3 = -1
        self.side2 = -1

        if key:
            self.side1 = random.random() * 10

    def countS(self):
        s = 4 * math.pi * self.side1**2
        return s

    def countV(self):
        v = 4 * math.pi * self.side1**3 / 3
        return v


class TParallelepiped(TBody):
    def __init__(self, key=False):
        super().__init__()

        if key:
            self.side1 = random.random() * 15
            self.side2 = random.random() * 15
            self.side3 = random.random() * 15

    def countS(self):
        s = 2 * (self.side1 * self.side2 + self.side2 * self.side3 + self.side3 * self.side1)
        return s

    def countV(self):
        v = self.side1 * self.side2 * self.side3
        return v