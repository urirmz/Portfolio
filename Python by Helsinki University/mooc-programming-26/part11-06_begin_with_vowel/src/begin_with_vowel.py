def begin_with_vowel(words: list[str]):
    return [word for word in words if word[:1] in "aeiouAEIOU"]