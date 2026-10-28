def read_fruits() -> dict:
  fruits = {}
  with open("fruits.csv") as file:
    for line in file:
      fruit_price = line.split(";")
      fruits[fruit_price[0]] = float(fruit_price[1])
  return fruits