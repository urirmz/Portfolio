# WRITE YOUR SOLUTION HERE:
class Person:
    def __init__(self, name: str, height: int):
        self.name = name
        self.height = height

    def __str__(self):
        return self.name

class Room:
    def __init__(self):
        self.persons = []

    def add(self, person: Person):
        self.persons.append(person)
    
    def is_empty(self):
        return len(self.persons) == 0

    def print_contents(self):
        combined_height = sum([person.height for person in self.persons])
        print(f"There are {len(self.persons)} persons in the room, and their combined height is {combined_height} cm")
        for person in self.persons:
            print(f"{person.name} ({person.height} cm)")

    def shortest(self):
        if self.is_empty():
            return None
        shortest = self.persons[0]
        for person in self.persons:
            if person.height < shortest.height:
                shortest = person
        return shortest

    def remove_shortest(self):
        shortest = self.shortest()
        if shortest == None:
            return None
        self.persons.remove(shortest)
        return shortest