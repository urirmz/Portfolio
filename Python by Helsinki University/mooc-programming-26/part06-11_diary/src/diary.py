DAIRY_FILE = "diary.txt"

while True:
  print("1 - add an entry, 2 - read entries, 0 - quit")
  command = int(input("Function:"))
  if command == 0:
    break
  elif command == 1:
    with open(DAIRY_FILE, "a") as file:
      text = input("Diary entry:")
      file.write(text + "\n")
      print("Diary saved")
  elif command == 2:
    with open(DAIRY_FILE) as file:
      print("Entries:")
      for line in file:
        print(line)

print("Bye now!")