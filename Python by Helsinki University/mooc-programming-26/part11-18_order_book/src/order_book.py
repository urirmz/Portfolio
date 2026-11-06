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
