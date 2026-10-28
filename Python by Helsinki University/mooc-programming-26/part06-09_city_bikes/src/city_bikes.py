import math

def get_station_data(filename: str) -> dict:
  data = {}
  with open(filename) as file:
    for line in file:
      if line.find("Longitude;") == 0:
        continue
      station = line.split(";")
      longitude = float(station[0])
      latitude = float(station[1])
      name = station[3]
      data[name] = (longitude, latitude)
  return data

def distance(stations: dict, station1: str, station2: str) -> float:
  station1_coordinates = stations[station1]
  longitude1 = station1_coordinates[0]
  latitude1 = station1_coordinates[1]
  
  station2_coordinates = stations[station2]
  longitude2 = station2_coordinates[0]
  latitude2 = station2_coordinates[1]

  x_km = (longitude1 - longitude2) * 55.26
  y_km = (latitude1 - latitude2) * 111.2
  distance_km = math.sqrt(x_km**2 + y_km**2)
  
  return distance_km

def greatest_distance(stations: dict) -> tuple:
  memo = {}
  greatest_distance = ("", "", -1)

  for station1 in stations:
    for station2 in stations:
      if station1 not in memo:
        memo[station1] = set()
      if station2 not in memo:
        memo[station2] = set()

      if station1 == station2 or station1 in memo[station2]:
        continue

      stations_distance = distance(stations, station1, station2)
      if stations_distance > greatest_distance[2]:
        greatest_distance = (station1, station2, stations_distance)
      
      memo[station1].add(station2)
      memo[station2].add(station1)

  return greatest_distance