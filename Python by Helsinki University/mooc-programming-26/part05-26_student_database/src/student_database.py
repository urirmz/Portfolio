def add_student(students: dict, name: str):
  students[name] = { "courses": {} }

def print_student(students: dict, name: str):
  if name in students:
    print(f"{name}:")
    courses = students[name]["courses"]
    courses_count = len(courses)
    if courses_count < 1:
      print(" no completed courses")
      return
    print(f" {courses_count} completed courses:")
    grades_sum = 0
    for course, grade in courses.items():
      print(f"  {course} {grade}")
      grades_sum += grade
    grades_average = grades_sum / courses_count
    print(" average grade", grades_average)
  else:
    print(f"{name}: no such person in the database")

def add_course(students: dict, student: str, course: tuple):
  if student not in students or course[1] == 0:
    return
  courses = students[student]["courses"]
  name = course[0]
  grade = course[1]
  if name not in courses or courses[name] < grade:
    courses[name] = grade

def summary(students: dict):
  student_count = len(students)
  print("students", student_count)

  student_with_most_courses_completed = ""
  most_courses_completed_count = -1
  for name, student in students.items():
    courses = student["courses"]
    courses_completed = len(courses)
    if courses_completed > most_courses_completed_count:
      most_courses_completed_count = courses_completed
      student_with_most_courses_completed = name
  print("most courses completed", most_courses_completed_count, student_with_most_courses_completed)

  student_with_best_average_grade = ""
  best_average_grade = -1
  for name, student in students.items():
    courses = student["courses"]
    grade_sum = 0
    for course, grade in courses.items():
      grade_sum += grade
    grade_average = grade_sum / len(courses)
    if grade_average > best_average_grade:
      best_average_grade = grade_average
      student_with_best_average_grade = name
  print("best average grade", best_average_grade, student_with_best_average_grade)