Virtual threads
  Lightweight threads managed by the JDK rather than the operating system
  Many virtual threads share the same operating-system thread
  Are ideal for I/O-bound applications with many blocking operations
  Virtual threads are tied to a carrier thread only during execution and are terminated after their task is completed
  Virtual threads are backward compatible with platform thread APIs
  Ways to create virtual threads
    VirtualThreadFactory
      ThreadFactory virtualThreadFactory = Thread.ofVirtual().factory();
      Thread virtualThread = virtualThreadFactory.newThread(runnable);
    ThreadBuilder 
      ThreadFactory virtualThreadFactory = Thread.builder().virtual().factory();
      Thread virtualThread = virtualThreadFactory.newThread(runnable);
    Virtual Threads ExecutorService
      ExecutorService executorService = Executors.newVirtualThreadPerTaskExecutor();
      executorService.submit(runnable);
  Potential drawbacks
    Compatibility issues with thread-local state in native code

Scoped values
  Allows to store and share immutable data within and across threads
  Child threads can inherit scoped values
  ScopedValue class
    Main methods
      newInstance()
        Creates a scoped value that is initially unbound for all threads
      where()
        Creates a new Carrier with a single mapping of a ScopedValue key to a value
        Associates a value with a context for execution
      get()
        Returns the value of the scoped value if bound in the current thread
      orElse()
        Returns the value of this scoped value if bound in the current thread, otherwise returns other
      orElseThrow()
        Returns the value of this scoped value if bound in the current thread, otherwise throws an exception
      isBound()
        Returns true if this scoped value is bound in the current thread
  Carrier final subclass
    A mapping of scoped values, as keys, to values.
    Is used to accumulate mappings so that an operation (a Runnable or Callable) 
      can be executed with all scoped values in the mapping bound to value
    During the lifetime of the run or call method, any method, whether called directly or indirectly from the expression, 
      has the ability to read the scoped value. However, when the run method finishes, the binding is destroyed
    Main methods
      run()
        Runs an operation with each scoped value in this mapping bound to its value in the current thread
      get()
        Return a new set consisting of a single binding
      call()
        Calls a value-returning operation with each scoped value in this mapping bound to its value in the current thread
      where()
        Returns a new Carrier with the mappings from this carrier plus a new mapping from key to value
    Main static methods
      of()
  Example 
    public static ScopedValue<Integer> globalId = ScopedValue.newInstance();
    public static void main(String[] args) {
        ScopedValue.where(globalId, new Random().nextInt(1000))
                .run(() -> System.out.println(globalId.get()));
    }
      
Record
  Record class is simple data carrier
  Is immutable
  Is final by default, so it can't be extended
  Has public access methods and private final fields
  Can implement the sealed interface
  Can't have the non-static instance fields
  Can have the nested classes
  Can have a Constructor with or without parameters
    When Constructor has parameters then the developer must implicitly declare the assignment of all record
  A new instance of a record can be created by using keyword new
  Example
    public record Person (String name, String address) {}
    public static void createPersonRecord() {
      Person person = new Person("John", "Dubai");
      person.getName(); // Getters are created automatically
    }

Sealed classes
  Allows classes and interfaces to define their permitted subtypes
  If Parent and child class located in same file, we can omit keyword 'permits' in Parent class declaration
  Children of sealed class can have its own children classes
  Children of sealed class can impement interfaces
  Parent sealed class and its children can locate in different packages in named module
  Constraints
    All permitted subclasses must belong to the same module as the sealed class
    Every permitted subclass must explicitly extend the sealed class
    Every permitted subclass must define a modifier: final, sealed, or non-sealed
  Example
    public sealed interface Service permits Car, Truck { }
  A permitted subclass must define a modifier. It may be declared final to prevent any further extensions
    public final class Truck extends Vehicle implements Service {}
  A permitted subclass may also be declared sealed. However, if we declare it non-sealed, then it’s open for extension
    public non-sealed class Car extends Vehicle implements Service {}

New switch statements
  Must cover all possible input values, or contain a default case
  With Selaed Class selector
    Must cover all the permitted subclasses of the Sealed class, or contain a default case
    Example
      public void checkSealed(SealedParent main) {
        switch (main) {
            case A o -> System.out.println("A");
            case B t -> System.out.println("B");
            case C th -> System.out.println("C");
        }
      }
  With Object selector
    Must always contain a default case
    Example
      public void checkObject(Object n) {
        switch (n) {
            case Integer i -> System.out.println("integer");
            case Long i -> System.out.println("long");
            case String s -> System.out.println("string");
            case Double d -> System.out.println("double");
            default -> System.out.println(n.getClass().getName());
        }
      }
  With Enum selector
    Must contain all possible variants of the argument Enum, or contain a default case
    Example 
      public void checkEnum(Color c) {
        switch (c) {
            case WHITE -> System.out.println("WHITE");
            case BLACK -> System.out.println("BLACK");
            case GREEN -> System.out.println("GREEN");
        }
      }

Text blocks
  Are used to declared multiline strings
  Start with a “”” (three double-quote marks) followed by optional whitespaces and a newline
    String example = """
      Example text""";