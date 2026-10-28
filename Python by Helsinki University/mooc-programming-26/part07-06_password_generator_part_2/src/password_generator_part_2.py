from string import digits, ascii_lowercase
from random import randint

def generate_strong_password(length: int, include_numbers: bool, include_special: bool) -> str:
  password = ""
  while len(password) < length:
    password += ascii_lowercase[randint(0, 25)]
    if include_numbers and len(password) < length:
      password += digits[randint(0, 9)]
    if include_special and len(password) < length:
      password += "!?=+-()#"[randint(0, 6)]
  return password