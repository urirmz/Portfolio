Introduction to object-oriented programming
Object-oriented programming is concerned with isolating concepts of a problem domain into separate entities and then using those entities to solve problems. 

Classes and Objects
We've already used some of the classes and objects provided by Java. A class defines the attributes of objects, i.e., the information related to them (instance variables), and their commands, i.e., their methods. The values of instance (i.e., object) variables define the internal state of an individual object, whereas methods define the functionality it offers.
A Method is a piece of source code written inside a class that's been named and has the ability to be called. A method is always part of some class and is often used to modify the internal state of an object instantiated from a class.
An object is always instantiated by calling a method that created an object, i.e., a constructor by using the new keyword.

The Relationship Between a Class and an Object
A class lays out a blueprint for any objects that are instantiated from it. Let's draw from an analogy from outside the world of computers. Detached houses are most likely familiar to most, and we can safely assume the existence of drawings somewhere that determine what exactly a detached house is to be like. A class is a blueprint. In other words, it specifies what kinds of objects can be instantiated from it

Example Class
public class Account {
    private double balance;
    private String owner;
    public Account(String owner, double balance) {
        this.balance = balance;
        this.owner = owner;
    }
    public void deposit(double amount) {
        this.balance = this.balance + amount;
    }
    public void withdrawal(double amount) {
        this.balance = this.balance - amount;
    }
    public double balance() {
        return this.balance;
    }
    @Override
    public String toString() {
        return this.owner + " balance: " + this.balance;
    }
}

Creating Classes
A new class can be added in NetBeans the following way: On the left side of the screen is the Projects list. Right-click on the project's name, which for this exercise is Part04_03.DogAttributes. From the drop-down menu, select New and Java Class. NetBeans will then ask for the class name.
A class specifies what the objects instantiated from it are like.
The object's variables (instance variables) specify the internal state of the object
The object's methods specify what the object does
A class is defined to represent some meaningful entity, where a "meaningful entity" often refers to a real-world object or concept. If a computer program had to process personal information, it would perhaps be meaningful to define a seperate class Person consisting of methods and attributes related to an individual.
Let's create a class named Person. For this class, we create a separate file named Person.java. Our program now consists of two separate files since the main program is also in its own file. The Person.java file initially contains the class definition public class Person and the curly brackets that confine the contents of the class.
public class Person {
}
A class defines the attributes and behaviors of objects that are created from it. Let's decide that each person object has a name and an age. It's natural to represent the name as a string, and the age as an integer. We'll go ahead and add these to our blueprint:
public class Person {
    private String name;
    private int age;
}
We specify above that each object created from the Person class has a name and an age. Variables defined inside a class are called instance variables, or object fields or object attributes. Other names also seem to exist.
Instance variables are written on the lines following the class definition public class Person {. Each variable is preceded by the keyword private. The keyword private means that the variables are "hidden" inside the object. This is known as encapsulation.
We have now defined a blueprint — a class — for the person object. Each new person object has the variables name and age, which are able to hold object-specific values. The "state" of a person consists of the values assigned to their name and age.

Defining a Constructor
We want to set an initial state for an object that's created. Custom objects are created the same way as objects from pre-made Java classes, such as ArrayList, using the new keyword. It'd be convenient to pass values ​​to the variables of that object as it's being created. For example, when creating a new person object, it's useful to be able to provide it with a name:
public static void main(String[] args) {
    Person ada = new Person("Ada");
    // ...
}
This is achieved by defining the method that creates the object, i.e., its constructor. The constructor is defined after the instance variables. In the following example, a constructor is defined for the Person class, which can be used to create a new Person object. The constructor sets the age of the object being created to 0, and the string passed to the constructor as a parameter as its name:
public class Person {
    private String name;
    private int age;

    public Person(String initialName) {
        this.age = 0;
        this.name = initialName;
    }
}
The constructor's name is always the same as the class name. The class in the example above is named Person, so the constructor will also have to be named Person. The constructor is also provided, as a parameter, the name of the person object to be created. The parameter is enclosed in parentheses and follows the constructor's name. The parentheses that contain optional parameters are followed by curly brackets. In between these brackets is the source code that the program executes when the constructor is called (e.g., new Person ("Ada")).
Objects are always created using a constructor.
A few things to note: the constructor contains the expression this.age = 0. This expression sets the instance variable age of the newly created object (i.e., "this" object's age) to 0. The second expression this.name = initialName likewise assigns the string passed as a parameter to the instance variable name of the object created.

Default Constructor
If the programmer does not define a constructor for a class, Java automatically creates a default one for it. A default constructor is a constructor that doesn't do anything apart from creating the object. The object's variables remain uninitialized (generally, the value of any object references will be null, meaning that they do not point to anything, and the values of primitives will be 0)
For example, an object can be created from the class below by making the call new Person()
public class Person {
    private String name;
    private int age;
}
If a constructor has been defined for a class, no default constructor exists. For the class below, calling new Person would cause an error, as Java cannot find a constructor in the class that has no parameters.
public class Person {
    private String name;
    private int age;

    public Person(String initialName) {
        this.age = 0;
        this.name = initialName;
    }
}

Defining Methods For an Object
We know how to create an object and initialize its variables. However, an object also needs methods to be able to do anything. As we've learned, a method is a named section of source code inside a class which can be invoked.
public class Person {
    private String name;
    private int age;
    public Person(String initialName) {
        this.age = 0;
        this.name = initialName;
    }
    public void printPerson() {
        System.out.println(this.name + ", age " + this.age + " years");
    }
}
A method is written inside of the class beneath the constructor. The method name is preceded by public void, since the method is intended to be visible to the outside world (public), and it does not return a value (void).
Instance variables are referred to with the prefix this. All of the object's variables are visible and available from within the method.
If the method's only purpose is to set a value to an instance variable, then it's named as setVariableName. Value-setting methods are often called "setters".

Objects and the Static Modifier
We've used the modifier static in some of the methods that we've written. The static modifier indicates that the method in question does not belong to an object and thus cannot be used to access any variables that belong to objects.
Going forward, our methods will not include the static keyword if they're used to process information about objects created from a given class. If a method receives as parameters all the variables whose values ​​it uses, it can have a static modifier.

Returning a Value From a Method
A method can return a value. All the variables we've encountered so far can also be returned by a method.
A method that returns nothing has the void modifier as the type of variable to be returned.
public void methodThatReturnsNothing() {
    // the method body
}
A method that returns an integer variable has the int modifier as the type of variable to be returned.
public int methodThatReturnsAnInteger() {
    // the method body, requires a return statement
}
A method that returns a string has the String modifier as the type of the variable to be returned
public String methodThatReturnsAString() {
    // the method body, requires a return statement
}
A method that returns a double-precision number has the double modifier as the type of the variable to be returned.
public double methodThatReturnsADouble() {
    // the method body, requires a return statement
}

A string representation of an object and the toString-method
We are guilty of programming in a somewhat poor style by creating a method for printing the object, i.e., the printPerson method. A preferred way is to define a method for the object that returns a "string representation" of the object. The method returning the string representation is always toString in Java. Let's define this method for the person in the following example:
public class Person {
    // ...
    public String toString() {
        return this.name + ", age " + this.age + " years";
    }
}
The toString functions as printPerson does. However, it doesn't itself print anything but instead returns a string representation, which the calling method can execute for printing as needed.
The method is used in a somewhat surprising way:
public static void main(String[] args) {
    Person pekka = new Person("Pekka");
    Person antti = new Person("Antti");
    int i = 0;
    while (i < 30) {
        pekka.growOlder();
        i = i + 1;
    }
    antti.growOlder();
    System.out.println(antti); // same as System.out.println(antti.toString());
    System.out.println(pekka); // same as System.out.println(pekka.toString());
}
In principle, the System.out.println method requests the object's string representation and prints it. The call to the toString method returning the string representation does not have to be written explicitly, as Java adds it automatically. When a programmer writes:
System.out.println(antti);
Java extends the call at run time to the following form:
System.out.println(antti.toString());
As such, the call System.out.println(antti) calls the toString method of the antti object and prints the string returned by it.

Calling an internal method
The object may also call its methods. For example, if we wanted the string representation returned by toString to also tell of a person's body mass index, the object's own bodyMassIndex method should be called in the toString method:
public String toString() {
    return this.name + ", age " + this.age + " years, my body mass index is " + this.bodyMassIndex();
}
So, when an object calls an internal method, the name of the method and this prefix suffice. An alternative way is to call the object's own method in the form bodyMassIndex(), whereby no emphasis is placed on the fact that the object's own bodyMassIndex method is being called:
public String toString() {
    return this.name + ", age " + this.age + " years, my body mass index is " + bodyMassIndex();
}

Adding object to a list
In the example below we first create a list meant for storing Person type object, after which we add persons to it. Finally the person objects are printed one by one.
ArrayList<Person> persons = new ArrayList<>();
// a person object can be created first
Person john = new Person("John");
// and then added to the list
persons.add(john);
// person objects can also be created "in the same sentence" that they are added to the list
persons.add(new Person("Matthew"));
persons.add(new Person("Martin"));
for (Person person: persons) {
    System.out.println(person);
}
Sample output
John, age 0 years
Matthew, age 0 years
Martin, age 0 years