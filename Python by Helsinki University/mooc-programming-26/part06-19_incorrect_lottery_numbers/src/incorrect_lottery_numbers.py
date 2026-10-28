def filter_incorrect():
  with open("lottery_numbers.csv", "r") as lottery_numbers, open("correct_numbers.csv", "w") as correct_numbers:
    for line in lottery_numbers:
      try:
        week_numbers = line.split(";")
        week = week_numbers[0]
        numbers = week_numbers[1].split(",")

        int(week.split(" ")[1]) # Tests if week is integer type

        if len(numbers) < 7:
          raise ValueError("Too few numbers in this week")

        distinct = set()
        for number in numbers:
          int_number = int(number)
          if int_number < 1 or int_number > 39:
            raise ValueError("The numbers are too small or large:")
          if int_number in distinct:
            raise ValueError("Repeated number")
          distinct.add(int_number)

        correct_numbers.write(line)
      except ValueError, IndexError:
        pass