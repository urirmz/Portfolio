Stack memory
  Part of the memory that holds primitive values
  It is accessed in an FIFO way. 
  Stores the values created by the methods, which are cleared once method execution finalizes

Heap memory
  Part of the memory that holds reference values (like objects and arrays)

Number abstract class
  Is the superclass of platform classes representing numeric values that are convertible to the primitive types 
    byte, double, float, int, long, and short
  It's extended by Byte, Double, Float, Integer, Long and Short
  Methods
    int intValue()
    long longValue()
    float floatValue()
    double doubleValue()
    byte byteValue()
    short shortValue()

Primitive casting
  Widening conversion
    Happens when the value of a variable is passed to another variable which can hold a bigger value than the original variable
    Are performed automatically by the Java compiler and don't require explicit cast
    Examples
      byte to short, int, long, float, or double
      short to int, long, float, or double
      char to int, long, float, or double
      int to long, float, or double
      long to float or double
      float to double
  Narrowing conversion
    Happens when the value of a variable is passed to another variable which can hold a smaller value than the original variable
    Can lead to results as MAX_VALUE, MIN_VALUE, data loss, precision loss, truncation or even sign changes
    Always requires an explicit cast
    Examples
      double to float, long, int, char, short, or byte
      long to int, char, short, or byte
      int to char, short, or byte

Integer Pool
  Caches integer values between -128 and 127 (inclusive). 
  When an integer within this range is created using autoboxing or the valueOf() method, 
    the JVM checks if an equivalent integer object already exists in the pool
  If it does, the existing object is reused; otherwise, a new object is created and added to the pool for future use

String pool
  When we create a String variable and assign a value to it, the JVM searches the pool for a String of equal value
    If found, the Java compiler will simply return a reference to its memory address, without allocating additional memory
    If not found, it will be added to the pool (interned) and its reference will be returned
  String.intern() method will create a new copy of the String content and store it in the String pool
  Strings created with "new" will never be stored in the thread pool

Strings
  \u escape can be used to represent unicode characters, for example \u2665 represents a ♥
  String.format() allows to created strings with special format, 
    substituting character sequences like %s for another string, or %d for integers
  Formatter class can be used for advance control over string format, like locale-based formatting
  Strings can be converted into their bytes representation using the getBytes() method

How arguments are passed to methods?
  Pass-by-value
    When a primitive type (like int, double, etc.) is passed to a method, 
      its value is copied, and the method receives that copy.
      Any changes to this copy do not affect the original variable's value
  Pass-by-reference
    When an object is passed to a method, the reference to that object is passed by value
      This means the method receives a copy of the reference, which points to the same object in memory as the original reference.
      Any changes made to the object through this copied reference will affect the original object 
      because both references point to the same object in memory
    However, if you reassign the copied reference inside the method to a new object, 
      this reassignment does not affect the original reference. 
      The original reference outside the method still points to the original object

Default values
  When declared locally, primitives doesn't have a default value: they must be explicitly initialized before used
  However in instance or static fields, if no initialization value is provided, primitives will be initialized with default values
    char
      '\u0000'
    boolean
      false
    int
      0
    double
      0.0
    float
      0.0f
    long 
      0L
  null is the default value of all reference data types (Object, String, Boolean, Integer, etc)

4 types of references in Java
  Strong/Hard
    Objects reachable through any strong reference can’t be garbage collected
    Objects created are automatically assigned a strong reference, for example
      List<String> list = new ArrayList<>;
    If we later nullify the reference, they can be collected by the garbage collector
      list = null;
  Soft 
    The object can stay in the memory for some time until the collector decides that he needs to collect it
      That’ll happen, especially when JVM is at risk of running out of memory
    Can be created with the class SoftReference
      SoftReference<List<String>> listReference = new SoftReference<List<String>>(new ArrayList<String>());
  Weak
    Objects referenced only by weak references are automatically collected
    Can be created with the class WeakReference
      WeakReference<List<String>> listReference = new WeakReference<List<String>>(new ArrayList<String>());
    Are most often used to implement canonicalizing mappings
      A "canonicalized" mapping is where you keep one instance of the object in question in memory and all others look up that particular instance via pointers or somesuch mechanism
  Phantom 
    Objects referenced by phantom references are eligible for garbage collection
    Before removing them from the memory, JVM puts them in a queue called reference queue, 
      after calling finalize() method on them
      This helps to know when an object is effectively removed from memory
    Can be created with the class PhantomReference
      PhantomReference<List<String>> listReference = new PhantomReference<List<String>>(new ArrayList<String>());

Garbage Collector
  Automatically finds and removes objects that are no longer needed, freeing up memory in the heap
  Primitives are not cleaned by gc
  Runs in the background as a daemon thread, helping to manage memory efficiently without requiring the programmer’s constant attention
  An object is said to be unreachable if it doesn’t contain any reference to it, making it eligible for Garbage Collection
  How to Make an Object Eligible for Garbage Collection?
    Nullifying the reference variable
    Re-assigning the reference variable
    Objects created within a method are eligible for garbage collection once the method completes
    Objects that are isolated and not referenced by any reachable objects
  System.gc()
    Suggests that the Java Virtual Machine expend effort toward recycling unused objects
      however does not guarantee the execution of cleaning the eligible object
  finalize() Object method
    Called by the garbage collector before destroying an object