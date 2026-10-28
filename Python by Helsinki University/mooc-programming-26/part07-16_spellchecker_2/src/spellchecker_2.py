from difflib import get_close_matches

valid_words = set()
with open("wordlist.txt") as file:
  for line in file:
    line = line.replace("\n", "")
    valid_words.add(line)

text = input("Write text: ")
words = text.split(" ")
corrected_words = []
suggestions = []
for word in words:
  lowercase_word = word.lower()
  if lowercase_word in valid_words:
    corrected_words.append(word)
  else:
    corrected_words.append(f"*{word}*")
    suggestions.append(f"{word}: {",".join(get_close_matches(word, valid_words))}")

corrected_text = " ".join(corrected_words)
print(corrected_text)
print("suggestions: ")
for suggestion in suggestions: print(suggestion)