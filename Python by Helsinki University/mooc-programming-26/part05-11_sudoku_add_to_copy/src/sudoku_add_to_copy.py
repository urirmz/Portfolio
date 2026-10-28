def print_sudoku(sudoku: list):
  for i in range(9):
    print_sudoku_row(sudoku[i])
    if i in [2, 5]:
      print()
    
def print_sudoku_row(row: list):
  line = f"{row[0]} {row[1]} {row[2]}  {row[3]} {row[4]} {row[5]}  {row[6]} {row[7]} {row[8]}"
  line = line.replace("0","_")
  print(line)

def copy_and_add(sudoku: list, row_no: int, column_no: int, number: int) -> list:
  copy = []
  for row in sudoku:
    copy.append(row[:])
  copy[row_no][column_no] = number
  return copy
