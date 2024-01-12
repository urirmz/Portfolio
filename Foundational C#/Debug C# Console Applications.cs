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
