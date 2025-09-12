Checked vs Unchecked Exceptions
  Checked exceptions are reviewed during compilation time
  Unchecked exceptions happen during runtime
    Unchecked exceptions do not need to be declared in a method or constructor's throws clause 
      if they can be thrown by the execution of the method or constructor and propagate outside the method or constructor boundary

Hierarchy 
  Both exceptions and errors inherit from the Throwable interface
  Unlike exceptions, errors cannot be handled. Some examples are: OutOfMemoryError, StackOverflowError and ThreadDeath
  Main exception types
    IOException
      Related with input and output
    SQLException
    RuntimeException
      Can be thrown during the normal operation of the Java Virtual Machine
      RuntimeException and its subclasses are unchecked exceptions
      From which inherits 
        NullPointerException
        IllegalArgumentException
        ArithmethicException
        ArrayIndexOutOfBoundsException
        ClassCastException
  Custom exceptions can be created by extending the Exception class, or implementing the Throwable interface

Catch
  Exceptions can be handled in a block like this
    try {
      // Code that may cause an exception
    } catch (ExceptionType exception) {
      // Code to run in case of exception
    } catch (OtherExceptionType exception) {
      // Optional code to run in case we want to target different types of exception
    } finally {
      // Optional code to run after the try and catch block, whether an exception happens or not
      // If present, always executes irrespective of what happens in the try or catch blocks
          Even if the try block throws an exception and there is no catch block to catch that exception, the JVM will execute the finally block.
          It will throw the exception to the caller only after the finally block finishes. 
          The only case where the finally block is not executed is if the code in the try or the catch block forces the JVM to shut down using a call to System.exit() method.
      // If a return statement is called in the try or catch blocks and a finally block is present,
          the JVM will hold the value of the return statement, execute the finally block and then return the value to the caller
      // If the finally block is present and contains a return statement, 
          values returned from try or catch blocks are always discarded
      // Throwing an exception from the finally block also makes the JVM discard the exceptions thrown from the try or catch blocks, 
          these other exceptions will be pushed to the suppressed array
    }
  If it is not a try-with-resources, try block must always contain a catch or a finally block

Multi-catch
  Can be used to execute the same block of code for different type of exceptions
    try {
      // Code that may cause an exception
    } catch (ExceptionType1 | ExceptionType2 exception) {
      // Code to run in case of exception
    }
  The type of the catch variable will be the most specific superclass of the exceptions listed
  Any number of classes may be listed in a multi-catch clause but none of them may have an
    ancestor/successor relationship between them
  The exception parameter in a multi-catch clause is implicitly final, so unlike single catch it can't be reassigned

Auto-closable resources
  Try can also be used to autoclose an object that extends the interface Closeable or Autocloseable
  Try with resource release resources when they are not needed implicitly
  Try-with-resources resource must either be a variable declaration 
    or an expression denoting a reference to a final or effectively final variable
  The scope of the variables defined in the try-with-resources is the try block
  When an exception is thrown inside the try block, 
    the resources are closed in inverse creation order, thus their close() methods invoked.
    If exceptions occur inside the close() methods, they are added to the suppressed exceptions array in the main exception
    After this, the catch block is executed
  Example
    try (Closable autoClosableElement = new Closable()) {
      // Code that may cause an exception
    } catch (ExceptionType exception) {
      // Code to run in case of exception
    }

Throwing exception
  Throwing an exception abandons the current flow of execution and the rest of statements in that flow are not executed
    the control leaves the current point of execution and goes to the point where the exception is handled

"throws" keyword in methods declaration
  The "throws Throwable" keyword can be added to a method signature or constructor
    to indicate that the method may cause an exception
  If a "throws" keyword is added to a constructor of a class, 
    any subclass must add it too, since subclass instantiation always calls parent constructor
  If a checked exception may be thrown inside the method, and it is not caught, the throws keyword is mandatory
  Methods with the "throws" keyword must be surrounded in try-catch block when invoked, 
    or their invoker method have the "throws" keyword also
  It is ok to declare a super-class in the throws class 
    and throw a subclass exception in the method, but the reverse is not acceptable

Errors
  Error is thrown in the program when hardware problems occur

Thread killing
    If an exception is not handled and reaches the top of the call chain, 
      the JVM will handle it by killing the thread in which it was thrown