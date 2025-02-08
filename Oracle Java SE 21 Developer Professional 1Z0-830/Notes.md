Primitive and refference data types
  Stack memory
    Part of the memory that holds primitive values
    It is accessed in an FIFO way. 
    Stores the values created by the methods, which are cleared once method execution finalizes
  Heap memory
    Part of the memory that holds refference values (like objects and arrays)
  Integer Pool
    Caches integer values between -128 and 127 (inclusive). 
    When an integer within this range is created using autoboxing or the valueOf() method, 
    the JVM checks if an equivalent integer object already exists in the pool. 
    If it does, the existing object is reused; otherwise, a new object is created and added to the pool for future use
  String pool
    When we create a String variable and assign a value to it, the JVM searches the pool for a String of equal value.
    If found, the Java compiler will simply return a reference to its memory address, without allocating additional memory.
    If not found, it will be added to the pool (interned) and its reference will be returned.
  Strings
    \u escape can be used to represent unicode characters, for example \u2665 represents a ♥
    String.format() allows to created strings with special format, substituting character sequences like %s for another string, or %d for integers
    Formatter class can be used for advance control over string format, like locale-based formatting

Iteration statements (loops)
  Labels
    Labels are declared in the way "${label}: ${loop}"
    Labels can be used to mark a loop, the marked loop can be used as a target for break and continue statements in the way "break ${label}" or "continue ${label}"

Enums
  Enums are used to specify a list of non-infinite keywords that match a given type
  Enums can be declared in the way: "${accesModifier} Enum ${enumName} { ${components} }", for example:
    public enum Priority {
      HIGH, MEDIUM, LOW
    }
  Each member of the Enum has an ordinal value associated, that can be retrieved like Priority.HIGH.ordinal();
  Enum members can also contain each own properties and methods, like:
    public enum Month {

      JANUARY(31), FEBRUARY(28), MARCH(31), APRIL(30), MAY(31), JUNE(30), JULY(31), AUGUST(31), SEPTEMBER(30), OCTUBER(31), NOVEMBER(30), DECEMBER(31)

      private int daysAmount;

      Moth(int daysAmount) {
        this.daysAmount = daysAmount;
      }

      getDaysAmount() {
        return daysAmount;
      }

    }
  
Object Oriented Programming
  General
    POJO 
      Stands for Plain Old Java Object, these classes contain constructor, getters and setters
    Initialization blocks
      The code inside the initialization block of a class will be executed everytime a new instance of this class is created
      The code inside the static initialization block of a class will be executed just once in the program life time, when the class is created
        Example:
        public Class MyClass {

            {
              System.out.println("This is executed everytime a new instance of this class is created")
            }

            static {
              System.out.println("This is executed just once in the program life time, when the class is created")
            }

        }
    Abstract classes
      Cannot be instatiated, but instead define properties and methods that a group of classes inheriting from them must contain
      Abstract class methods can be abstract methods or define a default implementation (that can be later overriden in inherited classes with the @Override annotation)
    Anonymous classes
      Can be created inside a method declaration to initialize an object, extending an existing class or implementing an interface, for example:
        public void sayHello() {        
          class EnglishGreeting implements HelloWorld {
              String name = "world";
              public void greet() {
                  greetSomeone("world");
              }
              public void greetSomeone(String someone) {
                  name = someone;
                  System.out.println("Hello " + name);
              }
          }

          HelloWorld englishGreeting = new EnglishGreeting();
          englishGreeting.greet();
        }
    Interfaces
      Define a behavioral contract that tells methods and properties that any class implementing from it must have
      Interface methods are by default public and abstract, but can also contain a default implementation, defined with the keyword "default"
      Classes are able to implement many interfaces, but may just inherit from one class
    instanceOf
      The instanceOf operator allows you to tell if an object is an instance, subclass, or implements the given class, for example:
        if (product instanceOf Phone) {
          ((Phone) product).ring();
        }
    "super" keyword
      Can be used to refference methods or properties of any parent class
    Polymorphism
      Means that the same method signature from an interface or a class can have different implementations thanks to inheritance and @Override annotation
    Method override
      It happens when a method supersede another method with the same name, from an interface that is implementing or a parent class that is inheriting
      Calling an overriding method in an object of this class will execute the class implementation, not its parent nor interface implementation
    Method overload
      Allows you to create methods with the same signature, but that take different parameters and have different implementation
    "final" modifier
      In a class, means that it cannot be extended by another class
      In a property, means its value cannot be modified
      In a method, means it cannot be overriden
    "static" modifier
      A method or property with the "static" modifier belongs to the class, not to any object instance
      A static member can be accesed in the way "${ClassName}.${member}", without creating an object of that class
    Static binding vs dynamic binding
      private, final and static properties and methods use static binding, which means their implementation will always be the same
      Other properties and methods use dynamic binding, which means their implementation depends of the object they belong to
      Static binding is resolved at compile time, while dynamic binding is resolved at runtime, for this reason static binded members will have better performance
    Encapsulation
      "protected" modifier allows access only to child classes, or any other classes inside the same package. 
        If no access modifier is specified, "protected" is the default modifier
      "private" modifier allos access only to methods in the same class
      "public" modifier allows acces to all packages in the program
      Access level can be extended by inherited classes (for example, overriding a private or protected method with a public one)
      Access level cannot be narrowed by inherited classes (for example, it's not possible to override a public method with a private or protected one)
    Object class
      All classes inherit from Object class, which has a constructor and the methods: 
        getClass(), hashCode(), toString(), clone(), notify(), notifyAll(), wait() and finalize() (though finalize is deprecated)
    "native" keyword
      Is only applicable to methods. It indicates that the method is implemented in native code using JNI (Java Native Interface)
      The methods which are implemented in C, C++ are called native methods
  SOLID principles
    Single responsability
      All classes must be as small as possible to handle just one responsability, otherwise it must be split into more classes
    Open/closed
      Software entities (classes, modules, functions) must be open to extension, but close to modification
    Liskov substitution
    Interface segregation
    Dependency inversion
  KISS principle
  YAGNI principle
  DRY principle