def double_items(numbers: list):
  doubled = numbers[:]
  for i in range(len(doubled)):
    doubled[i] *= 2
  return doubled