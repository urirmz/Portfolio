class LotteryNumbers:
    def __init__(self, week: int, numbers = list[int]):
        self.__week = week
        self.__numbers = set(numbers)

    def number_of_hits(self, numbers: list[int]):
        return sum([1 for number in numbers if number in self.__numbers])

    def hits_in_place(self, numbers: list[int]):
        return [number if number in self.__numbers else -1 for number in numbers]