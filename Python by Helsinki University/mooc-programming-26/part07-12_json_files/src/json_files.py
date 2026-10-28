import json

def print_persons(filename: str):
  with open(filename) as file:
    data = file.read()
  students = json.loads(data)
  for student in students:
    print(f"{student["name"]} {student["age"]} years ({", ".join(student["hobbies"])})")