def find_movies(database: list, search_term: str):
  found = []
  for movie in database:
    name = movie["name"].lower()
    if name.find(search_term.lower()) != -1:
      found.append(movie)
  return found