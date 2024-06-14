Class diagrams
A class diagram is a diagram used in designing and modeling software to describe classes and their relationships. Class diagrams enable us to model software in a high level of abstraction and without having to look at the source code.
Classes in a class diagram correspond with classes in the source code. The diagram shows the names and attributes of the classes, connections between the classes, and sometimes also the methods of the classes.
A class diagram describes classes, constructors and methods
A class diagram describes classes and their attributes, constructors and methods as well as the connections between classes. However a class diagram tells us nothing about the implementation of the constructors or the methods. Therefore a class diagram describes the structure of an object but not its functionality.
For example the method printPerson uses the class attributes name and age, but this cannot be seen from the class diagram.

Packages
As the number of classes implemented for the program grows, remembering all the functionality and methods becomes more difficult. What helps is naming the classes in a sensible manner and planning them so that each class has one clear responsibility. In addition to these measures, it's wise to divide the classes into packages. Classes in one package might share functionality, purpose, or some other logical property.
Packages are practically directories in which the source code files are organised.
IDEs offer existing tools for package management. Up until this point, we have only created classes and interfaces in the default package of the Source Packages folder of the project. You can create a new package in NetBeans by right-clicking on the Source Packages section (which contains the project's packages), and then selecting New -> Java Package....
You can create classes inside a package in the same way you can in the default package. Below we create the class Program in the newly created package library.
The package of a class (the package in which the class is stored) is noted at the beginning of the source code file with the statement package *name-of-package*;. Below, the class Program is in the package library.
package library;
public class Program {
    public static void main(String[] args) {
        System.out.println("Hello packageworld!");
    }
}
Every package, including the default package, may contain other packages. For instance, in the package definition package library.domain the package domain is inside the package library. The word domain is often used to refer to the storage space of the classes that represent the concepts of the problem domain. For example, the class Book could be inside the package library.domain, since it represents a concept in the library application.
package library.domain;
public class Book {
    private String name;
    public Book(String name) {
        this.name = name;
    }
    public String getName() {
        return this.name;
    }
}
A class can access classes inside a package by using the import statement. The class Book in the package library.domain is made available for use with the statement import library.domain.Book;. The import statements that are used to import classes are placed in the source code file after the package definition.
package library;
import library.domain.Book;
public class Program {
    public static void main(String[] args) {
        Book book = new Book("the ABCs of packages!");
        System.out.println("Hello packageworld: " + book.getName());
    }
}
Sample output
Hello packageworld: the ABCs of packages

Directory structure
The project directory src/main/java contains the source code files of the program. If the package of a class is library, that class is stored inside the src/main/java/libary folder of the source code directory.

Packages and access modifiers
The modifier private is used to define variables (and methods) that are only visible inside the class where they are defined. They cannot be used from outside that class. The methods and variables defined with public, on the other hand, are available for everyone to use.
If the access modifier is missing, the methods and variables are only visible inside the same package. We call this the default or package modifier.
The package structure of the program could look like the following (for example):
flightControl - includes the main program class that is needed to start the program
flightControl.domain - includes the classes that represent concepts of the problem domain: Airplane, Flight, and Place
flightControl.logic - includes the functionality that is used to control the application
flightControl.ui - includes the textual user interface

Exceptions
When program execution ends with an error, an exception is thrown. For example, a program might call a method with a null reference and throw a NullPointerException, or the program might try to refer to an element outside an array and result in an IndexOutOfBoundsException, and so on.

Handling exceptions
We use the try {} catch (Exception e) {} block structure to handle exceptions. The keyword try starts a block containing the code which might throw an exception. the block starting with the keyword catch defines what happens if an exception is thrown in the try block. The keyword catch is followed by the type of the exception handled by that block, for example "all exceptions" catch (Exception e).
try {
// code which possibly throws an exception
} catch (Exception e) {
// code block executed if an exception is thrown
}
We use the keyword catch, because causing an exception is referred to as throwing an exception.
As mentioned above, we do not have to prepare for runtime exceptions such as the NullPointerException. We do not have to handle these kinds of exceptions, so the program execution stops if an error causes the exception to be thrown. Next, we will look at one such situation, parsing strings to integers.
We have used the parseInt method of the Integer class before. The method throws a NumberFormatException if the string it has been given cannot be parsed into an integer.
Scanner reader = new Scanner(System.in);
System.out.print("Give a number: ");
int readNumber = Integer.parseInt(reader.nextLine());
Sample output
Give a number: dinosaur
Exception in thread "..." java.lang.NumberFormatException: For input string: "dinosaur"
The above program throws an error if the user input is not a valid number. The exception will cause the program execution to stop.
Let's handle the exception. We wrap the call that might throw an exception into a try block, and the code executed if the exception is thrown into a catch block.
Scanner reader = new Scanner(System.in);
System.out.print("Give a number: ");
int readNumber = -1;
try {
readNumber = Integer.parseInt(reader.nextLine());
} catch (Exception e) {
System.out.println("User input was not a number.");
}
Sample output
Give a number: 5
Sample output
Give a number: no!
User input was not a number.

Exceptions and resources
There is separate exception handling for reading operating system resources such as files. With so called try-with-resources exception handling, the resource to be opened is added to a non-compulsory part of the try block declaration in brackets.
The code below reads all lines from "file.txt" and adds them to an ArrayList. Reading a file might throw an exception, so it requires a try-catch block.
ArrayList<String> lines =  new ArrayList<>();
// create a Scanner object for reading files
try (Scanner reader = new Scanner(new File("file.txt"))) {

    // read all lines from a file
    while (reader.hasNextLine()) {
        lines.add(reader.nextLine());
    }
} catch (Exception e) {
System.out.println("Error: " + e.getMessage());
}
// do something with the lines
The try-with-resources approach is useful for handling resources, because the program closes the used resources automatically. Now references to files can "disappear", because we do not need them anymore. If the resources are not closed, the operating system sees them as being in use until the program is closed.

Shifting the responsibility
Methods and constructors can throw exceptions. There are roughly two categories of exceptions. There are exceptions we have to handle, and exceptions we do not have to handle. We can handle exceptions by wrapping the code into a try-catch block or throwing them out of the method.
The code below reads the file given to it as a parameter line by line. Reading a file can throw an exception — for example, the file might not exist or the program does not have read rights to the file. This kind of exception has to be handled. We handle the exception by wrapping the code into a try-catch block. In this example we do not really care about the exception, but we do print a message to the user about it.
public List<String> readLines(String fileName){
List<String> lines =  new ArrayList<>();
    try {
        Files.lines(Paths.get("file.txt")).forEach(line -> lines.add(line));
    } catch (Exception e) {
        System.out.println("Error: " + e.getMessage());
    }

    return lines;
}
A programmer can also leave the exception unhandled and shift the responsibility for handling it to whomever calls the method. We can shift the responsibility of handling an exception forward by throwing the exception out of a method, and adding notice of this to the declaration of the method. Notice on throwing an exception forward throws *ExceptionType* is added before the opening bracket of a method.
public List<String> readLines(String fileName) throws Exception {
ArrayList<String> lines =  new ArrayList<>();
Files.lines(Paths.get(fileName)).forEach(line -> lines.add(line));
return lines;
}
Now the method calling the readLines method has to either handle the exception in a try-catch block or shift the responsibility yet forward. Sometimes the responsibility of handling exceptions is avoided until the end, and even the main method can throw an exception to the caller:
public class MainProgram {
public static void main(String[] args) throws Exception {
// ...
}
}
Now the exception is thrown to the program executor, or the Java virtual machine. It stops the program execution when an error causing an exception to be thrown occurs.

Throwing exceptions
The throw command throws an exception. For example a NumberFormatException can be done with command throw new NumberFormatException(). The following code always throws an exception.
public class Program {
    public static void main(String[] args) throws Exception {
        throw new NumberFormatException(); // Program throws an exception
    }
}
One exception that the user does not have to prepare for is IllegalArgumentException. The IllegalArgumentException tells the user that the values given to a method or a constructor as parameters are wrong. It can be used when we want to ensure certain parameter values.
Let's create class Grade. It gets an integer representing a grade as a constructor parameter.
public class Grade {
private int grade;
    public Grade(int grade) {
        this.grade = grade;
    }
    public int getGrade() {
        return this.grade;
    }
}
We want that the grade fills certain criteria. The grade has to be an integer between 0 and 5. If it is something else, we want to throw an exception. Let's add a conditional statement to the constructor, which checks if the grade fills the criteria. If it does not, we throw the IllegalArgumentException with throw new IllegalArgumentException("Grade must be between 0 and 5.");.
public class Grade {
private int grade;
    public Grade(int grade) {
        if (grade < 0 || grade > 5) {
            throw new IllegalArgumentException("Grade must be between 0 and 5.");
        }
        this.grade = grade;
    }
    public int getGrade() {
        return this.grade;
    }
}
Grade grade = new Grade(3);
System.out.println(grade.getGrade());
Grade illegalGrade = new Grade(22);
// exception happens, execution will not continue from here
Sample output
3
Exception in thread "..." java.lang.IllegalArgumentException: Grade must be between 0 and 5.
If an exception is a runtime exception, e.g. IllegalArgumentException, we do not have to warn about throwing it on the method declaration.

Exceptions and Interfaces
An Interface can have methods which throw an exception. For example the classes implementing the following FileServer interface might throw an exception from the methods load or save.
public interface FileServer {
String load(String fileName) throws Exception;
void save(String fileName, String textToSave) throws Exception;
}
If an interface declares a throws Exception attribute to a method, so that these methods might throw an exception, the class implementing this interface must also have this attribute. However the class does not have to throw an error, as we can see below.
public class TextServer implements FileServer {
    private Map<String, String> data;
    public TextServer() {
        this.data = new HashMap<>();
    }
    @Override
    public String load(String fileName) throws Exception {
        return this.data.get(fileName);
    }
    @Override
    public void save(String fileName, String textToSave) throws Exception {
        this.data.put(fileName, textToSave);
    }
}

Details of the exception
A catch block defines which exception to prepare for with catch (Exception e). The details of the exception are saved to the e variable.
try {
// program code which might throw an exception
} catch (Exception e) {
// details of the exception are stored in the variable e
}
The Exception class has some useful methods. For example printStackTrace() prints the stack trace, which shows how we ended up with an exception. Below is a stack trace printed by the printStackTrace() method.
Sample output
Exception in thread "main" java.lang.NullPointerException
at package.Class.print(Class.java:43)
at package.Class.main(Class.java:29)
We read a stack trace from the bottom up. At the bottom is the first call, so the execution of the program has begun from the main() method of the Class class. Line 29 of the main method of the Class class calls the print() method. Line 43 of the print method has thrown a NullPointerException exception. The details of an exception are very useful when trying to pinpoint where an error happens.

Processing files
The PrintWriter class offers the functionality to write to files. The constructor of the PrintWriter class receives as its parameter a string that represents the location of the target file.
PrintWriter writer = new PrintWriter("file.txt");
writer.println("Hello file!"); //writes the string "Hello file!" and line change to the file
writer.println("More text");
writer.print("And a little extra"); // writes the string "And a little extra" to the file without a line change
writer.close(); //closes the file and ensures that the written text is saved to the file
The constructor of the PrintWriter class might throw an exception that must be either handled or thrown so that it is the responsibility of the calling method