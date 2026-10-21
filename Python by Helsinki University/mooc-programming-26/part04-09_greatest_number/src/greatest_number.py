def greatest_number(number1, number2, number3):
    return max(max(number1, number2), number3)

if __name__ == "__main__":
    greatest = greatest_number(5, 4, 8)
    print(greatest)