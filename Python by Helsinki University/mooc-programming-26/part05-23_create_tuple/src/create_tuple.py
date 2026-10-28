def create_tuple(x: int, y: int, z: int):
  numbers = [x,y,z]
  smallest = min(numbers)
  greatest = max(numbers)
  total_sum = sum(numbers)
  return (smallest, greatest, total_sum)