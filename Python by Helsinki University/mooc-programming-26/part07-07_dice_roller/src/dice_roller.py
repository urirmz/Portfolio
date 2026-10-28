from random import randint

def roll(dice: str):
  dices = {
    "A": [3, 3, 3, 3, 3, 6],
    "B": [2, 2, 2, 5, 5, 5],
    "C": [1, 4, 4, 4, 4, 4]
  }
  return dices[dice][randint(0, 5)]

def play(dice1: str, dice2: str, times: int):
  dice1_won = 0
  dice2_won = 0
  ties = 0

  for _ in range(0, times):
    dice1_roll = roll(dice1)
    dice2_roll = roll(dice2)
    if dice1_roll == dice2_roll:
      ties += 1
    elif dice1_roll > dice2_roll:
      dice1_won += 1
    else:
      dice2_won += 1

  return (dice1_won, dice2_won, ties)