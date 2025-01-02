// Integral types
// To see the value ranges for the various data types, type the following code into the Visual Studio Code Editor.
// Console.WriteLine("Signed integral types:");
// Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
// Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
// Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
// Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}");
// Console.WriteLine("");
// Console.WriteLine("Unsigned integral types:");
// Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
// Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
// Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
// Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");
// Output
// Signed integral types:
// sbyte  : -128 to 127
// short  : -32768 to 32767
// int    : -2147483648 to 2147483647
// long   : -9223372036854775808 to 9223372036854775807
// Unsigned integral types:
// byte   : 0 to 255
// ushort : 0 to 65535
// uint   : 0 to 4294967295
// ulong  : 0 to 18446744073709551615

// Floating-point types
// float and double values are stored internally in a binary (base 2) format, while decimal is stored in a decimal (base 10) format. Performing math on binary floating-point values can produce results that may surprise you if you're used to decimal (base 10) math. Often, binary floating-point math is an approximation of the real value. Therefore, float and double are useful because large numbers can be stored using a small memory footprint. However, float and double should only be used when an approximation is useful.
// When you need more a more precise answer, you should use decimal. Each value of type decimal has a relatively large memory footprint, however performing math operations gives you a more precise result. 
// To see the value ranges for the various data types, update your code in the Visual Studio Code Editor as follows:
// Console.WriteLine("");
// Console.WriteLine("Floating point types:");
// Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
// Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
// Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");
// Floating point types:
// float  : -3.402823E+38 to 3.402823E+38 (with ~6-9 digits of precision)
// double : -1.79769313486232E+308 to 1.79769313486232E+308 (with ~15-17 digits of precision)
// decimal: -79228162514264337593543950335 to 79228162514264337593543950335 (with 28-29 digits of precision)

// Large floating-point values
// Because floating-point types can hold large numbers with precision, their values can be represented using "E notation", which is a form of scientific notation that means "times 10 raised to the power of." So, a value like 5E+2 would be the value 500 because it's the equivalent of 5 * 10^2, or 5 x 102.

// Reference types and value types
// Reference types include arrays, classes, and strings. Reference types are treated differently from value types regarding the way values are stored when the application is executing.
// A value type variable stores its values directly in an area of storage called the stack. The stack is memory allocated to the code that is currently running on the CPU (also known as the stack frame, or activation frame). When the stack frame has finished executing, the values in the stack are removed.
// A reference type variable stores its values in a separate memory region called the heap. The heap is a memory area that is shared across many applications running on the operating system at the same time. The .NET Runtime communicates with the operating system to determine what memory addresses are available, and requests an address where it can store the value. The .NET Runtime stores the value, and then returns the memory address to the variable. When your code uses the variable, the .NET Runtime seamlessly looks up the address stored in the variable, and retrieves the value that's stored there.
// Update your code in the Visual Studio Code Editor as follows:
// int[] data;
// The previous code defines a variable that can hold a value of type int array.
// At this point, data is merely a variable that could hold a reference, or rather, a memory address of a value in the heap. Because it's not pointing to a memory address, it's called a null reference.
// Update your code in the Visual Studio Code Editor to create and assign a new instance of int array, using the following code:
// int[] data;
// data = new int[3];
// The new keyword informs .NET Runtime to create an instance of int array, and then coordinate with the operating system to store the array sized for three int values in memory. The .NET Runtime complies, and returns a memory address of the new int array. Finally, the memory address is stored in the variable data. The int array's elements default to the value 0, because that is the default value of an int.