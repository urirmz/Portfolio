# WRITE YOUR SOLUTION HERE:
class BankAccount:
  def __init__(self, owner: str, account_number: int, balance: float):
    self.__owner = owner
    self.__account_number = account_number
    self.__balance = balance

  def deposit(self, amount: float):
    self.__balance += amount
    self.__service_charge()

  def withdraw(self, amount: float):
    self.__balance -= amount
    self.__service_charge()

  @property
  def balance(self):
    return self.__balance

  @balance.setter
  def balance(self, balance: int):
    self.balance = balance

  def __service_charge(self):
    self.__balance *= .99