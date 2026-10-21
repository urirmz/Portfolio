def line(count, string):
    character = "*" if string == "" else string[:1] 
    print(character * count)

def triangle(size):
    characters = 1
    while characters <= size:
        line(characters, "#")
        characters += 1

# You can test your function by calling it within the following block
if __name__ == "__main__":
    triangle(5)
