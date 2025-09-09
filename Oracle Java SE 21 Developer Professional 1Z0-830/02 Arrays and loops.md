Arrays
  Extends Object
  Are always fixed size, 
    if you want to change its size you need to create a new array
  Can have duplicate values
  It is prohibited to specify the size if you specify individual elements
  It is possible to have an array of length 0
  Arrays are covariant, meaning they can store subclass objects of its declared type
  public clone() method
    All array classes have this method
    Creates a shallow copy of the array
  public boolean equals() 
    Check whether the two references point to the same object or not. 
    In other words, equals method of array classes returns the same result as ==

Labels
  Labels are declared in the way "${label}: ${loop}"
  Labels can be used to mark a loop, the marked loop can be used as a target for break and continue statements 
    in the way "break ${label}" or "continue ${label}"
  Although not necessary, the convention is to use capital letters for label names