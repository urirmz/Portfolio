class Series:
  def __init__(self, title: str, seasons: int, genres: list):
    self.title = title  
    self.seasons = seasons  
    self.genres = genres
    self.ratings = []

  def __str__(self):
    rating_count = len(self.ratings)
    if rating_count > 0:
      average_ratings = sum(self.ratings) / rating_count
      return f"{self.title} ({self.seasons} seasons)\ngenres: {", ".join(self.genres)}\n{rating_count} ratings, average {average_ratings:.1f} points"
    else:
      return f"{self.title} ({self.seasons} seasons)\ngenres: {", ".join(self.genres)}\nno ratings"

  def rate(self, score):
    self.ratings.append(score)

def minimum_grade(rating: float, series_list: list) -> list[Series]:
  result = []
  for series in series_list:
    for series_rating in series.ratings:
      if series_rating >= rating:
        result.append(series)
        break
  return result

def includes_genre(genre: str, series_list: list) -> list[Series]:
  result = []
  for series in series_list:
    for series_genre in series.genres:
      if series_genre == genre:
        result.append(series)
        break
  return result