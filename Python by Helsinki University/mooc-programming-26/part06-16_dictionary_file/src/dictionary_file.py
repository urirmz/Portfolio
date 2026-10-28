DICTIONARY_FILE = "dictionary.txt"

while True:
  print("1 - Add word, 2 - Search, 3 - Quit")
  function = int(input("Function:"))
  if function == 1:
    finnish = input("The word in Finnish: ")
    english = input("The word in English: ")
    with open(DICTIONARY_FILE, "a") as dictionary:
      dictionary.write(f"{finnish} - {english}")
    print("Dictionary entry added")
  elif function == 2:
    with open(DICTIONARY_FILE) as dictionary:
      search_term = input("Search term: ")
      for word_translation in dictionary:
        if word_translation.find(search_term) != -1:
          print(word_translation)
  else:
    print("Bye!")
    break
