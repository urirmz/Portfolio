def input_points_and_exercises() -> list:
  all_points_and_exercises = []
  while True:
    line = input("Exam points and exercises completed:")
    if line == "":
      break
    points_and_exercises = line.split(" ")
    all_points_and_exercises.append([int(points_and_exercises[0]), int(points_and_exercises[1])])
  return all_points_and_exercises

def get_total_points_per_subject(points_and_exercises: list) -> list:
  total_points = []
  for points in points_and_exercises:
    exam_points = points[0]
    exercise_points = points[1] // 10
    total_points.append(exam_points + exercise_points)
  return total_points

def get_pass_percentage(points_and_exercises: list, total_points_per_subject: list) -> int:
  pass_count = 0
  for i in range(len(points_and_exercises)):
    exercise_points = points_and_exercises[i][0]
    total_points = total_points_per_subject[i]
    if exercise_points >= 10 and total_points >= 15:
      pass_count += 1
  return pass_count*100 / len(points_and_exercises)

def print_grade_distribution(points_and_exercises: list, total_points: list):
  grade_distribution = { 5: 0, 4: 0, 3: 0, 2: 0, 1: 0, 0: 0 }
  for i in range(len(total_points)):
    points = total_points[i]
    if points in range(0, 15) or points_and_exercises[i][0] < 10:
      grade = 0
    elif points in range(15, 18):
      grade = 1
    elif points in range(18, 21):
      grade = 2
    elif points in range(21, 24):
      grade = 3
    elif points in range(24, 28):
      grade = 4
    else:
      grade = 5
    grade_distribution[grade] += 1
  for grade in grade_distribution:
    print(f"\t{grade}: {"*"*grade_distribution[grade]}")

points_and_exercises = input_points_and_exercises()
total_points = get_total_points_per_subject(points_and_exercises)
average = sum(total_points) / len(total_points)
pass_percentage = get_pass_percentage(points_and_exercises, total_points)

print("Statistics:")
print(f"Points average: {average:.1f}")
print(f"Pass percentage: {pass_percentage:.1f}")
print("Grade distribution:")
print_grade_distribution(points_and_exercises, total_points)