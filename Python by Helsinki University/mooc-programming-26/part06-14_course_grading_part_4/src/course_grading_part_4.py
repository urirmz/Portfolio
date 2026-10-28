RESULTS_FILE_TXT = "results.txt"
RESULTS_FILE_CSV = "results.csv"

students_file = input("Student information:")
exercises_file = input("Exercises completed:")
exam_points_file = input("Exam points:")
course_information_file = input("Course information:")

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

course_information = {}
with open(course_information_file) as file:
  for line in file:
    if "name" not in course_information:
      course_information["name"] = line.replace("name: ", "").replace("\n", "")
    else:
      course_information["study_credits"] = int(line.replace("study credits: ", ""))

with open(RESULTS_FILE_TXT, "w") as results_file_txt, open(RESULTS_FILE_CSV, "w") as results_file_csv:
  title = f"{course_information["name"]}, {course_information["study_credits"]} credits"
  results_file_txt.write(title + "\n")
  results_file_txt.write(len(title)*"=" + "\n")
  results_file_txt.write(f"{"name":30}{"exec_nbr":10}{"exec_pts.":10}{"exm_pts.":10}{"tot_pts.":10}{"grade":10}\n")
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
    results_file_txt.write(f"{name:30}{exercise_count:<10}{exercise_points:<10}{exam_points_sum:<10}{total_points:<10}{grade:<10}\n")
    results_file_csv.write(f"{id};{name};{grade}\n")

print(f"Results written to files {RESULTS_FILE_TXT} and {RESULTS_FILE_CSV}")