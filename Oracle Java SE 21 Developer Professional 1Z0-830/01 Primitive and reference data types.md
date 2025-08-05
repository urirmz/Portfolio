Stack memory
  Part of the memory that holds primitive values
  It is accessed in an FIFO way. 
  Stores the values created by the methods, which are cleared once method execution finalizes
  In Java 21, the default stack space size is 512KB, but it can be changed at the time of executing the program using command line option-Xss.

Heap memory
  Part of the memory that holds reference values (like objects and arrays)

Primitive data types
  Integral data types
    byte, char, short, int, long
  Floating point data types
    float, double
  Boolean data types
    boolean
Reference data types
  Classes, records, enums, interfaces

Default values
  Java initialize instance or static fields to default values if you don't initialize them explicitly
    char
      '\u0000' (blank space character)
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
    Any reference data type (Object, String, Boolean, Integer, etc)
      null
  Java doesn't initialize local variables if you don't initialize them explicitly,
    and won't compile the code if you try to use such variable
  Java doesn't have a problem if you have uninitialized variables as long as you don't try to use them

Numeric literals
  A number without a decimal is considered an int
  A number containing a decimal is considered a double
  A long literal can be written by appending lowercase of uppercase L (example: 10L)
  A float literal can be written by appending lowercase of uppercase f (example: 10.0f)
  A char literal can be written enclosing single character between single quotes (example: 'a')
  There are only two boolean literals: true and false
  null is also a literal
  Java allows numeric values to be written in hexadecimal, octal, as well as binary formats
    in hexadecimal, value must start with 0x or 0X (example: 0XF)
    in octal, value must start with 0 (example: 017)
    in binary, value must start with 0b or 0B (example: 0B0001)

Underscores in numeric literals
  Java allows underscores between to digits in numeric literals
    for example, 1000000 can also be written as 1_000_000
  Rules:
    1. They can't be used at the beginning or the end of a number. Thus, _2 and 2_ are invalid.
    2. They can't be used immediately before or after a decimal. Thus, 1_.2 and 1._2 are invalid.
    3. They can't be used before an identifying suffix such as F, D or L Thus, 1.0_f is invalid.
    4. They can't be used immediate before or after the binary or hexadecimal identifiers b and x. Thus, 0x_1 is invalid.
    5. Although confusing, it is legal to have multiple underscores between two digits. For example: 
      int a = 1____3; // Variable a has a value of 13
      int b = 1_3; // Variable b has a value of 13

Binary representation for integers
  Java does not have a native unsigned int data type
  All primitive integer types in Java (byte, short, int, and long) are signed, 
    meaning they use one bit to represent the sign (positive or negative) and the remaining bits for the magnitude
  Java uses two's complement representation for negative numbers,
    which basic rule is to take the positive, invert all bits then adda binary one. For example:
      int x = 3; // 0b0000_0000_0000_0011
      int y = ~x; // 0b1111_1111_1111_1100 -> y = -4;
      int z = ~y; // 0b0000_0000_0000_0011 -> z = 3;

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
    What will happen if the actual value held by the source variable is indeed larget than the size of the target variable?
      The JVM will simple cut out the extra higher order bits that can fit in the target

"final" references
  When you make a reference variable final, 
    it only means that the reference cannot refer to any other object,
    but the contents of that object can still change
    Example
      final Data d = new Data();
      d = new Data() // Won't compile because 'd' is final

Wrapper classes
  Are meant for the types that are used to represent numeric data
    Byte, Short, Integer, Long, Float and Double
  Extend from the common base class java.lang.Number
  Ways to create wrapper classes:
    - Using constructors (example: Integer i1 = new Integer(10);) (deprecated)
    - Using valueOf static methods (example: Integer i1 = Integer.valueOf(10);)
    - Through autoboxing (example: Integer i1 = 100;)
        If you assign a primitive value to a wrapper variable, the compiler will
        automatically box the primitive value into a wrapper object
  Ways to convert wrapper objects to primitives:
    - Using xxxValue() methods (example: int i2 = i1.intValue();)
    - Using unboxing (example: int i2 = i1;)
        If you assign a wrapper variable to a primitive variable, the compiler will
        automatically extract the primitive value and assign it to the target
    - Using parseXXX() methods (example: int i2 = Integer.parseInt("1");)

java.lang.Number abstract class
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

String class
  Extends Object and implements CharSequence
  It is final, so it cannot be extended
  Strings are immutable, so it is impossible to change the contents of a string once created
  \u escape can be used to represent unicode characters, for example \u2665 represents a ♥
  String.format() allows to created strings with special format,
  substituting character sequences like %s for another string, or %d for integers
  Formatter class can be used for advance control over string format, like locale-based formatting
  Strings can be converted into their bytes representation using the getBytes() method

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

Casting
  Java language allows a programmer to use their knowledge about their program to assure
    the compiler that a reference will point to an object of the correct type at runtime using the cast operator
    Fruit fruit = new Mango();
    Mango mango = (Mango) fruit;
  Casting doesn't change the actual object, 
    it only changes the perspective from which the compiler sees the object
  Narrowing cast (down-casting)
    When you cast a variable to a subtype
    Always requires a check from the JVM
  Widening cast (up-casting)
    When you cast a variable to a supertype
  It the JVM sees that a reference variable is being cast to type that does not satisfy the is-a test for the class
    of the object to which the variable is referring, it will throw a ClassCastException
  Since a class can extend one class and implement any number of Interfaces at the same time,
    the compiler cannot rule out cases where a reference can never point to an instance of a class implementing an interface,
    thus you can cast any type of reference to any interface.
    Except when a variable is final and that class does not implement the interface given in the cast
  Static members of a type shadow the static members with the same name in the super type,
    casting a variable to the super type is how you unshadow those members

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
    When a thread dies, objects created inside that thread are eligible for garbage collection,
      unless the reference of that object is still held on by some other living thread
  Island of isolation
    The graph of interconnected objects not reachable from an active part of the program,
      though they are reachable through each other
    It is considered garbage
  System.gc()
    Suggests that the Java Virtual Machine expend effort toward recycling unused objects
      however does not guarantee the execution of cleaning the eligible object
  finalize() Object method
    Called by the garbage collector before destroying an object