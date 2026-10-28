from string import ascii_letters, ascii_lowercase, ascii_uppercase, whitespace, digits

def change_case(orig_string: str):
  uppercase = set(ascii_uppercase)
  lowercase = set(ascii_lowercase)
  changed = ""
  for character in orig_string:
    if character in uppercase:
      changed += character.lower()
    elif character in lowercase:
      changed += character.upper()
    else:
      changed += character
  return changed

def split_in_half(orig_string: str):
  half_index = len(orig_string) // 2
  return (orig_string[:half_index], orig_string[half_index:])

def remove_special_characters(orig_string: str):
  available_characters = set(ascii_letters + digits + whitespace)
  result = ""
  for character in orig_string:
    if character in available_characters:
      result += character
  return result