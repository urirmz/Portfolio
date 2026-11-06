# WRITE YOUR SOLUTION HERE:
class Present:

  def __init__(self, name: str, weight: int):
    self.name = name
    self.weight = weight

  
class Box:

  def __init__(self):
    self.presents = []
    self.weight_sum = 0
  
  def add_present(self, present: Present):
    self.presents.append(present)
    self.weight_sum += present.weight

  def total_weight(self):
    return self.weight_sum
    

  