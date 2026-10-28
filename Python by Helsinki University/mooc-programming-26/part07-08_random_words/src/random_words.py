from random import randint

def words(n: int, beginning: str) -> list:
  words_with_beginning = []
  with open("words.txt", "r") as words:
    for word in words:
      if word.startswith(beginning):
        words_with_beginning.append(word.replace("\n", ""))
  count = len(words_with_beginning)
  if count < n:
    raise ValueError
  result = set()
  while len(result) < n:
    word = words_with_beginning[randint(0, count - 1)]
    if word not in result:
      result.add(word)
  return list(result)