def palindromes(string: str) -> bool:
  left = 0
  right = len(string) - 1
  while left < right:
    if string[left] != string[right]:
      return False
    left += 1
    right -= 1
  return True

while True: 
  word = input("Please type in a palindrome: ")
  if palindromes(word):
    print(f"{word} is a palindrome!")
    break
  print("that wasn't a palindrome")