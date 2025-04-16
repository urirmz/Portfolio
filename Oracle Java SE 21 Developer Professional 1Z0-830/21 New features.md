Virtual threads
  Lightweight threads managed by the JDK rather than the operating system
  Are ideal for I/O-bound applications with many blocking operations
  Leverage a JVM feature called fibers or, more specifically, a carrier thread based scheduler
  Many virtual threads share the same operating-system thread,
    called carrier thread
  Are tied to a carrier thread only during execution and are terminated after their task is completed
  Virtual threads delink carrier threads during blocking operations, freeing the carrier thread to execute other tasks
     They unmount during blocking operations like Thread.sleep()
     However, other tasks like holding a synchronized lock, prevents them from unmounting
  Are backward compatible with platform thread APIs
  Are mutable during their lifecycle, just like platform threads
  Are unbounded by default and their number is limited only by available memory, unlike traditional thread pools
  Native code that relies on thread-local storage may not work properly with virtual threads
    because they frequently switch carrier threads
  Ways to create virtual threads
    Thread class factory method
      Thread virtualThread = Thread.newVirtualThread();
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
  Prevent context leakage by explicitly associating values with specific scopes, unlike traditional thread-local storage
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
  Record classes are final by default, so they can't be extended
  Can implement the sealed interface
  Has private final fields and public access methods named after their fields, for example "name()"
  Their default implementation of equals() and hashCode() guarantees that 
    two record objects are equal if they are of the same type and contain equal field values.
    However, equals and hashCode methods can be overriden with custom logic
  Can be created inside a method
  Can have static fields, but not instance fields
  Can have nested classes
  Can have methods or mutable fields (like lists) if desired
  Can have a Constructor with or without parameters, but every created Constructor must explicitly declare the assignment of all record fields via
    the main constructor
      Example
        public  record RecordClass(String title) {
          public RecordClass() { 
            this("A title");
            System.out.println(title); 
          }
        }
  A new instance of a record can be created by using keyword new
    Example
      public record Person (String name, String address) {}
      public static void createPersonRecord() {
        Person person = new Person("John", "Dubai");
        person.name(); // Getters are created automatically based on the name of the fields
      }
  Can have initialization blocks declared with the name of the record class
    Example
      public  record RecordClass(String title) {
        public RecordClass {
            System.out.println(title);
        }
      }

Sealed classes
  Allows classes and interfaces to define their permitted subtypes
  If Parent and child class located in same file, we can omit keyword 'permits' in Parent class declaration
  Children of sealed class can have its own children classes
  Children of sealed class can impement interfaces
  Parent sealed class and its children can locate in different packages only in named module
  Constraints
    Children must be in the same module as the parent sealed class (if the sealed class is in a named module) 
      or in the same package (if the sealed class is in the unnamed module)
    Sealed classes can be located in different modules than their permitted subclasses, only if
      Parent module exports the package containing the sealed class
      Child module requires the parent module
      Subclasses are explicitly listed in the sealed class’s permits clause by fully qualified name
        public sealed class Shape permits com.othermodule.Circle, com.othermodule.Square { ... }
      Subclasses must be in the same runtime image
    Every permitted subclass must explicitly extend the sealed class
    Every permitted subclass must define a modifier: final, sealed, or non-sealed
      except for those which are inherently final like Enum or Record
  Example
    Sealed classes and interfaces must always define they permitted classes
      public sealed interface Service permits Car, Truck { }
    A permitted subclass must define a modifier. It may be declared final to prevent any further extensions
      public final class Truck extends Vehicle implements Service {}
    A permitted subclass may also be declared sealed. However, if we declare it non-sealed, then it’s open for extension
      public non-sealed class Car extends Vehicle implements Service {}
    

New switch statements
  Must cover all possible input values, or contain a default case
  "yield" keyword
    Allows to exit a switch expression by returning a value that becomes the value of the switch expression
  Allowed data types
    int, byte, short, char, 
    Integer, Byte, Short, Char,  
    String, Enum, Sealed Class, Object
  Unallowed data types
    long, boolean, double, float, Long, Boolean, Double, Float, 
  Switch statement selectors
    Selaed Class selector
      Must cover all the permitted subclasses of the Sealed class, or contain a default case
      Example
        public void checkSealed(SealedParent main) {
          switch (main) {
              case A o -> System.out.println("A");
              case B t -> System.out.println("B");
              case C th -> System.out.println("C");
          }
        }
    Object selector
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
      Example with "when" keyword
        String result = switch(obj) {
          case Integer i when i > 100 -> "Large";
          case Integer i when i > 50 -> "Medium";
          case Integer i -> "Small";
          case String s when s.length() > 5 -> "Long";
          case String s -> "Short";
          default -> "Unknown";
        };
    Enum selector
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
  Quotation marks inside text blocks don't need to be escaped unless they're part of a triple quote sequence
  Start with a “”” (three double-quote marks) followed by optional whitespaces and a newline
    String example = """
      Example text""";

Local Variable Type Inference ("var" reserved type name)
  Detects automatically the datatype of a variable based on the surrounding context
  A variable can be named var
  Constraints
    Cannot be used in method arguments, class field declarations, as a Generic type, or to declare lambda expressions
    Requires explicit non-null initialization
    Is not allowed in a compound declaration  
      var sb1 = new StringBuffer(), sb2 = new StringBuffer(); // Incorrect