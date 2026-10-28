import sys

def oldest_person(people: list):
  oldest_name = ""
  oldest_birth = sys.maxsize
  for person in people:
    name = person[0]
    birth = person[1]
    if birth < oldest_birth:
      oldest_name = name
      oldest_birth = birth
  return oldest_name