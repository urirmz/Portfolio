# Write your solution here:
class Item:
  def __init__(self, name: str, weight: int):
    self.__name = name
    self.__weight = weight

  def __str__(self):
    return f"{self.__name} ({self.__weight} kg)"

  def name(self):
    return self.__name

  def weight(self):
    return self.__weight

class Suitcase:
  def __init__(self, max_weight: int):
    self.__items = []
    self.__max_weight = max_weight

  def __str__(self):
    item_count = len(self.__items)
    return f"{item_count} item ({self.weight()} kg)" if item_count == 1 else f"{item_count} items ({self.weight()} kg)"

  def weight(self) -> int:
    return sum([item.weight() for item in self.__items])
  
  def add_item(self, item: Item):
    if self.weight() + item.weight() <= self.__max_weight:
      self.__items.append(item)

  def print_items(self):
    for item in self.__items: print(item)

  def heaviest_item(self) -> Item | None:
    if len(self.__items) == 0:
      return None
    heaviest = self.__items[0]
    for item in self.__items:
      if item.weight() > heaviest.weight():
        heaviest = item
    return heaviest

class CargoHold:
  def __init__(self, max_weight: int):
    self.__max_weight = max_weight
    self.__suitcases = []

  def __str__(self):
    suitcase_count = len(self.__suitcases)
    remaining_space = self.__max_weight - self.weight()
    return f"{suitcase_count} suitcase, space for {remaining_space} kg" if suitcase_count == 1 else f"{suitcase_count} suitcases, space for {remaining_space} kg"

  def weight(self) -> int:
    return sum([suitcase.weight() for suitcase in self.__suitcases])

  def add_suitcase(self, suitcase: Suitcase):
    if self.weight() + suitcase.weight() <= self.__max_weight:
      self.__suitcases.append(suitcase)

  def print_items(self):
    for suitcase in self.__suitcases: suitcase.print_items()