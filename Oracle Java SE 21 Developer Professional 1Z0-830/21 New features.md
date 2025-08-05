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
  Are always daemon threads
  Cannot be unmounted when it is executing a synchronized block, 
    this behavior is called "pinning"
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
  ScopedValue<T> class
    Main methods
      ScopedValue<T> newInstance()
        Creates a scoped value that is initially unbound for all threads
      Carrier where(ScopedValue<T>, T)
        Creates a new Carrier with a single mapping of a ScopedValue key to a value
        Associates a value with a context for execution
      T get()
        Returns the value of the scoped value if bound in the current thread
      T orElse()
        Returns the value of this scoped value if bound in the current thread, otherwise returns other
      T orElseThrow(Supplier<? extends Throwable>)
        Returns the value of this scoped value if bound in the current thread, otherwise throws an exception
      bbolean isBound()
        Returns true if this scoped value is bound in the current thread
  Carrier final subclass
    A mapping of scoped values, as keys, to values.
    Is used to accumulate mappings so that an operation (a Runnable or Callable) 
      can be executed with all scoped values in the mapping bound to value
    During the lifetime of the run or call method, any method, whether called directly or indirectly from the expression, 
      has the ability to read the scoped value. However, when the run method finishes, the binding is destroyed
    Main methods
      void run(Runnable)
        Runs an operation with each scoped value in this mapping bound to its value in the current thread
      T get(ScopedValue<T>)
        Return a new set consisting of a single binding
      R call(Vallable<? extends R>)
        Calls a value-returning operation with each scoped value in this mapping bound to its value in the current thread
      Carrier where(ScopedValue<T>, T)
        Returns a new Carrier with the mappings from this carrier plus a new mapping from key to value
    Main static methods
      Carrier of(ScopedValue<T>, T)
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
  Records are serializable
  Has private final fields and public access methods named after their fields, for example "name()"
  Their default implementation of equals() and hashCode() guarantees that 
    two record objects are equal if they are of the same type and contain equal field values.
    However, equals and hashCode methods can be overridden with custom logic
  Can have static fields, but not instance fields
  Can have static initializers, but not instance initializers
  Can have nested classes
  Can have methods or mutable fields (like lists) if desired
  Records are allowed to define an accessor method explicitly, it must be public and not have a throws clause
  Cannot have abstract or native methods
  A record may have at most one varargs component
    Example: public record Journal(int id, String... values) {}
  Canonical constructor
    Canonical constructor must initialize all of the components fields of the record
      using the parameters passed to it
    It has no throws clause
    Every record must have exactly one canonical constructor,
      if not provided explicitly, the compiler will provide it
  Every declared constructor in a record must explicitly declare the assignment of all record fields via
    the canonical constructor constructor
      Example
        public  record RecordClass(String title) {
          public RecordClass() { 
            this("A title");
            System.out.println(title); 
          }
        }
  A new instance of a record can be created by using keyword new
    Example
      public record Person(String name, String address) {}
      public static void createPersonRecord() {
        Person person = new Person("John", "Dubai");
        person.name(); // Getters are created automatically based on the name of the fields
      }
  Compact constructor
    There is no formal parameter list in the definition, 
      the compiler just copies it from the canonical constructor
    We are not assigning the value of the variables to the record fields,
      actually we are not allowed to set or modify the component fields explicitly anywhere in the compact constructor
    Component fields are final and are set only once by the compiler at the end of the compact constructor
      it inserts the assignment statements of the form this.<fieldname> = fieldname;
    Example
      public record Person(String name, String address) {
        public Person {
          if (name == null || name.isEmpty()) throw new Runtime Exception("Invalid name");
          if (address == null || address.isEmpty()) address = "";
        }
      }
  Record serialization
  Serialization and deserialization of records cannot be customized with
    writeObject(), readObject(), readObjectNoData(), writeExternal or readExternal()
  During deserialization, individual record components are deserialized and then 
    the canonical constructor of the record is invoked.
    The serialVersionUID of a record class, which is OL by default, is not checked

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
  Start with a “”” (three double-quote marks) followed by optional whitespaces and a newline
    String example = """
      Example text""";
  Quotation marks inside text blocks don't need to be escaped unless they're part of a triple quote sequence
  White space characters are used to indent the text block are removed from each line,
    these white spaces are collectively called "incidental whitespace"
  Any space after the incidental whitespace and before the first non-whitespace character
    is considered essential whitespace and is kept
  All trailing whitespace is removed and each line is terminated with a new line character
  Escape characters can be used in a text block
  If you want to break a long string into multiple lines of code without inserting a new line,
    you can do so, by using a backslash at the end of the line
      String example = """
      Hello\
      world!""";

Local Variable Type Inference ("var" reserved type name)
  Detects automatically the datatype of a variable based on the surrounding context
  Can only be used inside a method or constructor body
  A variable can be named var
    Constraints
      Cannot be used in method arguments, class field declarations, as a Generic type, or to declare lambda expressions
      Requires explicit non-null initialization
      Java prohibits type inference if the type of the array is not specified explicitly in the array initializer
      Is not allowed in a compound declaration  
        var sb1 = new StringBuffer(), sb2 = new StringBuffer(); // Incorrect
      When initializing arrays, it needs an explicit target-type, 
        and variable name must not contain brackets as this would imply that the type of the elements of the array is var, which is not allowed.
          var array2D[][] = { { 0, 1, 2, 4 }, { 5, 6 } }; // Won't compile
          var array2D =  { { 0, 1, 2, 4 }, { 5, 6 } }; // Won't compile
          var array2D = new int[][] { { 0, 1, 2, 4 }, { 5, 6 } }; // Will compile