POJO 
  Stands for Plain Old Java Object, these classes contain constructor, getters and setters
    
4 principles of OOP
  Abstraction, encapsulation, inheritance and polymorphism

Class intialization
  A class or interface type T will be initialized immediately before the first occurrence of any one of the following:
    T is a class and an instance of T is created.
    T is a class and a static method declared by T is invoked.
    A static field declared by T is assigned.
    A static field declared by T is used and the field is not a constant variable.
    T is a top-level class, and an assert statement lexically nested within T is executed.
    A reference to a static field (8.3.1.1) causes initialization of only the class or interface that actually declares it, 
      even though it might be referred to through the name of a subclass, a subinterface, or a class that implements an interface
    
Abstract classes
  Cannot be instantiated, but instead define properties and methods that a group of classes inheriting from them must contain
  Abstract class methods can be abstract methods or define a default implementation,
    that can be later overridden in inherited classes with the @Override annotation
  Abstract class can be empty
  Child of abstract class must implement the parent's abstract method
  Abstract methods must not be implemented in parent class
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
  They are never abstract, never sealed/non-sealed, 
    have no explicitly defined constructor and can have no subclasses

Nested classes
  Java allows a class to be defined within another class. These are called Nested Classes
    class OuterClass {
      ...
      class InnerClass {
          ...
      }
      static class StaticNestedClass {
          ...
      }
    }
  Static nested classes
    May be instantiated without instantiating its outer class
      OuterClass.StaticNestedClass staticNested = new OuterClass.StaticNestedClass();
    Can access only the static members of its outer class and the static members in other nested classes in the same outer class,
      including variables with private modifier
    Local records, enums and interfaces are always implicitly static
  Non-static nested classes (inner classes)
    Require an instance of its outer class to be instantiated
      OuterClass.InnerClass inner = new OuterClass().new InnerClass();
    Can access all variables of its outer class and other nested classes in the same outer class, 
      including variables with private, static and non-static modifiers
  
Local classes
  Nested classes defined within a local scope such as a method are called local classes
  Cannot have any access modifier, cannot be explicitly defined as static, and cannot be sealed/non-sealed
  Local records, enums and interfaces are always implicitly static
  Local classes are not accessible from outside the context in which they are defined

Interfaces
  Define a behavioral contract that tells methods and properties that any class implementing from it must have
  Interfaces declare methods, but they do not implement them. Implementing classes provide the actual implementation for interface methods
  Interfaces are implicitly abstract
  Everything declared inside an interface is implicitly public, 
    except methods explicitly declared private
  All variables defined in an interface are implicitly public, static and final.
    Interfaces cannot contain instance variables
  Interfaces can have four kinds of methods:
    1. abstract methods
      Contain the method declaration and no body
      In an interface, the keyword "abstract" is optional for abstract methods,
        since everything in an interface is implicitly public and abstract
    2. default methods
      Are a way for a interface to include a default implementation for a method,
        this implementation can be overridden by classes implementing the interface
      Are always public and cannot be marked as private or protected
    3. static methods
      Belong to the interface and not the class implementing the interface
      Must be invoked directly from the interface, like static methods of a class,
        as static methods of interfaces are not inherited,
        so they can't be invoked from implementing classes or instances
      Can be marked public or private but not protected
      Must provide a body, they cannot be marked default
    4. private methods
      Are primarily used as helper methods for other default or static methods within the same interface
      Can be static or non-static
      Must provide a body, they cannot be abstract
      Since are not visible outside the interface, cannot be marked as default
  Static and instance initializer blocks and constructors are not allowed in interfaces
  Classes are able to implement many interfaces, but may inherit only from one class
  Interfaces cannot implement other interfaces, but they can extend other interfaces
  Interfaces cannot be declared "final"
  Interfaces and Object class methods
    Interfaces can declare methods with the same signature as Object class methods and overload them, but never override them
    This means default methods cannot be declared with the name of Object class methods
    Methods like "int toString()" and "String hashCode()" are not allowed, since they change the default return type
    Methods like "String toString(int value)" are allowed, since overloading with the same return type is permitted
    Methods like "int hashCode()" and "String toString()" are allowed, since they describe methods that exist in Object class, 
      but they don't provide an implementation
  Marker interfaces
    Interfaces that do not contain anything at all, their purpose is to tag a class with information
  Multiple versions of a default method
    Since it is possible for a class to implement multiple interfaces, it is possible
      to inherit multiple implementations of a default method. When this happens,
      the class is forced to provide an implementation of the method of its own to remove ambiguity in invocation

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
  If the same object behaves differently, depending on which side of the object  you are
    looking at, then that object is polymorphic
  For example, if you have an Apple class that extends a fruit class, then an apple can
    behave as an Apple as well as a Fruit

Inheritance rules
  When we create instance of a child class, its parent class is firstly created,
    so a constructor of parent class is always called either explicitly or by the compiler
  Fields of the parent class are not overridden by the child class, only methods are
  When a variable with reference type of Parent and Child object type is created, 
    parent instance fields and child methods are accessed
  Even if a subclass does not inherit some of the instance variables of a superclass
    (because of access modifiers), a subclass object still consumes the space required
    to store all the instance variables of the super class
  A subclass can only access its immediate super class's version of members using "super"
  Extends clause must appear before the implements clause
  Java allows a class to inherit multiple fields with the same name as long as you don't try to use
    those fields ambiguously

Method varargs
  Makes passing a variable number of arguments to a method a little easier
  Within the method body, values are an array, however the caller does not need to create an array explicitly
  Example
    // Can be called as double average = average(1, 2, 3, 4);
    public double average(int... values) { 
      if (values.length == 0) {
        return 0;
      }
      double sum = 0;
      for (int i = 0; i < values.length; i++) {
        sum += values[i];
      }
      return sum / values.length;
    } 
  Constraints
    1. A method cannot have more than one varargs parameter
    2. If a varargs parameter is present, must be the last parameter of the method parameters

Method return types
  Java does not allow a method to return a value of a different type than the one specified in its declaration,
    however, there are three exceptions:
      1. Numeric promotion (by returning a type that performs a widening conversion)
      2. Autoboxing/unboxing (by returning primitive or wrapper types)
      3. It is ok for a method to return a subtype of its declared type

Method override
  It happens when a method supersede another method with the same signature,
    from an interface that is implementing or a parent class that is inheriting
  The signature (name and parameter types list) must be an exact match of the overridden method, 
    otherwise it will count as an overload instead of an override
  Calling an overriding method in an object of this class will execute the class implementation,
    not its parent nor interface implementation
  When a method is overridden by a subclass, it is impossible for any unrelated class
    to execute the super class's version of that method, however the subclass can still
    access to it using an implicit variable named "super"
  An overriding method must not be less accessible than the overridden method,
    however you can make the overriding method more accessible
  The return type of the overriding method must either be the same type of the overridden method,
    or it must be a subtype
  The overriding method is allowed to erase the generic type specification but 
    is not allowed to add a generic type specification if the  overridden method does not have it
  An overriding method cannot put a wider checked exception (a superclass exception)

Method overload
  Method signature includes just the method name and its ordered list of parameter types, nothing else
  A class cannot have more than one method with the same signature, 
    but method overloading allows you to create methods with different signature
  To the compiler, overloaded methods are just different methods
  Rules
    The method parameters must change: either the number, order or type of the parameters must be different in the two methods
      This is the most important rule. If not accomplished method overloading won't compile
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

Method selection
  1. Compilation error occurs only if the compiler is not able to successfully disambiguate a particular method call
  2. If the compiler finds a method whose parameter list is an exact match to the arguments, it is selected
  3. If more than one method is capable of accepting a call and none of them is an exact match, the most specific one is chosen
     For reference type variables, most specific means the closer superclass
     Since primitive type variables have no super/subclasses, Java define their relation as 
      double > float > long > int > char and int > short > byte
  4. Widening goes before autoboxing
  5. Autoboxing goes before varargs 

"final" modifier
  In a class, means that it cannot be extended by another class
  In a method, means it cannot be overridden
  In a property, means its value cannot be modified.
    Java doesn't assign a default value to final class properties,
    it forces the programmer to assign it

"static" modifier
  A method or property with the "static" modifier belongs to the class, not to any object instance
    "this" is not available inside static members, thus instance members cannot be accessed inside a static method 
  A static member can be accessed in the way "${ClassName}.${member}", without creating an object of that class,
    however Java allows a static member to be accessed through any instance of the class as well
  Since static fields belong to a class and not to an instance, there is only one copy of them
  Interfaces or Enums cannot be declared static, they are implicitly static

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
    A subclass in another package which extends this class will only inherit this variable, 
      but it cannot read or modify the value of a variable of a parent class instance
  "private" modifier 
    Allows access only to methods in the same class, or inner classes
  "public" modifier 
    Allows access to all packages in the program
  Access level can be extended by inherited classes (for example, overriding a private or protected method with a public one)
  Access level cannot be narrowed by inherited classes 
    (for example, it's not possible to override a public method with a private or protected one)
  A top level class (class not defined inside any other class), can only have two types of access:
    public and default
  A nested class can use any of the four access modifiers
  Illegal combinations of modifiers
    Compiler generates the error "illegal combination of modifiers" for
      - abstract private method(), since private methods can never be overriden
      - abstract static

Object class
  All classes inherit from Object class, which has a constructor and the methods: 
    Class<?> getClass(), int hashCode(), boolean equals(), Object clone(), String toString()
    void notify(), void notifyAll(), void wait() and void finalize() (deprecated)
  int hashCode() method
    Returns an integer value that represents the object, generated by a hashing algorithm
    Objects that are equal (according to their equals()) must return the same hash code. 
    Different objects not necessarily return different hash codes, however doing so improves perfomance of hash maps and tables
  boolean equals() method
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
    String toString() method
      Returns a string representation of the object
      By default, when not overridden, it returns a generic string consistent in 
        the name of the class of the object, that at-sign character '@', 
        and the unsigned hexadecimal representation of the hash code of the object

Comparing objects
  The relational operators != and == are good for comparing two values,
    which can be primitive values or references to objects,
    However, when used for comparing two references, these operators only compare
    object identity, that means, they check whether both references are pointing to 
    the same object or not

"native" keyword
  Is only applicable to methods. It indicates that the method is implemented in native code using JNI (Java Native Interface)
  The methods which are implemented in C, C++ are called native methods

"this" keyword
  Can't be used to name anything such as a variable or a method
  The type of "this" is the class in which is used
  Can't be modified
  Can be copied to another variable
  Can be used only within the context of an instance class (no static methods, variables or initializers)

Scopes
  Java has four visibility scopes, also known as lexical or static scopes, for variables:
    Class, method, block, flow
  Java has five lifespan scopes for variables:
    Class, instance, method, for loop and block
  Two variables can't be declared with the same name in the same visibility scope
  Shadowing
    Occurs when a variable declared in an inner scope has the same name as a variable declared in an outer scope 
    The inner variable effectively "shadows" or hides the outer variable, making the outer variable temporarily inaccessible within that inner scope
    The keyword "this" is used to unshadow an instance variable, if it is shadowed by a local variable of the same name
  Hiding
    Occurs when a subclass defines a static method with the same signature (name and parameter types) as a static method in its superclass. 
    In this scenario, the static method in the subclass "hides" the static method in the superclass
    Hiding does not completely replace members with the subclass version, instead the subclass
      now has two versions of the same features
  Obscuring
    Happens when the compiler is not able to determine what a simple name refers to
    For example, if a class has a field whose name is the same as the name of the package,
      and you try to use that simple name in a method

When the JVM creates a new instance of a class, it does 4 things:
  1. Checks whether class is already initialized. If not, loads and initializes class first.
    If the class has a super-class, and the superclass hasn't been initialized, the JVM will initialize the super-class first
  2. Allocates memory required to hold instance variables in heap space
  3. Initialize instance variables to default values
  4. Executes instance initializer and constructors

Constructors
  Their name is always exactly the same as the class and cannot have a return type,
    however they can have an empty return statement
  Every class must have at least one constructor, 
    but the programmer doesn't necessarily have to provide one.
    If the programmer doesn't provide one, compiler will add a default constructor
  Default constructor
    Takes no arguments and has no code in its body
    If you write any constructor for the class, the compiler provide won't provide a default constructor
  Overloading
    Class can have any number of constructors as long as they have different signatures
  Chaining
    Constructors can invoke other constructors using the keyword "this" and arguments in parentheses
    Only restriction is that call to other constructor must be the first line of code in a constructor,
      this implies that a constructor can invoke another constructor only once at the most

Initialization blocks
  The code inside the initialization block of a class will be executed everytime a new instance of this class is created,
    just before the constructor
  JVM executes all the instance initializers of the class, but just one of its constructor
  The code inside the static initialization block of a class will be executed just once in the program life time, when the class is created
    Example
      public Class MyClass {
          {
            System.out.println("This is executed everytime a new instance of this class is created, just before the constructor")
          }
          static {
            System.out.println("This is executed just once in the program life time, when the class is created")
          }
      }
  A class can have any number of static blocks, and they are executed in the order they appear in the class
  The compiler expects an instance initializer to execute without throwing an exception,
    if it can figure out that block of code will end up with an exception, it will refuse to compile

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