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

Reading From the Keyboard
We've been using the Scanner-class since the beginning of this course to read user input. The block in which data is read has been a while-true loop where the reading ends at a specific input.
Scanner scanner = new Scanner(System.in);
while (true) {
    String line = scanner.nextLine();

    if (line.equals("end")) {
        break;
    }

    // add the read line to a list for later
    // handling or handle the line immediately

}
In the example above, we pass system input (System.in) as a parameter to the constructor of the Scanner-class. In text-based user interfaces, the input of the user is directed into the input stream one line at a time, which means that the information is sent to be handled every time the user enters a new line.

The Concrete File Storage Format
Files exist on the hard drive of a computer, which is, in reality, a large set of ones and zeros, i.e., bits. Information is made up of these bits, e.g., one variable of type int takes up 32 bits (i.e., 32 ones or zeros). Modern terabyte-sized hard drives hold about 8 trillion bits (written out the number is 8,000,000,000,000). On this scale, a single integer is very small.
Files can exist practically anywhere on a hard drive, even separated into multiple pieces. The computer's filesystem has the responsibility of keeping track of the locations of files on the hard drive as well as providing the ability to create new files and modify them. The filesystem's main responsibility is abstracting the true structure of the hard drive; a user or a program using a file doesn't need to care about how, or where, the file is actually stored.

Reading From a File
Reading a file is done using the Scanner-class. When we want to read a file using the Scanner-class, we give the path for the file we want to read as a parameter to the constructor of the class. The path to the file can be acquired using Java's Paths.get command, which is given the file's name in string format as a parameter: Paths.get("filename.extension").
When the Scanner-object that reads the file has been created, the file can be read using a while-loop. The reading proceeds until all the lines of the file have been read, i.e., until the scanner finds no more lines to read. Reading a file may result in an error, and it's for this reason that the process requires separate blocks - one for the try, and another to catch potential errors. We'll be returning to the topic of error handling later.
// first
import java.util.Scanner;
import java.nio.file.Paths;
// in the program:
// we create a scanner for reading the file
try (Scanner scanner = new Scanner(Paths.get("file.txt"))) {

    // we read the file until all lines have been read
    while (scanner.hasNextLine()) {
        // we read one line
        String row = scanner.nextLine();
        // we print the line that we read
        System.out.println(row);
    }
} catch (Exception e) {
    System.out.println("Error: " + e.getMessage());
}
A file is read from the project root by default ( when new Scanner(Paths.get("file.txt")) is called), i.e., the folder that contains the folder src and the file pom.xml (and possibly other files as well). The contents of this folder can the inspected using the Files-tab in NetBeans.

An Empty Line In a File
Sometimes an empty line finds it way into a file. Skipping an empty line can be done using the command continue and the isEmpty-method of the string.
In the example below, we read from a file
Reading data is straightforward.
// we create a scanner for reading the file
try (Scanner scanner = new Scanner(Paths.get("henkilot.csv"))) {

    // we read all the lines of the file
    while (scanner.hasNextLine()) {
        String line = scanner.nextLine();

        // if the line is blank we do nothing
        if (line.isEmpty()) {
            continue;
        }

        // do something with the data

    }
} catch (Exception e) {
    System.out.println("Error: " + e.getMessage());
}

Reading Data of a Specific Format From a File
The world is full of data that are related to other data — these form collections. For example, personal information can include a name, date of birth and a phone number. Address information, on the other hand, can include a country, city, street address, postal number and so on.
Data is often stored in files using a specific format. One such format that's already familiar to us is comma-separated values (CSV) format, i.e., data separated by commas.
Scanner scanner = new Scanner(System.in);
while (true) {
    System.out.print("Enter name and age separated by a comma: ");
    String line = scanner.nextLine();
    if (line.equals("")) {
        break;
    }
    String[] parts = line.split(",");
    String name = parts[0];
    int age = Integer.valueOf(parts[1]);

    System.out.println("Name: " + name);
    System.out.println("Age: " + age);
}
The program works as follows:
Sample output
Enter name and age separated by a comma:
virpi,19
Name: virpi
Age: 19
Enter name and age separated by a comma:
jenna,21
Name: jenna
Age: 21
Enter name and age separated by a comma:
ada,20
Name: ada
Age: 20
Reading the same data from a file called records.txt would look like so:
try (Scanner scanner = new Scanner(Paths.get("records.txt"))) {
    while (scanner.hasNextLine()) {
        String line = scanner.nextLine();
        String[] parts = line.split(",");
        String name = parts[0];
        int age = Integer.valueOf(parts[1]);
        System.out.println("Name: " + name);
        System.out.println("Age: " + age);
    }
}