Object-oriented programming
Object-oriented programming is primarily about isolating concepts into their own entities or, in other words, creating abstractions.
Separating a concept into its own class is a good idea for many reasons. Firstly, certain details can be hidden inside the class (i.e., abstracted). That is, a class created from a distinct concept can serve multiple purposes. Another massive advantage is that since the details of the implementation of class are not visible to its user, they can be changed if desired. We realized that the clock contains three hands, i.e., it consists of three concepts. The clock is a concept in and of itself. As such, we can create a class for it too. Next, we create a class called "Clock" that hides the hands inside of it.
This is precisely the great idea behind ​​object-oriented programming: a program is built from small and distinct objects that work together

Object
An Object refers to an independent entity that contains both data (instance variables) and behavior (methods). Objects may come in lots of different forms: some may describe problem-domain concepts, others are used to coordinate the interaction that happens between objects. Objects interact with one another through method calls — these method calls are used to both request information from objects and give instructions to them.
Generally, each object has clearly defined boundaries and behaviors and is only aware of the objects that it needs to perform its task. In other words, the object hides its internal operations, providing access to its functionality through clearly defined methods. Moreover, the object is independent of any other object that it doesn't require to accomplish its task.
The state of an object is the value of its internal variables at any given point in time.

Class
A class defines the types of objects that can be created from it. It contains instance variables describing the object's data, a constructor or constructors used to create it, and methods that define its behavior
A class contains the blueprint needed to create objects, and also defines the objects' variables and methods. An object is created on the basis of the class constructor.

Constructor Overloading
We would also like to be able to create persons so that the constructor is provided both the age as well as the name as parameters. This is possible since a class may have multiple constructors.
Let's make an alternative constructor. The old constructor can remain in place.
public Person(String name) {
        this.name = name;
        this.age = 0;
        this.weight = 0;
        this.height = 0;
    }
public Person(String name, int age) {
    this.name = name;
    this.age = age;
    this.weight = 0;
    this.height = 0;
}
We now have two alternative ways to create objects:
public static void main(String[] args) {
    Person paul = new Person("Paul", 24);
    Person ada = new Person("Ada");
    System.out.println(paul);
    System.out.println(ada);
}
Sample output
Paul is 24 years old.
Ada is 0 years old.
The technique of having two (or more) constructors in a class is known as constructor overloading. A class can have multiple constructors that differ in the number and/or type of their parameters. It's not, however, possible to have two constructors with the exact same parameters.

Calling Your Constructor
Hold on a moment. We'd previously concluded that "copy-paste" code is not a good idea. When you look at the overloaded constructors above, however, they have a lot in common. We're not happy with this.
The first constructor - the one that receives a name as a parameter - is in fact a special case of the second constructor - the one that's given both name and age. What if the first constructor could call the second constructor?
This is possible. A constructor can be called from another constructor using the this keyword, which refers to this object in question!
Let's modify the first constructor so that it does not do anything by itself, but instead calls the second constructor and asks it to set the age to 0.
public Person(String name) {
    this(name, 0);
    //here the code of the second constructor is run, and the age is set to 0
}
public Person(String name, int age) {
    this.name = name;
    this.age = age;
    this.weight = 0;
    this.height = 0;
}
The constructor call this(name, 0); might seem a bit weird. A way to think about it is to imagine that the call is automatically replaced with "copy-paste" of the second constructor in such a way that the age parameter is set to 0. NB! If a constructor calls another constructor, the constructor call must be the first command in the constructor.
New objects can be created just as before:
public static void main(String[] args) {
    Person paul = new Person("Paul", 24);
    Person eve = new Person("Eve");

    System.out.println(paul);
    System.out.println(eve);
}
Sample output
Paul is 24 years old.
Eve is 0 years old.

Method Overloading
Methods can be overloaded in the same way as constructors, i.e., multiple versions of a given method can be created. Once again, the parameters of the different versions must be different. Let's make another version of the growOlder method that ages the person by the amount of years given to it as a parameter.
public void growOlder() {
    this.age = this.age + 1;
}
public void growOlder(int years) {
    this.age = this.age + years;
}
In the example below, "Paul" is born 24 years old, ages by a year and then by 10 years:
public static void main(String[] args) {
    Person paul = new Person("Paul", 24);
    System.out.println(paul);
    paul.growOlder();
    System.out.println(paul);
    paul.growOlder(10);
    System.out.println(paul);
}
Prints:
Sample output
Paul is 24 years old.
Paul is 25 years old.
Paul is 35 years old.
A Person now has two methods, both called growOlder. The one that gets executed depends on the number of parameters provided.
We may also modify the program so that the parameterless method is implemented using the method growOlder(int years):
public void growOlder() {
    this.growOlder(1);
}
public void growOlder(int years) {
    this.age = this.age + years;
}

Primitive and reference variables
Variables in Java are classified into primitive and reference variables. From the programmer's perspective, a primitive variable's information is stored as the value of that variable, whereas a reference variable holds a reference to information related to that variable. Reference variables are practically always objects in Java. Let's take a look at both of these types with the help of two examples.
int value = 10;
System.out.println(value);
Sample output
10
public class Name {
    private String name;

    public Name(String name) {
        this.name = name;
    }
}
Name luke = new Name("Luke");
System.out.println(luke);
Sample output
Name@4aa298b7
In the first example, we create a primitive int variable, and the number 10 is stored as its value. When we pass the variable to the System.out.println method, the number 10 is printed. In the second example, we create a reference variable called luke. A reference to an object is returned by the constructor of the Name class when we call it, and this reference is stored as the value of the variable. When we print the variable, we get Name@4aa298b7 as output. What is causing this?
The method call System.out.println prints the value of the variable. The value of a primitive variable is concrete, whereas the value of a reference variable is a reference. When we attempt to print the value of a reference variable, the output contains the type of the variable and an identifier created for it by Java: the string Name@4aa298b7 tells us that the given variable is of type Name and its identifier is 4aa298b7.

Primitive Variables
Java has eight different primitive variables. These are: boolean (a truth value: either true or false), byte (a byte containing 8 bits, between the values -128 and 127), char (a 16-bit value representing a single character), short (a 16-bit value that represents a small integer, between the values -32768 and 32767), int (a 32-bit value that represents a medium-sized integer, between the values -231 and 231-1), long (a 64-bit value that represents a large integer, between values -263 and 263-1), float (a floating-point number that uses 32 bits), and double (a floating-point number that uses 64 bits).
Declaring a primitive variable causes the computer to reserve some memory where the value assigned to the variable can be stored. The size of the storage container reserved depends on type of the primitive.
int first = 10;
int second = first;
int third = second;
System.out.println(first + " " + second + " " + third);
second = 5;
System.out.println(first + " " + second + " " + third);
10 10 10
10 5 10
The name of the variable tells the memory location where its value is stored. When you assign a value to a primitive variable with an equality sign, the value on the right side is copied to the memory location indicated by the name of the variable. For example, the statement int first = 10 reserves a location called first for the variable, and then copies the value 10 into it.
Similarly, the statement int second = first; reserves in memory a location called second for the variable being created and then copies into it the value stored in the location of variable first.

Reference Variables
All of the variables provided by Java (other than the eight primitive variables mentioned above) are reference type. A programmer is also free to create their own variable types by defining new classes. In practice, any object instanced from a class is a reference variable.

Differences betwen reference and primite variables
The most significant difference between primitive and reference variables is that primitives (usually numbers) are immutable. The internal state of reference variables, on the other hand, can typically be mutated. This has to do with the fact that the value of a primitive variable is stored directly in the variable, whereas the value of a reference variable is a reference to the variable's data, i.e., its internal state.
Arithmetic operations, such as addition, subtraction, and multiplication can be used with primitive variables — these operations do not change the original values of the variables. Arithmetic operations create new values that can be stored in variables as needed. Conversely, the values of reference variables cannot be changed by these arithmetic expressions.
The value of a reference variable — i.e., the reference — points to a location that contains information relating to the given variable. Let's assume that we have a Person class available to us, containing an instance variable 'age'. If we've instantiated a person object from the class, we can get our hands on the age variable by following the object's reference. The value of this age variable can then be changed as needed.

Primitive and Reference Variable as Method Parameters
assigning a value with the equality sign copies the value (possibly of some variable) on the right-hand side and stores it as the value of the left-hand side variable.

Primitive and Reference Variable as Method Parameters
A similar kind of copying occurs during a method call. Regardless of whether the variable is primitive or reference type, the value passed to the method as an argument is copied for the called method to use. With primitive variables, the value of the variable is conveyed to the method. With reference variables, it's a reference.
Let's look at this in practice and assume that we have the following Person class available to us.
public class Person {
    private String name;
    private int birthYear;
    public Person(String name) {
        this.name = name;
        this.birthYear = 1970;
    }
    public int getBirthYear() {
        return this.birthYear;
    }
    public void setBirthYear(int birthYear) {
        this.birthYear = birthYear;
    }
    public String toString() {
        return this.name + " (" + this.birthYear + ")";
    }
}
We'll inspect the execution of the program step by step.
public class Example {
    public static void main(String[] args) {
        Person first = new Person("First");
        System.out.println(first);
        youthen(first);
        System.out.println(first);
        Person second = first;
        youthen(second);
        System.out.println(first);
    }
    public static void youthen(Person person) {
        person.setBirthYear(person.getBirthYear() + 1);
    }
}
Sample output
First (1970)
First (1971)
First (1972)
The program's execution starts off from the first line of the main method. A variable of type Person is declared on its first line, and the value returned by the Person class constructor is copied as its value. The constructor creates an object whose birth year is set to 1970 and whose name is set to the value received as a parameter. The constructor returns a reference. Once the row has been executed, the program's state is the following — a Person object has been created in memory and the first variable defined in the main method contains a reference to it.

Objects and references
Calling a constructor with the command new causes several things to happen. First, space is reserved in the computer memory for storing object variables. Then default or initial values are set to object variables (e.g. an int type variable receives an initial value of 0). Lastly, the source code in the constructor is executed.
A constructor call returns a reference to an object. A reference is information about the location of object data.

Assigning a reference type variable copies the reference
Let's add a Person type variable called ball into the program, and assign joan as its initial value. What happens then?
Person joan = new Person("Joan Ball");
System.out.println(joan);
Person ball = joan;
The statement Person ball = joan; creates a new Person variable ball, and copies the value of the variable joan as its value. As a result, ball refers to the same object as joan.
Let's inspect the same example a little more thoroughly.
Person joan = new Person("Joan Ball");
System.out.println(joan);
Person ball = joan;
ball.growOlder();
ball.growOlder();
System.out.println(joan);
Sample output
Joan Ball, age 0 years
Joan Ball, age 2 years
Joan Ball — i.e. the Person object that the reference in the joan variable points at — starts as 0 years old. After this the value of the joan variable is assigned (so copied) to the ball variable. The Person object ball is aged by two years, and Joan Ball ages as a consequence!
An object's internal state is not copied when a variable's value is assigned. A new object is not being created in the statement Person ball = joan; — the value of the variable ball is assigned to be the copy of joan's value, i.e. a reference to an object.
Next, the example is continued so that a new object is created for the joan variable, and a reference to it is assigned as the value of the variable. The variable ball still refers to the object that we created earlier.
Person joan = new Person("Joan Ball");
System.out.println(joan);
Person ball = joan;
ball.growOlder();
ball.growOlder();
System.out.println(joan);
joan = new Person("Joan B.");
System.out.println(joan);
The following is printed:
Sample output
Joan Ball, age 0 years
Joan Ball, age 2 years
Joan B., age 0 years
So in the beginning the variable joan contains a reference to one object, but in the end a reference to another object has been copied as its value.

null value of a reference variable
Let's extend the example further by setting the value of the reference variable ball to null, i.e. a reference "to nothing". The null reference can be set as the value of any reference type variable.
Person joan = new Person("Joan Ball");
System.out.println(joan);
Person ball = joan;
ball.growOlder();
ball.growOlder();
System.out.println(joan);
joan = new Person("Joan B.");
System.out.println(joan);
ball = null;
The object whose name is Joan Ball is referred to by nobody. In other words, the object has become "garbage". In the Java programming language the programmer need not worry about the program's memory use. From time to time, the automatic garbage collector of the Java language cleans up the objects that have become garbage. If the garbage collection did not happen, the garbage objects would reserve a memory location until the end of the program execution.
Let's see what happens when we try to print a variable that references "nothing" i.e. null.
Person joan = new Person("Joan Ball");
System.out.println(joan);
Person ball = joan;
ball.growOlder();
ball.growOlder();
System.out.println(joan);
joan = new Person("Joan B.");
System.out.println(joan);
ball = null;
System.out.println(ball);
Sample output
Joan Ball, age 0 years
Joan Ball, age 2 years
Joan B., age 0 years
null
Printing a null reference prints "null". How about if we were to try and call a method, say growOlder, on an object that refers to nothing:
Person joan = new Person("Joan Ball");
System.out.println(joan);
joan = null;
joan.growOlder();
The result:
Sample output
Joan Ball, age 0 years
Exception in thread "main" java.lang.NullPointerException
at Main.main(Main.java:(row))
Java Result: 1
Bad things follow. This could be the first time you have seen the text NullPointerException. In the course of the program, there occured an error indicating that we called a method on a variable that refers to nothing.

Object as a method parameter
We have seen both primitive and reference variables act as method parameters. Since objects are reference variables, any type of object can be defined to be a method parameter

Assisted creation of constructors, getters, and setters
Development environments can help the programmer. If you have created object variables for a class, creating constructors, getters, and setters can be done almost automatically.
Go inside the code block of the class, but outside of all the methods, and simultaneously press ctrl and space. If your class has e.g. an object variable balance, NetBeans offers the option to generate the getter and setter methods for the object variable, and a constuctor that assigns an initial value for that variable.

Object as object variable
Objects may contain references to objects.

Date in Java programs
If you want to handle dates in your own programs, it's worth reading about the premade Java class LocalDate. It contains a significant amount of functionality that can be used to handle dates.
For example, the current date can be used with the existing LocalDate class in the following manner:
import java.time.LocalDate;
public class Example {

    public static void main(String[] args) {

        LocalDate now = LocalDate.now();
        int year = now.getYear();
        int month = now.getMonthValue();
        int day = now.getDayOfMonth();

        System.out.println("today is  " + day + "." + month + "." + year);

    }
}

Object of same type as method parameter
The idea behind abstraction is to conceptualize the programming code so that each concept has its own clear responsibilities.
A private variable can be accessed from all the methods contained by that class.