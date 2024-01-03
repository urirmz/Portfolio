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