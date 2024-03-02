A Programmer Blind to Their Own Code
A programmer often becomes blind to their code. Concentrating on a specific part of a study exercise can lead to relevant information being filtered out. One way in which perceptual blindness manifests itself in programming practice is when concentrating on a specific part of a program draws attention away from seemingly correct, yet erroneous parts. For instance, while inspecting the correctness of a program's output, a programmer may fixate on the print statements, and mistakenly neglect some aspects of the logic.

Commenting the Source Code
Comments have many purposes, and one of them is explaining how the code works to oneself when searching for bugs.
The goal is for the source code to be self documenting. This means that the functionality of the program should be evident from the way classes, methods, and variables are named.

Searching for Errors with Print Debugging
One required skill in programming is the ability to test and debug when searching for errors. The simplest way to search for errors is to use so-called print debugging, which in practice involves adding messages to certain lines of code. These messages are used to follow the flow of the program's execution, and can also contain values of variables that live in the program.
When a program is executed multiple times with appropriate inputs the hidden error is often found. Coming up with relevant inputs is a skill in its own right. It's essential to test the so-called corner cases, i.e., circumstances where the program execution could be exceptional. 

Lists
Programming languages offer tools to assist in storing a large quantity of values. We will next take a peek at perhaps the single most used tool in Java, the ArrayList, which is used for storing many values that are of the same type.
ArrayList is a pre-made tool in Java that helps dealing with lists. It offers various methods, including ones for adding values to the list, removing values from it, and also for the retrieval of a value from a specific place in the list.

Using and Creating Lists
For an ArrayList to be used, it first needs be imported into the program. This is achieved by including the command import java.util.ArrayList; at the top of the program. Below is an example program where an ArrayList is imported into the program.
// import the list to make it available to the program
import java.util.ArrayList;
public class Program {
    public static void main(String[] args) {
        // no implementation yet
    }
}
Creating a new list is done with the command ArrayList<Type> list = new ArrayList<>(), where Type is the type of the values to be stored in the list (e.g. String). We create a list for storing strings in the example below.
// import the list so the program can use it
import java.util.ArrayList;
public class Program {
    public static void main(String[] args) {
        // create a list
        ArrayList<String> list = new ArrayList<>();
        // the list isn't used yet
    }
}
The type of the ArrayList variable is ArrayList. When a list variable is initialized, the type of the values to be stored is also defined in addition to the variable type — all the variables stored in a given list are of the same type. 

Defining the Type of Values That a List Can Contain
When defining the type of values that a list can include, the first letter of the element type has to be capitalized. A list that includes int-type variables has to be defined in the form ArrayList<Integer>; and a list that includes double-type variables is defined in the form ArrayList<Double>.
The reason for this has to do with how the ArrayList is implemented. Variables in Java can be divided into two categories: value type (primitive) and reference type (reference type) variables. Value-type variables such as int or double hold their actual values. Reference-type variables such as ArrayList, in contrast, contain a reference to the location that contains the value(s) relating to that variable.
Value-type variables can hold a very limited amount of information, whereas references can store a near limitless amount of it.
You'll find examples below of creating lists that contain different types of values.
ArrayList<Integer> list = new ArrayList<>();
list.add(1);
ArrayList<Double> list = new ArrayList<>();
list.add(4.2);
ArrayList<Boolean> list = new ArrayList<>();
list.add(true);

Adding to a List and Retrieving a Value from a Specific Place
The next example demonstrates the addition of a few strings into an ArrayList containing strings. Addition is done with the list method add, which takes the value to be added as a parameter. We then print the value at position zero. To retrieve a value from a certain position, you use the list method get, which is given the place of retrieval as a parameter.
To call a list method you first write the name of the variable describing the list, followed by a dot and the name of the method.
// import list so that the program can use it
import java.util.ArrayList;
public class WordListExample {
    public static void main(String[] args) {
        // create the word list for storing strings
        ArrayList<String> wordList = new ArrayList<>();
        // add two values to the word list
        wordList.add("First");
        wordList.add("Second");
        // retrieve the value from position 0 of the word list, and print it
        System.out.println(wordList.get(0));
    }
}
Sample output
First

Retrieving Information from a "Non-Existent" Place
If you try to retrieve information from a place that does not exist on the list, the program will print a IndexOutOfBoundsException error. In the example below, two values are added to a list, after which there is an attempt to print the value at place two on the list.
import java.util.ArrayList;
public class Example {
    public static void main(String[] args) {
        ArrayList<String> wordList = new ArrayList<>();

        wordList.add("First");
        wordList.add("Second");

        System.out.println(wordList.get(2));
    }
}
Since the numbering (i.e., indexing) of the list elements starts with zero, the program isn't able to find anything at place two and its execution ends with an error.
Below is a description of the error message caused by the program. Sample output
Exception in thread "main" java.lang.IndexOutOfBoundsException: Index: 2, Size: 2
at java.util.ArrayList.rangeCheck(ArrayList.java:653)
at java.util.ArrayList.get(ArrayList.java:429)
at Example.main(Example.java:(line))
Java Result: 1
The error message provides hints of the internal implementation of an ArrayList object. It lists all the methods that were called leading up to the error. First, the program called the main method, whereupon ArrayList's get method was called. Subsequently, the get method of ArrayList called the rangeCheck method, in which the error occurred. This also acts as a good illustration of proper method naming. Even if we'd never heard of the rangeCheck method, we'd have good reason to guess that it checks if a searched place is contained within a given desired range. The error likely occurred because this was not the case.

A Place in a List Is Called an Index
Numbering places, i.e., indexing, always begins with zero. The list's first value is located at index 0, the second value at index 1, the third value at index 2, and so on. In programs, an index is denoted with a variable called i.