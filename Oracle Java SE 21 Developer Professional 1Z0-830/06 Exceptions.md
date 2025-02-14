Checked vs Unchecked Exceptions
  Checked exceptions are reviewed during compilation time
  Unchecked exceptions happen during runtime

Hierarchy 
  Both exceptions and errors inherit from the Throwable interface
  Unlike exceptions, errors cannot be handled. Some examples are: OutOfMemoryError, StackOverflowError and ThreadDeath
  The principal exception types are IOException (related with input and output), SQLException and 
    Runtime exception (from which inherits NullPointerException, IllegalArgumentException, ArithmethicException, ArrayIndexOutOfBoundsException, ClassCastException)
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
    }

"throws" keyword in methods declaration
  The "throws Throwable" keyword can be added to a method signature to indicate that the method may cause an exception
  Methods with the "throws" keyword must be sorrounded in try-catch block when invoked, or their invoker method have the "throws" keyword also 