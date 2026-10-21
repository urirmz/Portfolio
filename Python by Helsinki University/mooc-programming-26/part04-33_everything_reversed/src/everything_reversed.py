def everything_reversed(list) -> list:
  result = []
  for item in list:
    reverse = item[::-1]
    result.append(reverse)
  return result[::-1]