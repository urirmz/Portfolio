// Testing, debugging, and exception handling
//  The term "exception handling" refers to the process that a developer uses to manage those runtime exceptions within their code. Errors that occur during the build process are referred to as errors, and aren't part of the exception handling process.
// One way to categorize the types of testing is to split testing into Functional and Nonfunctional testing. The functional and nonfunctional categories each include subcategories of testing. For example, functional and nonfunctional testing could be divided into the following subcategories:
// Functional testing - Unit testing - Integration testing - System testing - Acceptance testing
// Nonfunctional testing - Security testing - Performance testing - Usability testing - Compatibility testing
// Code debugging is the process of isolating issues and identifying ways to fix them, and it's a developer responsibility.
// Exception handling is the process of managing errors that occur during runtime, and developers are responsible for handling exceptions by using "try" and "catch" statements in their code.

// Code debugging process
// When you notice a bug in your code, it can be tempting to try a direct approach. You know, that quick scan where you think the issue might be. If it pays off in the first 30 seconds, great, but don't let yourself be sucked in. Don't keep going to that next spot, and the next. Don't let yourself throw time against the following approaches:
// Reading through your code (just one more time) hoping that this time the issue jumps out at you.
// Breadcrumbing a few Console.WriteLine("here") messages in your code to the track progress through your app.
// Rerunning your app with different data. Hoping that if you see what works, you'll understand what doesn't work.
// You might have experienced various degrees of success with these methods, but don't be fooled. There is a better way.
// The one approach that's commonly regarded as being the most successful is using a debugger.
// But what's a debugger exactly?
// A debugger is a software tool used to observe and control the execution flow of your program with an analytical approach. Debuggers help you isolate the cause of a bug and help you resolve it. A debugger connects to your code using one of two approaches:
// By hosting your program in its own execution process.
// By running as a separate process that's attached to your running program.
// Debuggers come in different flavors. Some work directly from the command line while others come with a graphical user interface. Visual Studio Code integrates debugger tools in the user interface.
// The primary benefit of using a debugger is that you can watch your program running. You can follow program execution one line of code at a time. This approach minimizes the chance of guessing wrong.
// Visual Studio Code supports code debuggers that enable you to watch your code as it runs
// Every debugger has its own set of features. The two most important features that come with almost all debuggers are:
// Control of your program execution. You can pause your program and run it step by step, which allows you to see what code is executed and how it affects your program's state.
// Observation of your program's state. For example, you can look at the value of your variables and function parameters at any point during your code execution.
// Mastering the use of a code debugger is an important skill.

// Exceptions
// The terms "throw" and "catch" can be explained by evaluating the definition of an exception. "Exceptions are thrown by code that encounters an error and caught by code that can correct the error". The first part of this sentence tells you that exceptions are created by the .NET runtime when an error occurs in your code. The second part of the sentence tells you that you can write code to catch an exception that's been thrown. In addition, the code that catches the exception can be used to complete a corrective action, hopefully mitigating the situation caused by the code that resulted in the error. In other words, you can write code that protects your application when an error occurs.
// After evaluating that second sentence of the definition, you know the following:
// An exception gets created at runtime when your code produces an error.
// The exception can be treated like a variable that has some extra capabilities.
// You can write code that accesses the exception and takes corrective action.

// Debug features in the Visual Studio Code user interface
// Visual Studio Code includes several user interface features that will help you to configure, start, and manage debug sessions:
// Configure and launch the debugger: The Run menu and RUN AND DEBUG view can both be used to configure and launch debug sessions.
// Examine application state: The RUN AND DEBUG view includes a robust interface that exposes various aspects of your application state during a debug session.
// Runtime execution control: The Debug toolbar provides high-level runtime controls during code execution.
// The Visual Studio Code user interface can be used to configure, start, and manage debug sessions. The launch.json file contains the launch configurations for your application.
// The Run menu provides easy access to common run and debug commands grouped into six sections.
// The RUN AND DEBUG view provides access to runtime tools, including the Run and Debug controls panel. The sections of the RUN AND DEBUG view are VARIABLES, WATCH, CALL STACK, and BREAKPOINTS.
// The Debug toolbar provides execution controls while your application is running such as pause/continue, step over, step into, step out, restart and stop.
// The DEBUG CONSOLE is used to display messages from the debugger. The DEBUG CONSOLE can also display console output from your application.

// Launch configurations for debugging
// Visual Studio Code uses a launch configuration file to specify the application that runs in the debug environment.
// On the View menu, select Command Palette.
// At the command prompt, enter .net: g and then select .NET: Generate Assets for Build and Debug.
// Notice the new .vscode folder that has been added to your project folder.
// The .vscode folder contains files that are used to configure the debug environment.
// Expand the .vscode folder, and then select the launch.json file.
// Take a minute to examine the launch.json file.
// The launch configurations file can include multiple configurations. Each configuration includes a collection of attributes that are used to define that configuration.
// Notice that the prelaunchTask attribute specifies a build task.
// In the .vscode folder, select tasks.json.
// Notice that the tasks.json file contains the build task for your code project.
// Close the launch.json and tasks.json files.
// You take a closer look at the launch configuration attributes later in this module.

// Breakpoints
// Because your code executes in micro-seconds, effective code debugging depends on your ability to pause the program on any statement within your code. Breakpoints are used to specify where code execution pauses.
// Visual Studio Code provides several ways to configure breakpoints in your code. For example:
// Code Editor: You can set a breakpoint in the Visual Studio Code Editor by clicking in the column to the left of a line number.
// Run menu: You can toggle a breakpoint on/off from the Run menu. The current code line in the Editor specifies where the Toggle Breakpoint action is applied.
// When a breakpoint is set, a red circle is displayed to the left of the line number in the Editor. When you run your code in the debugger, execution pauses at the breakpoint.
// After setting breakpoints in your application and using them to isolate an issue, you may want to remove or disable the breakpoints.
// To remove a breakpoint, repeat the action used to set a breakpoint. For example, click the red circle to the left of the line number or use the toggle breakpoint option on the Run menu.
// What if you want to keep a breakpoint location, but you don't want it to trigger during your next debug session? Visual Studio Code enables you to "disable" a breakpoint rather than removing it altogether. To disable an active breakpoint, right-click the red dot to the left of the line number, and then select Disable Breakpoint from the context menu.
// When you disable a breakpoint, the red dot to the left of the line number is changed to a grey dot.
// In addition to managing individual breakpoints in the Editor, the Run menu provides options for performing bulk operations that act on all breakpoints:
// Enable All Breakpoints: Use this option to enable all disabled breakpoints.
// Disable All Breakpoints: Use this option to disable all breakpoints.
// Remove All Breakpoints: Use this option to remove all breakpoints (both enabled and disabled breakpoints are removed).


// Conditional breakpoints
// A conditional breakpoint is a special type of breakpoint that only triggers when a specified condition is met. For example, you can create a conditional breakpoint that pauses execution when a variable named numItems is greater than 5.
// You've already seen that right-clicking a breakpoint opens a context menu that includes the Edit Breakpoint option. Selecting Edit Breakpoint enables you to change a standard breakpoint into a conditional breakpoint.
// When you create a conditional breakpoint, you need to specify an expression that represents the condition.
// Each time the debugger encounters the conditional breakpoint, it evaluates the expression. If the expression evaluates as true, the breakpoint is triggered and execution pauses. If the expression evaluates as false, execution continues as if there was no breakpoint.

// Hit Count breakpoints and Logpoints
// A 'hit count' breakpoint can be used to specify the number of times that a breakpoint must be encountered before it will 'break' execution. You can specify a hit count value when creating a new breakpoint (with the Add Conditional Breakpoint action) or when modifying an existing one (with the Edit Condition action). In both cases, an inline text box with a dropdown menu opens where you can enter the hit count value.
// A 'Logpoint' is a variant of a breakpoint that does not "break" into the debugger but instead logs a message to the console. Logpoints are especially useful for injecting logging while debugging production environments that cannot be paused or stopped. A Logpoint is represented by a "diamond" shaped icon rather than a filled circle. Log messages are plain text but can include expressions to be evaluated within curly braces ('{}').
// Logpoints can include a conditional 'expression' and/or 'hit count' to further control when logging messages are generated.

// Launch configurations file
// The launch.json file includes one or more launch configurations in the configurations list. The launch configurations use attributes to support different debugging scenarios. The following attributes are mandatory for every launch configuration:
// name: The reader-friendly name assigned to the launch configuration.
// type: The type of debugger to use for the launch configuration.
// request: The request type of the launch configuration.
// These are some of the attributes you may encounter.
// Name
// The name attribute specifies the display name for the launch configuration. The value assigned to name appears in the launch configurations dropdown (on the controls panel at the top of the RUN AND DEBUG view).
// Type
// The type attribute specifies the type of debugger to use for the launch configuration. A value of codeclr specifies the debugger type for .NET 5+ and .NET Core applications (including C# applications).
// Request
// The request attribute specifies the request type for the launch configuration. Currently, the values launch and attach are supported.
// PreLaunchTask
// The preLaunchTask attribute specifies a task to run before debugging your program. The task itself can be found in the tasks.json file, which is in the .vscode folder along with the launch.json file. Specifying a prelaunch task of build runs a dotnet build command before launching the application.
// Program
// The program attribute is set to the path of the application dll or .NET Core host executable to launch.
// This property normally takes the form: ${workspaceFolder}/bin/Debug/<target-framework>/<project-name.dll>.
// Cwd
// The cwd attribute specifies the working directory of the target process.
// Args
// The args attribute specifies the arguments that are passed to your program at launch. There are no arguments by default.
// Console
// The console attribute specifies the type of console that's used when the application is launched. The options are internalConsole, integratedTerminal, and externalTerminal. The default setting is internalConsole. The console types are defined as:
// The internalConsole setting corresponds to the DEBUG CONSOLE panel in the Panels area below the Visual Studio Code Editor.
// The integratedTerminal setting corresponds to the OUTPUT panel in the Panels area below the Visual Studio Code Editor.
// The externalTerminal setting corresponds to an external terminal window. The Command Prompt application that comes with Windows is an example of a terminal window.
// Stop at Entry
// If you need to stop at the entry point of the target, you can optionally set stopAtEntry to be true.

// Update the launch configuration to accommodate console input
// As you read earlier, the DEBUG CONSOLE panel doesn't support console input. If you're debugging a console application that relies on user input, you need to update the console attribute in the associated launch configuration.
// To edit the console attribute:
// Open the launch.json file in the Visual Studio Code Editor.
// Locate the console attribute.
// Select the colon and assigned value, and then enter a colon character.
// Notice that when you overwrite the existing information with a colon, Visual Studio Code IntelliSense displays the three options in a dropdown list.
// Select either integratedTerminal or externalTerminal.
// Save the launch.json file.

// Update the launch configuration to accommodate multiple applications
// If your workspace has only one launchable project, the C# extension will automatically generate the launch.json file. If you have more than one launchable project, then you need to modify your launch.json file manually. Visual Studio Code generates a launch.json file using the basic template that you can update. In this scenario, you create separate configurations for each application that you want to debug. Prelaunch tasks, such as a build task, can be created in the tasks.json file.

// Exception handling
// Common scenarios that require exception handling include:
// User input: Exceptions can occur when code processes user input. For example, exceptions occur when the input value is in the wrong format or out of range.
// Data processing and computations: Exceptions can occur when code performs data calculations or conversions. For example, exceptions occur when code attempts to divide by zero, cast to an unsupported type, or assign a value that's out of range.
// File input/output operations: Exceptions can occur when code reads from or writes to a file. For example, exceptions occur when the file doesn't exist, the program doesn't have permission to access the file, or the file is in use by another process.
// Database operations: Exceptions can occur when code interacts with a database. For example, exceptions occur when the database connection is lost, a syntax error occurs in a SQL statement, or a constraint violation occurs.
// Network communication: Exceptions can occur when code communicates over a network. For example, exceptions occur when the network connection is lost, a timeout occurs, or the remote server returns an error.
// Other external resources: Exceptions can occur when code communicates with other external resources. Web Services, REST APIs, or third-party libraries, can throw exceptions for various reasons. For example, exceptions occur due to network connections issues, malformed data, etc.
// Exception handling in C# is implemented by using the try, catch, and finally keywords. Each of these keywords has an associated code block and can be used to satisfy a specific goal in your approach to exception handling. For example:
// try
// {   
//    // try code block - code that may generate an exception
// }
// catch
// {   
//    // catch code block - code to handle an exception
// }
// finally
// {   
//    // finally code block - code to clean up resources
// }
// The try code block contains the guarded code that may cause an exception. If the code within a try block causes an exception, the exception is handled by a corresponding catch block.
// The catch code block contains the code that's executed when an exception is caught. The catch block can handle the exception, log it, or ignore it. A catch block can be configured to execute when any exception type occurs, or only when a specific type of exception occurs.
// The finally code block contains code that executes whether an exception occurs or not. The finally block is often used to clean up any resources that are allocated in a try block. For example, ensuring that a variable has the correct or required value assigned to it.
// Exception handling in a C# application is generally implemented using one or more of the following patterns:
// The try-catch pattern consists of a try block followed by one or more catch clauses. Each catch block is used to specify handlers for different exceptions.
// The try-finally pattern consists of a try block followed by a finally block. Typically, the statements of a finally block run when control leaves a try statement.
// The try-catch-finally pattern implements all three types of exception handling blocks. A common scenario for the try-catch-finally pattern is when resources are obtained and used in a try block, exceptional circumstances are managed in a catch block, and the resources are released or otherwise managed in the finally block.

// Exception handling process
// When an exception occurs, the .NET runtime searches for the nearest catch clause that can handle the exception. The process begins with the method that caused the exception to be thrown. First, the method is examined to see whether the code that caused the exception is inside a try code block. If the code is inside try code block, the catch clauses associated with the try statement are considered in order. If the catch clauses are unable to handle the exception, the method that called the current method is searched. This method is examined to determine whether the method call (to the first method) is inside a try code block. If the call is inside a try code block, the associated catch clauses are considered. This search process continues until a catch clause is found that can handle the current exception.
// Once a catch clause is found that can handle the exception, the runtime prepares to transfer control to the first statement of the catch block. However, before execution of the catch block begins, the runtime executes any finally blocks associated with try statements found during the search. If more than one finally block is found, they are executed in order, starting with the one closest to the code that caused the exception to be thrown.
// If no catch clause is found to handle the exception, the runtime terminates the application and displays an error message to the user.

// Call stack
// You can think of the call stack like a tower of blocks. When you build a tower, you start with just one block. Each time you add a block to the tower, you place it on top of the existing blocks. When your application starts running in the debugger, the entry point to your application is the first layer added to the call stack (the first block of the tower). Each time a method calls another method, the new method is added to the top of the stack. When your code exits out of a method, the method is removed from the call stack.

// Compiler-generated exceptions
// The .NET runtime throws exceptions when basic operations fail. Here's a short list of runtime exceptions and their error conditions:
// ArrayTypeMismatchException: Thrown when an array can't store a given element because the actual type of the element is incompatible with the actual type of the array.
// DivideByZeroException: Thrown when an attempt is made to divide an integral value by zero.
// FormatException: Thrown when the format of an argument is invalid.
// IndexOutOfRangeException: Thrown when an attempt is made to index an array when the index is less than zero or outside the bounds of the array.
// InvalidCastException: Thrown when an explicit conversion from a base type to an interface or to a derived type fails at runtime.
// NullReferenceException: Thrown when an attempt is made to reference an object whose value is null.
// OverflowException: Thrown when an arithmetic operation in a checked context overflows.

// Implement try-catch
// Replace the content of the Program.cs file with the following code:
// double float1 = 3000.0;
// double float2 = 0.0;
// int number1 = 3000;
// int number2 = 0;
// Console.WriteLine(float1 / float2);
// Console.WriteLine(number1 / number2);
// Console.WriteLine("Exit program");
// Take a minute to examine the message output for your application.
// ∞
// Unhandled exception. System.DivideByZeroException: Attempted to divide by zero.
//    at Program.<Main>$(String[] args) in C:\Users\msuser\Desktop\Exceptions101\Program.cs:line 7
// Enclose the two calculations within the code block of a try statement as follows:
// double float1 = 3000.0;
// double float2 = 0.0;
// int number1 = 3000;
// int number2 = 0;
// try
// {
//     Console.WriteLine(float1 / float2);
//     Console.WriteLine(number1 / number2);
// }
// Console.WriteLine("Exit program");
// Construct a catch code block below the try code block as follows:
// try
// {
//     Console.WriteLine(float1 / float2);
//     Console.WriteLine(number1 / number2);
// }
// catch
// {
//     Console.WriteLine("An exception has been caught");
// }
// Take a minute to examine the output that your application produced.
// ∞
// An exception has been caught
// Exit program

// Properties of the Exception class:
// Data: The Data property holds arbitrary data in key-value pairs.
// HelpLink: The HelpLink property can be used to hold a URL (or URN) to a help file that provides extensive information about the cause of an exception.
// HResult: The HResult property can be used to access to a coded numerical value that's assigned to a specific exception.
// InnerException: The InnerException property can be used to create and preserve a series of exceptions during exception handling.
// Message: The Message property provides details about the cause of an exception.
// Source: The Source property can be used to access the name of the application or the object that causes the error.
// StackTrace: The StackTrace property contains a stack trace that can be used to determine where an error occurred.
// TargetSite: The TargetSite property can be used to get the method that throws the current exception.
// Access the properties of an exception object
// Update the Process1 method as follows:
// static void Process1()
// {
//     try
//     {
//         WriteMessage();
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"Exception caught in Process1: {ex.Message}");
//     }
// }
// Take a minute to examine your updates.
// Notice that your updated catch clause is catching an instance of the Exception class in an object named ex. Also notice that your Console.WriteLine() method is using ex to access the object's Message property and display the error message to the console.
// Although the catch clause can be used without arguments, that approach is not recommended. If you don't specify an argument, all exception types are caught and you can't decern between them.
// In general, you should only catch the exceptions that your code knows how to recover from. Therefore, your catch clause should specify an object argument that's derived from System.Exception. The exception type should be as specific as possible. This helps to avoid catching exceptions that your exception handler isn't able to resolve.
// Now that you know the type of exception to catch, you can update your catch clause to handle that specific exception type.
// Update the Process1 method as follows:
// static void Process1()
// {
//     try
//     {
//         WriteMessage();
//     }
//     catch (DivideByZeroException ex)
//     {
//         Console.WriteLine($"Exception caught in Process1: {ex.Message}");
//     }
// }
// Save your code, and then start a debug session.
// Notice that your updated application reports the same messages to the console.
// Although the reported messages are the same, there is an important difference. Your Process1 method will only catch exceptions of the specific type that it's prepared to handle.
// o generate a different exception type, update the WriteMessage method as follows:
// static void WriteMessage()
// {
//     double float1 = 3000.0;
//     double float2 = 0.0;
//     int number1 = 3000;
//     int number2 = 0;
//     byte smallNumber;

//     Console.WriteLine(float1 / float2);
//     // Console.WriteLine(number1 / number2);
//     checked
//     {
//         smallNumber = (byte)number1;
//     }
// }
// Notice the use of the checked statement.
// When performing integral type calculations that assign the value of one integral type to another integral type, the result depends on the overflow-checking context. In a checked context, the conversion succeeds if the source value is within the range of the destination type. Otherwise, an OverflowException is thrown. In an unchecked context, the conversion always succeeds, and proceeds as follows:
// If the source type is larger than the destination type, then the source value is truncated by discarding its "extra" most significant bits. The result is then treated as a value of the destination type.
// If the source type is smaller than the destination type, then the source value is either sign-extended or zero-extended so that it's of the same size as the destination type. Sign-extension is used if the source type is signed; zero-extension is used if the source type is unsigned. The result is then treated as a value of the destination type.
// If the source type is the same size as the destination type, then the source value is treated as a value of the destination type.
//  Note
//  Integral type calculations that are not inside a checked code block are treated as if they are inside an unchecked code block.

// Catch separate exception types in a code block
// There are times when variations in your data may cause different types of exceptions.
// Clear your breakpoints, and then replace the contents of your Program.cs file with the following code:
// // inputValues is used to store numeric values entered by a user
// string[] inputValues = new string[]{"three", "9999999999", "0", "2" };
// foreach (string inputValue in inputValues)
// {
//     int numValue = 0;
//     try
//     {
//         numValue = int.Parse(inputValue);
//     }
//     catch (FormatException)
//     {
//         Console.WriteLine("Invalid readResult. Please enter a valid number.");
//     }
//     catch (OverflowException)
//     {
//         Console.WriteLine("The number you entered is too large or too small.");
//     }
//     catch(Exception ex)
//     {
//         Console.WriteLine(ex.Message);
//     }
// }
// Take a minute to review this code.
// First, the code creates a string array named inputValues. The data in the array is intended to represent the input values entered by a user who was instructed to enter numeric values. Depending on the value entered, different exception types may occur.
// Notice that the code uses the int.Parse method to convert the string "input" values to integers. The int.Parse code is placed inside a try code block.

// Create an exception object
// Creating and throwing exceptions from within your code is an important aspect of C# programming. The ability to generate an exception in response to a specific condition, issue, or error helps you to ensure the stability of your application.
// The exception type that you create depends on the coding issue, and should match the intended purpose of the exception as closely as possible.
// Here are some common exception types that you might use when creating an exception:
// ArgumentException or ArgumentNullException: Use these exception types when a method or constructor is called with an invalid argument value or null reference.
// InvalidOperationException: Use this exception type when the operating conditions of a method don't support the successful completion of a particular method call.
// NotSupportedException: Use this exception type when an operation or feature is not supported.
// IOException: Use this exception type when an input/output operation fails.
// FormatException: Use this exception type when the format of a string or data is incorrect.
// The new keyword is used to create an instance of an exception. For example, you can create an instance of the ArgumentException exception type as follows:
// ArgumentException invalidArgumentException = new ArgumentException("ArgumentException: The 'GraphData' method received data outside the expected range.");
// throw invalidArgumentException;
// The Message property of an exception is readonly. Therefore, a custom Message property must be set when instantiating the object.
// When customizing an exception object, it's important to provide clear error messages that describe the problem and how to resolve it. You can also include additional information such as stack traces and error codes to help users correct the issue.
// An exception object can also be created directly within a throw statement. For example:
// throw new FormatException("FormatException: Calculations in process XYZ have been cancelled due to invalid data format.");
// Some considerations to keep in mind when throwing an exception include:
// The Message property should explain the reason for the exception. However, information that's sensitive, or that represents a security concern shouldn't be put in the message text.
// The StackTrace property is often used to track the origin of the exception. This string property contains the name of the methods on the current call stack, together with the file name and line number in each method that's associated with the exception. A StackTrace object is created automatically by the common language runtime (CLR) from the point of the throw statement. Exceptions must be thrown from the point where the stack trace should begin.

// When to throw an exception
// Methods should throw an exception whenever they can't complete their intended purpose. The exception thrown should be based on the most specific exception available that fits the error conditions.
// Consider a scenario where a developer is working on an application that implements a business process. The business process is dependent on user input. If the input doesn't match the expected data type, the method that implements the business process creates and throws an exception. The exception object can be configured with application specific information in the property values. The following code sample demonstrates the scenario:
// string[][] userEnteredValues = new string[][]
// {
//         new string[] { "1", "two", "3"},
//         new string[] { "0", "1", "2"}
// };
// foreach (string[] userEntries in userEnteredValues)
// {
//     try
//     {
//         BusinessProcess1(userEntries);
//     }
//     catch (Exception ex)
//     {
//         if (ex.StackTrace.Contains("BusinessProcess1") && (ex is FormatException))
//         {
//             Console.WriteLine(ex.Message);
//         }
//     }
// }
// static void BusinessProcess1(String[] userEntries)
// {
//     int valueEntered;
//     foreach (string userValue in userEntries)
//     {
//         try
//         {
//             valueEntered = int.Parse(userValue);
//             // completes required calculations based on userValue
//             // ...
//         }
//         catch (FormatException)
//         {
//             FormatException invalidFormatException = new FormatException("FormatException: User input values in 'BusinessProcess1' must be valid integers");
//             throw invalidFormatException;
//         }
//     }
// }

// Re-throwing exceptions
// In addition to throwing a new exception, throw can be used re-throw an exception from inside a catch code block. In this case, throw does not take an exception operand.
// catch (Exception ex)
// {
//     // handle or partially handle the exception
//     // ...
//     // re-throw the original exception object for further handling down the call stack
//     throw;
// }
// When you re-throw an exception, the original exception object is used, so you don't lose any information about the exception. If you want to create a new exception object that wraps the original exception, you can pass the original exception as an argument to the constructor of a new exception object. For example:
// catch (Exception ex)
// {
//     // handle or partially handle the exception
//     // ...

//     // create a new exception object that wraps the original exception
//     throw new ApplicationException("An error occurred", ex);
// }


