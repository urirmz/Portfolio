def smallest_average(person1: dict, person2: dict, person3: dict) -> dict:
  min_average = float("inf")
  smallest_average_person = {}
  for person in [person1, person2, person3]:
    average = (person["result1"] + person["result2"] + person["result3"]) / 3
    if average < min_average:
      min_average = average
      smallest_average_person = person
  return smallest_average_person