from datetime import timedelta
from datetime import datetime

DOTTED_DATE_FORMAT = "%d.%m.%Y"

filename = input("Filename: ")
starting_date = input("Starting date: ")
days = int(input("How many days: "))

date =  datetime.strptime(starting_date, DOTTED_DATE_FORMAT)
starting_date = datetime.strftime(date, DOTTED_DATE_FORMAT)

print("Please type in screen time in minutes on each day (TV computer mobile): ")
total_minutes = 0
lines_to_write = []
for _ in range(0, days):
  formatted_date = datetime.strftime(date, DOTTED_DATE_FORMAT)
  time = input(f"Screen time {formatted_date}:").strip().replace(" ", "/")
  total_minutes += sum([int(minutes) for minutes in time.split("/")])
  lines_to_write.append(f"{formatted_date}: {time}")
  date += timedelta(days=1)

lines_to_write.insert(0, f"Time period: {starting_date}-{formatted_date}") 
lines_to_write.insert(1, f"Total minutes: {total_minutes}")
lines_to_write.insert(2, f"Average minutes: {total_minutes / days}")

with open(filename, "w") as file:
  for line in lines_to_write:
    file.write(line + "\n")

print(f"Data stored in file {filename}")