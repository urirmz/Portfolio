import json
import urllib.request

def retrieve_all() -> list:
  data = urllib.request.urlopen("https://studies.cs.helsinki.fi/stats-mock/api/courses").read()
  courses = json.loads(data)
  active_courses = []
  for course in courses:
    if course["enabled"]:
      full_name = course["fullName"]
      name = course["name"]
      year = course["year"]
      exercise_sum = sum(course["exercises"])
      active_courses.append((full_name, name, year, exercise_sum))
  return active_courses

def retrieve_course(course_name: str) -> dict:
  data = urllib.request.urlopen(f"https://studies.cs.helsinki.fi/stats-mock/api/courses/{course_name}/stats").read()
  weeks = json.loads(data)
  max_students = 0
  total_hours = 0
  total_exercises = 0
  for week_number, week in weeks.items():
    max_students = max(max_students, week["students"])
    total_hours += week["hour_total"]
    total_exercises += week["exercise_total"]
  return {
    "weeks": len(weeks),
    "students": max_students,
    "hours": total_hours,
    "hours_average": total_hours // max_students,
    "exercises": total_exercises,
    "exercises_average": total_exercises // max_students
  }