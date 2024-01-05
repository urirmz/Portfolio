// The .NET software development kit (SDK) includes a command-line interface (CLI) that can be accessed from Visual Studio Code's integrated Terminal. During this training, you use .NET CLI commands to create new console applications, build your project code, and run your applications.
// For example, the following .NET CLI command will create a new console application in the specified folder location:
// dotnet new console -o ./CsharpProjects/TestProject
// The structure of a CLI command consists of the following three parts:
// The driver: dotnet in this example.
// The command: new console in this example.
// The command arguments: -o ./CsharpProjects/TestProject in this example.

// To compile a build of your application, enter the following command at the Terminal command prompt:
// dotnet build

// The dotnet build command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a .dll extension. Depending on the project type and settings, other files may also be included. If you're curious, you can find the TestProject.dll file in the EXPLORER panel at a folder location that's similar to the following path:
// C:\Users\someuser\Desktop\CsharpProjects\TestProject\bin\Debug\net7.0\
//  Note
// Your folder path will reflect your account and the folder path to your TestProject folder.
// To run your application, enter the following command at the Terminal command prompt:
// dotnet run
// The dotnet run command runs source code without any explicit compile or launch commands. It provides a convenient option to run your application from the source code with one command. It's useful for fast iterative development from the command line. The command depends on the dotnet build command to build the code.

// Methods in the .NET Class Library
// When you need to implement a programming task, the .NET Class Library is a good place to look, because it is an organized collection of programming resources.
// The .NET Class Library is a collection of thousands of classes containing tens of thousands of methods.
// you won't be using every class and method in the .NET Class Library. Depending on the types of projects that you work on, you'll become more familiar with some parts of the .NET Class Library and less familiar with others. Again, it's like spending time in a section of the public library, over time you become familiar with what's available. No one knows all of the .NET Class Library, not even people that work at Microsoft.
// Second, necessity will drive you to what you need. Most people go to the library when they need to find a book, not to see how many different books they can find.You don't need to research classes and methods without a reason. When you have trouble figuring out a programming task, you can use your favorite search engine to find blog posts, articles, or forums where other developers have worked through similar issues. Third-party sources can give you clues about which .NET classes and methods you might want to use, and you may even find sample code that you can try.
// From your previous experience with the Console.WriteLine() method, you should already know the basics:
// Start by typing the class name. In this case, the class name is Console.
// Add the member access operator, the . symbol.
// Add the method's name. In this case, the method's name is WriteLine.
// Add the method invocation operator, which is a set of parentheses ().
// Finally, specify the arguments that are passed to the method, if there are any, between the parentheses of the method invocation operator. In this case, you specify the text that you want the Console.WriteLine() method to write to the console (for example, "Hello World!").
// Optionally, depending on how the developers designed and implemented the given method, you may also need to:
// Pass additional values as input parameters.
// Accept a return value.
// In the next unit, you'll examine how to pass input values to a method, and how a method can be used to return a value to the calling routine.
// While some methods can be called the same way that you called Console.WriteLine(), there are other methods in the .NET Class Library that require a different approach.

// Stateful versus stateless methods
// In software development projects, the term state is used to describe the condition of the execution environment at a specific moment in time. As your code executes line by line, values are stored in variables. At any moment during execution, the current state of the application is the collection of all values stored in memory.
// Some methods don't rely on the current state of the application to work properly. In other words, stateless methods are implemented so that they can work without referencing or changing any values already stored in memory. Stateless methods are also known as static methods.
// For example, the Console.WriteLine() method doesn't rely on any values stored in memory. It performs its function and finishes without impacting the state of the application in any way.
// Other methods, however, must have access to the state of the application to work properly. In other words, stateful methods are built in such a way that they rely on values stored in memory by previous lines of code that have already been executed. Or they modify the state of the application by updating values or storing new values in memory. They're also known as instance methods.
// Stateful (instance) methods keep track of their state in fields, which are variables defined on the class. Each new instance of the class gets its own copy of those fields in which to store state.
// A single class can support both stateful and stateless methods. However, when you need to call stateful methods, you must first create an instance of the class so that the method can access state.
// Some methods require you to create an instance of a class before you call them, while others do not. How can you determine whether you need to create an instance of a class before calling its methods? 
// One approach for determining whether a method is stateful or stateless is to consult the documentation. The documentation includes examples that show whether the method must be called from the object instance or directly from the class.
// As an alternative to searching through product documentation, you can attempt to access the method directly from the class itself. If it works, you know that it's a stateless method. The worst that can happen is that you'll get a compilation error.

// Creating an instance of a class
// An instance of a class is called an object. To create a new instance of a class, you use the new operator. Consider the following line of code that creates a new instance of the Random class to create a new object called dice:
// Random dice = new Random();
// The new operator does several important things:
// It first requests an address in the computer's memory large enough to store a new object based on the Random class.
// It creates the new object, and stores it at the memory address.
// It returns the memory address so that it can be saved in the dice variable.
// From that point on, when the dice variable is referenced, the .NET Runtime performs a lookup behind the scenes to give the illusion that you're working directly with the object itself.
// The latest version of the .NET Runtime enables you to instantiate an object without having to repeat the type name (target-typed constructor invocation). For example, the following code will create a new instance of the Random class:
// Random dice = new();
// The intention is to simplify code readability. You always use parentheses when writing a target-typed new expression.

// Return values
// Some methods are designed to complete their function and end "quietly". In other words, they don't return a value when they finish. They are referred to as void methods.
// Other methods are designed to return a value upon completion. The return value is typically the result of an operation. A return value is the primary way for a method to communicate back to the code that calls the method.

// Input parameters
// The information consumed by a method is called a parameter. A method can use one or more parameters to accomplish its task, or none at all.
// Most methods are designed to accept one or more input parameters. The input parameters can be used to configure how the method performs its work, or they might be operated on directly. For example, the Random.Next() method uses input parameters to configure the upper and lower boundaries of the return value. However, the Console.WriteLine() uses the input parameter directly by printing the value to the console.
// Methods use a method signature to define the number of input parameters that the method will accept, as well as the data type of each parameter. The coding statement that calls the method must adhere the requirements specified by the method signature. Some methods provide options for the number and type of parameters that the method accepts.
// When a caller invokes the method, it provides concrete values, called arguments, for each parameter. The arguments must be compatible with the parameter type. However, the argument name, if one is used in the calling code, doesn't have to be the same as the parameter named defined in the method.

// Overloaded methods
// Many methods in the .NET Class Library have overloaded method signatures. Among other things, this enables you to call the method with or without arguments specified in the calling statement.
// An overloaded method is defined with multiple method signatures. Overloaded methods provide different ways to call the method or provide different types of data.

// IntelliSense
// Visual Studio Code includes IntelliSense features that are powered by a language service. For example, the C# language service provides intelligent code completions based on language semantics and an analysis of your source code. In this section, you'll use IntelliSense to help you implement the Random.Next() method.
// Since IntelliSense is exposed within the code editor, you can learn a lot about a method without leaving the coding environment. IntelliSense provides hints and reference information in a popup window under the cursor location as you enter your code. When you are typing code, the IntelliSense popup window will change its contents depending on the context.
// For example, as you enter the word dice slowly, IntelliSense will show all C# keywords, identifiers (or rather, variable names in the code), and classes in the .NET Class Library that match the letters being entered. Autocomplete features of the code editor can be used to finish typing the word that is the top match in the IntelliSense popup

// If statements
// The if statement relies on a Boolean expression that is enclosed in a set of parentheses. If the expression is true, the code after the if statement is executed. If not, the .NET runtime ignores the code and doesn't execute it.
// Enter the following if statements.
// if (total > 14)
// {
//     Console.WriteLine("You win!");
// }
// if (total < 15)
// {
//     Console.WriteLine("Sorry, you lose.");
// }
// These two if statements are used to handle the winning and losing scenarios. Take a minute to examine the first if statement.
// Notice that the if statement is made up of three parts:
// The if keyword
// A Boolean expression between parenthesis ()
// A code block defined by curly braces { }
// At run time, the Boolean expression total > 14 is evaluated. If this is a true statement (if the value of total is greater than 14) then the flow of execution will continue into the code defined in the code block. In other words, it will execute the code in the curly braces.
// However, if the Boolean expression is false (the value of total not greater than 14) then the flow of execution will skip past the code block. In other words, it will not execute the code in the curly braces.
// Finally, the second if statement controls the message if the user loses. In the next unit, you'll use a variation on the if statement to shorten these two statements into a single statement that more clearly expresses the intent.
// Boolean expressions can be created by using operators to compare two values. Operators include:
// ==, the "equals" operator, to test for equality
// >, the "greater than" operator, to test that the value on the left is greater than the value on the right
// <, the "less than" operator, to test that the value on the left is less than the value on the right
// >=, the "greater than or equal to" operator
// <=, the "less than or equal to" operator
// and so on

// Code block
// A code block is a collection of one or more lines of code that are defined by an opening and closing curly brace symbol { }. It represents a complete unit of code that has a single purpose in your software system. In this case, at runtime, all lines of code in the code block are executed if the Boolean expression is true. Conversely, if the Boolean expression is false, all lines of code in the code block are ignored.
// You should also know that code blocks can contain other code blocks. In fact, it's common for one code block to be "nested" inside another code block in your applications.

// OR operator
// To create your "doubles" game feature, enter the following if statement.
// if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3))
// {
//     Console.WriteLine("You rolled doubles! +2 bonus to total!");
//     total += 2;
// }
// Here you combine three Boolean expressions to create one composite Boolean expression in a single line of code. This is sometimes called a compound condition. You have one outer set of parentheses that combines three inner sets of parentheses separated by two pipe characters.
// The double pipe characters || are the logical OR operator, which basically says "either the expression to my left OR the expression to my right must be true in order for the entire Boolean expression to be true". If both Boolean expressions are false, then the entire Boolean expression is false. You use two logical OR operators so that you can extend the evaluation to a third Boolean expression.
// First, you evaluate (roll1 == roll2). If that's true, then the entire expression is true. If it's false, you evaluate (roll2 == roll3). If that's true, then the entire expression is true. If it's false, you evaluate (roll1 == roll3). If that's true, then the entire expression is true. If that is false, then the entire expression is false.
// If the composite Boolean expression is true, then you execute the following code block. This time, there are two lines of code. The first line of code prints a message to the user. The second line of code increments the value of total by 2.

// AND operator
// To create your "triples" game feature, enter the following if statement.
// if ((roll1 == roll2) && (roll2 == roll3)) 
// {
//     Console.WriteLine("You rolled triples! +6 bonus to total!");
//     total += 6;
// }
// Here you combine two Boolean expressions to create one composite Boolean expression in a single line of code. You have one outer set of parentheses that combines two inner sets of parentheses separated by two ampersand characters.
// The double ampersand characters && are the logical AND operator, which basically says "only if both expressions are true, then the entire expression is true". In this case, if roll1 is equal to roll2, and roll2 is equal to roll3, then by deduction, roll1 must be equal to roll3, and the user rolled triples.

// Use if and else statements instead of two separate if statements
// Instead of performing two checks to display the "You win!" or "Sorry, you lose" message, you'll use the else keyword.
// Notice that both if statements compare total with the same numeric value. This is the perfect opportunity to use an else statement.
// Update the two if statements as follows:
// if (total >= 15)
// {
//     Console.WriteLine("You win!");
// }
// else 
// {
//     Console.WriteLine("Sorry, you lose.");
// }
// Here, if total >= 15 is false, then the code block following the else keyword will execute. Since the two outcomes are related opposites, this is a perfect scenario for the else keyword.

// Nesting
// Nesting allows you to place code blocks inside of code blocks. In this case, you'll nest an if and else combination (the check for doubles) inside of another if statement (the check for triples) to prevent both bonuses from being awarded.
// Modify your code to match the following code listing:
// if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3))
// {
//     if ((roll1 == roll2) && (roll2 == roll3))
//     {
//         Console.WriteLine("You rolled triples!  +6 bonus to total!");
//         total += 6;
//     }
//     else
//     {
//         Console.WriteLine("You rolled doubles!  +2 bonus to total!");
//         total += 2;
//     }
// }
// The goal is to create an inner if-else construct where the two outcomes are related opposites, and then use the opposing outcomes (if/true and else/false) to award the bonus points for triples and doubles. To achieve this goal, you check for doubles in the outer if statement, and then for triples in the inner if statement. This pattern ensures that when the inner check for triples returns false, your else code block can award the points for doubles.

// Else if
// To make the game more fun, you can change the game from "win-or-lose" to awarding fictitious prizes for each score. You can offer four prizes. However, the player should win only one prize:
// If the player scores greater or equal to 16, they'll win a new car.
// If the player scores greater or equal to 10, they'll win a new laptop.
// If the player scores exactly 7, they'll win a trip.
// Otherwise, the player wins a kitten.
// if (total >= 16)
// {
//     Console.WriteLine("You win a new car!");
// }
// else if (total >= 10)
// {
//     Console.WriteLine("You win a new laptop!");
// }
// else if (total == 7)
// {
//     Console.WriteLine("You win a trip for two!");
// }
// else
// {
//     Console.WriteLine("You win a kitten!");
// }
// The if, else if, and else statements allow you to create multiple exclusive conditions as Boolean expressions. In other words, when you only want one outcome to happen, but you have several possible conditions and results, use as many else if statements as you want. If none of the if and else if statements apply, the final else code block will be executed. The else is optional, but it must come last if you choose to include it.

// C# arrays 
// C# arrays allow you to store sequences of values in a single data structure. In other words, imagine a single variable that can hold many values. Once you have a single variable that stores all the values, you can sort the values, reverse the order of the values, loop through each value and inspect it individually, and so on.
// To declare a new array of strings that can hold three elements, enter the following code:
// string[] fraudulentOrderIDs = new string[3];
// The new operator creates a new instance of an array in the computer's memory that can hold three string values. For more information about the new keyword, see the module "Call methods from the .NET Class Library using C#".
// Notice that the first set of square brackets [] merely tells the compiler that the variable named fraudulentOrderIDs is an array, but the second set of square brackets [3] indicates the number of elements that the array can hold.
// To access an element of an array, you use a numeric zero-based index inside of square brackets. You can assign a value to an array element using the = as if it were a regular variable.
// To assign Order ID values to your fraudulentOrderIDs array, update your code as follows:
// string[] fraudulentOrderIDs = new string[3];
// fraudulentOrderIDs[0] = "A123";
// fraudulentOrderIDs[1] = "B456";
// fraudulentOrderIDs[2] = "C789";
// Retrieve values from elements of an array
// Accessing the value of an array element works the same way as assigning a value to an array element. You just specify the index of the element whose value you want to retrieve.
// To write the value of each fraudulent Order ID, update your code as follows:
// string[] fraudulentOrderIDs = new string[3];
// fraudulentOrderIDs[0] = "A123";
// fraudulentOrderIDs[1] = "B456";
// fraudulentOrderIDs[2] = "C789";
// Console.WriteLine($"First: {fraudulentOrderIDs[0]}");
// Console.WriteLine($"Second: {fraudulentOrderIDs[1]}");
// Console.WriteLine($"Third: {fraudulentOrderIDs[2]}");
// Reassign the value of an array
// The elements of an array are just like any other variable value. You can assign, retrieve, and reassign a value to each element of the array.
// To reassign and then print the value of the first array element, enter the following code:
// fraudulentOrderIDs[0] = "F000";
// Console.WriteLine($"Reassign First: {fraudulentOrderIDs[0]}");
// Initialize an array
// You can initialize an array during declaration just like you would a regular variable. However, to initialize the elements of the array, you use a special syntax featuring curly braces.
// To declare the array initialize values in a single statement, enter the following code:
// string[] fraudulentOrderIDs = { "A123", "B456", "C789" };

// Foreach
// The foreach statement provides a simple, clean way to iterate through the elements of an array. The foreach statement processes array elements in increasing index order, starting with index 0 and ending with index Length - 1. It uses a temporary variable to hold the value of the array element associated with the current iteration. Each iteration will run the code block that's located below the foreach declaration.
// Here's a simple example:
// string[] names = { "Rowena", "Robin", "Bao" };
// foreach (string name in names)
// {
//     Console.WriteLine(name);
// }
// Below the foreach keyword, the code block that contains the Console.WriteLine(name); will execute once for each element of the names array. As the .NET runtime loops through each element of the array, the value stored in the current element of the names array is assigned to the temporary variable name for easy access inside of the code block.
// If you ran the code, you would see the following result.
// Rowena
// Robin
// Bao

// Variable name rules
// Variable names can contain alphanumeric characters and the underscore character. Special characters like the pound #, the dash -, and the dollar sign $ are not allowed.
// Variable names must begin with an alphabetical letter or an underscore, not a number. Developers use the underscore for a special purpose, so try to not use that for now.
// Variable names must NOT be a C# keyword. For example, these variable name declarations won't be allowed: float float; or string string;.
// Variable names are case-sensitive, meaning that string MyValue; and string myValue; are two different variables.

// Variable name conventions
// Conventions are suggestions that are agreed upon by the software development community. While you're free to decide not to follow these conventions, they're so popular that it might make it difficult for other developers to understand your code. You should practice adopting these conventions and make them part of your own coding habits.
// Variable names should use camel case, which is a style of writing that uses a lower-case letter at the beginning of the first word and an upper-case letter at the beginning of each subsequent word. >For example: string thisIsCamelCase;.
// Variable names should be descriptive and meaningful in your application. You should choose a name for your variable that represents the kind of data it will hold (not the data type). >For example: bool orderComplete;, NOT bool isComplete;.
// Variable names should be one or more entire words appended together. Don't use contractions because the name of the variable may be unclear to others who are reading your code. >For example: decimal orderAmount;, NOT decimal odrAmt;.
// Variable names shouldn't include the data type of the variable. You might see some advice to use a style like string strMyValue;. It was a popular style years ago. However, most developers don't follow this advice anymore and there are good reasons not to use it.

// Local variables 
// A local variable is a variable that is scoped within the body of a method, or a variable in a console application that uses top-level statements (like the code in this module).
// There are other types of constructs that you can use in your applications, and many have their own conventions. For example, classes are often used in C# programming. Classes support fields, which are members of a class that act like variables inasmuch that they store values, or rather, state. Classes also support accessibility modifiers, which allow some values to be private or public. A private member can only be referenced by other members in the same class. A public member can be referenced outside of the class. So, you can create private fields or public fields

// Code comments
// A code comment is an instruction to the compiler to ignore everything after the code comment symbols in the current line.
// // This is a code comment!
// This may not seem useful at first, however it's useful in three situations:
// When you want to leave a note about the intent of a passage of code. It can be helpful to include code comments that describe the purpose or the thought process when you're writing a particularly challenging set of coding instructions. Your future self will thank you.
// When you want to temporarily remove code from your application to try a different approach, but you're not yet convinced your new idea will work. You can comment out the code, write the new code, and once you're convinced the new code will work the way you want it to, you can safely delete the old (commented code).
// Adding a message like TODO to remind you to look at a given passage of code later. While you should use this judiciously, it's a useful approach. You may be working on another feature when you read a line of code that sparks a concern. Rather than ignoring the new concern, you can mark it for investigation later.
// To apply a block comment that comments out multiple lines, update your code as follows:
// /*
// string firstName = "Bob";
// int widgetsPurchased = 7;
// Console.WriteLine($"{firstName} purchased {widgetsPurchased} widgets.");
// */
// To add a comment that explains the higher-level purpose of your code, update your code as follows:
// /*
//   The following code creates five random OrderIDs
//   to test the fraud detection process.  OrderIDs 
//   consist of a letter from A to E, and a three
//   digit number. Ex. A123.
// */
// Random random = new Random();
// string[] orderIDs = new string[5];
// for (int i = 0; i < orderIDs.Length; i++)
// {
//     int prefixValue = random.Next(65, 70);
//     string prefix = Convert.ToChar(prefixValue).ToString();
//     string suffix = random.Next(1, 1000).ToString("000");

//     orderIDs[i] = prefix + suffix;
// }
// foreach (var orderID in orderIDs)
// {
//     Console.WriteLine(orderID);
// }

// Whitespace
// The term "whitespace" refers to individual spaces produced by the space bar, tabs produced by the tab key, and new lines produced by the enter key.
// The C# compiler ignores whitespace. Whitespace doesn't matter to the compiler. However ...
// Whitespace, when used properly, can increase your ability to read and comprehend the code.

/* Example readable code
//  /*
//    This code reverses a message, counts the number of times 
//    a particular character appears, then prints the results
//    to the console window.
//  */

// string originalMessage = "The quick brown fox jumps over the lazy dog.";

// char[] message = originalMessage.ToCharArray();
// Array.Reverse(message);

// int letterCount = 0;

// foreach (char letter in message)
// {
//     if (letter == 'o')
//     {
//         letterCount++;
//     }
// }

// string newMessage = new String(message);

// Console.WriteLine(newMessage);
// Console.WriteLine($"'o' appears {letterCount} times.");
*/