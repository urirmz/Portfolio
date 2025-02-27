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

CompletionStage
  Defines the contracts for behavior of an asynchronous computation step that we combine with other steps
CompletableFuture
  Implements CompletionStage and Future
  Main methods
    get()
      Waits if necessary for this future to complete, and then returns its result
        while waiting, the caller Thread is blocked
      If any callback method is applied to the CompletableFuture, 
        it returns the result of the last applied callback method
    getNow()
      Returns the result value (or throws any encountered exception) if completed, 
        else returns the given valueIfAbsent
    Callback methods 
      Are called after the previous result is available
      By default, are run in the same Thread and Executor, 
        async ones are run in an independent Thread and Executor
      thenRun(), thenRunAsync()
        Runs a Runnable
      thenCombine(), thenCombineAsync()
        Takes another CompletableFuture and after both results are available, 
          performs a BiFunction with both results as inputs, and returns a value
      thenAccept(), thenAcceptAsync()
        Takes another CompletableFuture and after both results are available, 
          performs a Consumer operation with both results as inputs, and returns void
      handle(), handleAsync()
        Takes a BiFunction with result and exception as arguments, 
          if any exception occur, it will be passed to the bifunction as the second argument
      exceptionally()
        Takes a Function with an exception as argument,
          if any exception occur, it will be passed to the function as argument
          Allows to return a default value
  Main static methods
    runAsync()
      Takes a Runnable and returns a new CompletableFuture that is asynchronously completed 
      Accepts an Executor to run the task in. In case no Executor is specified,
        the task will run in the ForkJoinPool.commonPool()
    supplyAsync()
      Takes a Supplier and returns a new CompletableFuture that is asynchronously completed 
      Accepts an Executor to run the task in. In case no Executor is specified,
        the task will run in the ForkJoinPool.commonPool()
    allOf()
      Returns a new CompletableFuture that is completed when all of the given CompletableFutures complete
    anyOf()
      Returns a new CompletableFuture that is completed when any of the given CompletableFutures complete, 
        with the same result

java.util.concurrent.locks package (Lock API)
  Lock interface
    Provide more extensive locking operations than can be obtained using synchronized methods and statements
    Allow more flexible structuring, may have quite different properties, and may support multiple associated Condition objects
    A Lock is a tool for controlling access to a shared resource by multiple threads
    Declares the methods
      lock()
        Acquires the lock. If the lock is not available then the current thread becomes disabled for thread scheduling
      unlock()
        Releases the lock
      tryLock()
        Acquires the lock only if it is free at the time of invocation, returns boolean
        Can be used with a wait for specific time
      lockInterruptibly()
        Acquires the lock unless the current thread is interrupted. Acquires the lock if it is available and returns immediately
      newCondition()
        Returns a new Condition instance that is bound to this Lock instance
    Main implementations
      ReentrantLock
        A lock is called re-entrant if the thread that holds the lock can lock it again
        Main methods  
          getHoldCount()
            Returns the number of holds on this lock by the current thread
          isHeldByCurrentThread()
            Returns true if current thread holds this lock and false otherwises
          isLocked()
            Queries if this lock is held by any thread
          isFair()
            Return boolean value of this lock fairness
          hasQueuedThreads() 
            Queries whether any threads are waiting to acquire this lock
          hasQueuedThread()
            Queries whether the given thread is waiting to acquire this lock
          getQueuedThreads()
            Returns a collection containing threads that may be waiting to acquire this lock
          hasWaiters()
            Queries whether any threads are waiting on the given condition associated with this lock
  ReadWriteLock interface
    Maintains a pair of associated locks, one for read-only operations and one for writing
    The read lock may be held simultaneously by multiple reader threads, so long as there are no writers
    The write lock is exclusive
      Contains methods  
        readLock()
          Returns the lock used for reading
        writeLock()
          Returns the lock used for writing
    Main implementations
      ReentrantReadWriteLock
        An implementation of ReadWriteLock supporting similar semantics to ReentrantLock
        Main methods
          isFair()
            Return boolean value of this lock fairness
          getReadLockCount()
            Queries the number of read locks held for this lock
          isWriteLocked()
            Queries if the write lock is held by any thread
          isWriteLockedByCurrentThread()
            Queries if the write lock is held by the current thread
          getWriteHoldCount()
            Queries the number of reentrant write holds on this lock by the current thread
          getReadHoldCount()
            Queries the number of reentrant read holds on this lock by the current thread
          getQueuedWriterThreads()
            Returns a collection containing threads that may be waiting to acquire the write lock
          getQueuedReaderThreads()
            Returns a collection containing threads that may be waiting to acquire the read lock
          hasQueuedThread()
            Queries whether any threads are waiting to acquire the read or write lock
          hasQueuedThread()
            Queries whether the given thread is waiting to acquire either the read or write lock
          getQueuedThreads()
            Returns a collection containing threads that may be waiting to acquire either the read or write lock
          hasWaiters()
            Queries whether any threads are waiting on the given condition associated with the write lock
          getWaitingThreads()
            Returns a collection containing those threads that may be waiting on the given condition associated with the write lock
  Condition interface
    Provide means for one thread to suspend execution (to "wait") 
      until notified by another thread that some state condition may now be true
    Where a Lock replaces the use of synchronized methods and statements, a Condition replaces the use of the Object monitor methods
    When a Thread tries to acquire a Lock, it first checks all the Condition attached to it
    Main methods      
      await()
        Causes the current thread to wait until it is signalled or interrupted
        The lock associated with this Condition is atomically released
      signal()
        Wakes up one waiting thread
      signalAll()
        Wakes up all waiting threads
  StampedLock
    A capability-based lock with three modes for controlling read/ write access
      Writing
      Reading
      Optimistic reading
    Lock acquisition methods return a stamp that represents and controls access with respect to a lock state
    Lock release and conversion methods require stamps as arguments, and fail if they do not match the state of the lock
    Main methods
      writeLock()
        Exclusively acquires the lock, blocking if necessary until available.
        Returns a write stamp, in the form of a long value, that can be used to unlock or convert mode
      tryWriteLock()
        Exclusively acquires the lock if it is immediately available
        Returns a write stamp that can be used to unlock or convert mode, or zero if the lock is not available
        Can be used with a timeout
      readLock()
        Non-exclusively acquires the lock, blocking if necessary until available
        Returns a read stamp that can be used to unlock or convert mode
      tryReadLock()
        Non-exclusively acquires the lock if it is immediately available
        Returns a read stamp that can be used to unlock or convert mode, or zero if the lock is not available
      tryOptimisticRead()
        Returns a stamp that can later be validated, or zero if exclusively locked
      validate()
        Returns true if the lock has not been exclusively acquired since issuance of the given stamp
        Always returns false if the stamp is zero
      unlockWrite()
        If the lock state matches the given stamp, releases the exclusive lock
      unlockRead()
        If the lock state matches the given stamp, releases the non-exclusive lock
      unlock()
        If the lock state matches the given stamp, releases the corresponding mode of the lock
      tryConvertToWriteLock()
        If the lock state matches the given stamp, atomically performs one of the following actions
          If the stamp represents holding a write lock, returns it
          If a read lock, if the write lock is available, releases the read lock and returns a write stamp
          If an optimistic read, returns a write stamp only if immediately available
          Returns zero in all other cases
      tryConvertToReadLock()
        If the lock state matches the given stamp, atomically performs one of the following actions
          If the stamp represents holding a write lock, releases it and obtains a read lock
          If a read lock, returns it
          If an optimistic read, acquires a read lock and returns a read stamp only if immediately available
          Returns zero in all other cases
      tryConvertToOptimisticRead()
        If the lock state matches the given stamp then, atomically 
          If the stamp represents holding a lock, releases it and returns an observation stamp
          If an optimistic read, returns it if validated
          Returns zero in all other cases, and so may be useful as a form of "tryUnlock"
      asReadWriteLock()
        Returns a ReadWriteLock view of this StampedLock 
        In which the ReadWriteLock. readLock() method is mapped to asReadLock(), 
          and ReadWriteLock. writeLock() to asWriteLock()

Synchronizers
  CyclicBarrier class
    Implements barrier pattern
    Describes a case in which all threads must stop at one point (barrier), 
      and can precede when all the threads are at this point
    Its constructor takes a parties argument that indicates the number of threads waiting upon,
      also takes an optional Runnable that is run when the barrier is tripped, performed by the last thread entering the barrier
    Main methods
      getParties()
        Returns the number of parties required to trip this barrier.
      await()
        Waits until all parties have invoked await on this barrier.
        If the current thread is not the last to arrive then it is disabled for thread scheduling purposes 
          and lies dormant until one of the following things happens
        Returns the arrival index of the current thread, where index getParties() - 1 
          indicates the first to arrive and zero indicates the last to arrive
      getNumberWaiting()
        Returns the number of parties currently waiting at the barrier
      reset()
        Resets the barrier to its initial state
        If any parties are currently waiting at the barrier, they will return with a BrokenBarrierException
      breakBarrier()
        Sets current barrier generation as broken and wakes up everyone. Called only while holding lock
  CountdownLatch class
    A CountDownLatch is initialized with a given count
    The await methods block until the current count reaches zero due to invocations of the countDown method
    Count cannot be reset
    Unlike CyclicBarrier, it works with tasks, no matter which thread performs them
    Main methods
      await()
        Causes the current thread to wait until the latch has counted down to zero, unless the thread is interrupted
        If the current count is zero then this method returns immediately
      countDown() 
        Decrements the count of the latch, releasing all waiting threads if the count reaches zero
        If the current count is greater than zero then it is decremented
        If the new count is zero then all waiting threads are re-enabled for thread scheduling purposes
        If the current count equals zero then nothing happens
      getCount()
        Returns the current count
  Semaphore class
    Maintains a set of permits. Each acquire blocks if necessary until a permit is available, and then takes it. 
      Each release adds a permit, potentially releasing a blocking acquirer
      Permits value may be negative, in which case releases must occur before any acquires will be granted.
    Are often used to restrict the number of threads than can access some (physical or logical) resource
    Main methods
      acquire()
        Acquires a permit from this semaphore, blocking until one is available, or the thread is interrupted.
          If one is available and returns immediately, reducing the number of available permits by one
        Accepts a permits argument, which is used to acquire a custom number of permits
      tryAcquire()
        Acquires a permit from this semaphore, only if one is available at the time of invocation
          If one is available and returns immediately, with the value true, reducing the number of available permits by one
          If no permit is available then this method will return immediately with the value false
        Allows a maximum timeout argument
      release()
        Releases a permit, returning it to the semaphore
      availablePermits()
        Returns the current number of permits available in this semaphore
      getQueuedThreads()
        Returns a collection containing threads that may be waiting to acquire
  Exchanger class
    A synchronization point at which threads can pair and swap elements within pairs. 
      Each thread presents some object on entry to the exchange method, matches with a partner thread, 
      and receives its partner's object on return
    It is a parametrized class, with the type of object that exchanges
    Contains just one method
      exchange()
        Waits for another thread to arrive at this exchange point (unless the current thread is interrupted), 
          and then transfers the given object to it, receiving its object in return
        Accepts an optional timeout argument, that indicates a maximum time to wait
  Phaser class
    Implements barrier pattern
    Unlike CyclicBarrier, it supports multiple phases. Each phase has a number
    Its constructor accepts an argument for a number of parties required to advance to the next phase, or a parent Phaser
    Main methods
      register()
        Adds a new unarrived party to this phaser
        If an ongoing invocation of onAdvance is in progress, this method may await its completion before returning
        If this phaser has a parent, and this phaser previously had no registered parties, 
          this child phaser is also registered with its parent
        If this phaser is terminated, the attempt to register has no effect, and a negative value is returned
        Returns the arrival phase number to which this registration applied
      arrive()
        Arrives at this phaser, without waiting for others to arrive
        Once the number of arrived parties is equal to the number of registered parties, 
          the execution of the program will continue
      awaitAdvance()
        Awaits the phase of this phaser to advance from the given phase value, 
          returning immediately if the current phase is not equal to the given phase value or this phaser is terminated
      arriveAndAwaitAdvance()
        Arrives at this phaser and awaits others
        It is equivalent to awaitAdvance(arrive())
      arriveAndDeregister()
        Arrives at this phaser and deregisters from it without waiting for others to arrive
        Deregistration reduces the number of parties required to advance in future phases
        If some thread will not participate in the next phase, this method must be called
      getPhase()
        Returns the current phase number
      getRegisteredParties()
        Returns the number of parties registered at this phaser
      getArrivedParties()
        Returns the number of registered parties that have arrived at the current phase of this phaser