from datetime import datetime

def is_it_valid(pic: str) -> bool:
  try:
    if (len(pic) != 11):
      raise ValueError("Invalid length")

    century_marker = pic[6:7]
    if century_marker == "+":
      datetime(int(pic[4:6]) + 1800, int(pic[2:4]), int(pic[:2]))
    elif century_marker == "-":
      datetime(int(pic[4:6]) + 1900, int(pic[2:4]), int(pic[:2]))
    elif century_marker == "A":
      datetime(int(pic[4:6]) + 2000, int(pic[2:4]), int(pic[:2]))
    else:
      raise ValueError("Century marker is not valid")

    control_character = pic[10:11]
    calculated_control_character_index = int(pic[0:10].replace("+", "").replace("-", "").replace("A", "")) % 31
    calculated_control_character = "0123456789ABCDEFHJKLMNPRSTUVWXY"[calculated_control_character_index]
    if control_character != calculated_control_character:
      raise ValueError("Calculated control character differs")
  except ValueError as e:
    print(e)
    return False
  return True