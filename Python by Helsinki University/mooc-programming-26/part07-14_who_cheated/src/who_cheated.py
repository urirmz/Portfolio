from datetime import time
import csv
 
def cheaters() -> list:
  cheaters = set()

  student_start_times = {}
  with open("start_times.csv", "r") as start_times:
    for line in csv.reader(start_times, delimiter=";"):
      student = line[0]
      start_time = line[1].split(":")
      hour = int(start_time[0])
      minute = int(start_time[1])
      student_start_times[student] = time(hour, minute)

  with open("submissions.csv", "r") as submissions:
    for line in csv.reader(submissions, delimiter=";"):
      student = line[0]
      submission_time = line[3].split(":")
      hour = int(submission_time[0])
      minute = int(submission_time[1])
      min_permitted_start_time = time(hour - 3, minute)
      if student_start_times[student] < min_permitted_start_time:
        cheaters.add(student)

  return list(cheaters)