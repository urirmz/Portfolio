def play_turn(game_board: list, x: int, y: int, piece: str) -> bool:
  if x not in range(0,3) or y not in range(0,3) or game_board[y][x] != "":
    return False
  game_board[y][x] = piece
  return True