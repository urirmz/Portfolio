valid_words = set()
with open("wordlist.txt") as file:
  for line in file:
    line = line.replace("\n", "")
    valid_words.add(line)

text = input("Write text:")
words = text.split(" ")
corrected_words = []
for word in words:
  lowercase_word = word.lower()
  if lowercase_word in valid_words:
    corrected_words.append(word)
  else:
    corrected_words.append(f"*{word}*")

corrected_text = " ".join(corrected_words)
print(corrected_text)