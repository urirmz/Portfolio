words = set()

while True:
  word = input("Word:")
  if word in words:
    break
  words.add(word)

print(f"You typed in {len(words)} different words")