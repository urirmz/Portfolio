list = []

while True:
  print(f"The list is now {list}")
  action = input("a(d)d, (r)emove or e(x)it:")
  if action == "d":
    number = 1 if not list else list[-1] + 1
    list.append(number)
  elif action == "r" and bool(list):
    list.pop()
  elif action == "x":
    break

print("Bye!")