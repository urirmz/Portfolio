def shortest(list) -> int:
  shortest = list[0]
  for string in list[1:]:
    if len(string) < len(shortest):
      shortest = string
  return shortest