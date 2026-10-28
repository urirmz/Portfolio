def block_correct(sudoku: list, row_no: int, column_no: int):
  unique = set()
  for row in range(row_no, row_no + 3):
    for column in range(column_no, column_no + 3):
      cell = sudoku[row][column] 
      if cell != 0 and cell in unique:
        return False
      unique.add(cell)
  return True