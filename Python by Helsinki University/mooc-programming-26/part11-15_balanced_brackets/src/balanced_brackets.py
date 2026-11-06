def balanced_brackets(my_string: str):
    brackets = "".join([c for c in my_string if c in "()[]"])

    if len(brackets) == 0:
        return True

    pairs = {"(": ")", "[": "]"}
    if brackets[0] not in pairs or pairs[brackets[0]] != brackets[-1]:
        return False

    return balanced_brackets(brackets[1:-1])