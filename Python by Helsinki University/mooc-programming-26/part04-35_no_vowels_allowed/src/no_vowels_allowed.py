def no_vowels(string) -> str:
  for vowel in ["a", "e", "i", "o", "u"]:
    string = string.replace(vowel, "")
  return string