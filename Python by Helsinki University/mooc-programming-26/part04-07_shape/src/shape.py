def line(count, string):
    character = "*" if string == "" else string[:1] 
    print(character * count)

def triangle(size, character):
    characters = 1
    while characters <= size:
        line(characters, character)
        characters += 1

def rectangle(height, width, character):
    while height > 0:
        line(width, character)
        height -= 1

def shape(triangle_size, triangle_character, square_height, square_character):
    triangle(triangle_size, triangle_character)
    rectangle(square_height, triangle_size, square_character)

# You can test your function by calling it within the following block
if __name__ == "__main__":
    shape(5, "x", 2, "o")