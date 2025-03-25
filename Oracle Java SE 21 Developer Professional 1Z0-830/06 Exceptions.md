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
      // Optional code to run after the try and catch block, wether an exception happens or not
      // It is always executed, unless JVM exits
      // If an exception occurs in the try block and no catch block is defined, 
            the finally block's return statement will execute and override any return value or exception from the try block
            This is a common pitfall - the finally block can actually prevent exceptions from being propagated
      // If an exception occurs in this block, it will take precedence
    }

Autoclosable resources
  Try can also be used to autoclose an object that extends the interface Closeable or Autocloseable
  Try with resource release resources when they are not needed implicitly
  Try-with-resources resource must either be a variable declaration 
    or an expression denoting a reference to a final or effectively final variable
  When an exception is thrown inside the try block, 
    the resources are closed in inversed creation order, thus their close() methods invoked.
    If exceptions occur inside the close() methods, they are added to the suppresed exceptions array in the main exception
    After this, the catch block is executed
  Example
    try (Closable autoClosableElement = new Closable()) {
      // Code that may cause an exception
    } catch (ExceptionType exception) {
      // Code to run in case of exception
    }

"throws" keyword in methods declaration
  The "throws Throwable" keyword can be added to a method signature to indicate that the method may cause an exception
  Methods with the "throws" keyword must be sorrounded in try-catch block when invoked, 
    or their invoker method have the "throws" keyword also 

Errors
  Error is thrown in the program when hardware problems occur