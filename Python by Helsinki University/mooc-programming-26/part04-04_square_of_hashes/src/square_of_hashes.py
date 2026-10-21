def line(count, string):
    character = "*" if string == "" else string[:1] 
    print(character * count)

def square_of_hashes(size):
    height = size
    while height > 0:
        line(size, "#")
        height -= 1

# You can test your function by calling it within the following block
if __name__ == "__main__":
    square_of_hashes(5)
