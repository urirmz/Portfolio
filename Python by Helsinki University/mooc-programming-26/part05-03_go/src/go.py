def who_won(game_board: list) -> int:
  player1 = 0
  player2 = 0
  for row in game_board:
    for cell in row:
      if cell == 1:
        player1 += 1
      elif cell == 2:
        player2 += 1
  if player1 > player2:
    return 1
  elif player2 > player1:
    return 2
  else:
    return 0