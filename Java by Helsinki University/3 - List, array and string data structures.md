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

Importing multiple premade Java tools into the program
Each tool offered by Java has a name and location. The program can use a tool after it has been imported with the import command. The command is given the location and the name of the desired class. For example, the use of an ArrayList necessitates placing the command import java.util.ArrayList; to the top of the program.
import java.util.ArrayList;
public class ListProgram {

    public static void main(String[] args) {
        ArrayList<String> wordList = new ArrayList<>();

        wordList.add("First");
        wordList.add("Second");
    }
}

Iterating Over a List
The number of values on a list is provided by the list's size method which returns the number of elements the list contains. The number is an integer (int), and it can be used as a part of an expression or stored in an integer variable for later use.
ArrayList<String> list = new ArrayList<>();
System.out.println("Number of values on the list: " + list.size());
list.add("First");
System.out.println("Number of values on the list: " + list.size());
int values = list.size();
list.add("Second");
System.out.println("Number of values on the list: " + values);
Sample output
Number of values on the list: 0
Number of values on the list: 1
Number of values on the list: 1

Iterating Over a List Continued
We can convert the if statements into a while loop that is repeated until the condition index < teachers.size() no longer holds (i.e., the value of the variable index grows too great).
ArrayList<String> teachers = new ArrayList<>();
teachers.add("Simon");
teachers.add("Samuel");
teachers.add("Ann");
teachers.add("Anna");
int index = 0;
// Repeat for as long as the value of the variable `index`
// is smaller than the size of the teachers list
while (index < teachers.size()) {
    System.out.println(teachers.get(index));
    index = index + 1;
}
Now the printing works regardless of the number of elements.
The for-loop we inspected earlier used to iterate over a known number of elements is extremely handy here. We can convert the loop above to a for-loop, after which the program looks like this.
ArrayList<String> teachers = new ArrayList<>();
teachers.add("Simon");
teachers.add("Samuel");
teachers.add("Ann");
teachers.add("Anna");
for (int index = 0; index < teachers.size(); index++) {
    System.out.println(teachers.get(index));
}
Sample output
Simon
Samuel
Ann
Anna
The index variable of the for-loop is typically labelled i:
for (int i = 0; i < teachers.size(); i++) {
    System.out.println(teachers.get(i));
}

Iterating Over a List with a For-Each Loop
If you don't need to keep track of the index as you're going through a list's values, you can make use of the for-each loop. It differs from the previous loops in that it has no separate condition for repeating or incrementing.
ArrayList<String> teachers = new ArrayList<>();
teachers.add("Simon");
teachers.add("Samuel");
teachers.add("Ann");
teachers.add("Anna");
for (String teacher: teachers) {
    System.out.println(teacher);
}
In practical terms, the for-each loop described above hides some parts of the for-loop we practiced earlier. The for-each loop would look like this if implemented as a for-loop:
ArrayList<String> teachers = new ArrayList<>();
teachers.add("Simon");
teachers.add("Samuel");
teachers.add("Ann");
teachers.add("Anna");
for (int i = 0; i < teachers.size(); i++) {
    String teacher = teachers.get(i);
    // contents of the for each loop:
    System.out.println(teacher);
}
In practice, the for-each loop examines the values of the list in order one at a time. The expression is defined in the following format: for (TypeOfVariable nameOfVariable: nameOfList), where TypeOfVariable is the list's element type, and nameOfVariable is the variable that is used to store each value in the list as we go through it.

Removing from a List
The list's remove method removes the value that is located at the index that's given as the parameter. The parameter is an integer.
ArrayList<String> list = new ArrayList<>();
list.add("First");
list.add("Second");
list.add("Third");
list.remove(1);
System.out.println("Index 0 so the first value: " + list.get(0));
System.out.println("Index 1 so the second value: " + list.get(1));
Sample output
Index 0 so the first value: First
Index 1 so the second value: Third
If the parameter given to remove is the same type as the values in the list, but not an integer, (integers are used to remove from a given index), it can be used to remove a value directly from the list.
ArrayList<String> list = new ArrayList<>();
list.add("First");
list.add("Second");
list.add("Third");
list.remove("First");
System.out.println("Index 0 so the first value: " + list.get(0));
System.out.println("Index 1 so the second value: " + list.get(1));
Sample output
Index 0 so the first value: Second
Index 1 so the second value: Third
If the list contains integers, you cannot remove a number value by giving an int type parameter to the remove method. This would remove the number from the index that the parameter indicates, instead of an element on the list that has the same value as the parameter. To remove an integer type value you can convert the parameter to Integer type; this is achieved by the valueOf method of the Integer class.
ArrayList<Integer> list = new ArrayList<>();
list.add(15);
list.add(18);
list.add(21);
list.add(24);
list.remove(2);
list.remove(Integer.valueOf(15));
System.out.println("Index 0 so the first value: " + list.get(0));
System.out.println("Index 1 so the second value: " + list.get(1));
Sample output
Index 0 so the first value: 18
Index 1 so the second value: 24

Checking the Existence of a Value
The list method contains can be used to check the existence of a value in the list. The method receives the value to be searched as its parameter, and it returns a boolean type value (true or false) that indicates whether or not that value is stored in the list.
ArrayList<String> list = new ArrayList<>();
list.add("First");
list.add("Second");
list.add("Third");
System.out.println("Is the first found? " + list.contains("First"));
boolean found = list.contains("Second");
if (found) {
    System.out.println("Second was found");
}
// or more simply
if (list.contains("Second")) {
    System.out.println("Second can still be found");
}
Sample output
Is the first found? true
Second was found
Second can still be found

List as a Method Parameter
Like other variables, a list can be used as a parameter to a method too. When the method is defined to take a list as a parameter, the type of the parameter is defined as the type of the list and the type of the values contained in that list. Below, the method print prints the values in the list one by one.
public static void print(ArrayList<String> list) {
    for (String value: list) {
        System.out.println(value);
    }
}
We're by now familiar with methods, and it works in the same way here. In the example below we use the print method that was implemented above.
ArrayList<String> strings = new ArrayList<>();
strings.add("First");
strings.add("Second");
strings.add("Third");
print(strings);
Sample output
First
Second
Third

On Copying the List to a Method Parameter
Earlier we have used integers, floating point numbers, etc. as method parameters. When variables such as int are used as method parameters, the value of the variable is copied for the method's use. The same occurs in the case that the parameter is a list.
Lists, among practically all the variables that can store large amounts of information, are reference-type variables. This means that the value of the variable is a reference that points to the location that contains the information.
When a list (or any reference-type variable) is copied for a method's use, the method receives the value of the list variable, i.e., a reference. In such a case the method receives a reference to the real value of a reference-type variable, and the method is able to modify the value of the original reference type variable, such as a list. In practice, the list that the method receives as a parameter is the same list that is used in the program that calls the method.
Let's look at this briefly with the following method.
public static void removeFirst(ArrayList<Integer> numbers) {
    if (numbers.size() == 0) {
        return;
    }

    numbers.remove(0);
}
ArrayList<Integer> numbers = new ArrayList<>();
numbers.add(3);
numbers.add(2);
numbers.add(6);
numbers.add(-1);
System.out.println(numbers);
removeFirst(numbers);
System.out.println(numbers);
removeFirst(numbers);
removeFirst(numbers);
removeFirst(numbers);
System.out.println(numbers);
Sample output
[3, 2, 6, -1]
[2, 6, -1]
[]

Arrays
From the point of view of the programmer, the size of the ArrayList is unlimited. In reality there are no magic tricks in the ArrayList — they have been programmed like any other programs or tools offered by the programming language. When you create a list, a limited space is reserved in the memory of the computer. When the ArrayList runs out of space, a larger space is reserved and the data from the previous space is copied to the new one.
Even though the ArrayList is simple to use, sometimes we need the ancestor of the ArrayList, the Array.
An Array contains a limited amount of numbered spots (indices) for values. The length (or size) of an Array is the amount of these spots, i.e. how many values can you place in the Array. The values in an Array are called elements.

Creating an Array
There are two ways to create an Array. In the first one you have to explicitly define the size upon the creating. This is how you create an Array to hold three integers:
int[] numbers = new int[3];
An array is declared by adding square brackets after the type of the elements it contains (typeofelements[]). A new Array is created by calling new followed by the type of the elements, square brackets and the number of the elements in the square brackets.
An Array to hold 5 Strings can be created like this:
String[] strings = new String[5];

Assigning and accessing elements
An element of an Array is referred to by its index. In the example below we create an Array to hold 3 integers, and then assign values to indices 0 and 2. After that we print the values.
int[] numbers = new int[3];
numbers[0] = 2;
numbers[2] = 5;
System.out.println(numbers[0]);
System.out.println(numbers[2]);
Assigning a value to a specific spot of an Array works much like assigning a value in a normal variable, but in the Array you must specify the index, i.e. to which spot you want to assign the value. The index is specified in square brackets. The ArrayList get-method works very similarly to accessing an element of an Array. Just the syntax, i.e. the way things are written, is different.
The index is an integer, and its value is between [0, length of the Array - 1]. For example an Array to hold 5 elements has indices 0, 1, 2, 3, and 4.
Scanner reader = new Scanner(System.in);
int[] numbers = new int[5];
numbers[0] = 42;
numbers[1] = 13;
numbers[2] = 12;
numbers[3] = 7;
numbers[4] = 1;
System.out.println("Which index should we access? ");
int index = Integer.valueOf(reader.nextLine());
System.out.println(numbers[index]);
The value held in an Array can also be assigned to be the value of another variable.
Scanner reader = new Scanner(System.in);
int[] numbers = new int[5];
numbers[0] = 42;
numbers[1] = 13;
numbers[2] = 12;
numbers[3] = 7;
numbers[4] = 1;
System.out.println("Which index should we access? ");
int index = Integer.valueOf(reader.nextLine());
int number = numbers[index];
System.out.println(number);
If the index is pointing outside the Array, i.e. the element doesn't exist, we get an ArrayIndexOutOfBoundsException. This error tells, that the Array doesn't contain the given index. You cannot access outside of the Array, i.e. index that's less than 0 or greater or equal to the size of the Array.

Type of the elements
You can create an array stating the type of the elements of the array followed by square brackets (typeofelements[]). Therefore the elements of the array can be of any type. Here's a few examples:
String[] months = new String[12];
double[] approximations = new double[100];
months[0] = "January";
approximations[0] = 3.14;

Array as a parameter of a method
You can use arrays as a parameter of a method just like any other variable. As an array is a reference type, the value of the array is a reference to the information contained in the array. When you use array as a parameter of a method, the method receives a copy of the reference to the array.
public static void listElements(int[] integerArray) {
    System.out.println("the elements of the array are: ");
    int index = 0;
    while (index < integerArray.length) {
        int number = integerArray[index];
        System.out.print(number + " ");
        index = index + 1;
    }
    System.out.println("");
}
int[] numbers = new int[3];
numbers[0] = 1;
numbers[1] = 2;
numbers[2] = 3;
listElements(numbers);
Sample output
the elements of the array are: 1 2 3
As noticed earlier, you can freely choose the name of the parameter inside the method, the name doesn't have to be the same as the name of the variable when you call the method. In the example above, we call the array integerArray, meanwhile the caller of the method has named the same array numbers.
Array is an object, so when you change the array inside the method, the changes persist after the execution of the method.

The shorter way to create an array
Just like for Strings, there's also a shortcut to create an array. Here we create an array to hold 3 integers, and initiate it with values 100, 1 and 42 in it:
int[] numbers = {100, 1, 42};
So apart from calling for new, we can also initialize an array with a block, that contains comma-separated values to be assigned in the array. This works for all the types: below we initialize an array of strings, then an array of floating-point numbers. Finally the values are printed.
String[] arrayOfStrings = {"Matti L.", "Matti P.", "Matti V."};
double[] arrayOfFloatingpoints = {1.20, 3.14, 100.0, 0.6666666667};
for (int i = 0; i < arrayOfStrings.length; i++) {
    System.out.println(arrayOfStrings[i] + " " +  arrayOfFloatingpoints[i]);
}
Sample output
Matti L. 1.20
Matti P. 3.14
Matti V. 100.0
When you initialize an array with a block, the length of the array is precisely the number of the values specified in the block. The values of the block are assigned to the array in the order, eg. the first value is assigned to index 0, the second value to index 1 etc.
// index           0   1    2    3   4   5     6     7
int[] numbers = {100,  1,  42,  23,  1,  1, 3200, 3201};

Reading and Printing Strings
You can read a string using the nextLine-method offered by Scanner. The program below reads the name of the user and prints it:
Scanner reader = new Scanner(System.in);
System.out.print("What's your name? ");
// reading a line from the user and assigning it to the name variable
String name = reader.nextLine();
System.out.println(name);
Sample output
What's your name? Vicky
Vicky
Strings can also be concatenated. If you place a + operator between two strings, you get a new string that's a combination of those two strings. Be mindful of any white spaces in your variables!
String greeting = "Hi ";
String name = "Lily";
String goodbye = " and see you later!";
String phrase = greeting + name + goodbye;
System.out.println(phrase);
Sample output
Hi Lily and see you later!

String Comparisons And "Equals"
Strings can't be compared with with the equals operator ==. For strings, there exists a separate equals-command, which is always appended to the end of the string that we want to compare.
String text = "course";
if (text.equals("marzipan")) {
    System.out.println("The text variable contains the text marzipan.");
} else {
    System.out.println("The text variable does not contain the text marzipan.");
}
The equals command is always appended to the end of the string that we want to compare, "string variable dot equals some text". You can also compare a string variable to another string variable.
String text = "course";
String anotherText = "horse";
if (text.equals(anotherText)) {
    System.out.println("The two texts are equal!");
} else {
    System.out.println("The two texts are not equal!");
}
When comparing strings, you should make sure the string variable has some value assigned to it. If it doesn't have a value, the program will produce a NullPointerException error, which means that no value has been assigned to the variable, or that it is empty (null).

Splitting a String
You can split a string to multiple pieces with the split-method of the String class. The method takes as a parameter a string denoting the place around which the string should be split. The split method returns an array of the resulting sub-parts. In the example below, the string has been split around a space.
String text = "first second third fourth";
String[] pieces = text.split(" ");
System.out.println(pieces[0]);
System.out.println(pieces[1]);
System.out.println(pieces[2]);
System.out.println(pieces[3]);
System.out.println();
for (int i = 0; i < pieces.length; i++) {
    System.out.println(pieces[i]);
}
Sample output
first
second
third
fourth
first
second
third
fourth

Strings have a contains-method, which tells if a string contains another string. It works like this:
String text = "volcanologist";
if (text.contains("can")) {
    System.out.println("can was found");
}
if (!text.contains("tin")) {
    System.out.println("tin wasn't found");
}
Sample output
can was found
tin wasn't found

CharAt Method
You can get a character at a specified index of a string with the charAt method.
String text = "Hello world!";
char character = text.charAt(0);
System.out.println(character);
Sample output
H

Length of string
You can find out the length of a string with length()-method:
String word = "equisterian";
int length = word.length();
System.out.println("The length of the word" + word + " is " + length);
Sample output
The length of the word equisterian is 11