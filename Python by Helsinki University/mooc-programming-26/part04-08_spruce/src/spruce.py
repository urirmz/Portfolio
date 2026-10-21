def spruce(size):
    print("a spruce!")
    base = size*2 - 1
    spaces = base // 2
    stars = 1
    while stars <= base:
        line = spaces*" " + stars*"*"
        if stars == 1:
            first_line = line
        print(line)
        stars += 2
        spaces -= 1
    print(first_line)

if __name__ == "__main__":
    spruce(5)