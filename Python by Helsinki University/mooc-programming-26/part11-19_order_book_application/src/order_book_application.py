class Task:
    __next_id = 1
    def __init__(self, description: str, programmer: str, workload: int):
        self.__id = Task.__next_id
        Task.__next_id += 1
        self.__description = description
        self.__programmer = programmer
        self.__workload = workload
        self.__is_finished = False

    def __str__(self):
        state = "FINISHED" if self.__is_finished else "NOT FINISHED"
        return f"{self.__id}: {self.__description} ({self.__workload} hours), programmer {self.__programmer} {state}"

    @property
    def id(self):
        return self.__id

    @property
    def description(self):
        return self.__description

    @property
    def workload(self):
        return self.__workload

    @property
    def programmer(self):
        return self.__programmer

    def is_finished(self):
        return self.__is_finished

    def mark_finished(self):
        self.__is_finished = True
        
class OrderBook:
    def __init__(self):
        self.__tasks = {}

    def add_order(self, description: str, programmer: str, workload: int):
        task = Task(description, programmer, workload)
        self.__tasks[task.id] = task

    def all_orders(self) -> list[Task]:
        return [task for _, task in self.__tasks.items()]

    def programmers(self) -> list[str]:
        return list({task.programmer for _, task in self.__tasks.items()})

    def mark_finished(self, id: int):
        if id not in self.__tasks:
            raise ValueError(f"No task exists for id {id}")
        self.__tasks[id].mark_finished()

    def finished_orders(self) -> list[Task]:
        return [task for _, task in self.__tasks.items() if task.is_finished()]

    def unfinished_orders(self) -> list[Task]:
        return [task for _, task in self.__tasks.items() if not task.is_finished()]

    def status_of_programmer(self, programmer: str):
        finished_tasks = 0
        finished_tasks_workload = 0
        unfinished_tasks = 0
        unfinished_tasks_workload = 0
        for _, task in self.__tasks.items():
            if task.programmer != programmer:
                continue
            if task.is_finished():
                finished_tasks += 1
                finished_tasks_workload += task.workload
            else:
                unfinished_tasks += 1
                unfinished_tasks_workload += task.workload
        if finished_tasks == 0 and unfinished_tasks == 0:
            raise ValueError("No programmer with given name")
        return (finished_tasks, unfinished_tasks, finished_tasks_workload, unfinished_tasks_workload)

class OrderBookApplication:
    def __init__(self):
        self.__order_book = OrderBook()
    
    def print_commands(self):
        print("commands:")
        print("0 exit")
        print("1 add order")
        print("2 list finished tasks")
        print("3 list unfinished tasks")
        print("4 mark task as finished")
        print("5 programmers")
        print("6 status of programmer")

    def execute(self):
        self.print_commands()
        while True:
            try:
                print("")
                command = int(input("command: "))
                if command == 0:
                    break
                elif command == 1:
                    description = input("description: ")
                    programmer_workload = input("programmer and workload estimate: ").split(" ")
                    if len(programmer_workload) != 2:
                        raise ValueError("erroneous input")
                    self.__order_book.add_order(description, programmer_workload[0], int(programmer_workload[1]))
                    print("added!")
                elif command == 2:
                    finished_tasks = self.__order_book.finished_orders()
                    if len(finished_tasks) == 0:
                        print("no finished tasks")
                    else:
                        for task in finished_tasks: print(task)
                elif command == 3:
                    unfinished_tasks = self.__order_book.unfinished_orders()
                    if len(unfinished_tasks) == 0:
                        print("no unfinished tasks")
                    else:
                        for task in unfinished_tasks: print(task)
                elif command == 4:
                    task_id = int(input("id: "))
                    self.__order_book.mark_finished(task_id)
                    print("marked as finished")
                elif command == 5:
                    for programmer in self.__order_book.programmers(): 
                        print(programmer)
                elif command == 6:
                    programmer = input("programmer: ")
                    (finished_tasks, unfinished_tasks, finished_tasks_workload, unfinished_tasks_workload) = self.__order_book.status_of_programmer(programmer)
                    print(f"tasks: finished {finished_tasks} not finished {unfinished_tasks}, hours: done {finished_tasks_workload} scheduled {unfinished_tasks_workload}")
            except ValueError:
                print("erroneous input")

application = OrderBookApplication()
application.execute()