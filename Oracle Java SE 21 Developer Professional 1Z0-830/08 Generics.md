Can be used to create class or methods that will work for different types

To use it in a method, the Generic type is declared after the access modifiers inside diamond brackets,
  the the generic type can used as if was any type
  Generics cannot be used with primitive types, for example new ArrayList<int>(); won't compile
    The following example method is able to print arrays of any type
    private static <E> void printArray(E[] array) {
      for (E element : array) {
        System.out.println("Element: " + elemnt);
      }
    }

Convention letters
    Conventionally, the following letters are used to name type parameters:
      K for Key
      N for Number
      T for Type
      V for Value
      S, U, V for 2nd, 3rd and 4th types
      A for Accumulator
      R for Return type

Type erasure
  It eliminates the need to create separate class for differently typed usages
  Parametrized type information is NOT reifiable,
    this means it is not available at runtime, so there's no way the JVM can assert that 
    an object is of a type that you claim to be of.
    For example, if you define a variable of type List<Number>, 
    the JVM will only know it is a variable of type List
  For this reason, compiler does not allow casts involving generics that cannot guarantee itself
    ArrayList<Number> numbers = new ArrayList<Number>();
    ArrayList<Integer> integers = (ArrayList<Integer>) numbers; // Won't compile
  Due to type erasure, generics make code type safe just at compile time, not at runtime
  On method overloading
    Due to type erasure, generic information cannot be a part of the signature,
    thus, two methods that differ only in their type arguments are not valid overloads

Covariance with generics
  Covariance refers to the situation where you are able to use a supertype in place of a subtype
  Generics are invariant, which means you cannot count on the type argument to determine covariance

Supertype-subtype relationships
  1. If the type arguments of the two parametrized types are an exact match, 
      they have the same relationship as their generic types
      for example, ArrayList<?> is a subtype of List<?>
  2. If the generic types of the two parametrized types are an exact match, 
      then the relationship is determined by their type arguments
      for example, List<?> is a supertype of List<? extends Number> and also List<? super Number>
  3. If neither of the two are an exact match, 
     then both of the above rules must be satisfied individually to establish a relationship
     for example, ArrayList<Integer> is a subtype of List<? extends Number>

Generic types can also be used to specify any type that extends any interface or class in the following way
  private static <T extends Comparable<T>> T maxValue(T x, T y, T z) {
    T maxValue = x;

    if (y.compareTo(max) > 0) {
      max = y;
    }

    if (z.compareTo(max) > 0) {
      max = z;
    }

    return max;
  }

Even several conditions can be added to the type, in the way <T extends Comparable<T> & Iterable<T>>

Generic types can be used in classes, in the following way
  public class Box<T> {

    Set<T> item;

    public T getItem() {
      return item;
    }

  }

Wildcards
  The "?" character is a wildcard that means any type
  Example
    public static void processElements(<? extends Parent> elements) {
      // do something...
    }

    public static void processElements2(<? super Child> elements) {
      // do something...
    }
  Wild cards cannot occur on the right side of the assignment
    List<? extends Exception> list = new ArrayList<? extends Exception>(); // Incorrect


Difference between E type and ? type
  E type means the type will always be of E type
  ? type means the type can be of any type and then change

Some classes can be instantiated without specifying a type, for example the line
  List list = new ArrayList<>();
  will generate a List<E> object, however it will throw a warning

In classes, generic type parameters are different from class level and method level, though they may have the same name
  Example
    public class MyClass<T> {
      private T value;

      public MyClass(T value) { 
        this.value = value; 
      }

      // Defines a method with a different generic type parameter T, which is separate from the class-level type parameter
      private <T> void display(T message) {
        System.out.println(value + " " + message);
      }
    }

Bounded type parameters
  A list with an upper bounded wildcard allows you to take things out, 
    while a lower bounded wildcard allows you to add things to it, this can be remembered with the
    mnemonic PECS, which stands for Producer Extends, Consumer Super
  Upper bound
    Tells the compiler that a generic is always going to be a type that extends another,
      so it can safely replace the generic with its declared super type
    Can be specified with the keyword "extends" even for interfaces, for example
      <E extends CharSequence>
    Interfaces in upper bounds can be combined, so a class will need to implement them all
      <E extends Number & Comparable & Runnable>
  Lower bound
    Are useful to prevent unnecessary access to members of an object
    Can be specified with the keyword "super" even for interfaces, for example
      <E super CharSequence>

Rules
  You cannot instantiate objects using generic types with the "new" keyword,
    for example new E(); is invalid
  You cannot use a generic type variable in an instanceof operator, 
    for example (listInts instanceof ArrayList<Integer>) won't compile
  Because arrays are reified and generics are type erased,
    you cannot create an array of a parametrized type
  You cannot use primitive types in type parameters or type arguments
  Static variables can't be defined with the type of the type variable, 
    for example, static E e; is invalid
  It is not permitted to extend a generic class from java.lang.Throwable