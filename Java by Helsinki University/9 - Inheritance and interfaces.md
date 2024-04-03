Class inheritance
Every Java class extends the class Object, which means that every class we create has at its disposal all the methods defined in the Object class. If we want to change how these methods are defined in Object function, they must be overriden by defining a new implementation for them in the newly created class. The objects we create receive the methods equals and hashCode, among others, from the Object class.
Every class derives from Object, but it's also possible to derive from other classes. When we examine the API (Application Programming Interface) of Java's ArrayList, we notice that ArrayList has the superclass AbstractList. AbstractList, in turn, has the class Object as its superclass.
  java.lang.Object
  java.util.AbstractCollection<E>
    java.util.AbstractList<E>
       java.util.ArrayList<E>
Each class can directly extend only one class. However, a class indirectly inherits all the properties of the classes it extends. So the ArrayList class derives from the class AbstractList, and indirectly derives from the classes AbstractCollection and Object. So ArrayList has at its disposal all the variables and methods of the classes AbstractList, AbstractCollection, and Object.

Extends
You use the keyword extends to inherit the properties of a class. The class that receives the properties is called the subclass, and the class whose properties are inherited is called the superclass.
Let's take a look at a car manufacturing system that manages car parts. A basic component of part management is the class Part, which defines the identifier, the manufacturer, and the description.
public class Part {
    private String identifier;
    private String manufacturer;
    private String description;
    public Part(String identifier, String manufacturer, String description) {
        this.identifier = identifier;
        this.manufacturer = manufacturer;
        this.description = description;
    }
    public String getIdentifier() {
        return identifier;
    }
    public String getDescription() {
        return description;
    }
    public String getManufacturer() {
        return manufacturer;
    }
}
One part of the car is the engine. As is the case with all parts, the engine, too, has a manufacturer, an identifier, and a description. In addition, each engine has a type: for instance, an internal combustion engine, an electric motor, or a hybrid engine.
The traditional way to implement the class Engine, without using inheritance, would be this.
public class Engine {
    private String engineType;
    private String identifier;
    private String manufacturer;
    private String description;
    public Engine(String engineType, String identifier, String manufacturer, String description) {
        this.engineType = engineType;
        this.identifier = identifier;
        this.manufacturer = manufacturer;
        this.description = description;
    }
    public String getEngineType() {
        return engineType;
    }
    public String getIdentifier() {
        return identifier;
    }
    public String getDescription() {
        return description;
    }
    public String getManufacturer() {
        return manufacturer;
    }
}
We notice a significant amount of overlap between the contents of Engine and Part. It can confidently be said the Engine is a special case of Part. The Engine is a Part, but it also has properties that a Part does not have, which in this case means the engine type.
Let's recreate the class Engine and, this time, use inheritance in our implementation. We'll create the class Engine which inherits the class Part: an engine is a special case of a part.
public class Engine extends Part {
    private String engineType;
    public Engine(String engineType, String identifier, String manufacturer, String description) {
        super(identifier, manufacturer, description);
        this.engineType = engineType;
    }
    public String getEngineType() {
        return engineType;
    }
}
The class definition public class Engine extends Part indicates that the class Engine inherits the functionality of the class Part. We also define an object variable engineType in the class Engine.
The constructor of the Engine class is worth some consideration. On its first line we use the keyword super to call the constructor of the superclass. The call super(identifier, manufacturer, description) calls the constructor public Part(String identifier, String manufacturer, String description) which is defined in the class Part. Through this process the object variables defined in the superclass are initiated with their initial values. After calling the superclass constructor, we also set the proper value for the object variable engineType.
The super call bears some resemblance to the this call in a constructor; this is used to call a constructor of this class, while super is used to call a constructor of the superclass. If a constructor uses the constructor of the superclass by calling super in it, the super call must be on the first line of the constructor. This is similar to the case with calling this (must also be the first line of the constructor).
Since the class Engine extends the class Part, it has at its disposal all the methods that the class Part offers. You can create instances of the class Engine the same way you can of any other class.
Engine engine = new Engine("combustion", "hz", "volkswagen", "VW GOLF 1L 86-91");
System.out.println(engine.getEngineType());
System.out.println(engine.getManufacturer());
Sample output
combustion
volkswagen
As you can see, the class Engine has all the methods that are defined in the class Part.

Access modifiers private, protected, and public
If a method or variable has the access modifier private, it is visible only to the internal methods of that class. Subclasses will not see it, and a subclass has no direct means to access it.
A subclass sees everything that is defined with the public modifier in the superclass. If we want to define some variables or methods that are visible to the subclasses but invisible to everything else, we can use the access modifier protected to achieve this.

Calling the constructor of the superclass
You use the keyword super to call the constructor of the superclass. The call receives as parameters the types of values that the superclass constructor requires. If there are multiple constructors in the superclass, the parameters of the super call dictate which of them is used.
When the constructor (of the subclass) is called, the variables defined in the superclass are initialized. The events that occur during the constructor call are practically identical to what happens with a normal constructor call. If the superclass doesn't provide a non-parameterized constructor, there must always be an explicit call to the constructor of the superclass in the constructors of the subclass.
We demonstrate in the example below how to call this and super. The class Superclass includes an object variable and two constructors. One of them calls the other constructor with the this keyword. The class Subclass includes a parameterized constructor, but it has no object variables. The constructor of Subclass calls the parameterized constructor of the Superclass.
public class Superclass {
    private String objectVariable;
    public Superclass() {
        this("Example");
    }
    public Superclass(String value) {
        this.objectVariable = value;
    }
    public String toString() {
        return this.objectVariable;
    }
}
public class Subclass extends Superclass {
    public Subclass() {
        super("Subclass");
    }
}
Superclass sup = new Superclass();
Subclass sub = new Subclass();
System.out.println(sup);
System.out.println(sub);
Sample output
Example
Subclass

Calling a superclass method
You can call the methods defined in the superclass by prefixing the call with super, just as you can call the methods defined in this class by prefixing the call with this. For example, when overriding the toString method, you can call the superclass's definition of that method in the following manner:
@Override
public String toString() {
    return super.toString() + "\n  And let's add my own message to it!";
}

The actual type of an object dictates which method is executed
An object's type decides what the methods provided by the object are. For instance, we implemented the class Student earlier. If a reference to a Student type object is stored in a Person type variable, only the methods defined in the Person class (and its superclass and interfaces) are available:
Person ollie = new Student("Ollie", "6381 Hollywood Blvd. Los Angeles 90028");
ollie.credits();        // DOESN'T WORK!
ollie.study();              // DOESN'T WORK!
System.out.println(ollie);   // ollie.toString() WORKS
So an object has at its disposal the methods that relate to its type, and also to its superclasses and interfaces. The Student object above offers the methods defined in the classes Person and Object.
In the last exercise we wrote a new toString implementation for Student to override the method that it inherits from Person. The class Person had already overriden the toString method it inherited from the class Object. If we handle an object by some other type than its actual type, which version of the object's method is called?
In the following example, we'll have two students that we refer to by variables of different types. Which version of the toString method will be executed: the one defined in Object, Person, or Student?
Student ollie = new Student("Ollie", "6381 Hollywood Blvd. Los Angeles 90028");
System.out.println(ollie);
Person olliePerson = new Student("Ollie", "6381 Hollywood Blvd. Los Angeles 90028");
System.out.println(olliePerson);
Object ollieObject = new Student("Ollie", "6381 Hollywood Blvd. Los Angeles 90028");
System.out.println(ollieObject);
Object alice = new Student("Alice", "177 Stewart Ave. Farmington, ME 04938");
System.out.println(alice);
Sample output
Ollie
  6381 Hollywood Blvd. Los Angeles 90028
  credits 0
Ollie
  6381 Hollywood Blvd. Los Angeles 90028
  credits 0
Ollie
  6381 Hollywood Blvd. Los Angeles 90028
  credits 0
Alice
  177 Stewart Ave. Farmington, ME 04938
  credits 0
The method to be executed is chosen based on the actual type of the object, which means the class whose constructor is called when the object is created. If the method has no definition in that class, the version of the method is chosen from the class that is closest to the actual type in the inheritance hierarchy.

Polymorphism
Regardless of the type of the variable, the method that is executed is always chosen based on the actual type of the object. Objects are polymorphic, which means that they can be used via many different variable types. The executed method always relates to the actual type of the object. This phenomenon is called polymorphism.

When is inheritance worth using?
Inheritance is a tool for building and specializing hierarchies of concepts; a subclass is always a special case of the superclass. If the class to be created is a special case of an existing class, this new class could be created by extending the existing class. For example, in the previously discussed car part scenario an engine is a part, but an engine has extra functionality that not all parts have.
When inheriting, the subclass receives the functionality of the superclass. If the subclass doesn't need or use some of the inherited functionality, inheritance is not justifiable. Classes that inherit will inherit all the methods and interfaces from the superclass, so the subclass can be used in place of the superclass wherever the superclass is used. It's a good idea to keep the inheritance hierarchy shallow, since maintaining and further developing the hierarchy becomes more difficult as it grows larger. Generally speaking, if your inheritance hierarchy is more than 2 or 3 levels deep, the structure of the program could probably be improved.
Inheritance is not useful in every scenario. For instance, extending the class Car with the class Part (or Engine) would be incorrect. A car includes an engine and parts, but an engine or a part is not a car. More generally, if an object owns or is composed of other objects, inheritance should not be used.