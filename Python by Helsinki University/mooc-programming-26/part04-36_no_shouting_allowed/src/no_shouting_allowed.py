def no_shouting(strings: list) -> list:
  result = []
  for string in strings:
    if not string.isupper():
      result.append(string)
  return result