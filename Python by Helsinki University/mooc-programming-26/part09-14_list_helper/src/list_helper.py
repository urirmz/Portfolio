# WRITE YOUR SOLUTION HERE:
class ListHelper:

  @classmethod
  def greatest_frequency(cls, numbers: list):
    frequencies = {}
    most_common = numbers[0]
    for number in numbers:
      frequencies[number] = frequencies.get(number, 0) + 1
      if frequencies[number] >= frequencies[most_common]:
        most_common = number
    return most_common

  @classmethod
  def doubles(cls, numbers: list):
    frequencies = {}
    for number in numbers:
      frequencies[number] = frequencies.get(number, 0) + 1
    doubles = 0
    for number, frequency in frequencies.items():
      if frequency > 1:
        doubles += 1
    return doubles