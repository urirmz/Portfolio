def invert(dictionary: dict):
  copy = dictionary.copy()
  dictionary.clear()
  for key, value in copy.items():
    dictionary[value] = key