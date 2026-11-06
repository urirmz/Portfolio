class Money:
    def __init__(self, euros: int, cents: int):
        self.__euros = euros
        self.__cents = cents

    def __str__(self):
        return f"{self.__euros}.{self.__cents:02d} eur"

    def __as_decimal(self) -> float:
        return self.__euros + self.__cents*.01

    def __eq__(self, another: Money):
        return self.__euros == another.__euros and self.__cents == another.__cents

    def __ne__(self, another: Money):
        return not self.__eq__(another)

    def __lt__(self, another: Money):
        return self.__as_decimal() < another.__as_decimal()

    def __gt__(self, another: Money):
        return self.__as_decimal() > another.__as_decimal()

    def __add__(self, another: Money):
        euros = self.__euros + another.__euros
        cents = self.__cents + another.__cents
        euros += cents // 100
        cents %= 100
        return Money(euros, cents)

    def __sub__(self, another: Money):
        euros = self.__euros - another.__euros
        cents = self.__cents - another.__cents
        if cents < 0: 
            euros -= abs(cents // 100)
            cents = abs(cents % 100)
        if euros < 0:
            raise ValueError("a negative result is not allowed")
        return Money(euros, cents)