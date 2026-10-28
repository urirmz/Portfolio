def histogram(s: str):
  histogram = {}
  for char in s:
    histogram[char] = histogram.get(char, 0) + 1
  for char, count in histogram.items():
    print(f"{char} {count*"*"}")