def column_correct(sudoku: list, column_no: int):
  unique = set()
  for row in sudoku:
    cell = row[column_no]
    if cell != 0 and cell in unique:
      return False
    unique.add(cell)
  return True