students_file = input("Student information:")
exercises_file = input("Exercises completed:")

students = {}
with open(students_file) as file:
  for line in file:
    student = line.split(";")
    id = student[0]
    if id == "id":
      continue
    name = student[1]
    last_name = student[2]
    students[id] = f"{name} {last_name}".replace("\n", "")

exercises = {}
with open(exercises_file) as file:
  for line in file:
    exercise = line.split(";")
    student_id = exercise[0]
    if student_id == "id":
      continue
    exercises[student_id] = [int(exercise[1]), int(exercise[2]), int(exercise[3]), int(exercise[4]), int(exercise[5]), int(exercise[6]), int(exercise[7])]

for id, name in students.items():
  exercise_sum = sum(exercises[id])
  print(f"{name} {exercise_sum}")