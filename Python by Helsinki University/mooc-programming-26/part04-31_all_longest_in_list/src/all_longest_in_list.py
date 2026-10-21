def all_the_longest(list) -> list:
  longest = [list[0]]
  for word in list[1:]:
    word_length = len(word)
    longest_length = len(longest[0])
    if word_length > longest_length:
      longest = [word]
    elif word_length == longest_length:
      longest.append(word)
  return longest