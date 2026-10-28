def read_matrix() -> list[list[int]]:
  matrix = []
  with open("matrix.txt") as file:
    for row in file:
      numbers = row.split(",")
      numbers_row = []
      for number in numbers:
        numbers_row.append(int(number))
      matrix.append(numbers_row)
  return matrix

def matrix_sum() -> int:
  matrix = read_matrix()
  matrix_sum = 0
  for row in matrix:
    matrix_sum += sum(row)
  return matrix_sum

def matrix_max() -> int:
  matrix = read_matrix()
  matrix_max = float("-inf")
  for row in matrix:
    row_max = max(row)
    matrix_max = max(matrix_max, row_max)
  return matrix_max

def row_sums() -> list:
  matrix = read_matrix()
  row_sums = []
  for row in matrix:
    row_sums.append(sum(row))
  return row_sums