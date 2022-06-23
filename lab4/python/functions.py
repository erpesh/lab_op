from classes import TBall, TParallelepiped


def sumV(balls, n):
    result = 0
    for i in range(n):
        result += balls[i].countV()
    return result


def sumS(parallelepipeds, n):
    result = 0
    for i in range(n):
        result += parallelepipeds[i].countS()
    return result


def info_balls(balls, n):
    for i in range(n):
        print(f"Ball number {i + 1}")
        print(f"R = {balls[i].side1} , S = {balls[i].countS()}, V = {balls[i].countV()}")
        print()


def info_parallelepipeds(parallelepipeds, n):
    for i in range(n):
        print(f"Parallelepiped number {i + 1}")
        print(
            f"a = {parallelepipeds[i].side1} , b = {parallelepipeds[i].side2} , c = {parallelepipeds[i].side3} , "
            f"S = {parallelepipeds[i].countS()}, V = {parallelepipeds[i].countV()}")
        print()


def set_balls(n):
    balls = []
    for _ in range(n):
        ans = input("Do you want to generate ball automatically (yes/no)?")
        if ans == "yes":
            balls.append(TBall(True))
        else:
            ball = TBall()
            ball.side1 = float(input("Input radius: "))
            balls.append(ball)
    return balls


def set_parallelepipeds(n):
    parallelepipeds = []
    for _ in range(n):
        ans = input("Do you want to generate parallelepiped automatically (yes/no)?")
        if ans == "yes":
            parallelepipeds.append(TParallelepiped(True))
        else:
            parallelepiped = TParallelepiped()
            parallelepiped.side1 = float(input("Input side1: "))
            parallelepiped.side2 = float(input("Input side2: "))
            parallelepiped.side3 = float(input("Input side3: "))
            parallelepipeds.append(parallelepiped)
    return parallelepipeds
