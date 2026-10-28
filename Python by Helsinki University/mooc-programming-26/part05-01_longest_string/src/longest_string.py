def longest(strings: list) -> str:
  longest = ""
  longest_length = 0
  for string in strings:
    length = len(string)
    if length > longest_length:
      longest = string
      longest_length = length
  return longest

if __name__ == "__main__":
    strings = ["hi", "hiya", "hello", "howdydoody", "hi there"]
    print(longest(strings))