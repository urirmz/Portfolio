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