def factorials(n: int) -> dict:
  result = { 1: 1 }
  for i in range(2, n + 1):
    result[i] = i * result[i - 1]
  return result