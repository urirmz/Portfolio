def older_people(people: list, year: int) -> list:
  older_people = []
  for person in people:
    name = person[0]
    birth = person[1]
    if birth < year:
      older_people.append(name)
  return older_people