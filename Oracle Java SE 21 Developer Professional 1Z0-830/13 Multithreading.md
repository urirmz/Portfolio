Multithreading is the process of executing a program in multiple threads

Common use cases
  Updating a shared resource
  Blocking operations
  Producer and consumer
  Readers and writers

Main thread 
  The thread of execution when program just started
  Child threads can be run later in parallel with specific instructions

Thread lifecycle
  New
  Running / Waiting (waiting) / Blocked (blocked) / Sleeping (sleeping)
  Dead (the state when the run() method has completed its work)

Runnable interface
  Is a functional interface with the declared method run()

How to start a Thread
  1. Create a class that implements the Runnable interface and pass it to a Thread object
  2. Create a lambda function implementing Runnable interface and pass it to a Thread object
  3. Create an anonymous class implementing Runnable interface and pass it to a Thread object
  4. Create a class extending Thread class and override the run() method
  5. Create an anonymous class extending Thread class and override the run() method
  6. Instantiate a new Thread and pass a method reference

Thread scheduler
  Part of the Java Virtual Machine 
  Decides which thread will be executed next and which threads should wait
  Scheduling algorithm
    1. Scheduler select the threads that has highest priority
    2. In case other threads with high priority will request access to processor, then new thread will get access to the CPU during the first opportunity
    3. Once it deals with threads that have same priority, scheduler will use first come first serve
  Although priority can help to order thread execution, it can never be predicted exactly

Thread class
  Implements Runnable interface
  Can be used to instantiate a new Thread
  Main properties
    name, priority, daemon, interrupted, ThreadGroup
  Main methods
    run()
      Contains the method to run in the new Thread
      Can be called directly from the Thread object, 
        but doing so will run it in the current Thread, not a new one
    start()
      Starts the new Thread and runs the run() method inside it
    setPriority()
      Sets the priority of this Thread
      Must be an int from 1 to 10, where higher means more priority
      New Threads take the same priority as its parents by default
    setDaemon()
      Sets the daemon flag of this Thread to true
      A daemon Thread is thread that does not prevent the JVM from exiting when the program finishes but the thread is still running
    getThreadGroup()
      Returns the current ThreadGroup
    join()
      Joins the current thread to its parent thread, finishing this one
      Can be used with a delay
    interrupt()
      Sets the interrupted property to true    
    isInterrupted()
      Tests whether this thread has been interrupted
    yield()
      A hint to the scheduler that the current thread is willing to yield its current use of a processor
      The scheduler is free to ignore this hint   
    holdsLock() 
      Returns true if and only if the current thread is holding the monitor on a specific object
    suspend(), stop(), resume()
      Are deprecated and must not be used
  Main static methods
    currentThread()
      Returns a reference to the thread where the method is running
    sleep()
      Pauses the current Thread for the provided amount of milliseconds

ThreadGroup class
  Represents a set of threads
  Can also contain subgroups of ThreadGroup
  Can be used to manage multiple Threads simultaneously
  Main methods
    getName()
      Returns the name of this thread group
    interrupt()
      Interrupts all live threads in this thread group and its subgroups
    getMaxPriority()
      Returns the maximum priority of this thread group
    setMaxPriority()
      Sets the maximum priority of the group
    enumerate()
      Copies into the specified array every live thread in this thread group and its subgroups
    activeCount()
      Returns an estimate of the number of live platform threads in this thread group and its subgroups

Exceptions in Threads
  If an exception is not caught, the thread is dead, if a handler for uncaught exceptions is installed, it will receive a callback
  Thread.UncaughtExceptionHandler is an interface defined as a nested interface 
    for handlers to be called when a thread suddenly stops due to an uncaught exception. 
  When a thread is about to stop due to an uncaught exception, the JVM will check for an UncaughtExceptionHandler using Thread.getUncaughtExceptionHandler() and call the uncaughtException() method on the handler, passing the thread and the exception as arguments.

TimeUnit enum
  Contains time durations at a given unit of granularity and provides utility methods to convert across units, 
    and to perform timing and delay operations in these units
  Members
    NANOSECONDS, MICROSECONDS, MILLISECONDS, SECONDS, MINUTES, HOURS, DAYS
  Main methods
    sleep(), convert(), to{Unit}()

Race condition
  State of the system where substantive behavior of an application is dependent on the sequence or timing of other events
  Can be avoided by building proper thread synchronization in critical sections of execution
  Potential effects
    Memory leaks
      Memory needed is not released by a thread
    Inconsistent data
      Two or more threads manage to get access to the same resource, 
        one updates it and other overrides the update
      Dirty read: one thread reads a resource and another writes in it, so the first thread has read outdated data
    Deadlock
      Multiple threads block each other forever, waiting for locks held by one another
      Example
        Thread1 captures lock1, Thread2 captures lock2. 
        Thread one condition to release lock1 is capture lock2, and Thread2 condition to release lock2 is to capture lock1
      How to avoid
        Don't use multiple locks inside one thread
        Capture multiple locks in the same order, in different threads
        Use time constraints to acquire lock (in case thread didn't obtain a lock within the specific time thread keeps execution)
    Livelock
      Two or more processes continually repeat the same interaction in response to changes in the other processes without doing any useful work
      Example
        A messaging system where, when an exception occurs, the message consumer rolls back the transaction 
          and puts the message back to the head of the queue. 
          Then the same message is repeatedly read from the queue, only to cause another exception and be put back on the queue. 
          The consumer will never pick up any other message from the queue
      How to avoid
        Set a max number of retries
        Separate the failing condition

Synchronization
  Critical section
    Group of instructions that should be executed concurrently only by specific number of threads and performing specific operations
  Atomic operations
    Operation that is performed within a single processing cycle. In other words, atomic operation is an uninterruptable operation
    These operations include read and write operations, assign value to a variable, and operations from java.util.concurrent.atomic package
    Synchronization is necessary when there are multiple Threads performing non atomic operations 
  mutex
    Short for “mutual exclusion”
    Mechanism that enforces limits on access to resource when there are many threads of execution
    Usually mutexes are provided by the operating system kernel
  Monitor
    Is a mechanism to synchronize threads access to critical section
    Consists of a mutex, lock object, and condition variables
     Condition variable is a container of threads that are waiting for a certain condition
  "synchronized" keyword
    Doesn't allow more than one thread to access certain method simultaneously
    In a synchronized method, the monitor of the object used to invoke the method is captured, 
    In a static synchronized method, the monitor of the class is capture instead
  "synchronized" blocks
    Allows to have synchronized access only for an specific part of a method
    To create synchronized block, pass the reference to an object where you want to capture monitor
    Only one thread may enter the block, and once it leaves, it will release monitor of this class and 
      the next thread will enter this block and will capture monitor of
    Example
      public static void increment() {
        // Thread unsafe part
        synchronized (Main.class) {
            count++; // Thread safe part
        }
      }
  Object synchronization methods
    Are inherited from the Object class and can only be called inside a synchronized block or method, otherwise
      IllegalMonitorStateException will be thrown
    wait() 
      Causes the current thread to wait until it is awakened, typically by being notified or interrupted
      When an object is in wait state, its monitor is released
      Can accept a maximum wait time, after which execution will continue unconditionally
    notify()
      Wakes up a single thread that is waiting on this object's monitor
    notifyAll()
      Wakes up all threads that are waiting on this object's monitor

For non-dependent operations like initialization of class fields, 
  compiler may apply some optimizations, like reordering

Memory management
  Hardware memory model
    CPUs
      Modern computer often has two and even more central processing units.
      Each CPU can run one thread at any given time.
      Internal registers
        Each CPU contains a set of registers, considered the memory of the CPU,
          and perform operations on these registers much faster that it can perform on variables in the main memory
      Cache layer
        CPU also have CPU cache memory layer. CPU is able to access cache memory much faster than the RAM memory, 
          but not as fast as it can access internal registers.
    RAM 
      Stores information about all the running processes
      Is much bigger than cache memory of the CPUs
      All processors may access the RAM
    Processing routes
      When CPU reads data from RAM
        CPU will read some parts of the data from RAM into the CPU cache, or even into internal registers
          Only after that, CPU operate on the data
      When CPU writes registers to Ram
        CPU will flush the result of computation from its internal register to the cache memory, 
          and at some point flush the value back to the Ram.
      When cache memory memory is needed for something else, 
        is flushed back to the Ram
  Java memory model
    Both heap and stack are located in RAM reserved for Java process
    Stacks and heap may sometimes be present in CPU caches and internal CPU registers
    Heap
      There's a common heap for all the threads
      Stores all the objects used in the program
      Objects that are not reachable by any reference are cleared by the Garbage Collector
    Stack
      Every thread has its own stack
      Stores local variables used by methods, like primitives and references to objects in the heap
      Its cleared once the variables are out of scope      

"volatile" keyword
  Is used to indicate that a variable's value will be modified by different threads
  It ensures that changes to a variable are always visible to other threads, preventing thread caching issues
  Operations won't be atomic even if you would work with volatile variable

java.util.concurrent.atomic package
  Provides classes that support lock-free thread-safe programming on single variables,
    like AtomicBoolean, AtomicInteger, AtomicLong, AtomicReference (for Objects), etc
  Each of these types may be updated atomically abd provides its own API to perform necessary operations

ThreadLocal class
  This class provides thread-local variables, 
    which means each thread that accesses one (via its get or set method) has its own independently initialized copy of the variable
  ThreadLocal instances are typically private static fields in classes that wish to associate state with a thread
  ThreadLocal instances are not accesible from another thread
  Can be created in the way
    public static ThreadLocal<Integer> transactionId = new ThreadLocal<>();
InheritableThreadLocal class
  Extends ThreadLocal to provide inheritance of values from parent thread to child thread
  Instead of each thread having its own value inside a thread local, 
    the inheritable thread local grants access to values to a thread and all child threads created by the thread
    
Thread pool
  Software design pattern in multi-threading programming
  Maintains multiple threads waiting for tasks to be allocated for concurrent execution by the supervising program
  Increases performance and avoids latency in execution due to frequent creation and destruction of threads for short life tasks

Recommended number of Threads
  With one executor
    Number of threads = Number of available cores * (1 + Waiting time / Service time)
  With multiple executors
    Number of threads = Number of available cores * Target CPU utilization * (1 + Waiting time / Service time)

Callable interface
  Functional interface that takes a generic type and declares the call() method
  call() returns the generic type that this Callable is representing and its signature include a throw for an exepction

Future interface
  Represents the result of an asynchronous computation
  Main methods
    cancel()
      Attempts to cancel execution of this task
      Has no effect if the task is already completed or cancelled, or could not be cancelled for some other reason
    isCancelled()
      Returns true if this task was cancelled before it completed normally
    isDone()
      Returns true if this task completed. 
      Completion may be due to normal termination, an exception, or cancellation
    get()
      Waits if necessary for the computation to complete, and then retrieves its result
      Blocks the calling thread until it is completed or interrupted
      Can be used with a timeout
    resultNow()
      Returns the computed result, without waiting
      This method is for cases where the caller knows that the task has already completed successfully
    exceptionNow()
      Returns the exception thrown by the task, without waiting
      This method is for cases where the caller knows that the task has already completed with an exception
    state()
      Returns the computation state

Executors
  Executors are capable of running asynchronous tasks and typically manage a pool of threads, so there's no need to create new threads manually
  All threads of the internal pool will be reused under the hood for relevant tasks, 
    so that we can run as many concurrent tasks as we want throughout the life cycle of our application with a single executor
  Executor interface
    Contains the method execute(), which takes a Runnable an executes it at some time in the future,
      in the given thread, or in a thread of the pool, depending on the implementation
  ExecutorService interface
    It is the most popular implementation of Executor
    Provides methods to manage termination of tasks, and methods that can produce a Future for tracking progress of them
    Implements the AutoCloseable interface
    Main methods
      submit()
        Submits a Runnable or Callable task for execution
        Returns a Future representing that task. The Future's get method will return null upon successful completion
      shutdown()
        Initiates an orderly shutdown in which previously submitted tasks are executed, but no new tasks will be accepted
      shutdownNow()
        Attempts to stop all actively executing tasks, halts the processing of waiting tasks
        Returns a list of the tasks that were awaiting execution
      isTerminated()
        Returns true if all tasks have completed following shut down
      awaitTermination()
        Blocks the calling thread until all tasks have completed execution after a shutdown request, 
          or the timeout occurs, or the current thread is interrupted, whichever happens first
      invokeAll()
        Executes the given tasks, returning a list of Futures holding their status and results when all complete
      invokeAny()
        Executes the given tasks, returning the result of one that has completed successfully
  ScheduledExecutorService interface
    Extends form ExecutorService with methods for scheduling Runnables and Callables
    New methods
      schedule()
        Submits a one-shot task that becomes enabled after the given delay
      scheduleAtFixedRate()
        Submits a periodic action that becomes enabled first after the given initial delay, and subsequently with the given period; 
          that is, executions will commence after initialDelay, then initialDelay + period, then initialDelay + 2 * period, and so on
      scheduleWithFixedDelay()
        Submits a periodic action that becomes enabled first after the given initial delay, 
          and subsequently with the given delay between the termination of one execution and the commencement of the next
  Executors class
    Contains Factory and utility methods for Executor, ExecutorService, ScheduledExecutorService, 
      ThreadFactory, and Callable classes defined in this package
    Most methods return an object implementing theses interfaces, set up with commonly useful configuration settings
    Methods that return ExecutorService
      newFixedThreadPool()
        Creates a thread pool that reuses a fixed number of threads
        If additional tasks are submitted when all threads are active, they will wait in the queue until a thread is available
      newWorkStealingPool()
        Creates a thread pool that maintains enough threads to support the given parallelism level, and may use multiple queues to reduce contention
      newSingleThreadExecutor()
        Creates an Executor that uses a single worker thread operating off an unbounded queue
        Tasks are guaranteed to execute sequentially, and no more than one task will be active at any given time
      newCachedThreadPool()
        Creates a thread pool that creates new threads as needed, but will reuse previously constructed threads when they are available
        These pools will typically improve the performance of programs that execute many short-lived asynchronous tasks
      newThreadPerTaskExecutor()
        Creates an Executor that starts a new Thread for each task
        The number of threads created by the Executor is unbounded
      unconfigurableExecutorService()
        Returns an object that delegates all defined ExecutorService methods to the given executor, 
          but not any other methods that might otherwise be accessible using casts. 
        This provides a way to safely "freeze" configuration and disallow tuning of a given concrete implementation
    Return ScheduledExecutorService
      newSingleThreadScheduledExecutor()
        Creates a single-threaded executor that can schedule commands to run after a given delay, or to execute periodically
      newScheduledThreadPool()
        Creates a thread pool that can schedule commands to run after a given delay, or to execute periodically
      unconfigurableScheduledExecutorService()
        Returns an object that delegates all defined ScheduledExecutorService methods to the given executor,
          but not any other methods that might otherwise be accessible using casts
        This provides a way to safely "freeze" configuration and disallow tuning of a given concrete implementation

Fork/Join framework
  Helps to speed up parallel processing by using all available cores
  It is designed for work that can be broken into smaller pieces recursively
  The goal is to use all the available processing power to enhance the performance of your application
  The framework forks recursively, breaking the task into smaller independent subtasks until they are
    simple enough to be executed asynchronously and after that, all subtasks are recursively joined into a single result
  ForkJoinPool class
    Extends AbstractExecutorService class
    Differs from other kinds of ExecutorService mainly by virtue of employing work-stealing: 
      all threads in the pool attempt to find and execute tasks submitted to the pool and/ or created by other active tasks 
      (eventually blocking waiting for work if none exist)
    Can be created with a constructor or by calling the static method commonPool(), which returns a staticly created ForkJoinPool
      The constructor accepts parallelism level, ForkJoinWorkerThreadFactory, UncaughtExceptionHandler and asyncMode
    ForkJoinPool accepts classes that inherit from ForkJoinTask in its invoke() method
      Calling ForkJoinPool.invoke() method in a ForkJoinTask a runs its compute() method, so compute() must be overriden with the desired task
      RecursiveAction 
        Executes actions, but doesn't return anything
        fork() method is used to asynchronously execute this task in the pool the current task is running in
          it is used inside the compute() method to fork into two subtasks
      RecursiveTask
        Returns a result
        fork() method is used to asynchronously execute this task in the pool the current task is running in
          it is used inside the compute() method to fork into two subtasks
        join() method returns the result of this task, and returns the control to the parent thread
      Pseudocode template for compute() method
        if (portion of work is small enough) {
          do the work directly
        } else {
          split work into two pieces
          invoke two pieces and wait for results
        }
 