Can be used to create class or methods that will work for different types

To use it in a method, the Generic type is declared after the access modifiers inside diamond brackets,
  the the generic type can used as if was any type
    The following example method is able to print arrays of any type
    private static <E> void printArray(E[] array) {
      for (E element : array) {
        System.out.println("Element: " + elemnt);
      }
    }

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