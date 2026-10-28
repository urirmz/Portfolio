from datetime import time
import csv
 
def final_points() -> dict:
  student_start_times = {}
  with open("start_times.csv", "r") as start_times:
    for line in csv.reader(start_times, delimiter=";"):
      student = line[0]
      start_time = line[1].split(":")
      hour = int(start_time[0])
      minute = int(start_time[1])
      student_start_times[student] = time(hour, minute)

  student_tasks = {}
  with open("submissions.csv", "r") as submissions:
    for line in csv.reader(submissions, delimiter=";"):
      student = line[0]
      task_number = line[1]
      task_points = int(line[2])
      submission_time = line[3].split(":")
      hour = int(submission_time[0])
      minute = int(submission_time[1])
      min_permitted_start_time = time(hour - 3, minute)
      if student_start_times[student] < min_permitted_start_time:
        continue
      if student not in student_tasks:
        student_tasks[student] = {}
      tasks = student_tasks[student]
      tasks[task_number] = max(task_points, tasks.get(task_number, -1))

  student_points = {}
  for student, tasks in student_tasks.items():
    student_points[student] = sum([task_points for task, task_points in tasks.items()])

  return student_points