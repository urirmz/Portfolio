def anagrams(string1: str, string2: str) -> bool:
  return sorted(string1) == sorted(string2)