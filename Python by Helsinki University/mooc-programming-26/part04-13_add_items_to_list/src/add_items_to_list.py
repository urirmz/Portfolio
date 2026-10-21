count = int(input("How many items:"))
items = []

for i in range(0, count):
  item = int(input(f"Item {i + 1}:"))
  items.append(item)

print(items)