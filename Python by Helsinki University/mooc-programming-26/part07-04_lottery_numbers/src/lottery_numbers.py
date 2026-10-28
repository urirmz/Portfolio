from random import randint

def lottery_numbers(amount: int, lower: int, upper: int) -> list:
  numbers = set()
  while len(numbers) < amount:
    number = randint(lower, upper)
    if number not in numbers:
      numbers.add(number)
  return sorted(numbers)