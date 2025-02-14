A design pattern consist of four main elements: name, goal, solution an results
Creational patterns, structural patterns and behavior patterns as well as anti-patterns are distinguished

Creational patterns 
  Are intended to organize the process of creating objects
  The most common creational patterns are
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
  Characterize the ways in which classes or objects interact with each other. 
  Behavioral patterns include
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
    but also for separating them. 
  Structural patterns include:
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
  General Responsibility Assignment Software Patterns are design patterns used to solve general tasks of assigning responsibilities 
  to classes and objects.
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