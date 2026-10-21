def longest_series_of_neighbours(list) -> int:
  longest = 1
  current = 1
  for i in range(1, len(list)):
    difference = max(list[i - 1], list[i]) - min(list[i - 1], list[i])
    if difference <= 1:
      current += 1
    else:
      current = 1
    longest = max(longest, current)
  return longest