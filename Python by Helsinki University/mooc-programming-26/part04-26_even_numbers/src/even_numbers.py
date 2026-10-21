def even_numbers(list: list) -> list:
  evens = []
  for number in list:
    if number % 2 == 0:
      evens.append(number)
  return evens