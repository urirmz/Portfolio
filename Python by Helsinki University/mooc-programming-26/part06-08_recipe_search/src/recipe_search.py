def read_recipes(file: str) -> list[dict]:
  recipe = {}
  recipes = []
  with open(file) as recipes_file:
    for line in recipes_file:
      line = line.replace("\n", "")
      if line == "":
        recipes.append(recipe)
        recipe = {}
      elif "name" not in recipe:
        recipe["name"] = line
      elif "time" not in recipe:
        recipe["time"] = int(line)
      elif "ingredients" not in recipe:
        recipe["ingredients"] = [line]
      else:
        recipe["ingredients"].append(line)
  recipes.append(recipe)
  return recipes

def search_by_name(file: str, name: str):
  recipes = read_recipes(file)
  found = []
  for recipe in recipes:
    recipe_name = recipe["name"]
    if recipe_name.lower().find(name) != -1:
      found.append(recipe_name)
  return found

def search_by_time(file: str, time: int):
  recipes = read_recipes(file)
  found = []
  for recipe in recipes:
    recipe_time = recipe["time"]
    if recipe_time < time:
      found.append(f"{recipe["name"]}, preparation time {recipe_time} min")
  return found

def search_by_ingredient(file: str, ingredient: str):
  recipes = read_recipes(file)
  print(recipes)
  found = []
  for recipe in recipes:
    recipe_ingredients = recipe["ingredients"]
    for recipe_ingredient in recipe_ingredients:
      if recipe_ingredient.lower().find(ingredient) != -1:
        found.append(f"{recipe["name"]}, preparation time {recipe["time"]} min")
        break
  return found