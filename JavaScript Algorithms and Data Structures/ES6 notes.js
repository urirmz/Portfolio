// Scopes of let and var
// When you declare a variable with the var keyword, it is declared globally, or locally if declared inside a function.
// When you declare a variable with the let keyword inside a block, statement, or expression, its scope is limited to that block, statement, or expression.

// Arrays declared with const
// Objects (including arrays and functions) assigned to a variable using const are still mutable. Using the const declaration only prevents reassignment of the variable identifier.
// const declaration alone doesn't really protect your data from mutation. To ensure your data doesn't change, JavaScript provides a function Object.freeze to prevent data mutation.

// Arrow functions
// In JavaScript, we often don't need to name our functions, especially when passing a function as an argument to another function. Instead, we create inline functions. We don't need to name these functions because we do not reuse them anywhere else.
// To achieve this, we often use the following syntax:
// const myFunc = function() {
//   const myVar = "value";
//   return myVar;
// }
// ES6 provides us with the syntactic sugar to not have to write anonymous functions this way. Instead, you can use arrow function syntax:
// const myFunc = () => {
//   const myVar = "value";
//   return myVar;
// }
// When there is no function body, and only a return value, arrow function syntax allows you to omit the keyword return as well as the brackets surrounding the code. This helps simplify smaller functions into one-line statements:
// const myFunc = () => "value";
// This code will still return the string value by default.
// Just like a regular function, you can pass arguments into an arrow function.
// const doubler = (item) => item * 2;
// doubler(4);
// doubler(4) would return the value 8.
// If an arrow function has a single parameter, the parentheses enclosing the parameter may be omitted.
// const doubler = item => item * 2;

// Default parameters
// Set Default Parameters for Your Functions
// In order to help us create more flexible functions, ES6 introduces default parameters for functions.
// Check out this code:
// const greeting = (name = "Anonymous") => "Hello " + name;
// console.log(greeting("John"));
// console.log(greeting());
// The console will display the strings Hello John and Hello Anonymous.
// The default parameter kicks in when the argument is not specified (it is undefined). As you can see in the example above, the parameter name will receive its default value Anonymous when you do not provide a value for the parameter. You can add default values for as many parameters as you want.

// Rest parameters
// In order to help us create more flexible functions, ES6 introduces the rest parameter for function parameters. With the rest parameter, you can create functions that take a variable number of arguments. These arguments are stored in an array that can be accessed later from inside the function.
// Check out this code:
// function howMany(...args) {
//   return "You have passed " + args.length + " arguments.";
// }
// console.log(howMany(0, 1, 2));
// console.log(howMany("string", null, [1, 2, 3], { }));
// The console would display the strings You have passed 3 arguments. and You have passed 4 arguments..
// The rest parameter eliminates the need to use the arguments object and allows us to use array methods on the array of parameters passed to the function howMany.

// Spread operator
// The spread operator unpacks all contents of an array into a comma-separated list
// Spread operator allows us to expand arrays and other expressions in places where multiple parameters or elements are expected.
// ...arr returns an unpacked array. In other words, it spreads the array. However, the spread operator only works in-place, like in an argument to a function or in an array literal. For example:
// const spreaded = [...arr];

// Destructuring assignment from structures
// Consider the following ES5 code:
// const user = { name: 'John Doe', age: 34 };
// const name = user.name;
// const age = user.age;
// name would have a value of the string John Doe, and age would have the number 34.
// Here's an equivalent assignment statement using the ES6 destructuring syntax:
// const { name, age } = user;
// Again, name would have a value of the string John Doe, and age would have the number 34.
// Here, the name and age variables will be created and assigned the values of their respective values from the user object. You can see how much cleaner this is.
// Destructuring allows you to assign a new variable name when extracting values. You can do this by putting the new name after a colon when assigning the value.
// Using the same object from the last example:
// const user = { name: 'John Doe', age: 34 };
// Here's how you can give new variable names in the assignment:
// const { name: userName, age: userAge } = user;
// You may read it as "get the value of user.name and assign it to a new variable named userName" and so on. The value of userName would be the string John Doe, and the value of userAge would be the number 34.
// You can use the same principles from the previous two lessons to destructure values from nested objects.
// Using an object similar to previous examples:
// const user = {
//   johnDoe: { 
//     age: 34,
//     email: 'johnDoe@freeCodeCamp.com'
//   }
// };
// Here's how to extract the values of object properties and assign them to variables with the same name:
// const { johnDoe: { age, email }} = user;
// And here's how you can assign an object properties' values to variables with different names:
// const { johnDoe: { age: userAge, email: userEmail }} = user;

// Destructuring assignment from arrays
// One key difference between the spread operator and array destructuring is that the spread operator unpacks all contents of an array into a comma-separated list. Consequently, you cannot pick or choose which elements you want to assign to variables.
// Destructuring an array lets us do exactly that:
// const [a, b] = [1, 2, 3, 4, 5, 6];
// console.log(a, b);
// The console will display the values of a and b as 1, 2.
// The variable a is assigned the first value of the array, and b is assigned the second value of the array. We can also access the value at any index in an array with destructuring by using commas to reach the desired index:
// const [a, b,,, c] = [1, 2, 3, 4, 5, 6];
// console.log(a, b, c);
// The console will display the values of a, b, and c as 1, 2, 5.