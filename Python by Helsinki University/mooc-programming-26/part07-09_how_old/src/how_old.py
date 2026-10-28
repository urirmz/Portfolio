from datetime import datetime

day = int(input("Day: "))
month = int(input("Month: "))
year = int(input("Year: "))

NEW_MILLENIUM_EVE = datetime(1999, 12, 31)
birth = datetime(year, month, day)
old_in_new_millenium_eve = NEW_MILLENIUM_EVE - birth

if birth > NEW_MILLENIUM_EVE:
  print("You weren't born yet on the eve of the new millennium.")
else:
  print(f"You were {old_in_new_millenium_eve.days} days old on the eve of the new millennium.")