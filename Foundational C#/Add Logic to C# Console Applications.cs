// Expression
// An expression is any combination of values (literal or variable), operators, and methods that return a single value. A statement is a complete instruction in C#, and statements are comprised of one or more expressions. For example, the following if statement contains a single expression that returns a single value:
// if (myName == "Luiz")
// You might have been thinking that the value returned by an expression would be a number or maybe a string. It's true that application developers use different types of expressions for different purposes. In this case, when you're developing an if selection statement, you'll be using an expression that returns either true or false. Developers refer to this type of expression as a Boolean expression. When your code includes a Boolean expression, return value is always a single true or false value.

// Equality and inequality
// When checking for equality, you'll locate the equality operator == between the two values being checked. If the values on either side of the equality operator are equivalent, then the expression will return true. Otherwise, it will return false.
// Conversely, you might also need to check whether two values aren't equal. To check for inequality, you'll use the inequality operator != between the two values.

// Check for string equality
// You might be surprised that the line Console.WriteLine("a" == "A"); outputs false. When comparing strings, case matters.
// Also, consider this line of code:
// Console.WriteLine("a" == "a ");
// Here you've added a space character at the end of the string. This expression will also output false.
// In some cases, having a space character before or after the text might be perfectly acceptable. However, if you need to accept a match that isn't exact, you can "massage" the data first. "Massaging" the data means that you perform some cleanup before you perform a comparison for equality.
// Before you check two string values for equality, especially when one or both values were entered by a user, you should:
// Make sure both strings are all upper-case or all lower-case using the ToUpper() or ToLower() helper method on any string value.
// Remove any leading or trailing blank spaces using the Trim() helper method on any string value.

// Evaluating comparisons
// When working with numeric data types, you might want to determine if a value is larger or smaller than another value. Use the following operators to perform these types of comparisons:
// Greater than >
// Less than <
// Greater than or equal to >=
// Less than or equal to <=
// Naturally, the == and != operators that you used to compare string values above will also work when comparing numeric data types.

// Methods that return a Boolean value
// Some methods return a Boolean value (true or false).
// Type the following code into the Visual Studio Code Editor.
// string pangram = "The quick brown fox jumps over the lazy dog.";
// Console.WriteLine(pangram.Contains("fox"));
// Console.WriteLine(pangram.Contains("cow"));
// Save your code file, and then use Visual Studio Code to build and run your code.
// You should see the following output.
// True
// False

// Logical negation
// The term "Logical Negation" refers to the unary negation operator !. Some people call this operator the "not operator". When you place the ! operator before a conditional expression (or any code that's evaluated to either true or false), it forces your code to reverse its evaluation of the operand. When logical negation is applied, the evaluation produces true , if the operand evaluates to false , and false , if the operand evaluates to true.
// Here is an example that might help you to see the connection between these ideas. The following two lines of code produce the same result. The second line is more compact.
// // These two lines of code will create the same output
// Console.WriteLine(pangram.Contains("fox") == false);
// Console.WriteLine(!pangram.Contains("fox"));

// Conditional operator
// The conditional operator ?: evaluates a Boolean expression and returns one of two results depending on whether the Boolean expression evaluates to true or false. The conditional operator is commonly referred to as the ternary conditional operator.
// Here's the basic form:
// <evaluate this condition> ? <if condition is true, return this value> : <if condition is false, return this value>
// Example:
// int saleAmount = 1001;
// int discount = saleAmount > 1000 ? 100 : 50;
// Console.WriteLine($"Discount: {discount}");

// Variable scope
// Selection and iteration statements use code blocks to group-together the code lines that should be executed, skipped, or iterated over. But that's not the only purpose for code blocks. Code blocks can also be used to control or limit variable accessibility. Variable "scope" refers to the portion of an application where a variable is accessible.
// The boundaries of a code block are typically defined by squiggly braces, {}.
// A locally scoped variable is only accessible inside of the code block in which it's defined. If you attempt to access the variable outside of the code block, you'll get a compiler error.

// Code blocks
// If a code block needs only one line of code, chances are you don't need to define a formal code block using curly braces. Although technically you don't even need to separate your code into multiple lines, combining statements on a single line can make your code hard to read.
// Removing the curly braces as described above is a stylistic change that shouldn't affect the functionality of your code. However, you should take steps to ensure that your changes do not negatively impact how readable the code is. You can evaluate the impact of removing the curly braces and white space, then revert back to the original code if you find that the changes made your code less readable.
// When implementing an if statement that includes a single-statement code block, Microsoft recommends that you consider these conventions:
// Never use single-line form (for example: if (flag) Console.WriteLine(flag);
// Using braces is always accepted, and required if any block of an if/else if/.../else compound statement uses braces or if a single statement body spans multiple lines.
// Braces may be omitted only if the body of every block associated with an if/else if/.../else compound statement is placed on a single line.
// Type the following code into the Visual Studio Code Editor:
// bool flag = true;
// if (flag)
// {
//     Console.WriteLine(flag);
// }
// Update your code in the Visual Studio Code Editor as follows:
// bool flag = true;
// if (flag)
//     Console.WriteLine(flag);
// Since both the if statement and the method call to Console.WriteLine() are short, you might be tempted to combine them on a single line. After all, C# syntax for the if statement allows you to combine statements in this way.
// Update your code in the Visual Studio Code Editor as follows:
// bool flag = true;
// if (flag) Console.WriteLine(flag);
// To examine the readability impact for larger if-elseif-else constructs, update your code as follows:
// string name = "steve";
// if (name == "bob") Console.WriteLine("Found Bob");
// else if (name == "steve") Console.WriteLine("Found Steve");
// else Console.WriteLine("Found Chuck");
// Compare the code that you just ran with the following code:
// string name = "steve";
// if (name == "bob")
//     Console.WriteLine("Found Bob");
// else if (name == "steve") 
//     Console.WriteLine("Found Steve");
// else
//     Console.WriteLine("Found Chuck");

// Switch statement
// the following code sample that shows the basic structure of switch statement:
// int employeeLevel = 200;
// string employeeName = "John Smith";
// string title = "";
// switch (employeeLevel)
// {
//     case 100:
//         title = "Junior Associate";
//         break;
//     case 200:
//         title = "Senior Associate";
//         break;
//     case 300:
//         title = "Manager";
//         break;
//     case 400:
//         title = "Senior Manager";
//         break;
//     default:
//         title = "Associate";
//         break;
// }
// Console.WriteLine($"{employeeName}, {title}");
// The match expression (which may also be referred to as the switch expression) is the value following the switch keyword, in this case (employeeLevel). Each switch section is defined by a case pattern. Case patterns are constructed using the keyword case followed by a value. The first case pattern in this example is: case "100":. Case patterns are Boolean expressions that evaluate to either true or false. Each switch section includes a small number of code lines that will be executed if the case pattern is a match for the match expression. In this example, if fruit is assigned a value of "100", the first case pattern will evaluate as true and that switch section will be executed. Only one switch section is allowed to be executed. This means that execution of a switch section is not permitted to “fall through” to the next switch section. The break keyword is one of several ways to end a switch section before it gets to the next section. If you forget the break keyword (or, optionally, the return keyword) the compiler will generate an error.
// A switch statement must include at least one switch section, but will normally contain three or more switch sections.
// The switch is best used when:
// You have a single value (variable or expression) that you want to match against many possible values.
// For any given match, you need to execute a couple of lines of code at most.
// The switch expression is evaluated against the case labels from top to bottom until a value that is equal to the switch expression is found. If none of the labels are a match, the statement list for the default case will be executed. If no default is included, control is transferred to the end point of the switch statement. Each label must provide a value type that matches the type specified in the switch expression.
// To assign multiple labels to the first switch section, update your code as follows:
// case 100:
// case 200:
//     title = "Senior Associate";
//     break;

// For statement
// The for statement iterates through a code block a specific number of times. This level of control makes the for statement unique among the other iteration statements. The foreach statement iterates through a block of code once for each item in a sequence of data like an array or collection. The while statement iterates through a block of code until a condition is met.
// Furthermore, the for statement gives you much more control over the process of iteration by exposing the conditions for iteration.
// Type the following code into the Visual Studio Code Editor.
// for (int i = 0; i < 10; i++)
// {
//     Console.WriteLine(i);
// }
// This code presents a simple for statement that loops through its code block 10 times, printing the current value of i.
// Take a minute to identify the six parts of the for statement.
// The for statement includes the following six parts:
// 1. The for keyword.
// 2. A set of parenthesis that defines the conditions of for iteration. The parentheses contain three distinct parts, separated by the end of statement operator, a semi-colon.
// 3. The first part defines and initializes the iterator variable. In this example: int i = 0. This section is referred to as the initializer.
// 4. The second part defines the completion condition. In this example: i < 10. In other words, the runtime will continue to iterate over the code in the code block below the for statement while i is less than 10. When i becomes equal to 10, the runtime stops executing the for statement's code block. The docs refer to this section as the condition.
// 5. The third part defines the action to take after each iteration. In this case, after each iteration, i++ will increment the value of i by 1. The docs refer to this section as the iterator.
// 6. Finally, the code block. The code block contains the code that will be executed for each iteration. Notice that the value of i is referenced inside of the code block. The docs refer to this section as the body.
// Given our rules for naming variables, you may wonder if i is a valid name for the variable that holds the current iteration. In this case, i is considered by most to be valid. Other popular choices are x and counter. The name j is also used in those situations when you have an outer for statement that uses i, and need to create an iteration variable for an inner for statement.
// Update your code as follows:
// for (int i = 0; i < 10; i++)
// {
//     Console.WriteLine(i);
//     if (i == 7) break;
// }
// Take a minute to review the use of the break keyword in your updated code.
// We first saw the break keyword in the module "Branch the flow of code using the switch-case construct in C#". As it turns out, we can use the break keyword to exit out of iteration statements as well.

// Do and while
// The do-while and while statements are yet another iteration statement that allows you to iterate through a code block and thereby change the flow of execution of your code
// The do-while statement executes a statement or a block of statements while a specified Boolean expression evaluates to true. Because that expression is evaluated after each execution of the loop, a do-while loop executes one or more times.
// do
// {
//     // This code executes at least one time
// } while (true);
// The flow of execution starts inside of the curly brace. The code executes at least one time, then the Boolean expression next to the while keyword is evaluated. If the Boolean expression returns true, the code block is executed again.
// By hard coding the Boolean expression to true, we've created an infinite loop--a loop that will never end, at least, n
// Continue statement 
// In certain cases, we want to short-circuit the remainder of the code in the code block and continue to the next iteration. We can do that using the continue statement.
// Use the Visual Studio Code Editor to update your code as follows:
// Random random = new Random();
// int current = random.Next(1, 11);
// do
// {
//     current = random.Next(1, 11);
//     if (current >= 8) continue;
//     Console.WriteLine(current);
// } while (current != 7);
// Since our code that writes the value of current to the console is located after the if (current >= 8) continue;, our code ensures that a value of current that is greater than or equal to 8 will never be written to the output window
// The continue statement transfers execution to the end of the current iteration. This behavior is different than the behavior we saw with the break statement. The break statement terminates the iteration (or switch) and transfers control to the statement that follows the terminated statement. If there is no statement after the terminated statement, then control transfers to the end of the file or method.

// User input
// When using a Console.ReadLine() statement to obtain user input, it's common practice to use a nullable type string (designated string?) for the input variable and then evaluate the value entered by the user. The following code sample uses a nullable type string to capture user input. The iteration continues while the user-supplied value is null:
// string? readResult;
// Console.WriteLine("Enter a string:");
// do
// {
//     readResult = Console.ReadLine();
// } while (readResult == null);
// The Boolean expression evaluated by the while statement can be used to ensure user input meets a specified requirement. For example, if a prompt asks the user to enter a string that includes at least three characters, the following code could be used:
// string? readResult;
// bool validEntry = false;
// Console.WriteLine("Enter a string containing at least three characters:");
// do
// {
//     readResult = Console.ReadLine();
//     if (readResult != null)
//     {
//         if (readResult.Length >= 3)
//         {
//             validEntry = true;
//         }
//         else
//         {
//             Console.WriteLine("Your input is invalid, please try again.");
//         }
//     }
// } while (validEntry == false);
// If you want to use Console.ReadLine() input for numeric values, you need to convert the string value to a numeric type.
// The int.TryParse() method can be used to convert a string value to an integer. The method uses two parameters, a string that will be evaluated and the name of an integer variable that will be assigned a value. The method returns a Boolean value. The following code sample demonstrates using the int.TryParse() method:
// // capture user input in a string variable named readResult
// int numericValue = 0;
// bool validNumber = false;
// validNumber = int.TryParse(readResult, out numericValue);
// If the string value assigned to readResult represents a valid integer, the value will be assigned to the integer variable named numericValue, and true will be assigned to the Boolean variable named validNumber. If the value assigned to readResult doesn't represent a valid integer, validNumber will be assigned a value of false.

// Data type casting and conversion
// If you need to change a value from the original data type to a new data type and the change could produce an exception at run time, you must perform a data conversion.
// To perform data conversion, you can use one of several techniques:
// Use a helper method on the data type
// Use a helper method on the variable
// Use the Convert class' methods