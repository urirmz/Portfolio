def largest() -> int:
  largest = float("-inf")
  with open("numbers.txt") as numbers:
    for number in numbers:
      largest = max(largest, int(number))
  return largest