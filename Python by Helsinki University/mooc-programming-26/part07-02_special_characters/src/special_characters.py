import string

def separate_characters(my_string: str):
  ascii_in_string = ""
  punctuation_in_string = ""
  other_in_string = ""

  ascii_letters = set(string.ascii_letters)
  punctuation = set(string.punctuation)

  for character in my_string:
    if character in ascii_letters:
      ascii_in_string += character
    elif character in punctuation:
      punctuation_in_string += character
    else:
      other_in_string += character

  return (ascii_in_string, punctuation_in_string, other_in_string)