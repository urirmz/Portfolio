class Course:
  def __init__(self, name: str, grade: int, credits: int):
    self.name = name
    self.grade = grade
    self.credits = credits

  def update_grade(self, grade: int):
    # Keeps the highest grade achieved for the course
    if grade > self.grade:
      self.grade = grade

  def __str__(self):
    return f"{self.name} ({self.credits} cr) grade {self.grade}"


class StudyTracker:
  def __init__(self):
    self.courses = {}

  def add_course(self, name: str, grade: int, credits: int):
    if name in self.courses:
      self.courses[name].update_grade(grade)
    else:
      self.courses[name] = Course(name, grade, credits)

  def get_course(self, name: str):
    if name in self.courses:
      print(self.courses[name])
    else:
      print("no entry for this course")

  def statistics(self):
    num_courses = len(self.courses)
    total_credits = sum(course.credits for course in self.courses.values())
    
    if num_courses > 0:
      mean_grade = sum(course.grade for course in self.courses.values()) / num_courses
    else:
      mean_grade = 0.0

    print(f"{num_courses} completed courses, a total of {total_credits} credits")
    print(f"mean {mean_grade:.1f}")
    print("grade distribution")
    
    for i in range(5, 0, -1):
      count = sum(1 for course in self.courses.values() if course.grade == i)
      print(f"{i}: {'x' * count}")


class CourseRecordsApplication:
  def __init__(self):
    self.__tracker = StudyTracker()

  def help(self):
    print("1 add course")
    print("2 get course data")
    print("3 statistics")
    print("0 exit")
  
  def execute(self):
    self.help()
    while True:
      print("")
      command = input("command: ")
      if command == "0":
        break
      elif command == "1":
        name = input("course: ")
        grade = int(input("grade: "))
        credits = int(input("credits: "))
        self.__tracker.add_course(name, grade, credits)
      elif command == "2":
        name = input("course: ")
        self.__tracker.get_course(name)
      elif command == "3":
        self.__tracker.statistics()
      

application = CourseRecordsApplication()
application.execute()