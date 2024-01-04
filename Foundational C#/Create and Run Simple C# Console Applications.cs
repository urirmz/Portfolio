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

// When you need to implement a programming task, the .NET Class Library is a good place to look, because it is an organized collection of programming resources.
// The .NET Class Library is a collection of thousands of classes containing tens of thousands of methods.
// you won't be using every class and method in the .NET Class Library. Depending on the types of projects that you work on, you'll become more familiar with some parts of the .NET Class Library and less familiar with others. Again, it's like spending time in a section of the public library, over time you become familiar with what's available. No one knows all of the .NET Class Library, not even people that work at Microsoft.
// Second, necessity will drive you to what you need. Most people go to the library when they need to find a book, not to see how many different books they can find.You don't need to research classes and methods without a reason. When you have trouble figuring out a programming task, you can use your favorite search engine to find blog posts, articles, or forums where other developers have worked through similar issues. Third-party sources can give you clues about which .NET classes and methods you might want to use, and you may even find sample code that you can try.

// all methods in the .NET Class Library
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