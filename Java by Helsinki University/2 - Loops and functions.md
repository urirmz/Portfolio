Loops and Infinite Loops
A loop consists of an expression that determines whether or not the code within the loop should be repeated, along with a block containing the source code to be repeated. A loop takes the following form.
while (_expression_) {
    // The content of the block wrapped in curly brackets
    // The block can have an unlimited amount of content
}
We'll use the value true as the loop's expression for now. This way, the loop's execution is always continued when the program arrives at the point that decides whether it should be repeated or not. This happens when the execution of the program first arrives at the loop expression for the first time, and also when it reaches the end of the loop's block.
The loop execution proceeds line-by-line. The following program outputs I can program an infinite number of times.
while (true) {
    System.out.println("I can program!");
}
A program that runs infinitely does not end on its own. In NetBeans, it can be shut down by clicking the red button located on the left side of the output window.

Ending a Loop
The loop can be broken out of with command 'break'. When a computer executes the command 'break', the program execution moves onto the next command following the loop block.
The example below is a program that prints numbers from one to five. Note how the variable that's used within the loop is defined before the loop. This way the variable can be incremented inside the loop and the change sticks between multiple iterations of the loop.
int number = 1;
while (true) {
    System.out.println(number);
    if (number >= 5) {
        break;
    }

    number = number + 1;
}
System.out.println("Ready!");
Sample output
1
2
3
4
5
Ready!
Users can also be asked for input within a loop. The variables that are commonly used in loops (such as Scanner readers) are defined before the loop, whereas variables (such as the value read from the user) that are specific to the loop are defined within it.
In the example below, the program asks the user whether to exit the loop or not. If the user inputs the string "y", the execution of the program moves to the command following the loop block, after which the execution of the program ends.
Scanner scanner = new Scanner(System.in);
while (true) {
    System.out.println("Exit? (y exits)");
    String input = scanner.nextLine();
    if (input.equals("y")) {
        break;
    }

    System.out.println("Ok! Let's carry on!");
}
System.out.println("Ready!");
The program in the example works as follows. The user's inputs are marked in red.
Sample output
Exit? (y exits)
no
Ok! Let's carry on!
Exit? (y exits)
non
Ok! Let's carry on!
Exit? (y exits)
y
Ready!

Returning to the Start of the Loop
When the execution reaches the end of the loop, the execution starts again from the start of the loop. This means that all the commands in the loop have been executed. You can also return to the beginning from other places besides the end with the command continue. When the computer executes the command continue, the execution of the program moves to the beginning of the loop.
The example below demonstrates the use of the continue command. The program asks the user to input positive numbers. If the user inputs a negative number or a zero, the program prints the message "Unfit number, try again", after which the execution returns to the beginning of the loop. In the previous example, the program read inputs of type string from the user. Similar programs with different input types are also possible. In the example below, the user is asked for numbers until they input a zero.
Scanner scanner = new Scanner(System.in);
while (true) {
    System.out.println("Insert positive integers");
    int number = Integer.valueOf(scanner.nextLine());

    if (number <= 0) {
        System.out.println("Unfit number! Try again.");
        continue;
    }

    System.out.println("Your input was " + number);
}
The program in the example above is repeated infinitely since the break command used for exiting the loop is not used. To exit the loop, the break command must be added to it.

Calculation with Loops
If the variable used to store the data is introduced within the loop, the variable is only available within that loop and nowhere else.

While Loop with a Condition
So far we have been using a loop with the boolean true in its parenthesis, meaning the loop continues forever (or until the loop is ended with the break command ).
Actually, the parenthesis of a loop can contain a conditional expression, or a condition, just like the parenthesis of an if statement. The true value can be replaced with an expression, which is evaluated as the program is executed. The expression is defined the same way as the condition of a conditional statement.
The following code prints the numbers 1,2,...,5. When the value of the variable number is more than 5, the while-condition evaluates to false and the execution of the loop ends for good.
int number = 1;
while (number < 6) {
    System.out.println(number);
    number++;
}

For Loop
First we introduce the variable i, used to count the number of times the loop has been executed so far, and set its value to 0: int i = 0;. This is followed by the definition of the loop — the loop's condition is i < 10 so the loop is executed as long as the value of the variable i is less than 10. The loop body contains the functionality to be executed System.out.println(i);, which is followed by increasing the value of the variable i++. The command i++ is shorthand for i = i + 1.
for (int i = 0; i < 10; i++) {
    System.out.println(i);
}

On Stopping a Loop Execution
A loop does not stop executing immediately when its condition evaluates to true. A loop's condition is evaluated at the start of a loop, meaning when (1) the loop starts for the first time or (2) the execution of a previous iteration of the loop body has just finished.
Let's look at the following loop.
int number = 1;
while (number != 2) {
    System.out.println(number);
    number = 2;
    System.out.println(number);
    number = 1;
}
It prints the following:
Sample output
1
2
1
2
1
2
...
Even though number equals 2 at one point, the loop runs forever.
The condition of a loop is evaluated when the execution of a loop starts and when the execution of the loop body has reached the closing curly bracket. If the condition evaluates to true, execution continues from the top of the loop body. If the condition evaluates to false, execution continues from the first statement following the loop.

Simulating program execution
As the number of variables increases, understanding a program becomes harder. Simulating program execution can help in understanding it.
You can simulate program execution by drawing a table containing a column for each variable and condition of a program, and a separate space for program output. You then go through the source code line by line, and write down the changes to the state of the program (the values of each variable or condition), and the program output.
The values of variables result and i from the previous example have been written out onto the table below at each point the condition i < 4 is evaluated.
result	i	i < 4
0	0	true
3	1	true
6	2	true
9	3	true
12	4	false

Implementing a program small part at a time
In the previous exercise, we used a series of exercises to practice implementing a program one piece at a time.
When you are writing a program, whether it's an exercise or a personal project, figure out the types of parts the program needs to function and proceed by implementing them one part at a time. Make sure to test the program right after implementing each part.
Never try solving the whole problem at once, because that makes running and testing the program in the middle of the problem-solving process difficult. Start with something easy that you know you can do. When one part works, you can move on to the next.

Methods and dividing the program into smaller parts
Technically speaking, a method is a named set of statements. It's a piece of a program that can be called from elsewhere in the code by the name given to the method. For instance System.out.println("I am a parameter given to the method!") calls a methods that performs printing to the screen. The internal implementation of the method — meaning the set of statements to be executed — is hidden, and the programmer does not need to concern themselves with it when using the method.

Custom Methods
A method means a named set consisting of statements that can be called from elsewhere in the program code by its name. Programming languages offer pre-made methods, but programmers can also write their own ones.
In the code boilerplate, methods are written outside of the curly braces of the main, yet inside out the "outermost" curly braces. They can be located above or below the main.
import java.util.Scanner;
public class Example {
    public static void main(String[] args) {
        Scanner scanned = new Scanner(System.in);
        // program code
    }

    // your own methods here
}
Let's observe how to create a new method. We'll create the method greet.
public static void greet() {
    System.out.println("Greetings from the method world!");
}
And then we'll insert it into a suitable place for a method.
import java.util.Scanner;
public class Example {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        // program code
    }

    // your own methods here
    public static void greet() {
        System.out.println("Greetings from the method world!");
    }
}
The definition of the method consists of two parts. The first line of the definition includes the name of the method, i.e. greet. On the left side of the name are the keywords public static void. Beneath the line containing the name of the method is a code block surrounded by curly brackets, inside of which is the code of the method — the commands that are executed when the method is called. The only thing our method greet does is write a line of text on the screen.
Calling a custom method is simple: write the name of the methods followed by a set of parentheses and the semicolon. In the following snippet the main program (main) calls the greet method four times in total.
import java.util.Scanner;
public class ProgramStructure {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        // program code
        System.out.println("Let's try if we can travel to the method world:");
        greet();
        System.out.println("Looks like we can, let's try again:");
        greet();
        greet();
        greet();
    }
    // own methods
    public static void greet() {
        System.out.println("Greetings from the method world!");
    }
}
The execution of the program produces the following output:
Sample output
Let's try if we can travel to the method world:
Greetings from the method world!
Looks like we can, let's try again:
Greetings from the method world!
Greetings from the method world!
Greetings from the method world!
The order of execution is worth noticing. The execution of the program happens by executing the lines of the main method (main) in order from top to bottom, one at a time. When the encountered statement is a method call, the execution of the program moves inside the method in question. The statements of the method are executed one at a time from top to bottom. After this the execution returns to the place where the method call occured, and then proceeds to the next statement in the program.
Strictly speaking, the main program (main) itself is a method. When the program starts, the operating system calls main. The main method is the starting point for the program, since the execution begins from its first line. The execution of a program ends at the end of the main method.
Methods cannot be defined e.g. inside other methods.

On Naming Methods
The names of methods begin with a word written entirely with lower-case letters, and the rest of the words begin with an upper-case letter - this style of writing is known as camelCase. Additionally, the code inside methods is indented by four characters.

Method Parameters
Parameters are values given to a method that can be used in its execution. The parameters of a method are defined on the uppermost line of the method within the parentheses following its name. The values of the parameters that the method can use are copied from the values given to the method when it is executed.
In the following example a parameterized method greet is defined. It has an int type parameter called numOfTimes.
public static void greet(int numOfTimes) {
    int i = 0;
    while (i < numOfTimes) {
        System.out.println("Greetings!");
        i++;
    }
}
We will call the method greet with different values. The parameter numOfTimes is assigned the value 1on the first call, and 3on the second.
public static void main(String[] args) {
    greet(1);
    System.out.println("");
    greet(3);
}
Sample output
Greetings!
Greetings!
Greetings!
Greetings!

Multiple Parameters
A method can be defined with multiple parameters. When calling such a method, the parameters are passed in the same order.
public static void sum(int first, int second) {
    System.out.println("The sum of numbers " + first + " and " + second + " is " + (first + second));
}
sum(3, 5);
int number1 = 2;
int number2 = 4;
sum(number1, number2);
Sample output
The sum of numbers 3 and 5 is 8
The sum of numbers 2 and 4 is 6

Parameter Values Are Copied in a Method Call
As a method is called the values of its parameters are copied. In practice, this means that both the main method and the method to be called can use variables with the same name. However, changing the value of the variables inside the method does not affect the value of the variable in the main method that has the same name.
So, method parameters are distinct from the variables (or parameters) of other methods, even if they had the same name. As a variable is passed to a method during a method call, the value of that variable gets copied to be used as the value of the parameter variable declared in the method definition. Variables in two separate methods are independent of one another.

Methods Can Return Values
The definition of a method tells whether that method returns a value or not. If it does, the method definition has to include the type of the returned value. Otherwise the keyword void is used in the definition.
public static **void** incrementByThree() {
    ...
}
The keyword void means that the method returns nothing. If we want the method to return a value, the keyword must be replaced with the type of the return variable. In the following example, there is a method called alwaysReturnsTen which returns an integer-type (int) variable (in this case the value 10).
To actually return a value, we use the command return followed by the value to be returned (or the name of the variable whose value is to be returned).
public static int alwaysReturnsTen() {
    return 10;
}
The method defined above returns an int-type value of 10 when called. For the return value to be used, it must be stored in a variable. This is done the same way as regular value assignment to a variable, by using an equals sign.
public static void main(String[] args) {
    int number = alwaysReturnsTen();

    System.out.println("the method returned the number " + number);
}
The return value of the method is placed in an int type variable as with any other int value. The return value can also be used in any other expression.
double number = 4 * alwaysReturnsTen() + (alwaysReturnsTen() / 2) - 8;
System.out.println("the result of the calculation " + number);
All the variable types we've encountered so far can be returned from a method.
When execution inside a method reaches the command return, the execution of that method ends and the value is returned to the calling method.
The lines of source code following the command return are never executed. If a programmer adds source code after the return to a place which can never be reached during the method's execution, the IDE will produce an error message.
For the IDE, a method such as the following is faulty.
public static int faultyMethod() {
    return 10;
    System.out.println("I claim to return an integer, but I don't.");
}

Defining Variables Inside Methods
Defining variables inside methods is done in the same manner as in the "main program". The following method calculates the average of the numbers it receives as parameters. Variables sum and avg are used to help in the calculation.
public static double average(int number1, int number2, int number3) {
    int sum = number1 + number2 + number3;
    double avg = sum / 3.0;
    return avg;
}
Variables defined in a method are only visible inside that method. In the example above, this means that the variables sum and avg defined inside the method average are not visible in the main program. 

Calculating the Return Value Inside a Method
The return value does not need to be entirely pre-defined - it can also be calculated. The return command that returns a value from the method can also be given an expression that is evaluated before the value is returned.
In the following example, we'll define a method sum that adds the values of two variables and returns their sum. The values of the variables to be summed are received as method parameters.
public static int sum(int first, int second) {
    return first + second;
}

Execution of Method Calls and the Call Stack
How does the computer remember where to return after the execution of a method?
The environment that executes Java source code keeps track of the method being executed in the call stack. The call stack contains frames, each of which includes information about a specific method's internal variables and their values. When a method is called, a new frame containing its variables is created in the call stack. When the execution of a method ends, the frame relating to a method is removed from the call stack, which leads to execution resuming at the previous method of the stack.

Call Stack and Method Parameters
Let's examine the call stack in a situation where parameters have been defined for the method.
public static void main(String[] args) {
    int beginning = 1;
    int end = 5;

    printStars(beginning, end);
}
public static void printStars(int beginning, int end) {
    while (beginning < end) {
        System.out.print("*");
        beginning++; // same as beginning = beginning + 1
    }
}
The execution of the program begins on the first line of the main method. The next two lines create the variables beginning and end, and also assign values to them. The state of the program prior to calling the method printStars
Sample output
main
  beginning = 1
  end = 5
When printStars is called, the main method enters a waiting state. The method call causes new variables beginning and end to be created for the method printStars, to which the values passed as parameters are assigned to. These values are copied from the variables beginning and end of the main method. The state of the program on the first line of the execution of the method printStars is illustrated below.
Sample output
printStars
  beginning = 1
  end = 5
main
  beginning = 1
  end = 5
When the command beginning++ is executed within the loop, the value of the variable beginning that belongs to the method currently being executed changes.
Sample output
printStars
  beginning = 2
  end = 5
main
  beginning = 1
  end = 5
As such, the values of the variables in the method main remain unchanged. The execution of the method printStart would continue for some time after this. When the execution of that method ends, the execution resumes inside the main method.
Sample output
main
  beginning = 1
  end = 5