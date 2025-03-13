Stack memory
  Part of the memory that holds primitive values
  It is accessed in an FIFO way. 
  Stores the values created by the methods, which are cleared once method execution finalizes

Heap memory
  Part of the memory that holds reference values (like objects and arrays)

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

Strings
  \u escape can be used to represent unicode characters, for example \u2665 represents a ♥
  String.format() allows to created strings with special format, 
    substituting character sequences like %s for another string, or %d for integers
  Formatter class can be used for advance control over string format, like locale-based formatting
  Strings can be converted into their bytes representation using the getBytes() method

Uninitialized local variables cannot be used in Java

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
