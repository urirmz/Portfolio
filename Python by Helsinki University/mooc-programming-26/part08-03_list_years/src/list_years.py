from datetime import datetime

def list_years(dates: list[datetime]):
  return sorted([date.year for date in dates])