def read_input(message: str, min: int, max: int) -> int:
  error_message = f"You must type in an integer between {min} and {max}"
  while True:
    try:
      number = int(input(message))
      if number >= min and number <= max:
        break
      else:
        print(error_message)
    except ValueError:
      print(error_message)
  return number