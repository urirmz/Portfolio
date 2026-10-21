def most_common_character(string: str) -> int:
  most_common_character = None
  counted = { None: -1 }
  for char in string:
    if char in counted:
      continue
    count = string.count(char)
    counted[char] = count
    if count > counted[most_common_character]:
      most_common_character = char
  return most_common_character