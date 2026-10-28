def row_correct(sudoku: list, row_no: int):
  numbers = set()
  for cell in sudoku[row_no]:
    if cell != 0 and cell in numbers:
      return False
    numbers.add(cell)
  return True