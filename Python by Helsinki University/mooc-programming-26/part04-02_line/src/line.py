def line(count, string):
    character = "*" if string == "" else string[:1] 
    print(character * count)

if __name__ == "__main__":
    line(7, "%")
    line(10, "LOL")
    line(3, "")