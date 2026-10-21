def length_of_longest(list) -> int:
  length_of_longest = 0
  for string in list:
    length_of_longest = max(length_of_longest, len(string))
  return length_of_longest