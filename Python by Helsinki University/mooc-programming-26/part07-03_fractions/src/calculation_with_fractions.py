from fractions import Fraction

def fractionate(amount: int) -> list:
  return [Fraction(1, amount) for _ in range(0, amount)]