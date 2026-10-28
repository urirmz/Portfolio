def find_words(search_term: str):
    matching_words = []
    with open("words.txt", "r") as file:
        words = [line.strip() for line in file]
        
    if search_term.startswith("*"):
        suffix = search_term[1:]
        for word in words:
            if word.endswith(suffix):
                matching_words.append(word)              
    elif search_term.endswith("*"):
        prefix = search_term[:-1]
        for word in words:
            if word.startswith(prefix):
                matching_words.append(word)
    elif "." in search_term:
        for word in words:
            if len(word) != len(search_term):
                continue
            match = True
            for i in range(len(search_term)):
                if search_term[i] != "." and search_term[i] != word[i]:
                    match = False
                    break
            if match:
                matching_words.append(word)                
    else:
        for word in words:
            if word == search_term:
                matching_words.append(word)
                
    return matching_words
