POJO 
  Stands for Plain Old Java Object, these classes contain constructor, getters and setters
    
4 principles of OOP
  Abstraction, encapsulation, inheritance and polymorphism
    
Initialization blocks
  The code inside the initialization block of a class will be executed everytime a new instance of this class is created
  The code inside the static initialization block of a class will be executed just once in the program life time, when the class is created
    Example
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
  Abstract class methods can be abstract methods or define a default implementation,
    that can be later overriden in inherited classes with the @Override annotation
  Abstract class can be empty
  Child of abstract class must implement the parent's abstract method
  Abstract method must not be implemented in parent class
  Abstract class can be sealed

Anonymous classes
  Can be created inside a method declaration to initialize an object, 
    extending an existing class or implementing an interface
  Example
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
  Interface methods are by default public and abstract, but can also contain a default implementation, 
    defined with the keyword "default"
  Classes are able to implement many interfaces, but may just inherit from one clas
  Interfaces cannot be declared "final"

instanceOf
  The instanceOf operator allows you to tell if an object is an instance, subclass, or implements the given class
  Example
    if (product instanceOf Phone) {
      ((Phone) product).ring();
    }

"super" keyword
  Can be used to reference methods or properties of any parent clas

Polymorphism
  Means that the same method signature from an interface or a class 
    can have different implementations thanks to inheritance and @Override annotation

Method override
  It happens when a method supersede another method with the same name, 
    from an interface that is implementing or a parent class that is inheriting
  Calling an overriding method in an object of this class will execute the class implementation, 
    not its parent nor interface implementation

Inheritance rules
  When we create instance of a child class, its parent class is firstly created
  Fields of the parent class are not overriden by the child class, only methods are overriden
  When a variable with reference type of Parent and Child object type is created, 
    parent instance fields and child methods are accessed

Method overload
  Allows you to create methods with the same signature, but that take different parameters and have different implementation
  Rules
    The method parameters must change: either the number or the type of parameters must be different in the two methods
    The return type can be freely modified
    The access modifier (public, private, and so on) can be freely modified
    Thrown exceptions, if any, can be freely modified
  Priority order
    1. The compiler looks for the most specific match for the arguments
      Arguments that match the exact call
    2. Implicit widening 
      Example: converting byte to long
    3. Implicit autoboxing
      Example: converting int to Integer
    4. Variable arguments
      Example: convertStrings(String ... abc) taking (String a, String b, String c)

"final" modifier
  In a class, means that it cannot be extended by another class
  In a property, means its value cannot be modified
  In a method, means it cannot be overriden

"static" modifier
  A method or property with the "static" modifier belongs to the class, not to any object instance
  A static member can be accesed in the way "${ClassName}.${member}", without creating an object of that class

static import
  Allows unqualified access to static members without inheriting from the type containing the static members
    import static java.lang.Math.*;
    // Once the static members have been imported, they may be used without qualification:
    double r = cos(PI * theta); // instead of calling Math.cos(Math.PI * theta);

Static binding vs dynamic binding
  private, final and static properties and methods use static binding, which means their implementation will always be the same
  Other properties and methods use dynamic binding, which means their implementation depends of the object they belong to
  Static binding is resolved at compile time, while dynamic binding is resolved at runtime, for this reason static binded members will have better performance

Encapsulation
  "default" modifier 
    Allows access to any other classes inside the same package
    If no access modifier is specified, the default modifier is applied
  "protected" modifier 
    Allows access only to child classes, or to classes in same package
  "private" modifier 
    Allows access only to methods in the same class
  "public" modifier 
    Allows access to all packages in the program
  Access level can be extended by inherited classes (for example, overriding a private or protected method with a public one)
  Access level cannot be narrowed by inherited classes 
    (for example, it's not possible to override a public method with a private or protected one)

Object class
  All classes inherit from Object class, which has a constructor and the methods: 
    getClass(), hashCode(), equals(), clone(), toString(), notify(), notifyAll(), wait() and finalize() (deprecated)
  hashCode() method
    Returns an integer value that represents the object, generated by a hashing algorithm
    Objects that are equal (according to their equals()) must return the same hash code. 
    Different objects not necessarily return different hash codes, however doing so improves perfomance of hash maps and tables
  equals() method
    The equals() method should provide
    Symmetry 
      For any non-null x and y references, the x.equals(y) method must return true if and only if y.equals(x) returns true
    Reflexivity
      For any non-null references x, the x.equals(x) method must return true
    Transitivity 
      For any non-null references x, y, and z, if x.equals(y) returns true and y.equals(z) returns true, 
        then x.equals(z) must also return true
    Persistence
      The result of equals() must change only when the fields involved are changed
    Inequality with null
      For any object, a.equals(null) must return false

"native" keyword
  Is only applicable to methods. It indicates that the method is implemented in native code using JNI (Java Native Interface)
  The methods which are implemented in C, C++ are called native methods

Yoda conditions 
  A "safe" style of writing comparison expressions when programming in languages with C syntax, 
  which consists in writing a constant member of the expression (constant or function call) 
  to the left of the comparison operator (that is, 5 == a instead of habitual a == 5)

CRC cards
  Class-responsibility-collaboration card (Class-Responsibility-Cooperation) 
    is a brainstorming method for designing object-oriented software
  As a rule, CRC-maps are used in those cases when classes and ways of their interactions are first defined in the software design process

SOLID principles
  Single responsability
    All classes must be as small as possible to handle just one responsability, otherwise it must be split into more classes
  Open/closed
    Software entities (classes, modules, functions) must be open to extension, but close to modification
  Liskov substitution
    Objects in a program should be replaceable with instances of their subtypes without altering the correctness of the program
  Interface segregation
    No client should depend on methods that it does not use
    Interfaces should also solve specific problems and contain operations that are logically connected
  Dependency inversion
    High level modules should not depend on low level modules, both should depend on abstractions
    Abstracts should not depend on details. Details should depend on abstractions

KISS principle
  "Keep it simple, stupid". It's a design philosophy emphasizing simplicity in both design and implementation
  Simplier systems are easier to understand, debug and maintain. 
  Avoid functionalities not necessary for current requirements and complexity that does not add direct value
  Design your system in small, manegeable and independent modules. 
  Minimize dependencies
  Break down functions into smaller, single purpose functions. Avoid deep nesting

YAGNI principle
  "You aren't gonna need it". Encourages avoiding necessary functionalities until is needed, focusing instead on inmediate project requirements
  It aims is to minimize costs of build, delay, carry and repair
  Features that provide inmediate value are prioritized. 
  The continuous refinement is based in actual user feedback and requirements
  Start with a minimum viable product and avoid speculative features. Develop in small, manegeable increments and seek continuous feedback. Regularly, refactor and simplify
  Postpone decisions that are future features until they are necessary and avoid premature optimization
  
DRY principle
  "Don't repeat yourself". Involves abstracting common functionalities into reusable functions, modules or classes
  Ensures consistent behavior, improves maintainability, readability and speeds the development process
  Leverage in frameworks to avoid boilerplate code and utilize libraries instead of reinventing the wheel 