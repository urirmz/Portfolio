def formatted(list) -> list:
  result = []
  for number in list:
    result.append(f"{number:.2f}")
  return result