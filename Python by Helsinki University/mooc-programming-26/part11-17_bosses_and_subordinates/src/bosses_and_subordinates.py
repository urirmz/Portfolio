class Employee:
    def __init__(self, name: str):
        self.name = name
        self.subordinates = []

    def add_subordinate(self, employee: 'Employee'):
        self.subordinates.append(employee)

def count_subordinates(employee: Employee) -> int:
    subordinates = 0
    for subordinate in employee.subordinates:
        subordinates += 1 + count_subordinates(subordinate)
    return subordinates