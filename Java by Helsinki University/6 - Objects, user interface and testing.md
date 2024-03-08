Objects on a list and a list as part of an object
Next, let's have a look at objects that contain a list. Examples of objects like these include objects that describe sets, for example playlists.
In the following example, we have made a class for the concept of a playlist. The playlist contains songs: songs can be added, songs can be removed, and the songs that the playlist contains can be printed.
// imports
public class Playlist {
    private ArrayList<String> songs;
    public Playlist() {
        this.songs = new ArrayList<>();
    }
    public void addSong(String song) {
        this.songs.add(song);
    }
    public void removeSong(String song) {
        this.songs.remove(song);
    }
    public void printSongs() {
        for (String song: this.songs) {
            System.out.println(song);
        }
    }
}
Creating playlists is easy with the help of the class above.
Playlist list = new Playlist();
list.addSong("Sorateiden kuningas");
list.addSong("Teuvo, maanteiden kuningas");
list.printSongs();
Sample output
Sorateiden kuningas
Teuvo, maanteiden kuningas

Clearing a List
The ArrayList class has a method which is useful here, is called .clear(). NetBeans can hint at the available methods when you type the object name an a dot. Try to write <NameOfTheList>. inside the method frame and see what happens.

Stack
A stack is a data structure that you can add to and take from. Always to the top of it or from the top.

Objects in an Instance Variable List
A list that is an object's instance variable can contain objects other than strings as long as the type of objects in the list is specified when defining the list.

Retrieving a Specific Object from a List
Methods that retrieve objects from a list should be implemented in the following way. First off, we'll check whether or not the list is empty - if it is, we return a null reference or some other value indicating that the list had no values. After that, we create an object reference variable that describes the object to be returned. We set the first object on the list as its value. We then go through the values on the list by comparing each list object with the object variable representing the object to be returned. If the comparison finds a better matching object, its assigned to the object reference variable to be returned. Finally, we return the object variable describing the object that we want to return.
public Person getTallest() {
    // return a null reference if there's no one on the ride
    if (this.riding.isEmpty()) {
        return null;
    }
    // create an object reference for the object to be returned
    // its first value is the first object on the list
    Person returnObject = this.riding.get(0);
    // go through the list
    for (Person prs: this.riding) {
        // compare each object on the list
        // to the returnObject -- we compare heights
        // since we're searching for the tallest,
        if (returnObject.getHeight() < prs.getHeight()) {
            // if we find a taller person in the comparison,
            // we assign it as the value of the returnObject
            returnObject = prs;
        }
    }
    // finally, the object reference describing the
    // return object is returned
    return returnObject;
}
Finding the tallest person is now easy.
Person matti = new Person("Matti");
matti.setHeight(180);
Person juhana = new Person("Juhana");
juhana.setHeight(132);
Person awak = new Person("Awak");
awak.setHeight(194);
AmusementParkRide hurjakuru = new AmusementParkRide("Hurjakuru", 140);
hurjakuru.isAllowedOn(matti);
hurjakuru.isAllowedOn(juhana);
hurjakuru.isAllowedOn(awak);
System.out.println(hurjakuru);
System.out.println(hurjakuru.averageHeightOfPeopleOnRide());
System.out.println();
System.out.println(hurjakuru.getTallest().getName());
Person tallest = hurjakuru.getTallest();
System.out.println(tallest.getName());
Sample output
Hurjakuru, minimum height requirement: 140, visitors: 2
on the ride:
Matti
Awak
187.0
Awak
Awak

Separating the user interface from program logic
Let's examine the process of implementing a program and separating different areas of responsibility from each other. The program asks the user to write words until they write the same word twice.
Sample output
Write a word: carrot
Write a word: turnip
Write a word: potato
Write a word: celery
Write a word: potato
You wrote the same word twice!
Let's build this program piece by piece. One of the challenges is that it is difficult to decide how to approach the problem, or how to split the problem into smaller subproblems, and from which subproblem to start. There is no one clear answer — sometimes it is good to start from the problem domain and its concepts and their connections, sometimes it is better to start from the user interface.
We could start implementing the user interface by creating a class UserInterface. The user interface uses a Scanner object for reading user input. This object is given to the user interface.
public class UserInterface {
    private Scanner scanner;
    public UserInterface(Scanner scanner) {
        this.scanner = scanner;
    }
    public void start() {
        // do something
    }
}
Creating and starting up a user interface can be done as follows.
public static void main(String[] args) {
    Scanner scanner = new Scanner(System.in);
    UserInterface userInterface = new UserInterface(scanner);
    userInterface.start();
}

Objects as a natural part of problem solving
We just built a solution to a problem where the program reads words from a user until the user enters a word that has already been entered before. Our example input was as follows:
Sample output
Enter a word: carrot
Enter a word: celery
Enter a word: turnip
Enter a word: potato
Enter a word: celery
You gave the same word twice!
We came up with the following solution:
public class UserInterface {
    private Scanner scanner;
    private ArrayList<String> words;
    public UserInterface(Scanner scanner) {
        this.scanner = scanner;
        this.words = new ArrayList<String>();
    }
    public void start() {
        while (true) {
            System.out.print("Enter a word: ");
            String word = scanner.nextLine();
            if (alreadyEntered(word)) {
                break;
            }
            // adding the word to the list of previous words
            this.words.add(word);
        }
        System.out.println("You gave the same word twice!");
    }
    public boolean alreadyEntered(String word) {
       if (word.equals("end")) {
            return true;
        }
        return false;
    }
}
From the point of view of the user interface, the support variable 'words' is just a detail. The main thing is that the user interface remembers the set of words that have been entered before. The set is a clear distinct "concept" or an abstraction. Distinct concepts like this are all potential objects: when we notice that we have an abstraction like this in our code, we can think about separating the concept into a class of its own.
Word set
Let's make a class called 'WordSet'. After implementing the class, the user interface's start method looks like this:
while (true) {
    String word = scanner.nextLine();
    if (words.contains(word)) {
        break;
    }
    wordSet.add(word);
}
System.out.println("You gave the same word twice!");
From the point of view of the user interface, the class WordSet should contain the method 'boolean contains(String word)', that checks whether the given word is contained in our set of words, and the method 'void add(String word)', that adds the given word into the set.
We notice that the readability of the user interface is greatly improved when it's written like this.
The outline for the class 'WordSet' looks like this:
public class WordSet {
    // object variable(s)
    public WordSet() {
        // constructor
    }
    public boolean contains(String word) {
        // implementation of the contains method
        return false;
    }
    public void add(String word) {
        // implementation of the add method
    }
}
Earlier solution as part of implementation
We can implement the set of words by making our earlier solution, the list, into an object variable:
import java.util.ArrayList;
public class WordSet {
    private ArrayList<String> words
    public WordSet() {
        this.words = new ArrayList<>();
    }
    public void add(String word) {
        this.words.add(word);
    }
    public boolean contains(String word) {
        return this.words.contains(word);
    }
}
Now our solution is quite elegant. We have separated a distinct concept into a class of its own, and our user interface looks clean. All the "dirty details" have been encapsulated neatly inside an object.
Let's now edit the user interface so that it uses the class WordSet. The class is given to the user interface as a parameter, just like Scanner.
public class UserInterface {
    private WordSet wordSet;
    private Scanner scanner;
    public userInterface(WordSet wordSet, Scanner scanner) {
        this.wordSet = wordSet;
        this.scanner = scanner;
    }
    public void start() {
        while (true) {
            System.out.print("Enter a word: ");
            String word = scanner.nextLine();
            if (this.wordSet.contains(word)) {
                break;
            }
            this.wordSet.add(word);
        }
        System.out.println("You gave the same word twice!");
    }
}
Starting the program is now done as follows:
public static void main(String[] args) {
    Scanner scanner = new Scanner(System.in);
    WordSet set = new WordSet();
    UserInterface userInterface = new UserInterface(set, scanner);
    userInterface.start();
}

Recycling
When concepts have been separated into different classes in the code, recycling them and reusing them in other projects becomes easy. For example, the class 'WordSet' could be used in a graphical user interface, and it could also be part of a mobile phone application. In addition, testing the program is much easier when it has been divided into several concepts, each of which has its own separate logic and can function alone as a unit.

Programming tips
In the larger example above, we were following the advice given here.
Proceed with small steps
Try to separate the program into several sub-problems and work on only one sub-problem at a time
Always test that the program code is advancing in the right direction, in other words: test that the solution to the sub-problem is correct
Recognize the conditions that require the program to work differently. In the example above, we needed a different functionality to test whether a word had been already entered before.
Write as "clean" code as possible
Indent your code
Use descriptive method and variable names
Don't make your methods too long, not even the main method
Do only one thing inside one method
Remove all copy-paste code
Replace the "bad" and unclean parts of your code with clean code
If needed, take a step back and assess the program as a whole. If it doesn't work, it might be a good idea to return into a previous state where the code still worked. As a corollary, we might say that a program that's broken is rarely fixed by adding more code to it.

User interface
Typically each program has its own user interface. We will create the class UserInterface and separate it from the main program.

Introduction to testing
Error Situations and Step-By-Step Problem Resolving
Errors end up in the programs that we write. Sometimes the errors are not serious and cause headache mostly to users of the program. Occasionally, however, mistakes can lead to very serious consequences. In any case, it's certain that a person learning to program makes many mistakes.
You should never be afraid of or avoid making mistakes since that is the best way to learn. For this reason, try to break the program that you're working on from time to time to investigate error messages, and to see if those messages tell you something about the error(s) you've made.
As programs grow in their complexity, finding errors becomes even more challenging. The debugger integrated into NetBeans can help you find errors. The use of the debugger is introduced with videos embedded in the course material; going over them is always an option.

Stack Trace
When an error occurs in a program, the program typically prints something called a stack trace, i.e., the list of method calls that resulted in the error. For example, a stack trace might look like this:
Sample output
  Exception in thread "main" ...
      at Program.main(Program.java:15)
The type of error is stated at the beginning of the list, and the following line tells us where the error occurred. The line "at Program.main(Program.java:15)" says that the error occurred at line number 15 in the Program.java file.
Sample output
  at Program.main(Program.java:15)

Checklist for Troubleshooting
If your code doesn't work and you don't know where the error is, these steps will help you get started.
Indent your code properly and find out if there are any missing parentheses.
Verify that the variables used are correctly named.
Test the program flow with different inputs and find out the sort of input that causes the program to not work as desired. If you received an error in the tests, the tests may also indicate the input used.
Add print commands to the program in which you print out the values of the variables used at various stages of the program's execution.
Verify that all variables you are using are initialized. If they aren't, a NullPointerException error will occur.
If your program causes an exception, you should definitely pay attention to the stack trace associated with the exception, which is the list of method calls that resulted in the situation that caused the exception.
Learn how to use the debugger. 

Passing Test Input to Scanner
Manually testing the program is often laborious. It's possible to automate the passing of input by, for example, passing the string to be read into a Scanner object. You'll find an example below of how to test a program automatically. The program first enters five strings, followed by the previously seen string. After that, we try to enter a new string. The string "six" should not appear in the word set.
The test input can be given as a string to the Scanner object in the constructor. Each line break in the test feed is marked on the string with a combination of a backslash and an n character "\n".
String input = "one\n" + "two\n"  +
                "three\n" + "four\n" +
                "five\n" + "one\n"  +
                "six\n";
Scanner reader = new Scanner(input);
ArrayList<String> read = new ArrayList<>();
while (true) {
    System.out.println("Enter an input: ");
    String line = reader.nextLine();
    if (read.contains(line)) {
        break;
    }
    read.add(line);
}
System.out.println("Thank you!");
if (read.contains("six")) {
    System.out.println("A value that should not have been added to the group was added to it.");
}
The program's output only shows the one provided by the program, and no user commands.
Sample output
Enter an input:
Enter an input:
Enter an input:
Enter an input:
Enter an input:
Enter an input:
Thank you!
Passing a string to the constructor of the Scanner class replaces input read from the keyboard. As such, the content of the string variable input 'simulates' user input. A line break in the input is marked with \n. Therefore, each part ending in an newline character in a given string input corresponds to one input given to the nextLine() command.
When testing your program again manually, change the parameter Scanner object constructor to System.in, i.e., to the system's input stream. Alternatively, you can also change the test input, since we're dealing with a string.
The working of the program should continue to be checked on-screen. The print output can be a little confusing at first, as the automated input is not visible on the screen at all. The ultimate aim is to also automate the checking of the correctness of the output so that the program can be tested and the test result analyzed with the "push of a button".

Unit Testing
The automated testing method laid out above where the input to a program is modified is quite convenient, but limited nonetheless. Testing larger programs in this way is challenging. One solution to this is unit testing, where small parts of the program are tested in isolation.
Unit testing refers to the testing of individual components in the source code, such as classes and their provided methods. The writing of tests reveals whether each class and method observes or deviates from the guideline of each method and class having a single, clear responsibility. The more responsibility the method has, the more complex the test. If a large application is written in a single method, writing tests for it becomes very challenging, if not impossible. Similarly, if the application is broken into clear classes and methods, then writing tests is straightforward.
Ready-made unit test libraries are commonly used in writing tests, which provide methods and help classes for writing tests. The most common unit testing library in Java is JUnit , which is also supported by almost all programming environments. For example, NetBeans can automatically search for JUnit tests in a project — if any are found, they will be displayed under the project in the Test Packages folder.
Let's take a look at writing unit tests with the help of an example. Let's assume that we have the following Calculator class and want to write automated tests for it.
public class Calculator {
    private int value;
    public Calculator() {
        this.value = 0;
    }
    public void add(int number) {
        this.value = this.value + number;
    }
    public void subtract(int number) {
        this.value = this.value + number;
    }
    public int getValue() {
        return this.value;
    }
}
The calculator works by always remembering the result produced by the preceding calculation. All subsequent calculations are always added to the previous result. A minor error resulting from copying and pasting has been left in the calculator above. The method subtract should deduct from the value, but it currently adds to it.
Unit test writing begins by creating a test class, which is created under the Test-Packages folder. When testing the Calculator class, the test class is to be called CalculatorTest. The string Test at the end of the name tells the programming environment that this is a test class. Without the string Test, the tests in the class will not be executed. (Note: Tests are created in NetBeans under the Test Packages folder.)
The test class CalculatorTest is initially empty.
public class CalculatorTest {
}
Tests are methods of the test class where each test tests an individual unit. Let's begin testing the class — we start off by creating a test method that confirms that the newly created calculator's value is intially 0.
import static org.junit.Assert.assertEquals;
import org.junit.Test;
public class CalculatorTest {
    @Test
    public void calculatorInitialValueZero() {
        Calculator calculator = new Calculator();
        assertEquals(0, calculator.getValue());
    }
}
In the calculatorInitialValueZero method a calculator object is first created. The assertEquals method provided by the JUnit test framework is then used to check the value. The method is imported from the Assert class with the import Static command, and it's given the expected value as a parameter - 0 in this instance - and the value returned by the calculator. If the values of the assertEquals method values ​​differ, the test will not pass. Each test method should have an "annotation" @ Test. This tells the JUnit test framework that this is an executable test method.
To run the tests, select the project with the right-mouse button and click Test.
Running the tests prints to the output tab (typically at the bottom of NetBeans) that contains some information specific to each test class. In the example below, tests of the CalculatorTest class from the package are executed. The number of tests executed were 1, none of which failed — failure in this context means that the functionality tested by the test did not work as expected. ->
Sample output
Testsuite: CalculatorTest
Tests run: 1, Failures: 0, Errors: 0, Skipped: 0, Time elapsed: 0.054 sec
test-report:
test:
BUILD SUCCESSFUL (total time: 0 seconds)
Let's add functionality for adding and subtracting to the test class.
import static org.junit.Assert.assertEquals;
import org.junit.Test;
public class CalculatorTest {
    @Test
    public void calculatorInitialValueZero() {
        Calculator calculator = new Calculator();
        assertEquals(0, calculator.getValue());
    }
    @Test
    public void valueFiveWhenFiveAdded() {
        Calculator calculator = new Calculator();
        calculator.add(5);
        assertEquals(5, calculator.getValue());
    }
    @Test
    public void valueMinusTwoWhenTwoSubstracted() {
        Calculator calculator = new Calculator();
        calculator.subtract(2);
        assertEquals(-2, calculator.getValue());
    }
}
Executing the tests produces the following output.
Sample output
Testsuite: CalculatorTest
Tests run: 3, Failures: 1, Errors: 0, Skipped: 0, Time elapsed: 0.059 sec
Testcase: valueMinusTwoWhenTwoSubstracted(CalculatorTest): FAILED
expected:<-2> but was:<2>
junit.framework.AssertionFailedError: expected:<-2> but was:<2>
at CalculatorTest.valueMinusTwoWhenTwoSubstracted(CalculatorTest.java:25)
Test CalculatorTest FAILED
test-report:
test:
BUILD SUCCESSFUL (total time: 0 seconds)
The output tells us that three tests were executed. One of them failed. The test output also informs us of the line in which the error occured (25), and of the expected (-2) and actual (2) values. Whenever the execution of tests ends in an error, NetBeans also displays the error state visually.

Unit Testing and the Parts of an Application
Unit testing tends to be extremely complicated if the whole application has been written in "Main". To make testing easier, the app should be split into small parts, each having a clear responsibility. In the previous section, we practiced this when we seperated the user interface from the application logic. Writing tests for parts of an application, such as the 'JokeManager' class from the previous section is significantly easier than writing them for program contained in "Main" in its entirety.

Test-Driven Development
Test-driven development is a software development process that's based on constructing a piece of software in small iterations. In test-driven software development, the first thing a programmer always does is write an automatically-executable test, which tests a single piece of the computer program.
The test will not pass because the functionality that satisfies the test, i.e., the part of the computer program to be examined, is missing. Once the test has been written, functionality that meets the test requirements is added to the program. The tests are then run again. If all tests pass, a new test is added, or alternatively, if the tests fail, the already-written program is corrected. If necessary, the internal structure of the program will be corrected or refactored, so that the functionality of the program remains the same, but the structure becomes clearer.
Test-driven software development consists of five steps that are repeated until the functionality of the program is complete.
Write a test. The programmer decides which program functionality to test and writes a test for it.
Run the tests and check if the tests pass. When a new test is written, the tests are run. If the test passes, the test is most likely erroneous and should be corrected - the test should only test functionality that hasn't yet been implemented.
Write the functionality that meets the test's requirements. The programmer implements functionality that only meets the test requirements. Note: this doesn't do things that the test does not require - functionality is only added in small increments.
Perform the tests. If the tests fail, there is likely to be an error in the functionality written. Correct the functionality - or, if there is no error in the functionality, fix the latest test that was performed.
Repair the internal structure of the program. As the size of the program increases, its internal structure is adjusted as needed. Methods that are too long are broken down into multiple parts and classes representing concepts are isolated. The tests are not modified, but are instead used to verify the correctness of the changes made to the program's internal structure - if a change in the program structure changes the functionality of the program, the tests will produce a warning and the programmer can remedy the situation.

