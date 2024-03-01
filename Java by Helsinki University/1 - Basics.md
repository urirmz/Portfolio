Printing
You can use the pre-defined Java command System.out.println(), to which you need to provide the text inside the parentheses that you'd like to be printed:
System.out.println("Hello World");
System.out.print  works exactly like System.out.println, but it doesn't add a line break to the end of the output.

Program Boilerplate
In Java, our programs have to include some boilerplate code to function. This boilerplate, an example of which is shown below, for example tells the computer what your program is called. Below, the name of the program is Example. This name has to correspond to the name of the file that contains the source code (e.g. Example.java).
public class Example {
    public static void main(String[] args) {

        System.out.println("Text to be printed");

    }
}
Execution of the program starts from the line that follows public static void main(string[] args) {, and ends at the closing curly bracket }. Commands are executed one line at a time.

Printing Multiple Lines
Programs are constructed command-by-command, where each command is placed on a new line. In the example below, the command System.out.println appears twice, which means that two print commands are being executed in the program.
public class Ohjelma {
    public static void main(String[] args) {
        System.out.println("Hello world!");
        System.out.println("... and the universe!");
    }
}

"sout"
Writing the command `System.out.println("...") can be taxing. In NetBeans, try to write sout on blank line (within main) and press tab (the key left to q). What happens? This shortcut may save you a lot of time in the future.

Terminology and Code Comments
Command parameters
The information to be printed by the print command, i.e. its parameters, are passed to it by placing them inside the parentheses () that follow the command. For example, passing Hi as a parameter to the System.out.println command is done like this: System.out.println("Hi").

Semicolon Separates Commands
Commands are separated with a semicolon ;. We could, if we wanted to, write almost everything on a single line. However, that would be difficult to understand.
System.out.println("Hello "); System.out.println("world"); System.out.println("!\n");
Sample output
Hello
world
!

Comments
Source code can be commented to clarify it or to add notes. There are two ways to do this.
Single-line comments are marked with two slashes //. Everything following them on the same line is interpreted as a comment.
Multi-line comments are marked with a slash and an asterisk /*, and closed with an asterisk followed by a slash */. Everything between them is interpreted as a comment.

Reading Input
Input refers to text written by the user read by the program. Input is always read as a string. For reading input, we use the Scanner tool that comes with Java. The tool can be imported for use in a program by adding the command import java.util.Scanner; before the beginning of the main program's frame (public class ...). The tool itself is created with Scanner scanner = new Scanner(System.in);.
Below is an example of a program which asks for user input, reads the string entered by the user, and then prints it.
// Introduce the scanner tool used for reading user input
import java.util.Scanner;
public class Program {

    public static void main(String[] args) {
        // Create a tool for reading user input and name it scanner
        Scanner scanner = new Scanner(System.in);

        // Print "Write a message: "
        System.out.println("Write a message: ");

        // Read the string written by the user, and assign it
        // to program memory "String message = (string that was given as input)"
        String message = scanner.nextLine();

        // Print the message written by the user
        System.out.println(message);
    }
}
More precisely, input is read with the scanner tool's nextLine() method. The call scanner.nextLine() is left waiting for the user to write something. When user writes something and presses enter, the provided string is assigned to a string variable (in this instance message). 

Fundamentals of Strings
As you might have noticed, in programming we refer to "strings" rather than "text". The term "string" is shorthand for "string of characters" which describes how the computer sees text on a more fundamental level: as a sequence of individual characters.
We've so far used strings in two ways. When practicing the print command, we passed the string to be printed to the print command in quotation marks, and when practicing reading input, we saved the string we read to a variable.
In practice, variables are named containers that contain information of some specified type and have a name. A string variable is declared in a program by stating the type of the variable (String) and its name (myString, for instance). Typically a variable is also assigned a value during its declaration. You can assign a value by following the declaration with an equals sign followed by the value and a semicolon.
A string variable called message that is assigned the value "Hello world!" is declared like this:
String message = "Hello world!";
When a variable is created, a specific container is made available within the program, the contents of which can later be referenced. Variables are referenced by their name. For instance, creating and printing a string variable is done as shown below:
String message = "Hello world!";
System.out.println(message);

Concatenation - Joining Strings Together
The string to be printed can be formed from multiple strings using the + operator. For example, the program below prints "Hello world!" on one line.
public class Program {

    public static void main(String[] args) {
        System.out.println("Hello " + "world!");
    }
}

Program Execution Waits for Input
When the program's execution comes a statement that attempts to read input from the user (the command reader.nextLine()), the execution stops and waits. The execution continues only after the user has written some input and pressed enter.

Variables
A variable can be thought of as a container in which information of a given type can be stored. Examples of these different types include text (String), whole numbers (int), floating-point numbers (double), and whether something is true or false (boolean). A value is assigned to a variable using the equals sign (=).
int months = 12;
A variable's value can be joined to a string using the + sign, as seen in the following example.
String text = "contains text";
int wholeNumber = 123;
double floatingPoint = 3.141592653;
boolean trueOrFalse = true;
System.out.println("Text variable: " + text);
System.out.println("Integer variable: " + wholeNumber);
System.out.println("Floating-point variable: " + floatingPoint);
System.out.println("Boolean: " + trueOrFalse);
Output:
Sample output
Text variable: contains text
Integer variable: 123
Floating-point variable: 3.141592653
Booolean: true

Changing a Value Assigned to a Variable
A variable exists from the moment of its declaration, and its initial value is preserved until another value is assigned to it. You can change a variable's value using a statement that comprises the variable name, an equals sign, and the new value to be assigned. Remember to keep in mind that the variable type is only stated during the initial variable declaration.
int number = 123;
System.out.println("The value of the variable is " + number);
Output:
The value of the variable is 123

Variable's Type Persists
Once a variable's type has been declared, it can no longer be changed. For example, a boolean value cannot be assigned to a variable of the integer type, nor can an integer be assigned to a variable of the boolean type.
However, exceptions do exist: an integer can be assigned to a variable of the double type, since Java knows how to convert an integer to a double during assignment.
double floatingPoint = 0.42;
floatingPoint = 1; // Works
int value = 10;
floatingPoint = value; // Also works

Variables Express the Program and the Problem to Be Solved
Programming is a problem-solving tool. The aim is to create solutions for any given problem, such as the automation of control in cars. As a problem is approached, the developer decides on the terms used to describe the problem domain. The terminology that is chosen, such as variable names, will serve to describe the problem for anyone who is to work with it in the future.
Variable naming is limited by certain constraints.
Variable names cannot contain certain special symbols, such as exclamation marks (!). Spaces are also not allowed, since they're used to separate parts of commands. Instead of spaces, the convention in Java is to use a style known as camelCase. Note! The first letter of a variable name is always lower-cased:
int camelCaseVariable = 7;
Numbers can be used within a variable name as long as the name does not begin with a number. Also, a name cannot consists of numbers only.
int 7variable = 4; // Not allowed!
int variable7 = 4; // Allowed, but is not a descriptive variable name
A variable's name cannot already be in use. These names include, for instance, variables previously defined in the program and commands provided by Java, such as System.out.print and System.out.println

The Type of the Variable Informs of Possible Values
A variable's type is specified when it's initally declared. For example, a variable containing the string "text" is declared with the statement String string = "text";, and an integer having the value 42 is declared with the statement int value = 42;
Type	                                Example	Accepted            values
Whole number, i.e., int	                int value = 4;	            An integer can contain whole numbers whose values lie between -2147483648 and 2147483647.
Floating-point number, i.e., double	    double value = 4.2;	        Floating-point numbers contain decimal numbers, with the greatest possible value being approximately 21023. When a decimal number is represented with a floating-point number, the value can be inaccurate as floating-points are incapable of representing all decimal numbers. The reasons behind this are explored in the Computer organization course.
String	                                String text = "Hi!";	    A string can contain text. Strings are enclosed in quotation marks.
True or false value, i.e., boolean	    boolean right = true;	    A boolean contains either the value true or false.

Reading Different Variable Types from User
In the text-based user interfaces that we've used in our programs, the user's input is always read as a string, since the user writes their input as text.
Other input types, such as integers, doubles, and booleans are also read as text. However, they need to be converted to the target variable's type with the help of some tools provided by Java.
Reading Integers
The Integer.valueOf command converts a string to an integer. It takes the string containing the value to be converted as a parameter.
Reading Doubles
The Double.valueOf command converts a string to a double. It takes the string containing the value to be converted as a parameter.
Reading Booleans
The Integer.valueOf command converts a string to an integer and the Double.valueOf converts it to a floating-point. The valueOf command also appears when converting a string to a boolean — this is done with the command Boolean.valueOf.
Boolean variables can either have the value true or false. When converting a string to a boolean, the string must be "true" if we want the boolean value to be true. The case is insensitive here: both "true" and "TRue" turn into the boolean value of true. All other strings turn into the boolean false.
import java.util.Scanner;
public class Program {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String text = scanner.nextLine();
        int integer = Integer.valueOf(scanner.nextLine());
        double floatingPoint = Double.valueOf(scanner.nextLine());
        boolean trueOrFalse = Boolean.valueOf(scanner.nextLine());

        // and so on
    }
}

Calculating with numbers
The basic mathematical operations are both familiar and straightforward: addition +, subtraction -, multiplication *, and division /. The precedence is also familiar: operations are performed from left to right with the parentheses taken into account. Expressions involving * and / are calculated before those involving + and -, as is customary in elementary school mathematics.
int first = 2;
System.out.println(first); // prints 2
int second = 4;
System.out.println(second); // prints 4
int sum = first + second; // The sum of the values of the variables first and second is assigned to the variable sum
System.out.println(sum); // prints 6

Precedence and Parentheses
You can affect the order of operations by using parentheses. Operations within parentheses are performed before those outside them.
int calculationWithParentheses = (1 + 1) + 3 * (2 + 5);
System.out.println(calculationWithParentheses); // prints 23

Expression and Statement
An expression is a combination of values that is turned into another value through a calculation or evaluation. The statement below includes the expression 1 + 1 + 3 * 2 + 5, which is evaluated prior to its assignment to the variable.
int calculationWithoutParentheses = 1 + 1 + 3 * 2 + 5;
An expression is evaluated where it occurs in the program's source code. As such, the evaluation can occur within a print statement, if the expression is used in calculating the value of the print statement's parameter.
int first = 2;
int second = 4;
System.out.println(first + second); // prints 6
System.out.println(2 + second - first - second); // prints 0
An expression does not change the value stored in a variable unless the expression's result is assigned to a variable or used as a parameter, for instance, in printing.
int first = 2;
int second = 4;
// the expression below does not even work, since
// the result is not assigned to any variable
// or given as a parameter to a print statement
first + second;

Division
Division of integers is a slightly trickier operation. The types of the variables that are part of the division determine the type of result achieved by executing the command. If all of the variables in the division expression are integers, the resulting value is an integer as well.
int result = 3 / 2;
System.out.println(result);
Sample output
1
The previous example prints 1: both 3 and 2 are integers, and the division of two integers always produces an integer.
If the dividend or divisor (or both!) of the division is a floating point number, the result is a floating point number as well.
double whenDividendIsFloat = 3.0 / 2;
System.out.println(whenDividendIsFloat); // prints 1.5
double whenDivisorIsFloat = 3 / 2.0;
System.out.println(whenDivisorIsFloat); // prints 1.5
An integer can be converted into a floating point number by placing a type-casting operation (double) before it:
int first = 3;
int second = 2;
double result1 = (double) first / second;
System.out.println(result1); // prints 1.5
double result2 = first / (double) second;
System.out.println(result2); // prints 1.5
double result3 = (double) (first / second);
System.out.println(result3); // prints 1.0
The last example produces an incorrectly rounded result, because the integer division is executed before the type casting.
If the result of a division is assigned to an integer-type variable, the result is automatically an integer.
int integer = (int) 3.0 / 2;
System.out.println(integer);
Sample output
1

Conditional statements and conditional operation
The simplest conditional statement looks something like this.
System.out.println("Hello, world!");
if (true) {
    System.out.println("This code is unavoidable!");
}
Sample output
Hello, world!
This code is unavoidable!
A conditional statement begins with the keyword if followed by parentheses. An expression is placed inside the parentheses, which is evaluated when the conditional statement is reached. The result of the evaluation is a boolean value. No evaluation occurred above. Instead, a boolean value was explicitly used in the conditional statement.
The parentheses are followed by a block, which is defined inside opening- { and closing } curly brackets. The source code inside the block is executed if the expression inside the parentheses evaluates to true.
Let's look at an example where we compare numbers in the conditional statement.
int number = 11;
if (number > 10) {
    System.out.println("The number was greater than 10");
}
If the expression in the conditional statement evaluates to true, the execution of the program progresses to the block defined by the conditional statement. In the example above, the conditional is "if the number in the variable is greater than 10". On the other hand, if the expression evaluates to false, the execution moves on to the statement after the closing curly bracket of the current conditional statement.
NB! An if -statement is not followed by a semicolon since the statement doesn't end after the conditional.

Code Indentation and Block Statements
A code block refers to a section enclosed by a pair of curly brackets. The source file containing the program includes the string public class, which is followed by the name of the program and the opening curly bracket of the block. The block ends in a closing curly bracket.
Blocks define a program's structure and its bounds. A curly bracket must always have a matching pair: any code that's missing a closing (or opening) curly bracket is erroneous.
A conditional statement also marks the start of a new code block.
In addition to the defining program structure and functionality, block statements also have an effect on the readability of a program. Code living inside a block is indented. For example, any source code inside the block of a conditional statement is indented four spaces deeper than the if command that started the conditional statement. Four spaces can also be added by pressing the tab key (the key to the left of 'q'). When the block ends, i.e., when we encounter a } character, the indentation also ends. The } character is at the same level of indentation as the if-command that started the conditional statement.
The example below is incorrectly indented.
if (number > 10) {
number = 9;
}
The example below is correctly indented.
if (number > 10) {
    number = 9;
}

Automatic code indentation
Code in Java is indented either by four spaces or a single tab for each block. Use either spaces or tabs for indentation, not both. The indentation might break in some cases if you use both at the same time. NetBeans will help you with this if you hit the "alt + shift + f" (macOS "control + shift + f") key combination.

Comparison Operators
> greater than
>= greater than or equal to
< less than
<= less than or equal to
== equal to
!= not equal to
int number = 55;
if (number != 0) {
    System.out.println("The number is not equal to 0");
}
if (number >= 1000) {
    System.out.println("The number is at least 1000");
}
Sample output
The number was not equal to 0

Else
If the expression inside the parentheses of the conditional statement evaluates to false, then the execution of the code moves to the statement following the closing curly bracket of the current conditional statement. This is not always desired, and usually we want to create an alternative option for when the conditional expression evaluates to false.
This can be done with the help of the else command, which is used together with the if command.
int number = 4;
if (number > 5) {
    System.out.println("Your number is greater than five!");
} else {
    System.out.println("Your number is five or less!");
}
Sample output
Your number is five or less!
If an else branch has been specified for a conditional statement, the block defined by the else branch is run in the case that the condition of the conditional statement is false. The else-command is placed on the same line as the closing bracket of the block defined by the if-command.

More Conditionals: else if
In the case of multiple conditionals, we use the else if-command. The command else if is like else, but with an additional condition. else if follows the if-condition, and they may be multiple.
int number = 3;
if (number == 1) {
    System.out.println("The number is one");
} else if (number == 2) {
    System.out.println("The given number is two");
} else if (number == 3) {
    System.out.println("The number must be three!");
} else {
    System.out.println("Something else!");
}
Sample output
The number must be three!

Conditional Statement Expression and the Boolean Variable
The value that goes between the parentheses of the conditional statement should be of type boolean after the evaluation. boolean type variables are either true or false.
boolean isItTrue = true;
System.out.println("The value of the boolean variable is " + isItTrue);
Sample output
The value of the boolean variable is true
Comparison operators can also be used outside of conditionals. In those cases, the boolean value resulting from the comparison is stored in a boolean variable for later use.
int first = 1;
int second = 3;
boolean isGreater = first > second;

Remainder
The modulo operator is a slightly less-used operator, which is, however, very handy when we want to check the divisibility of a number, for example. The symbol for the modulo operator is %.
int remainder = 7 % 2;
System.out.println(remainder); // prints 1
System.out.println(5 % 3); // prints 2
System.out.println(7 % 4); // prints 3
System.out.println(8 % 4); // prints 0
System.out.println(1 % 2); // prints 1

Conditional Statements and Comparing Strings
Even though we can compare integers, floating point numbers, and boolean values using two equals signs (variable1 == variable2), we cannot compare the equality of strings using two equals signs.
This has to do with the internal workings of strings as well as how variable comparison is implemented in Java. In practice, the comparison is affected by how much information a variable can hold — strings can hold a limitless amount of characters, whereas integers, floating-point numbers, and boolean values always contain a single number or value only. Variables that always contain only one number or value can be compared using an equals sign, whereas this doesn't work for variables containing more information. We will return to this topic later in this course.
When comparing strings we use the equals-command, which is related to string variables. The command works in the following way:
Scanner reader = new Scanner(System.in);
System.out.println("Enter a string");
String input = reader.nextLine();
if (input.equals("a string")) {
    System.out.println("Great! You read the instructions correctly.");
} else {
    System.out.println("Missed the mark!");
}
The equals command is written after a string by attaching it to the string to be compared with a dot. The command is given a parameter, which is the string that the variable will be compared against. If the string variable is being directly compared with a string, then the string can be placed inside the parentheses of the equals-command within quotation marks. Otherwise, the name of the string variable that holds the string to be compared is placed inside the parentheses.

Logical Operators
The expression of a conditional statement may consist of multiple parts, in which the logical operators and &&, or ||, and not ! are used.

You can calculate the square root of an integer with the command Math.sqrt like this:
int number = 42;
double squareRoot = Math.sqrt(number);
System.out.println(squareRoot);
