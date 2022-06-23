import random
from functions import set_balls, set_parallelepipeds, info_balls, info_parallelepipeds, sumV, sumS


def main():
    n = int(input("Input number of figures: "))
    m = random.randint(1, n - 1)
    n -= m
    print(f"We'll create {n} ball and {m} parallelepipeds!")
    balls = set_balls(n)
    parallelepipeds = set_parallelepipeds(m)
    print()
    info_balls(balls, n)
    info_parallelepipeds(parallelepipeds, m)
    print(f"Sum of balls' volumes = {sumV(balls, n)}")
    print(f"Sum of parallelepipeds' areas = {sumS(parallelepipeds, m)}")


if __name__ == '__main__':
    main()
