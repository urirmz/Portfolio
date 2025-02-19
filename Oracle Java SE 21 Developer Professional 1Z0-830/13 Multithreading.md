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
  Running or Non running (waiting, blocked)
  Terminated

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
    suspend(), stop(), resume()
      Are deprecated and must not be used
  Main static methods
    currentThread()
      Returns a reference to the thread where the method is running
    sleep()
      Pauses the current Thread for the provided amount of milliseconds

ThreadGroup
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
      Multiple threads block each other while waiting for locks held by one another
    Livelock
      Two or more processes continually repeat the same interaction in response to changes in the other processes without doing any useful work

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
  Synchronized keyword
    Doesn't allow more than one thread to access certain method simultaneously
    In a synchronized method, the monitor of the object used to invoke the method is captured, 
    In a static synchronized method, the monitor of the class is capture instead
  Synchronized blocks
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
    Are inherited from the Object class
    wait() 
      Causes the current thread to wait until it is awakened, typically by being notified or interrupted
      When an object is in wait state, its monitor is released
      Can only be invoked in a synchronized section
    notify()
      Wakes up a single thread that is waiting on this object's monitor
    notifyAll()
      Wakes up all threads that are waiting on this object's monitor
