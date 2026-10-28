students_file = input("Student information:")
exercises_file = input("Exercises completed:")
exam_points_file = input("Exam points:")

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

exam_points = {}
with open(exam_points_file) as file:
  for line in file:
    exam = line.split(";")
    student_id = exam[0]
    if student_id == "id":
      continue
    exam_points[student_id] = [int(exam[1]), int(exam[2]), int(exam[3])]

print(f"{"name":30}{"exec_nbr":10}{"exec_pts.":10}{"exm_pts.":10}{"tot_pts.":10}{"grade":10}")
for id, name in students.items():
  exercise_count = sum(exercises[id])
  exercise_points = exercise_count * 10 // 40
  exam_points_sum = sum(exam_points[id])
  total_points = exercise_points + exam_points_sum
  if total_points in range(0, 15):
    grade = 0
  elif total_points in range(15, 18):
    grade = 1
  elif total_points in range(18, 20):
    grade = 2
  elif total_points in range(21, 24):
    grade = 3
  elif total_points in range(24, 28):
    grade = 4
  else:
    grade = 5
  print(f"{name:30}{exercise_count:<10}{exercise_points:<10}{exam_points_sum:<10}{total_points:<10}{grade:<10}")