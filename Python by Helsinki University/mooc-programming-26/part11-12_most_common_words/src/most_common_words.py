def most_common_words(filename: str, lower_limit: int):
    with open(filename) as file: 
        clean_content = "".join([char if char not in "\n,.;" else " " for char in file.read()])
        all_words = clean_content.split(" ")
    word_count = { word: all_words.count(word) for word in all_words }
    word_count.pop("")
    return { word: count for word, count in word_count.items() if count >= lower_limit }