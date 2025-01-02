// Methods 
// he method signature declares the method's return type, name, and input parameters. For example, consider the following method signature:
// void SayHello();
// The method name is SayHello. Its return type is void, meaning the method returns no data. However, methods can return a value of any data type, such as bool, int, double, and arrays as well. Method parameters, if any, should be included in the parenthesis (). Methods can accept multiple parameters of any data type. In this example, the method has no parameters.
// Before you can run a method, you need to add a definition. The method definition uses brackets {} to contain the code that executes when the method is called. For example:
// void SayHello() 
// {
//     Console.WriteLine("Hello World!");
// }
// Now the method will print Hello World! whenever it's called.
// A method is called by using its name and including any required arguments. Consider the following:
// Console.Write("Input!");
// The string "Input!" is the argument provided to the Write method.
// A method can be called before or after its definition. For example, the SayHello method can be defined and called using the following syntax:
// SayHello();
// void SayHello() 
// {
//     Console.WriteLine("Hello World!");
// }
// Notice that it isn't necessary to have the method defined before you call it. This flexibility allows you to organize your code as you see fit. It's common to define all methods at the end of a program. 
// When you call a method, the code in the method body will be executed. This means execution control is passed from the method caller to the method. Control is returned to the caller after the method completes its execution
// Best practices
// When choosing a method name, it's important to keep the name concise and make it clear what task the method performs. Method names should be Pascal case and generally shouldn't start with digits. Names for parameters should describe what kind of information the parameter represents. Consider the following method signatures:
// void ShowData(string a, int b, int c);
// void DisplayDate(string month, int day, int year);

// Build code with methods
// Methods are useful for organizing code, reusing code, and for tackling problems efficiently. You can think of a method like a black box that takes input, performs the named task, and returns output. With this assumption, you can quickly structure programs just by naming your tasks as methods, and then filling in the logic after you've identified all of the necessary tasks.
// Methods can be used to quickly structure applications
// The return keyword can be used to terminate method execution
// Each step of a problem can often be translated into its own method
// Use methods to solve small problems to build up your solution

// Method parameters
// Parameters in a method work similar to variables. A parameter is defined by specifying the data type followed by the name of the parameter. Parameters are declared in the method signature, and the values for the parameters are provided by the method caller instead of being initialized inside the method itself. Consider the following code:
// 	CountTo(5);
// 	void CountTo(int max) 
// 	{
// 		for (int i = 0; i < max; i++)
// 		{
// 			Console.Write($"${i}, ");
// 		}
// 	}
// In this example, the method CountTo accepts an integer parameter named max. The parameter is referenced in the for loop of the method. When CountTo is called, the integer 5 is supplied as an argument.

// Method scope
// for loops, if-else statements, and methods all represent different types of code blocks. Each code block has its own 'scope'. 'Scope' is the region of a program where certain data is accessible. Variables declared inside a method, or any code block, are only accessible within that region. As programs become more complicated, this pattern helps programmers consistently use clearly named variables and maintain easy to read code.
// Variables declared inside of a method are only accessible to that method.
// Variables declared in top-level statements are accessible throughout the program.
// Methods don't have access to variables defined within different methods.
// Methods can call other methods.

// Value and reference type parameters
// In C#, variables can be categorized into two main types, value types and reference types. These types describe how variables store their values.
// Value types such as int, bool, float, double, and char directly contain values. Reference types such as string, array, and objects (such as instances of Random) don't store their values directly. Instead, reference types store an address where their value is being stored.
// Strings are an immutable type. Even though a string is a reference value type, unlike an array, its value can't be altered once it's assigned. 
// Methods using value type arguments create their own copy of the values.
// Methods that perform changes on an array parameter affect the original input array.
// String is an immutable reference type.
// Methods that perform changes on a string parameter don't affect the original string.

// Named arguments
// When calling a method that accepts many parameters, it can be tricky to understand what the arguments represent. Using named arguments can improve the readability of your code. Use a named argument by specifying the parameter name followed by the argument value. In this task, you'll practice using named arguments.
// Locate the following line of code: RSVP("Linh", 2, "none", false);
// Update the method call as follows:
// RSVP(name: "Linh", partySize: 2, allergies: "none", inviteOnly: false);
// Notice that you supply the name of the parameter, followed by a colon and the value. This syntax defines a named argument. It isn't necessary to name all of the arguments. For example, the following syntax is also valid:
// RSVP("Linh", 2, allergies: "none", inviteOnly: false); RSVP("Linh", partySize: 2, "none", false);
// Named arguments, when used with positional arguments, are valid if they're used in the correct position. Named arguments are also valid as long as they're not followed by any positional arguments. For example, including "Linh" and 2 at the end would be invalid:
// RSVP(allergies: "none", inviteOnly: false, "Linh", 2);
// If you entered this code, you would get the following error: Named argument 'allergies' is used out-of-position but is followed by an unnamed argument
// Locate the following line of code: RSVP("Tony", 1, "Jackfruit", true);
// Update the method call as follows:
// RSVP("Tony", inviteOnly: true, allergies: "Jackfruit",  partySize: 1);
// Notice that the named arguments don't have to appear in the original order. However, the unnamed argument Tony is a positional argument, and must appear in the matching position.

// Optional parameters
// A parameter becomes optional when it's assigned a default value. If an optional parameter is omitted from the arguments, the default value is used when the method executes
// To define optional parameters, update the RSVP method signature as follows:
// void RSVP(string name, int partySize = 1, string allergies = "none", bool inviteOnly = true)
// Take a moment to observe the syntax. The parameters are still separated by commas, but the parameters partySize, allergies, and inviteOnly are each assigned to a value.

// Return types
// Not only can methods perform operations, they can return a value as well. Methods can return a value by including the return type in the method signature. Methods can return any data type, or they can return nothing at all. The return type must always be specified before the method name.
// Using void as the return type means the method only performs operations and doesn't return a value. For example:
// void PrintMessage(string message)
// When a data type (such as int, string, bool, etc.) is used, the method performs operations and then returns the specified type upon completion. Inside the method, the keyword return is used to return the result. In void methods, you can also use the return keyword to terminate the method.
// Update the following code:
// double GetDiscountedPrice(int itemIndex)
// {
//     double result = items[itemIndex] * (1 - discounts[itemIndex]);
//     return result;
// }
// To return a value from a method, add a value or expression after the return keyword. The value returned must match the data type specified in the method signature.

