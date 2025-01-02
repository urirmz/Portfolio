// Console.write
// To print an entire message to the output console, you used the first technique, Console.WriteLine(). At the end of the line, it added a line feed similar to how to create a new line of text by pressing Enter or Return.
// To print to the output console, but without adding a line feed at the end, you used the second technique, Console.Write(). So, the next call to Console.Write() prints another message to the same line.
// The Console part is called a class. Classes "own" methods; or you could say that methods live inside of a class. To visit the method, you must know which class it's in. For now, think of a class as a way to represent an object. In this case, all of the methods that operate on your output console are defined inside of the Console class.
// There's also a dot (or period) that separates the class name Console and the method name WriteLine(). The period is the member access operator. In other words, the dot is how you "navigate" from the class to one of its methods.
// The WriteLine() part is called a method. You can always spot a method because it has a set of parentheses after it. Each method has one job. The WriteLine() method's job is to write a line of data to the output console. The data that's printed is sent in between the opening and closing parenthesis as an input parameter. Some methods need input parameters, while others don't. But if you want to invoke a method, you must always use the parentheses after the method's name. The parentheses are known as the method invocation operator.
// Finally, the semicolon is the end of statement operator. A statement is a complete instruction in C#. The semicolon tells the compiler that you've finished entering the command.

// Character literals
// If you only wanted a single alphanumeric character printed to screen, you could create a char literal by surrounding one alphanumeric character in single quotes. The term char is short for character. In C#, this data type is officially named "char", but frequently referred to as a "character".
// Console.WriteLine('b');
// Notice that the letter b is surrounded with single quotation marks 'b'. Single quotes create a character literal. Recall that using double quotation marks creates a string data type.
// Press the green Run button to run your code. You should see the following result in the output window:
// b
// If you enter the following code:
// Console.WriteLine('Hello World!');
// You would get the following error:
// (1,19): error CS1012: Too many characters in character literal
// Notice the single quotation marks surrounding Hello World!. When you use single quotation marks, the C# compiler expects a single character. However, in this case, the character literal syntax was used, but 12 characters were supplied instead!
// Just like the string data type, you use char whenever you have a single alphanumeric character for presentation (not calculation).

// Integer literals
// If you want to display a numeric whole number (no fractions) value in the output console, you can use an int literal. The term int is short for integer, which you may recognize from studying math. In C#, this data type is officially named "int", but frequently referred to as "integer". An int literal requires no other operators like the string or char.
// Console.WriteLine(123);
// 123

// Floating-point literals
// A floating-point number is a number that contains a decimal, for example 3.14159. C# supports three data types to represent decimal numbers: float, double, and decimal. Each type supports varying degrees of precision.
// Float Type    Precision
// ----------------------------
// float         ~6-9 digits
// double        ~15-17 digits
// decimal        28-29 digits
// Here, precision reflects the number of digits past the decimal that are accurate.
// Add the following line of code in the code editor:
// Console.WriteLine(0.25F);
// To create a float literal, append the letter F after the number. In this context, the F is called a literal suffix. The literal suffix tells the compiler you wish to work with a value of float type. You can use either a lower-case f or upper-case F as the literal suffix for a float.
// Add the following line of code in the code editor:
// Console.WriteLine(2.625);
// To create a double literal, just enter a decimal number. The compiler defaults to a double literal when a decimal number is entered without a literal suffix.
// Add the following line of code in the code editor:
// Console.WriteLine(12.39816m);
// To create a decimal literal, append the letter m after the number. In this context, the m is called a literal suffix. The literal suffix tells the compiler you wish to work with a value of decimal type. You can use either a lower-case m or upper-case M as the literal suffix for a decimal.

// Boolean literals
// If you wanted to print a value representing either true or false, you could use a bool literal.
// The term bool is short for Boolean. In C#, they're officially referred to as "bool", but often developers use the term "Boolean".

// Variables
// A variable is a container for storing a type of value. Variables are important because their values can change, or vary, throughout the execution of a program. Variables can be assigned, read, and changed. You use variables to store values that you intend to use in your code.
// To create a new variable, you must first declare the data type of the variable, and then give it a name.
// string firstName;
// In this case, you're creating a new variable of type string called firstName. From now on, this variable can only hold string values.
// Not only does the name of a variable have to follow certain syntax rules, it should also be used to make the code more human-readable and understandable. That's a lot to ask of one line of code!
// Here's a few important considerations about variable names:
// Variable names can contain alphanumeric characters and the underscore character. Special characters like the hash symbol # (also known as the number symbol or pound symbol) or dollar symbol $ are not allowed.
// Variable names must begin with an alphabetical letter or an underscore, not a number.
// Variable names are case-sensitive, meaning that string Value; and string value; are two different variables.
// Variable names must not be a C# keyword. For example, you cannot use the following variable declarations: decimal decimal; or string string;.
// There are coding conventions that help keep variables readable and easy to identify. As you develop larger applications, these coding conventions can help you keep track of variables among other text.
// Here are some coding conventions for variables:
// Variable names should use camel case, which is a style of writing that uses a lower-case letter at the beginning of the first word and an upper-case letter at the beginning of each subsequent word. For example, string thisIsCamelCase;.
// Variable names should begin with an alphabetical letter. Developers use the underscore for a special purpose, so try to not use that for now.
// Variable names should be descriptive and meaningful in your app. Choose a name for your variable that represents the kind of data it will hold.
// Variable names should be one or more entire words appended together. Don't use contractions or abbreviations because the name of the variable (and therefore, its purpose) may be unclear to others who are reading your code.
// Variable names shouldn't include the data type of the variable. You might see some advice to use a style like string strValue;. That advice is no longer current.
// To retrieve a value from a variable, you just use the name of the variable. This example will set a variable's value, then retrieve that value and display it in the console.
// Modify the code you wrote to match the following code:
// string firstName;
// firstName = "Bob";
// Console.WriteLine(firstName);
// Now, run the code. You'll see the following result in the output console:
// Bob
// Retrieving a value from a variable is also referred to as "getting the variable", or simply, a "get" operation.
// Initialize the variable
// You must set a variable to a value before you can get the value from the variable. Otherwise, you'll see an error.
// To avoid the possibility of an unassigned local variable, it is recommended that you set the value as soon as possible after you declare it.
// In fact, you can perform both the declaration and setting the value of the variable in one line of code. This technique is called initializing the variable.
// Modify the code you wrote to match the following code:
// string firstName = "Bob";
// Console.WriteLine(firstName);
// Now, run the code. You should see the following output:
// Bob

// Implicitly typed local variables
// The C# compiler works behind the scenes to assist you as you write your code. It can infer your variable's data type by its initialized value. In this unit, you'll learn about this feature, called implicitly typed local variables.
// An implicitly typed local variable is created by using the var keyword followed by a variable initialization. For example:
// var message = "Hello world!";
// In this example, a string variable was created using the var keyword instead of the string keyword.
// The var keyword tells the C# compiler that the data type is implied by the assigned value. After the type is implied, the variable acts the same as if the actual data type had been used to declare it. The var keyword is used to save on keystrokes when types are lengthy or when the type is obvious from the context.
// It's important to understand that the var keyword is dependent on the value you use to initialize the variable. If you try to use the var keyword without initializing the variable, you'll receive an error when you attempt to compile your code.

// Character escape sequences
// An escape character sequence is an instruction to the runtime to insert a special character that will affect the output of your string. In C#, the escape character sequence begins with a backslash \ followed by the character you're escaping. For example, the \n sequence will add a new line, and a \t sequence will add a tab.
// What if you need to insert a double-quotation mark in a literal string? If you don't use the character escape sequence, you'll confuse the compiler because it will think you want to terminate the string prematurely. The compiler won't understand the purpose of the characters after the second double-quotation mark.
// Console.WriteLine("Hello "World"!");
// To handle that situation, use the \" escape sequence:
// Console.WriteLine("Hello \"World\"!");
// What if you need to use the backslash for other purposes, like to display a file path?
// Console.WriteLine("c:\source\repos");
// The problem is the sequence \s. The \r doesn't produce an error because it's a valid escape sequence for a carriage return. However, you don't want to use a carriage return in this context.
// To solve this problem, you use the \\ to display a single backslash.
// Console.WriteLine("c:\\source\\repos");

// Verbatim string literal
// A verbatim string literal will keep all whitespace and characters without the need to escape the backslash. To create a verbatim string, use the @ directive before the literal string.
// Console.WriteLine(@"    c:\source\repos    
//         (this is where your code goes)");
// Notice that the string spans two lines and the whitespace generated by this C# instruction is kept in the following output.
//     c:\source\repos    
//         (this is where your code goes)

// Unicode escape characters
// You can also add encoded characters in literal strings using the \u escape sequence, then a four-character code representing some character in Unicode (UTF-16).
// // Kon'nichiwa World
// Console.WriteLine("\u3053\u3093\u306B\u3061\u306F World!");

// Concatenate a literal string and a variable
// To concatenate two strings together, you use the string concatenation operator, which is the plus symbol +.
// You can perform several concatenation operations in the same line of code.
// Modify the code you wrote earlier to the following:
// string firstName = "Bob";
// string greeting = "Hello";
// string message = greeting + " " + firstName + "!";
// Console.WriteLine(message);
// Here you create a more complex message by combining several variables and literal strings.
// Now, run the code. You'll see the following result in the output console:
// Hello Bob!

// String interpolation
// String interpolation combines multiple values into a single literal string by using a "template" and one or more interpolation expressions. An interpolation expression is indicated by an opening and closing curly brace symbol { }. You can put any C# expression that returns a value inside the braces. The literal string becomes a template when it's prefixed by the $ character.
// In other words, instead of writing the following line of code:
// string message = greeting + " " + firstName + "!";
// You can write this more concise line of code instead:
// string message = $"{greeting} {firstName}!";
// To interpolate two strings together, you create a literal string and prefix the string with the $ symbol. The literal string should contain at least one set of curly braces {} and inside of those characters you use the name of a variable.
// Select all of the code in the .NET Editor, and press Delete or Backspace to delete it.
// Enter the following code in the .NET Editor:
// string firstName = "Bob";
// string message = $"Hello {firstName}!";
// Console.WriteLine(message);
// Now, run the code. You'll see the following result in the output console:
// Hello Bob!

// Combine verbatim literals and string interpolation
// Suppose you need to use a verbatim literal in your template. You can use both the verbatim literal prefix symbol @ and the string interpolation $ symbol together.
// Delete the code from the previous steps and type the following code into the .NET Editor:
// string projectName = "First-Project";
// Console.WriteLine($@"C:\Output\{projectName}\Data");
// Now, run the code and you should see the following result.
// C:\Output\First-Project\Data
// In this example, the $ symbol allows you to reference the projectName variable inside the braces, while the @ symbol allows you to use the unescaped \ character.

// Addition operator
// To add two numbers together, you'll use the addition operator, which is the plus symbol +. Yes, the same plus symbol + that you use for string concatenation is also used for addition. The reuse of one symbol for multiple purposes is sometimes called "overloading the operator" and happens frequently in C#.
// In this instance, the C# compiler understands what you're attempting to do. The compiler parses your code and sees that the + (the operator) is surrounded by two numeric values (the operands). Given the data types of the variables (both are ints), it figures out that you intended to add those two values.
// Enter the following code into the .NET Editor:
// int firstNumber = 12;
// int secondNumber = 7;
// Console.WriteLine(firstNumber + secondNumber);
// Run the code and you'll see the following result in the output console:
// 19

// Mix data types to force implicit type conversions
// What happens if you try to use the + symbol with both string and int values?
// Modify the code you wrote to match the following code:
// string firstName = "Bob";
// int widgetsSold = 7;
// Console.WriteLine(firstName + " sold " + widgetsSold + " widgets.");
// Run the code and you'll see the following result in the output console:
// Bob sold 7 widgets.
// In this case, the C# compiler understands that you want to use the + symbol to concatenate the two operands. It deduces this because the + symbol is surrounded by operands of string and int data types. So, it attempts to implicitly convert the int variable widgetsSold into a string temporarily so it can concatenate it to the rest of the string. The C# compiler tries to help you when it can, but ideally, you would be explicit about your intentions.

// Add parentheses to clarify your intention to the compiler
// match the following code:
// string firstName = "Bob";
// int widgetsSold = 7;
// Console.WriteLine(firstName + " sold " + (widgetsSold + 7) + " widgets.");
// Run the code and you'll see the following result in the output console:
// Bob sold 14 widgets.
// The parentheses symbol () becomes another overloaded operator. In this case, the opening and closing parentheses form the order of operations operator, just like you might use in a mathematical formula. You indicate that you want the inner-most parentheses resolved first resulting in the addition of int values widgetsSold and the value 7. Once that is resolved, then it will implicitly convert the result to a string so that it can be concatenated with the rest of the message.

// Basic math operations
// + is the addition operator
// - is the subtraction operator
// * is the multiplication operator
// / is the division operator
// However, the resulting quotient of the division example may not be what you may have expected. The values after the decimal are truncated from the quotient since it is defined as an int, and int cannot contain values after the decimal.
// To see division working properly, you need to use a data type that supports fractional digits after the decimal point like decimal.
// Delete the code from the previous steps and enter the following code into the .NET Editor:
// decimal decimalQuotient = 7.0m / 5;
// Console.WriteLine($"Decimal quotient: {decimalQuotient}");
// Run the code. You should see the following output:
// Decimal quotient: 1.4
// What if you need to divide two variables of type int but do not want the result truncated? In that case, you must perform a data type cast from int to decimal. Casting is one type of data conversion that instructs the compiler to temporarily treat a value as if it were a different data type.
// To cast int to decimal, you add the cast operator before the value. You use the name of the data type surrounded by parentheses in front of the value to cast it. In this case, you would add (decimal) before the variables first and second.
// Delete the code from the previous steps and enter the following code into the .NET Editor:
// int first = 7;
// int second = 5;
// decimal quotient = (decimal)first / (decimal)second;
// Console.WriteLine(quotient);
// Run the code. You should see the following output:
// 1.4
// Note
// You've seen three uses for the parenthesis operator: method invocation, order of operations and casting.
// Remainder after integer division
// The modulus operator % tells you the remainder of int division. What you really learn from this is whether one number is divisible by another. This can be useful during long processing operations when looping through hundreds or thousands of data records and you want to provide feedback to the end user after every 100 data records have been processed.
// Delete the code from the previous steps and enter the following code into the .NET Editor:
// Console.WriteLine($"Modulus of 200 / 5 : {200 % 5}");
// Console.WriteLine($"Modulus of 7 / 5 : {7 % 5}");
// Run the code. You should see the following output:
// Modulus of 200 / 5 : 0
// Modulus of 7 / 5 : 2
// When the modulus is 0, that means the dividend is divisible by the divisor.
// In math, PEMDAS is an acronym that helps students remember the order of operations. The order is:
// Parentheses (whatever is inside the parenthesis is performed first)
// Exponents
// Multiplication and Division (from left to right)
// Addition and Subtraction (from left to right)
// C# follows the same order as PEMDAS except for exponents. While there's no exponent operator in C#, you can use the System.Math.Pow method. The module "Call methods from the .NET Class Library using C#" will feature this method and others.

// Increment and decrement values
// Frequently, you'll need to increment and/or decrement values, especially when you're writing looping logic or code that interacts with a data structure.
// The += operator adds and assigns the value on the right of the operator to the value on the left of the operator. So, lines two and three in the following code snippet are the same:
// int value = 0;     // value is now 0.
// value = value + 5; // value is now 5.
// value += 5;        // value is now 10.
// The ++ operator increments the value of the variable by 1. So, lines two and three in the following code snippet are the same:
// int value = 0;     // value is now 0.
// value = value + 1; // value is now 1.
// value++;           // value is now 2.
// These same techniques can be used for subtraction, multiplication, and more. The following exercise steps will highlight a few.
//  Note
// Operators like +=, -=, *=, ++, and -- are known as compound assignment operators because they compound some operation in addition to assigning the result to the variable. The += operator is specifically termed the addition assignment operator.
// Both the increment and decrement operators have an interesting quality — depending on their position, they perform their operation before or after they retrieve their value. In other words, if you use the operator before the value as in ++value, then the increment will happen before the value is retrieved. Likewise, value++ will increment the value after the value has been retrieved.

// Format the decimal output
// You want to display the first digit of the GPA, a decimal point, followed by the first two digits after the decimal. You can achieve this format by using variables to store the leading and trailing digits respectively, and then printing them together using Console.WriteLine(). You can use the math operations you learned to extract the leading and trailing digits.
// Navigate to the top of the Console.WriteLine() statements.
// Create a blank code line above the Console.WriteLine() statements.
// On the blank code line that you created, to initialize a variable that will store the leading digit of the GPA, enter the following code:
// int leadingDigit = (int) gradePointAverage;
// Notice that to extract the leading digit from the decimal, you're casting it to an integer value. This is a simple and reliable method because casting a fractional value will never round up the result. Meaning if the GPA is 2.99, casting the decimal value to an int will result in 2.
// To initialize a variable that will store the first two digits after the decimal, enter the following code:
// int firstDigit = (int) (gradePointAverage * 10) % 10;
// In the first half of this operation, you move the decimal one place to the right and cast it to an integer. In the second half, you use the remainder, or modulo, operator to get the remainder of division by 10, which isolates the last digit in the integer. Here's an example:
// Suppose gradePointAverage = 2.994573 Then, performing the operation on these values would result in the following steps:
// int firstDigit = (int) (2.994573 * 10) % 10;
// int firstDigit = 29 % 10;
// int firstDigit = 9;
// And the resulting value of firstDigit is 9.
// Next, you'll apply the same operation to retrieve the second digit.
// On a new blank code line, enter the following code:
// int secondDigit = (int) (gradePointAverage * 100 ) % 10;
// In this line, you move the decimal two places and use the modulo operator to retrieve the last digit.
// To correct the final GPA output, update the last Console.WriteLine() statement as follows:
// Console.WriteLine($"Final GPA: {leadingDigit}.{firstDigit}{secondDigit}");