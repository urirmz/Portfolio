def transpose(matrix: list):
  copy = []
  for row in matrix:
    copy.append(row[:])
  for row in range(len(copy)):
    for column in range(len(copy[row])):
      matrix[row][column] = copy[column][row]