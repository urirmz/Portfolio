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
// The term widening conversion means that you're attempting to convert a value from a data type that could hold less information to a data type that can hold more information. For example, a value stored in a variable of type int converted to a variable of type decimal, doesn't lose information.
// Add the following code:
// decimal myDecimal = 3.14m;
// Console.WriteLine($"decimal: {myDecimal}");
// int myInt = (int)myDecimal;
// Console.WriteLine($"int: {myInt}");
// To perform a cast, you use the casting operator () to surround a data type, then place it next to the variable you want to convert (example: (int)myDecimal). You perform an explicit conversion to the defined cast data type (int).
// Save your code file, and then use Visual Studio Code to run your code.
// You should see the following output:
// decimal: 3.14
// int: 3
// The key to this example is this line of code:
// int myInt = (int)myDecimal;
// The variable myDecimal holds a value that has precision after the decimal point. By adding the casting instruction (int), you're telling the C# compiler that you understand it's possible you'll lose that precision, and in this situation, it's fine. You're telling the compiler that you're performing an intentional conversion, an explicit conversion.
// The term narrowing conversion means that you're attempting to convert a value from a data type that can hold more information to a data type that can hold less information. In this case, you may lose information such as precision (that is, the number of values after the decimal point). An example is converting value stored in a variable of type decimal into a variable of type int. If you print the two values, you would possibly notice the loss of information.
// When you know you're performing a narrowing conversion, you need to perform a cast. Casting is an instruction to the C# compiler that you know precision may be lost, but you're willing to accept it.

// ToString()
// Every data type variable has a ToString() method. What the ToString() method does depends on how it's implemented on a given type. However, on most primitives, it performs a widening conversion. While this isn't strictly necessary (since you can rely on implicit conversion in most cases) it can communicate to other developers that you understand what you're doing and it's intentional.
// Parse()
// Most of the numeric data types have a Parse() method, which converts a string into the given data type.
// Convert class
// The Convert class has many helper methods to convert a value from one type into another. In the following code example, you convert a couple of strings into values of type int.
// string value1 = "5";
// string value2 = "7";
// int result = Convert.ToInt32(value1) * Convert.ToInt32(value2);
// Console.WriteLine(result);
// You should see the following output:
// 35

// Casting vs converting
// The following example demonstrates what happens when you attempt to cast a decimal into an int (a narrowing conversion) versus using the Convert.ToInt32() method to convert the same decimal into an int.
// int value = (int)1.5m; // casting truncates
// Console.WriteLine(value);
// int value2 = Convert.ToInt32(1.5m); // converting rounds up
// Console.WriteLine(value2);
// You should see the following output:
// 1
// 2
// When you're casting int value = (int)1.5m;, the value of the float is truncated so the result is 1, meaning the value after the decimal is ignored completely. you could change the literal float to 1.999m and the result of casting would be the same.
// When you're converting using Convert.ToInt32(), the literal float value is properly rounded up to 2. If you changed the literal value to 1.499m, it would be rounded down to 1.

// TryParse()
// The TryParse() method does several things simultaneously:
// It attempts to parse a string into the given numeric data type.
// If successful, it stores the converted value in an out parameter.
// It returns a bool to indicate whether the action succeeded or failed.
// You can use the Boolean return value to take action on the value (like performing some calculation), or display a message if the parse operation was unsuccessful.

// Out parameters
// Methods can return a value or return "void" - meaning they return no value. Methods can also return values through out parameters, which are defined just like an input parameter, but include the out keyword.
// Update your code in the Visual Studio Code Editor as follows:
// string value = "102";
// int result = 0;
// if (int.TryParse(value, out result))
// {
//    Console.WriteLine($"Measurement: {result}");
// }
// else
// {
//    Console.WriteLine("Unable to report the measurement.");
// }
// When calling a method with an out parameter, you must use the keyword out before the variable, which holds the value. The out parameter is assigned to the result variable in the code (int.TryParse(value, out result). You can then use the value the out parameter contains throughout the rest of your code using the variable result.
// The int.TryParse() method returns true if it successfully converted the string variable value into an int; otherwise, it returns false. So, surround the statement in an if statement, and then perform the decision logic, accordingly.
// The converted value is stored in the int variable result. The int variable result is declared and initialized before this line of code, so it should be accessible both inside the code blocks that belong to the if and else statements, as well as outside of them.
// The out keyword instructs the compiler that the TryParse() method won't return a value the traditional way only (as a return value), but also will communicate an output through this two-way parameter.

// Array methods
// Sort()
// Type the following code into the Visual Studio Code Editor:
// string[] pallets = { "B14", "A11", "B12", "A13" };
// Console.WriteLine("Sorted...");
// Array.Sort(pallets);
// foreach (var pallet in pallets)
// {
//     Console.WriteLine($"-- {pallet}");
// }
// Take a minute to review the Array.Sort(pallets); line from the previous code you added.
// Here you're using the Sort() method of the Array class to sort the items in the array alphanumerically.
// Reverse()
// To reverse the order of the pallets using the Array.Reverse() method, update your code as follows:
// string[] pallets = { "B14", "A11", "B12", "A13" };
// Console.WriteLine("Sorted...");
// Array.Sort(pallets);
// foreach (var pallet in pallets)
// {
//     Console.WriteLine($"-- {pallet}");
// }
// Console.WriteLine("");
// Console.WriteLine("Reversed...");
// Array.Reverse(pallets);
// foreach (var pallet in pallets)
// {
//     Console.WriteLine($"-- {pallet}");
// }
// Focus on the line of code Array.Reverse(pallets); line from the previous code you added.
// Here, you're using the Reverse() method of the Array class to reverse the order of items.
// Clear()
// The Array.Clear() method allows you to remove the contents of specific elements in your array and replace it with the array default value. For example, in a string array the element value cleared is replaced with null, when you clear a int array element the replacement is done with 0 (zero).
// Update your code in the Visual Studio Code Editor as follows:
// string[] pallets = { "B14", "A11", "B12", "A13" };
// Console.WriteLine("");
// Array.Clear(pallets, 0, 2);
// Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
// foreach (var pallet in pallets)
// {
//     Console.WriteLine($"-- {pallet}");
// }
// Take a minute to focus on the line of code Array.Clear(pallets, 0, 2);.
// Here you're using the Array.Clear() method to clear the values stored in the elements of the pallets array starting at index 0 and clearing 2 elements.
// Resize()
// The Array.Resize() method adds or removes elements from your array.
// Rework the code to include code to resize the array. When complete, your code should match the following code listing:
// string[] pallets = { "B14", "A11", "B12", "A13" };
// Console.WriteLine("");
// Array.Clear(pallets, 0, 2);
// Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
// foreach (var pallet in pallets)
// {
//     Console.WriteLine($"-- {pallet}");
// }
// Console.WriteLine("");
// Array.Resize(ref pallets, 6);
// Console.WriteLine($"Resizing 6 ... count: {pallets.Length}");
// pallets[4] = "C01";
// pallets[5] = "C02";
// foreach (var pallet in pallets)
// {
//     Console.WriteLine($"-- {pallet}");
// }
// Take a few minutes to focus on the line Array.Resize(ref pallets, 6);.
// Here, you're calling the Resize() method passing in the pallets array by reference, using the ref keyword. In some cases, methods require you pass arguments by value (the default) or by reference (using the ref keyword).
// Conversely, you can remove array elements using Array.Resize().
// ToCharArray()
// Update your code in the Visual Studio Code Editor as follows:
// string value = "abc123";
// char[] valueArray = value.ToCharArray();
// Here you're using the ToCharArray() method to create an array of char, each element of the array has one character of the original string.
// Join()
// Perhaps you need to separate each element of the char array using a comma, as is common when working with data that is represented as ASCII text. To do that, you'll use the String class' Join() method, passing in the char you want to delimit each segment (the comma) and the array itself.
// Update your code in the Visual Studio Code Editor as follows:
// string value = "abc123";
// char[] valueArray = value.ToCharArray();
// Array.Reverse(valueArray);
// string result = String.Join(",", valueArray);
// Console.WriteLine(result);
// Save your code file, and then use Visual Studio Code to run your code.
// You should see the following output:
// 3,2,1,c,b,a
// Split()
// The Split() method is used with variables of type string to create an array of strings.
// Use the Visual Studio Code Editor to add the following lines of code at the bottom of the file:
// string[] items = result.Split(',');
// foreach (string item in items)
// {
//     Console.WriteLine(item);
// }
// Take a minute to review the previous code.
// The comma is supplied to .Split() as the delimiter to split one long string into smaller strings. The code then uses a foreach loop to iterate through each element of the newly created array of strings, items.
// When you run the code, you'll see the following output:
// 3,2,1,c,b,a
// 3
// 2
// 1
// c
// b
// a
// The items array created using string[] items = result.Split(','); is used in the foreach loop and displays the individual characters from the original string contained in the value variable.

// Composite Formatting
// Composite formatting uses numbered placeholders within a string. At run time, everything inside the braces is resolved to a value that is also passed in based on their position.
// This example of composite formatting uses a built-in method Format() on the string data type keyword. Update your code in the Visual Studio Code Editor as follows:
// string first = "Hello";
// string second = "World";
// string result = string.Format("{0} {1}!", first, second);
// Console.WriteLine(result);
// If you run this code, you observe the following output.
// Hello World!
// There are a few important things to notice about this code.
// Data types and variables of a given data type have built-in "helper methods" to make certain tasks easy.
// The literal string "{0} {1}!" forms a template, parts of which are replaced at run time.
// The token {0} is replaced by the first argument after the string template, in other words, the value of the variable first.
// The token {1} is replaced by the second argument after the string template, in other words, the value of the variable second.

// String interpolation
// In order for a string to be interpolated, you must prefix it with the $ directive. Now, create the same examples from earlier using string interpolation instead of composite formatting. Update your code as follows:
// string first = "Hello";
// string second = "World";
// Console.WriteLine($"{first} {second}!");
// Console.WriteLine($"{second} {first}!");
// Console.WriteLine($"{first} {first} {first}!");
// Save your code file, and then use Visual Studio Code to run your code.
// You should see the following output:
// Hello World!
// World Hello!
// Hello Hello Hello!

// Formatting currency
// Composite formatting and string interpolation can be used to format values for display given a specific language and culture. In the following example, the :C currency format specifier is used to present the price and discount variables as currency. Update your code as follows:
// decimal price = 123.45m;
// int discount = 50;
// Console.WriteLine($"Price: {price:C} (Save {discount:C})");
// If you executed this code on a computer that has its Windows display language set to "English (United States)", you observe the following output.
// Price: $123.45 (Save $50.00)
// Notice how adding the :C to the tokens inside of the curly braces formats the number as currency regardless of whether you use int or decimal.

// How the user's country/region and language affect string formatting
// What if you execute the previous code on a computer in France that has its Windows Display Language set to French? In that case you would see the following output.
// Price: 123,45 € (Save 50,00 €)
// The reason for the previous "€" output is that the string currency formatting feature is dependent on the local computer setting for culture. In this context, the term "culture" refers to the country/region and language of the end user. The culture code is a five character string that computers use to identify the location and language of the end user. The culture code ensures certain information like dates and currency can be presented properly.

// Formatting numbers
// The N numeric format specifier makes numbers more readable. Update your code as follows:
// decimal measurement = 123456.78912m;
// Console.WriteLine($"Measurement: {measurement:N} units");
// If you're viewing this from the en-US culture, you observe the following output.
// Measurement: 123,456.79 units
// By default, the N numeric format specifier displays only two digits after the decimal point.
// If you want to display more precision, you can do that by adding a number after the specifier. The following code will display four digits after the decimal point using the N4 specifier. Update your code as follows:
// decimal measurement = 123456.78912m;
// Console.WriteLine($"Measurement: {measurement:N4} units");
// If you're viewing this from the en-US culture, you observe the following output.
// Measurement: 123,456.7891 units

// Formatting percentages
// Use the P format specifier to format percentages. Add a number afterwards to control the number of values displayed after the decimal point. Update your code as follows:
// decimal tax = .36785m;
// Console.WriteLine($"Tax rate: {tax:P2}");
// If you're viewing this from the en-US culture, you observe the following output.
// Tax rate: 36.79 %

// Formatting strings
// The PadLeft() method adds blank spaces to the left-hand side of the string so that the total number of characters equals the argument you send it. In this case, you want the total length of the string to be 12 characters.
// Update your code in the Visual Studio Code Editor as follows:
//  string input = "Pad this";
//  Console.WriteLine(input.PadLeft(12));
//  When you run the code, you observe four characters prefixed to the left of the string bring the length to 12 characters long.
//  	Pad this
// To add space or characters to the right side of your string, use the PadRight() method instead.
// You can also call a second overloaded version of the method and pass in whatever character you want to use instead of a space
// Update your code in the Visual Studio Code Editor as follows:
//  Console.WriteLine(input.PadLeft(12, '-'));
//  Console.WriteLine(input.PadRight(12, '-'));
// Save your code file, and then use Visual Studio Code to run your code. You should see four dashes prefixing the left of the string that is 12 characters long.
//  ----Pad this
//  Pad this----

// IndexOf()
// Type the following code into the Visual Studio Code Editor:
// string message = "Find what is (inside the parentheses)";
// int openingPosition = message.IndexOf('(');
// int closingPosition = message.IndexOf(')');
// Console.WriteLine(openingPosition);
// Console.WriteLine(closingPosition);
// You should see the following output:
// 13
// 36
// In this case, the index of the ( character is 13. Remember, these values are zero-based, so it's the 14th character in the string. The index of the ) character is 36.

// Substring()
// The Substring() method needs the starting position and the number of characters, or length, to retrieve. So, you calculate the length in a temporary variable called length, and pass it with the openingPosition value to retrieve the string inside of the parenthesis.
// Update your code in the Visual Studio Code Editor as follows:
// string message = "Find what is (inside the parentheses)";
// int openingPosition = message.IndexOf('(');
// int closingPosition = message.IndexOf(')');
// openingPosition += 1;
// int length = closingPosition - openingPosition;
// Console.WriteLine(message.Substring(openingPosition, length));
// Save your code file, and then use Visual Studio Code to run your code. You should see the following output:
// inside the parentheses

// LastIndexOf()
// You increase the complexity of the message variable by adding many sets of parentheses, then write code to retrieve the content inside the last set of parentheses.
// Update your code in the Visual Studio Code Editor as follows:
// string message = "(What if) I am (only interested) in the last (set of parentheses)?";
// int openingPosition = message.LastIndexOf('(');
// openingPosition += 1;
// int closingPosition = message.LastIndexOf(')');
// int length = closingPosition - openingPosition;
// Console.WriteLine(message.Substring(openingPosition, length));
// Save your code file, and then use Visual Studio Code to run your code. You should see the following output:
// set of parentheses
// The key to this example is the use of LastIndexOf(), which you use to get the positions of the last opening and closing parentheses.

// Retrieve all instances of substrings inside parentheses
// This time, you update the message to have three sets of parentheses, and you write code to extract any text inside of the parentheses. You're able to reuse portions of the previous work, but need to add a while statement to iterate through the string until all sets of parentheses are discovered, extracted, and displayed.
// Update your code in the Visual Studio Code Editor as follows:
// string message = "(What if) there are (more than) one (set of parentheses)?";
// while (true)
// {
//     int openingPosition = message.IndexOf('(');
//     if (openingPosition == -1) break;

//     openingPosition += 1;
//     int closingPosition = message.IndexOf(')');
//     int length = closingPosition - openingPosition;
//     Console.WriteLine(message.Substring(openingPosition, length));

//     // Note the overload of the Substring to return only the remaining 
//     // unprocessed message:
//     message = message.Substring(closingPosition + 1);
// }
// Save your code file, and then use Visual Studio Code to run your code. You should see the following output:
// What if
// more than
// set of parentheses

// IndexOfAny()
// This time, you search for several different symbols, not just a set of parentheses.
// You update the message string, adding different types of symbols like square [] brackets and curly braces {}. To search for multiple symbols simultaneously, use on .IndexOfAny(). You search with .IndexOfAny() to return the index of the first symbol from the array openSymbols found in the message string.
// Update your code in the Visual Studio Code editor as follows:
// string message = "Help (find) the {opening symbols}";
// Console.WriteLine($"Searching THIS Message: {message}");
// char[] openSymbols = { '[', '{', '(' };
// int startPosition = 6;
// int openingPosition = message.IndexOfAny(openSymbols);
// Console.WriteLine($"Found WITHOUT using startPosition: {message.Substring(openingPosition)}");
// openingPosition = message.IndexOfAny(openSymbols, startPosition);
// Console.WriteLine($"Found WITH using startPosition {startPosition}: {message.Substring(openingPosition)}");
// Save your code file, and then use Visual Studio Code to run your code.
// You should see the following output:
// Searching THIS message: Help (find) the {opening symbols}
// Found WITHOUT using startPosition: (find) the {opening symbols}
// Found WITH using startPosition 6: {opening symbols}

// Remove()
// You would typically use Remove() when there's a standard and consistent position of the characters you want to remove from the string.
// Update your code in the Visual Studio Code Editor as follows:
// string data = "12345John Smith          5000  3  ";
// string updatedData = data.Remove(5, 20);
// Console.WriteLine(updatedData);
// You should see the following output:
// 123455000  3  
// The Remove() method works similarly to the Substring() method. You supply a starting position and the length to remove those characters from the string.

// Replace()
// You would use the Replace() method when you must replace one or more characters with a different character (or no character). The Replace() method is different from the other methods you've used so far, it will replace every instance of the given characters, not just the first or last instance.
// Update your code in the Visual Studio Code Editor as follows:
// string message = "This--is--ex-amp-le--da-ta";
// message = message.Replace("--", " ");
// message = message.Replace("-", "");
// Console.WriteLine(message);
// Save your code file, and then use Visual Studio Code to run your code.
// You should see the following output:
// This is example data
// Here you used the Replace() method twice. The first time you replaced the string -- with an empty space. The second time you replaced the string - with an empty string, which completely removes the character from the string.