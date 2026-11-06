# WRITE YOUR SOLUTION HERE:
class Recording:
  def __init__(self, length: int):
    if length < 0:
      raise ValueError
    self.__length = length

  @property
  def length(self):
    return self.__length

  @length.setter
  def length(self, length):
    if length < 0:
      raise ValueError
    self.__length = length