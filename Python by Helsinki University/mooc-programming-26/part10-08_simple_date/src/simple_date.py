# WRITE YOUR SOLUTION HERE:
class SimpleDate:
  def __init__(self, day, month, year):
    self.__day = day
    self.__month = month
    self.__year = year

  def __str__(self):
    return f"{self.__day}.{self.__month}.{self.__year}"

  def __day_of_year(self) -> int:
    return self.__day + (self.__month - 1)*30

  def __lt__(self, another: SimpleDate):
    return self.__year < another.__year if self.__year != another.__year else self.__day_of_year() < another.__day_of_year()

  def __gt__(self, another: SimpleDate):
    return self.__year > another.__year if self.__year != another.__year else self.__day_of_year() > another.__day_of_year()

  def __eq__(self, another: SimpleDate):
    return self.__day == another.__day and self.__month == another.__month and self.__year == another.__year

  def __ne__(self, another: SimpleDate):
    return not self.__eq__(another)

  def __add__(self, days: int) -> SimpleDate:
    day = self.__day + days
    month = self.__month
    year = self.__year
    if day > 30:
      month += day // 30
      day %= 30
    if month > 12:
      year += month // 12
      month %= 12
    return SimpleDate(day, month, year)

  def __sub__(self, another: SimpleDate) -> int:
    return abs((self.__year - another.__year)*360 + (self.__day_of_year() - another.__day_of_year()))