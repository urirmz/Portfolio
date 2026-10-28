def filter_solutions():
  SOLUTIONS_FILE = "solutions.csv"
  CORRECT_SOLUTIONS_FILE = "correct.csv"
  INCORRECT_SOLUTIONS_FILE = "incorrect.csv"

  open(CORRECT_SOLUTIONS_FILE, "w").close()
  open(INCORRECT_SOLUTIONS_FILE, "w").close()

  with open(SOLUTIONS_FILE) as solutions, open(CORRECT_SOLUTIONS_FILE, "a") as correct, open(INCORRECT_SOLUTIONS_FILE, "a") as incorrect:
    for solution in solutions:
      name_operation_result = solution.split(";")
      operation = name_operation_result[1]
      if "+" in operation:
        operands = operation.split("+")
        result = int(operands[0]) + int(operands[1])
      else:
        operands = operation.split("-")
        result = int(operands[0]) - int(operands[1])
      if result == int(name_operation_result[2]):
        correct.write(solution)
      else:
        incorrect.write(solution)