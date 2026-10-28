from string import ascii_lowercase
from random import randint

def generate_password(length: int) -> str:
  return "".join([ascii_lowercase[randint(0, 25)] for _ in range(0, length)])