// Javascript variables
// In computer science, data is anything that is meaningful to the computer. JavaScript provides eight different data types which are undefined, null, boolean, string, symbol, bigint, number, and object.
// When JavaScript variables are declared, they have an initial value of undefined. If you do a mathematical operation on an undefined variable your result will be NaN which means "Not a Number". If you concatenate a string with an undefined variable, you will get a string of undefined.
// In JavaScript, you can determine the type of a variable or a value with the typeof operator, as follows:
// typeof 3
// typeof '3'
// typeof 3 returns the string number, and typeof '3' returns the string string

// Case sensitivity
// In JavaScript all variables and function names are case sensitive. This means that capitalization matters.
// Best Practice: Write variable names in JavaScript in camelCase. In camelCase, multi-word variable names have the first word in lowercase and the first letter of each subsequent word is capitalized.

// Declaring variables
// One of the biggest problems with declaring variables with the var keyword is that you can easily overwrite variable declarations
// Unlike var, when you use let, a variable with the same name can only be declared once
// const has all the awesome features that let has, with the added bonus that variables declared using const are read-only. They are a constant value, which means that once a variable is assigned with const, it cannot be reassigned    
// You should always name variables you don't want to reassign using the const keyword. This helps when you accidentally attempt to reassign a variable that is meant to stay constant.
// Note: It is common for developers to use uppercase variable identifiers for immutable values and lowercase or camelCase for mutable values (objects and arrays). You will learn more about objects, arrays, and immutable and mutable values in later challenges.

// Math operators:
// You can easily increment or add one to a variable with the ++ operator.
// i++;
// is the equivalent of     
// i = i + 1;
// You can easily decrement or decrease a variable by one with the -- operator.
// i--;
// is the equivalent of
// i = i - 1;
// The remainder operator % gives the remainder of the division of two numbers.
// We can say:
// myVar = myVar + 5;
// to add 5 to myVar. Since this is such a common pattern, there are operators which do both a mathematical operation and assignment in one step.
// One such operator is the += operator.
// Like the += operator, -= subtracts a number from a variable.
// myVar = myVar - 5;
// will subtract 5 from myVar. This can be rewritten as:
// myVar -= 5;
// The *= operator multiplies a variable by a number.
// myVar = myVar * 5;
// will multiply myVar by 5. This can be rewritten as:
// myVar *= 5;
// The /= operator divides a variable by another number.
// myVar = myVar / 5;
// Will divide myVar by 5. This can be rewritten as:
// myVar /= 5;

// Strings:
// When you are defining a string you must start and end with a single or double quote. What happens when you need a literal quote: " or ' inside of your string?
// In JavaScript, you can escape a quote from considering it as an end of string quote by placing a backslash (\) in front of the quote.
// const sampleStr = "Alan said, \"Peter is learning JavaScript\".";
// Quotes are not the only characters that can be escaped inside a string. Escape sequences allow you to use characters you may not otherwise be able to use in a string.
// Code	Output
// \'	single quote
// \"	double quote
// \\	backslash
// \n	newline
// \t	tab
// \r	carriage return
// \b	backspace
// \f	form feed
// When the + operator is used with a String value, it is called the concatenation operator. You can build a new string out of other strings by concatenating them together.
// We can also use the += operator to concatenate a string onto the end of an existing string variable.
// Sometimes you will need to build a string. By using the concatenation operator (+), you can insert one or more variables into a string you're building.
// You can find the length of a String value by writing .length after the string variable or string literal.
// Most modern programming languages, like JavaScript, don't start counting at 1 like humans do. They start at 0. This is referred to as Zero-based indexing.
// Bracket notation is a way to get a character at a specific index within a string.
// In JavaScript, String values are immutable, which means that they cannot be altered once created.
// In order to get the last letter of a string, you can subtract one from the string's length. For example, if const firstName = "Ada", you can get the value of the last letter of the string by using firstName[firstName.length - 1].
// Use the replace() method to remove all special characters from a string

// Arrays
// With JavaScript array variables, we can store several pieces of data in one place. You start an array declaration with an opening square bracket, end it with a closing square bracket
// You can also nest arrays within other arrays. This is also called a multi-dimensional array.
// Unlike strings, the entries of arrays are mutable and can be changed freely, even if the array was declared with const.
// One way to think of a multi-dimensional array, is as an array of arrays. When you use brackets to access your array, the first set of brackets refers to the entries in the outermost (the first level) array, and each additional pair of brackets refers to the next level of entries inside.
// const arr = [
//   [1, 2, 3],
//   [4, 5, 6],
//   [7, 8, 9],
//   [[10, 11, 12], 13, 14]
// ];
// const subarray = arr[3];
// const nestedSubarray = arr[3][0];
// const element = arr[3][0][1];
// In this example, subarray has the value [[10, 11, 12], 13, 14], nestedSubarray has the value [10, 11, 12], and element has the value 11 .
// The push() method takes one or more arguments and appends them to the end of the array, in the order in which they appear. It returns the new length of the array.
// Examples:
// const arr1 = [1, 2, 3];
// arr1.push(4, 5);
// const arr2 = ["Stimpson", "J", "cat"];
// arr2.push(["happy", "joy"]);
// arr1 now has the value [1, 2, 3, 4, 5] and arr2 has the value ["Stimpson", "J", "cat", ["happy", "joy"]].
// Another way to change the data in an array is with the .pop() function.
// .pop() is used to pop a value off of the end of an array. We can store this popped off value by assigning it to a variable. In other words, .pop() removes the last element from an array and returns that element.
// pop() always removes the last element of an array. What if you want to remove the first?
// That's where .shift() comes in. It works just like .pop(), except it removes the first element instead of the last.
// Not only can you shift elements off of the beginning of an array, you can also unshift elements to the beginning of an array i.e. add elements in front of the array.
// .unshift() works exactly like .push(), but instead of adding the element at the end of the array, unshift() adds the element at the beginning of the array.

// Functions
// In JavaScript, we can divide up our code into reusable parts called functions.
// Here's an example of a function:
// const function functionName() {
//   console.log("Hello World");
// }
// You can call or invoke this function by using its name followed by parentheses, like this: functionName()
// Parameters are variables that act as placeholders for the values that are to be input to a function when it is called. When a function is defined, it is typically defined along with one or more parameters. The actual values that are input (or "passed") into a function when it is called are known as arguments.
// Here is a function with two parameters, param1 and param2:
// function testFun(param1, param2) {
//   console.log(param1, param2);
// }
// We can pass values into a function with arguments. You can use a return statement to send a value back out of a function.
// In JavaScript, scope refers to the visibility of variables. Variables which are defined outside of a function block have Global scope. This means, they can be seen everywhere in your JavaScript code.
// Variables which are declared without the let or const keywords are automatically created in the global scope. This can create unintended consequences elsewhere in your code or when running a function again. You should always declare your variables with let or const.
// Variables which are declared within a function, as well as the function parameters, have local scope. That means they are only visible within that function.
// It is possible to have both local and global variables with the same name. When you do this, the local variable takes precedence over the global variable.
// A function can include the return statement but it does not have to. In the case that the function doesn't have a return statement, when you call it, the function processes the inner code but the returned value is undefined.
// In Computer Science a queue is an abstract Data Structure where items are kept in order. New items can be added at the back of the queue and old items are taken off from the front of the queue.

// Conditional Logic with If Statements
// The equality operator == compares two values and returns true if they're equivalent or false if they are not
// Strict equality (===) is the counterpart to the equality operator (==). If the values being compared have different types, they are considered unequal, and the strict equality operator will return false.
// The inequality operator (!=) is the opposite of the equality operator. It means not equal and returns false where equality would return true and vice versa.  Like the equality operator, the inequality operator will convert data types of values while comparing.
// The strict inequality operator (!==) is the logical opposite of the strict equality operator. It means "Strictly Not Equal" and returns false where strict equality would return true and vice versa. The strict inequality operator will not convert data types.
// The greater than operator (>) compares the values of two numbers. If the number to the left is greater than the number to the right, it returns true. Otherwise, it returns false. Like the equality operator, the greater than operator will convert data types of values while comparing.
// The greater than or equal to operator (>=) compares the values of two numbers. If the number to the left is greater than or equal to the number to the right, it returns true. Otherwise, it returns false.
// The less than operator (<) compares the values of two numbers. If the number to the left is less than the number to the right, it returns true. Otherwise, it returns false. Like the equality operator, the less than operator converts data types while comparing.
// The less than or equal to operator (<=) compares the values of two numbers. If the number to the left is less than or equal to the number to the right, it returns true. If the number on the left is greater than the number on the right, it returns false. Like the equality operator, the less than or equal to operator converts data types.
//  The logical and operator (&&) returns true if and only if the operands to the left and right of it are true.
// The logical or operator (||) returns true if either of the operands is true. Otherwise, it returns false.
// When a condition for an if statement is true, the block of code following it is executed. What about when that condition is false? Normally nothing would happen. With an else statement, an alternate block of code can be executed.
// If you have multiple conditions that need to be addressed, you can chain if statements together with else if statements.

// Switch
// If you need to match one value against many options, you can use a switch statement. A switch statement compares the value to the case statements which define various possible values. Any valid JavaScript statements can be executed inside a case block and will run from the first matched case value until a break is encountered.
// Case values are tested with strict equality (===). The break tells JavaScript to stop executing statements. If the break is omitted, the next statement will be executed.
// In a switch statement you may not be able to specify all possible values as case statements. Instead, you can add the default statement which will be executed if no matching case statements are found. Think of it like the final else statement in an if/else chain. A default statement should be the last case.
// switch (num) {
//   case value1:
//     statement1;
//     break;
//   case value2:
//     statement2;
//     break;
// ...
//   default:
//     defaultStatement;
//     break;
// }
// // If the break statement is omitted from a switch statement's case, the following case statement(s) are executed until a break is encountered. If you have multiple inputs with the same output, you can represent them in a switch statement like this:
// let result = "";
// switch (val) {
//   case 1:
//   case 2:
//   case 3:
//     result = "1, 2, or 3";
//     break;
//   case 4:
//     result = "4 alone";
// }
// Cases for 1, 2, and 3 will all produce the same result.

// Return 
// When a return statement is reached, the execution of the current function stops and control returns to the calling location.

// Objects
// Objects are similar to arrays, except that instead of using indexes to access and modify their data, you access the data in objects through what are called properties.
// Objects are useful for storing data in a structured way, and can represent real world objects
// Here's a sample cat object:
// const cat = {
//     "name": "Whiskers",
//     "legs": 4,
//     "tails": 1,
//     "enemies": ["Water", "Dogs"]
//   };
// In this example, all the properties are stored as strings, such as name, legs, and tails. However, you can also use numbers as properties. You can even omit the quotes for single-word string properties, as follows:
// const anotherObject = {
//     make: "Ford",
//     5: "five",
//     "model": "focus"
//   };
// There are two ways to access the properties of an object: dot notation (.) and bracket notation ([]), similar to an array.
// Dot notation is what you use when you know the name of the property you're trying to access ahead of time.
// If the property of the object you are trying to access has a space in its name, you will need to use bracket notation.
// Another use of bracket notation on objects is to access a property which is stored as the value of a variable. This can be very useful for iterating through an object's properties or when accessing a lookup table.
// Here is an example of using a variable to access a property:
// const dogs = {
//   Fido: "Mutt",
//   Hunter: "Doberman",
//   Snoopie: "Beagle"
// };
// const myDog = "Hunter";
// const myBreed = dogs[myDog];
// console.log(myBreed);
// The string Doberman would be displayed in the console.
// You can add new properties to existing JavaScript objects the same way you would modify them.
// Here's how we would add a bark property to ourDog:
// ourDog.bark = "bow-wow";
// or
// ourDog["bark"] = "bow-wow";
// We can also delete properties from objects like this:
// delete ourDog.bark;
// To check if a property on a given object exists or not, you can use the .hasOwnProperty() method. someObject.hasOwnProperty(someProperty) returns true or false depending on if the property is found on the object or not.
// he sub-properties of objects can be accessed by chaining together the dot or bracket notation.
// Here is a nested object:
// const ourStorage = {
//   "desk": {
//     "drawer": "stapler"
//   },
//   "cabinet": {
//     "top drawer": { 
//       "folder1": "a file",
//       "folder2": "secrets"
//     },
//     "bottom drawer": "soda"
//   }
// };
// ourStorage.cabinet["top drawer"].folder2;
// ourStorage.desk.drawer;

// Loops
// You can run the same code multiple times by using a loop.
// The first type of loop we will learn is called a while loop because it runs while a specified condition is true and stops once that condition is no longer true.
// The initialization statement is executed one time only before the loop starts. It is typically used to define and setup your loop variable. The condition statement is evaluated at the beginning of every loop iteration and will continue as long as it evaluates to true. When the condition is false at the start of the iteration, the loop will stop executing. This means if the condition starts as false, your loop will never execute.
// If you have a multi-dimensional array, you can use the same logic as the prior waypoint to loop through both the array and any sub-arrays. Here is an example:
// const arr = [
//     [1, 2], [3, 4], [5, 6]
//   ];
  
//   for (let i = 0; i < arr.length; i++) {
//     for (let j = 0; j < arr[i].length; j++) {
//       console.log(arr[i][j]);
//     }
//   }
//   This outputs each sub-element in arr one at a time. Note that for the inner loop, we are checking the .length of arr[i], since arr[i] is itself an array.
// do...while loop will first do one pass of the code inside the loop no matter what, and then continue to run the loop while the specified condition evaluates to true

// Recursion
// Recursion is the concept that a function can be expressed in terms of itself.
//   function multiply(arr, n) {
//     let product = 1;
//     for (let i = 0; i < n; i++) {
//       product *= arr[i];
//     }
//     return product;
//   }
// However, notice that multiply(arr, n) == multiply(arr, n - 1) * arr[n - 1]. That means you can rewrite multiply in terms of itself and never need to use a loop.
//   function multiply(arr, n) {
//     if (n <= 0) {
//       return 1;
//     } else {
//       return multiply(arr, n - 1) * arr[n - 1];
//     }
//   }
// The recursive version of multiply breaks down like this. In the base case, where n <= 0, it returns 1. For larger values of n, it calls itself, but with n - 1. That function call is evaluated in the same way, calling multiply again until n <= 0. At this point, all the functions can return and the original multiply returns the answer.

// Random fractions
// JavaScript has a Math.random() function that generates a random decimal number between 0 (inclusive) and 1 (exclusive). Thus Math.random() can return a 0 but never return a 1
// Use Math.floor() to round a number down to its nearest whole number.
// You can generate a random whole number in the range from zero to a given number. You can also pick a different lower number for this range.
// You'll call your minimum number min and your maximum number max.
// This formula gives a random whole number in the range from min to max. Take a moment to read it and try to understand what this code is doing:
// Math.floor(Math.random() * (max - min + 1)) + min

//ParseInt function
// The parseInt() function parses a string and returns an integer. Here's an example:
// const a = parseInt("007");
// The above function converts the string 007 to the integer 7. If the first character in the string can't be converted into a number, then it returns NaN.
// The parseInt() function parses a string and returns an integer. It takes a second argument for the radix, which specifies the base of the number in the string. The radix can be an integer between 2 and 36.
// The function call looks like:
// parseInt(string, radix);
// And here's an example:
// const a = parseInt("11", 2);
// The radix variable says that 11 is in the binary system, or base 2. This example converts the string 11 to an integer 3.

// Conditional ternary operator
// The ternary operator, can be used as a one line if-else expression.
// The syntax is a ? b : c, where a is the condition, b is the code to run when the condition returns true, and c is the code to run when the condition returns false.
// The following function uses an if/else statement to check a condition:
// function findGreater(a, b) {
//   if(a > b) {
//     return "a is greater";
//   }
//   else {
//     return "b is greater or equal";
//   }
// }
// This can be re-written using the conditional operator:
// function findGreater(a, b) {
//   return a > b ? "a is greater" : "b is greater or equal";
// }