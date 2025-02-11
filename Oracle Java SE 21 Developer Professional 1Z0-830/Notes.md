Primitive and reference data types
  Stack memory
    Part of the memory that holds primitive values
    It is accessed in an FIFO way. 
    Stores the values created by the methods, which are cleared once method execution finalizes
  Heap memory
    Part of the memory that holds reference values (like objects and arrays)
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
    4 principles of OOP
      Abstraction, encapsulation, inheritance and polymorphism
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
      Can be used to reference methods or properties of any parent class
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
      "default" modifier allows access to any other classes inside the same package. If no access modifier is specified, this is the default modifier
      "protected" modifier allows access only to child classes
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
    Yoda conditions 
      A "safe" style of writing comparison expressions when programming in languages with C syntax, 
      which consists in writing a constant member of the expression (constant or function call) 
      to the left of the comparison operator (that is, 5 == a instead of habitual a == 5).
    CRC cards
      Class-responsibility-collaboration card (Class-Responsibility-Cooperation) is a brainstorming method for designing object-oriented software. 
      As a rule, CRC-maps are used in those cases when classes and ways of their interactions are first defined in the software design process.
  SOLID principles
    Single responsability
      All classes must be as small as possible to handle just one responsability, otherwise it must be split into more classes
    Open/closed
      Software entities (classes, modules, functions) must be open to extension, but close to modification
    Liskov substitution
      Objects in a program should be replaceable with instances of their subtypes without altering the correctness of the program
    Interface segregation
      No client should depend on methods that it does not use. This means, interfaces should also solve specific problems and contain operations that are logically connected
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
  Design patterns
    A design pattern consist of four main elements: name, goal, solution an results.
    Creational patterns, structural patterns and behavior patterns as well as anti-patterns are distinguished.
    Creational patterns 
      Are intended to organize the process of creating objects. The most common creational patterns are:
        Abstract Factory
          Provides an interface for creating related objects of families of classes without specifying their specific implementations (families of product objects)
        Factory Method 
          Defines an interface for creating objects from a hierarchical family of classes based on the transmitted data (subclass of object that is instantiated)
        Builder
          creates an object of a particular class in various ways (how a composite object gets created)
        Singleton
          Guarantees the existence of only one or a finite number of instances of the class (the sole instance of a class)
        Prototype 
          Used when creating complex objects. Based on the prototype, objects are stored and recreated, for example, by copying
    Behavior patterns 
      Characterize the ways in which classes or objects interact with each other. Behavioral patterns include:
        Chain of Responsibility 
          Organizes a chain of recipient objects that do not know the capabilities of each other, independent of the sender object, 
          and pass the request to each other (object that can fulfill a request)
        Command 
          Used to determine, by some attribute, an object of a particular class to which a request will be passed for processing (when and how a request is fulfilled)
        Iterator
          Allows you to sequentially traverse all the elements of a collection or other composite object, 
          without knowing the details of the internal data representation (how an aggregate's elements are accessed, traversed)      
        Mediator
          Allows you to reduce the number of connections between classes with a large number of them, 
          highlighting one class that knows everything about the methods of other classes     
        Memento 
          Saves the current state of the object for further restoration    
        Observer 
          Allows for a one-to-many relationship between objects to track object changes     
        State 
          Allows an object to change its behavior by changing the internal state object
        Strategy 
          Specifies a set of algorithms with the ability to select one of the classes to perform a specific task during object creation (an algorithm)     
        Template Method 
          Creates a parent class that uses several methods, the implementation of which is assigned to derived classes (steps of an algorithm)    
        Visitor
          Represents an operation in one or more related classes of some structure that is called by a method specific 
          to each such class in another class (operations that can be applied to object(s) without changing their class(es))   
        Interpreter
          For a certain way of presenting information defines the rules (grammar and interpretation of a language)
    Structural patterns 
      Are responsible for the composition of objects and classes, and not only for bringing together parts of an application, 
      but also for separating them. Structural patterns include:
        Adapter 
          Is used when it is necessary to use classes together with unrelated interfaces. 
          The behavior of the adaptable class is changed to the required one (interface to an object)
        Bridge 
          Separates the representation of the class and its implementation, 
          allowing you to independently change both (implementation of an object)     
        Composite 
          Groups objects into hierarchical tree structures and allows you to work with a single object in the same way as with a group of objects (structure and composition of an object)     
        Decorator 
          Represents a way to change the behavior of an object without creating subclasses. 
          Allows you to use the behavior of one object in another (responsibilities of an object without subclassing)    
        Facade 
          Creates a class with a common high-level interface to a certain number of interfaces in a subsystem (interface to a subsystem)     
        Flyweight 
          Separates the properties of the class for optimal support for a large number of small objects (storage costs of objects)   
        Proxy 
          Replaces a complex object with a simpler one and controls access to it
    Antipatterns
      Some anti-patterns:
        Big ball of mud
          Is a term for a system or simply a program that does not have even the slightest discernible architecture. 
          Typically includes more than one anti-pattern. 
          This affects systems developed by people with no training in software architecture.       
        Yo-Yo problem
          Arises when you need to understand the program, the inheritance hierarchy and the nesting of method calls are very long and complex. 
          The programmer therefore needs to navigate between many different classes and methods in order to control the behavior of the program. 
          The term comes from the name of the yo-yo toy.      
        Magic Button
          Occurs when the form processing code is concentrated in one place and, of course, is not structured in any way.      
        Magic Number 
          The presence in the code of repeated the same numbers or numbers, the explanation of the origin of which is missing.     
        Gas Factory 
          Complex design for a simple task.      
        Analiys paralisys. 
          In software development manifests itself through extremely long phases of project planning, collecting the necessary artifacts for this, 
          software modeling and design, which do not make much sense to achieve the final goal.       
        Interface Bloat
          Is a term used to describe interfaces that try to contain all possible operations on data.      
        Accidental complexity 
          Is a programming problem that could easily have been avoided. Occurs due to a misunderstanding of the problem or ineffective planning.
  GRASP
    General Responsibility Assignment Software Patterns are design patterns used to solve general tasks of assigning responsibilities to classes and objects. 
    Nine GRASP patterns are known:
      Information Expert 
        An information expert describes the fundamental principles for assigning responsibilities to classes and objects. 
        According to the description, an information expert (an object endowed with certain duties) is an object that has the maximum information necessary to perform the assigned duties.
      Creator 
        The essence of the responsibility of such an object is that it creates other objects. 
        The analogy with factories immediately suggests itself. That is correct. Factories also have a creation responsibility.     
      Controller
        Is responsible for processing input system events, delegating the responsibility for their processing to competent classes. 
        In general, a controller implements one or more use cases. Using controllers allows you to separate logic from presentation, thereby increasing code reusability.    
      Low Coupling 
        If objects in an application are strongly coupled, then any change to them causes changes to all related objects. 
        And this is inconvenient and generates bugs.
        That's why in all learning literature it is mentioned that it is necessary that the code be loosely coupled and depend only on abstractions.    
      High Cohesion 
        High cohesion is a software engineering concept that refers to how closely all the routines in a class, or all the code in a routine, 
        support a central purpose. Classes that contain strongly related functionalities are described as having high cohesion.    
      Pure Fabrication 
        Is a class that doesn't represent any real domain object, but is specifically designed to increase cohesion, decoupling, or increase reuse. 
        Pure Fabrication reflects the concept of services in the Domain Programming model.    
      Indirection 
        The redirection pattern implements low coupling between classes by assigning responsibilities for their interaction to an additional object - an intermediary.    
      Protected Variations 
        Protects elements from being modified by other elements (objects or subsystems) by making the interaction a fixed interface. 
        All interaction between elements must occur through it. The behavior can only be changed by creating a different implementation of the interface.    
      Polymorphism 
        Allows you to handle alternative behaviors based on type and replace plug-in system components. 
        Responsibilities are allocated to different behaviors using polymorphic operations for that class. 
        All alternative implementations are cast to a common interface.

Exceptions
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

Collection framework
  Collections vs Arrays
    Collections are dynamic size, while arrays are always fixed size
    Collections can work just with reference types, while arrays can work with both primitive and reference types
    Arrays have better performance
  Collection interface 
    Contains the following methods:
      size(), isEmpty(), contains(), toArray(), add(), remove(), containsAll(), addAll(), removeAll(), retainAll(), clear(), equals() and hashCode()
      It implements the Iterable interface, which contains the iterator() method
    The main interfaces that inherit the collection interface are
      List interface
        Its main implementations are
          ArrayList
            Uses an internal array to hold objects
            Default capacity is 10. When full, a new ArrayList is created and objects copied to the new list
          Vector
            Similar to an ArrayList, the only difference is that all vector methods are synchronized, meaning it is multithread safe
            Synchronized methods can only by access by one thread at a time, preventing thread interference and memory consistency errors
          Stack
            Extends vector, but contains all the methods from the Queue
            It is used to implement a LIFO (Last In, First Out)
            It is deprecated, but kept to maintain backwards compatibility
          LinkedList
        Contains the following methods
          get(), set(), add(), indexOf(), lastIndexOf(), listIterator(), sublist(), replaceAll(), sort()
      Set interface
        Contains only unique objects
        Its main implementations are
          EnumSet
          HashSet
          LinkedHashSet
          TreeSet
        Doesn't introduce any new method
      Queue interface
        Its main implementations are
          ArrayDeque
          LinkedList
          PriorityQueue
        Contains the following methods
          offer(), remove(), poll(), element(), peek()
        

    

