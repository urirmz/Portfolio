Primitive and refference data types
  Stack memory
    Part of the memory that holds primitive values
    It is accessed in an FIFO way. Stores the values created by the methods, which are cleared once method execution finalizes
  Heap memory
    Part of the memory that holds refference values (like objects and arrays)
  Integer Pool
    Caches integer values between -128 and 127 (inclusive). 
    When an integer within this range is created using autoboxing or the valueOf() method, 
    the JVM checks if an equivalent integer object already exists in the pool. 
    If it does, the existing object is reused; otherwise, a new object is created and added to the pool for future use
  String pool