def same_chars(string, index1, index2):
    last_index = len(string) - 1
    return False if index1 > last_index or index2 > last_index else string[index1] == string[index2]

if __name__ == "__main__":
    # same characters m and m
    print(same_chars("programmer", 6, 7)) # True
    # different characters p and r
    print(same_chars("programmer", 0, 4)) # False
    # the second index is not within the string
    print(same_chars("programmer", 0, 12)) # False