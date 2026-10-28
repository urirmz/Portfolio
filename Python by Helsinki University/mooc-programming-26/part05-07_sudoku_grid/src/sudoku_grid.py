def row_correct(sudoku: list, row_no: int):
  numbers = set()
  for cell in sudoku[row_no]:
    if cell != 0 and cell in numbers:
      return False
    numbers.add(cell)
  return True

def column_correct(sudoku: list, column_no: int):
  unique = set()
  for row in sudoku:
    cell = row[column_no]
    if cell != 0 and cell in unique:
      return False
    unique.add(cell)
  return True

def block_correct(sudoku: list, row_no: int, column_no: int):
  unique = set()
  for row in range(row_no, row_no + 3):
    for column in range(column_no, column_no + 3):
      cell = sudoku[row][column] 
      if cell != 0 and cell in unique:
        return False
      unique.add(cell)
  return True

def sudoku_grid_correct(sudoku: list):
  for i in range(len(sudoku)):
    if not row_correct(sudoku, i):
      return False
  for i in range(len(sudoku[0])):
    if not column_correct(sudoku, i):
      return False
  blocks = [[0,0], [0,3], [0,6], [3,0], [3,3], [3,6], [6,0], [6,3], [6,6]]
  for block in blocks:
    row = block[0]
    column = block[1]
    if not block_correct(sudoku, row, column):
      return False
  return True