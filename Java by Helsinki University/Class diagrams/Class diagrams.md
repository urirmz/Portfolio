Describing class and class attributes
First we will describe one class and its attributes. Below is the source code for a class called Person which has two class attributes name and age.
public class Person {
    private String name;
    private int age;
}
In a class diagram, a class is represented by a rectangle with the name of the class written on top. A line below the name of the class divides the name from the list of attributes (names and types of the class variables). The attributes are written one attribute per line.
In a class diagram, class attributes are written "attributeName: attributeType". A + before the attribute name means the attribute is public, and a - means the attribute is private.
Describing class constructor
In a class diagram, we list the constructor (and all other methods) below the attributes. A line below the attributes list separates it from the method list. Methods are written with +/- (depending on the visibility of the method), method name, parameters, and their types. The constructor above is written +Person(initialName:String)
The parameters are written the same way class attributes are — "parameterName: parameterType".
Describing class methods
In a class diagram, we list all class methods including the constructors; constructors are listed first and then all class methods. We also write the return type of a method in the class diagram.

Connections between classes
In a class diagram, the connections between classes are shown as arrows. The arrows also show the direction of the connection. In a class diagram variables which refer to other objects are not written with the rest of the class attributes, but are shown as connections between the classes. In the class diagram below we have the classes Person and Book, and the connection between them.
The arrow shows the direction of the connection. The connection above shows that a Book knows its author but a Person does not know about books they are the author of. We can also add a label to the arrow to describe the connection. In the above diagram the arrow has an accompanying label telling us that a Book has an author.
If a book has multiple authors, the authors are saved to a list. In a class diagram, this situation is described by adding a star to the end of the arrow showing the connection between the classes. The star tells us that a book can have between 0 and unlimited number of authors. Below we have not amended the label to describe the multiplicity of the connection, but it would be a good idea for the sake of clarity.
If there is no arrowhead in a connection, both classes know about each other.

Inheritance
In a class diagram inheritance is described by an arrow with a triangle head. The triangle points to the class being inherited from. 
Inheritance of abstract classes is described almost the same way as regular classes. However we add the description <<abstract>> above the name of the class. The name of the class and its abstract methods are also written in cursive.

Describing interfaces
In class diagrams, interfaces are written <<interface>> NameOfTheInterface. Methods are described just like they are for a class. Implementing an interface is shown as a dashed arrow with a triangle arrowhead.