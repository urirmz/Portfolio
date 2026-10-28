def print_letter_square(layers: int):
    size = 2 * layers - 1
    for i in range(size):
        row = []
        for j in range(size):
            distance_from_center = max(abs(i - (layers - 1)), abs(j - (layers - 1)))
            char_code = ord('A') + distance_from_center
            row.append(chr(char_code))
        print("".join(row))

layers = int(input("Layers:"))
print_letter_square(layers)