def count_matching_elements(matrix: list, element: int) -> int:
  count = 0
  for row in matrix:
    count += row.count(element)
  return count