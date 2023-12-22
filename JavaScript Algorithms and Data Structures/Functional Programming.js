// Functional Programming
// Functional programming is a style of programming where solutions are simple, isolated functions, without any side effects outside of the function scope: INPUT -> PROCESS -> OUTPUT
// Functional programming is about:
// Isolated functions - there is no dependence on the state of the program, which includes global variables that are subject to change
// Pure functions - the same input always gives the same output
// Functions with limited side effects - any changes, or mutations, to the state of the program outside the function are carefully controlled

// Functional Programming Terminology
// Callbacks are the functions that are slipped or passed into another function to decide the invocation of that function. You may have seen them passed to other methods, for example in filter, the callback function tells JavaScript the criteria for how to filter an array.
// Functions that can be assigned to a variable, passed into another function, or returned from another function just like any other normal value, are called first class functions. In JavaScript, all functions are first class functions.
// The functions that take a function as an argument, or return a function as a return value, are called higher order functions.
// When functions are passed in to or returned from another function, then those functions which were passed in or returned can be called a lambda.

// Imperative Code
// Functional programming is a good habit. It keeps your code easy to manage, and saves you from sneaky bugs. But before we get there, let's look at an imperative approach to programming to highlight where you may have issues.
// In English (and many other languages), the imperative tense is used to give commands. Similarly, an imperative style in programming is one that gives the computer a set of statements to perform a task.
// Often the statements change the state of the program, like updating global variables. A classic example is writing a for loop that gives exact directions to iterate over the indices of an array.
// In contrast, functional programming is a form of declarative programming. You tell the computer what you want done by calling a method or function.
// JavaScript offers many predefined methods that handle common tasks so you don't need to write out how the computer should perform them. For example, instead of using the for loop mentioned above, you could call the map method which handles the details of iterating over an array. This helps to avoid semantic errors, like the "Off By One Errors" that were covered in the Debugging section.

// Avoid Mutations and Side Effects Using Functional Programming
// One of the core principles of functional programming is to not change things. Changes lead to bugs. It's easier to prevent bugs knowing that your functions don't change anything, including the function arguments or any global variable.
// The previous example didn't have any complicated operations but the splice method changed the original array, and resulted in a bug.
// Recall that in functional programming, changing or altering things is called mutation, and the outcome is called a side effect. A function, ideally, should be a pure function, meaning that it does not cause any side effects.
// Let's try to master this discipline and not alter any variable or object in our code.

// Pass Arguments to Avoid External Dependence in a Function
// Another principle of functional programming is to always declare your dependencies explicitly. This means if a function depends on a variable or object being present, then pass that variable or object directly into the function as an argument.
// There are several good consequences from this principle. The function is easier to test, you know exactly what input it takes, and it won't depend on anything else in your program.
// This can give you more confidence when you alter, remove, or add new code. You would know what you can or cannot change and you can see where the potential traps are.
// Finally, the function would always produce the same output for the same set of inputs, no matter what part of the code executes it.
// Refactor Global Variables Out of Functions
// So far, we have seen two distinct principles for functional programming:
// Don't alter a variable or object - create new variables and objects and return them if need be from a function. Hint: using something like const newArr = arrVar, where arrVar is an array will simply create a reference to the existing variable and not a copy. So changing a value in newArr would change the value in arrVar.
// Declare function parameters - any computation inside a function depends only on the arguments passed to the function, and not on any global object or variable.
// Adding one to a number is not very exciting, but we can apply these principles when working with arrays or more complex objects.

// Map method
// functional programming is centered around a theory of functions.
// It would make sense to be able to pass them as arguments to other functions, and return a function from another function. Functions are considered first class objects in JavaScript, which means they can be used like any other object. They can be saved in variables, stored in an object, or passed as function arguments.
// Let's start with some simple array functions, which are methods on the array object prototype. In this exercise we are looking at Array.prototype.map(), or more simply map.
// The map method iterates over each item in an array and returns a new array containing the results of calling the callback function on each element. It does this without mutating the original array.
// When the callback is used, it is passed three arguments. The first argument is the current element being processed. The second is the index of that element and the third is the array upon which the map method was called.
// See below for an example using the map method on the users array to return a new array containing only the names of the users as elements. For simplicity, the example only uses the first argument of the callback.
// const users = [
//   { name: 'John', age: 34 },
//   { name: 'Amy', age: 20 },
//   { name: 'camperCat', age: 10 }
// ];
// const names = users.map(user => user.name);
// console.log(names);
// The console would display the value  [ 'John', 'Amy', 'camperCat' ].
// from applying Array.prototype.map(), or simply map() earlier, the map method returns an array of the same length as the one it was called on. It also doesn't alter the original array, as long as its callback function doesn't.
// In other words, map is a pure function, and its output depends solely on its inputs. Plus, it takes another function as its argument.
// You might learn a lot about the map method if you implement your own version of it. It is recommended you use a for loop or Array.prototype.forEach().

// Filter method
// Another useful array function is Array.prototype.filter(), or simply filter().
// filter calls a function on each element of an array and returns a new array containing only the elements for which that function returns a truthy value - that is, a value which returns true if passed to the Boolean() constructor. In other words, it filters the array, based on the function passed to it. Like map, it does this without needing to modify the original array.
// The callback function accepts three arguments. The first argument is the current element being processed. The second is the index of that element and the third is the array upon which the filter method was called.
// See below for an example using the filter method on the users array to return a new array containing only the users under the age of 30. For simplicity, the example only uses the first argument of the callback.
// const users = [
//   { name: 'John', age: 34 },
//   { name: 'Amy', age: 20 },
//   { name: 'camperCat', age: 10 }
// ];
// const usersUnder30 = users.filter(user => user.age < 30);
// console.log(usersUnder30); 
// The console would display the value [ { name: 'Amy', age: 20 }, { name: 'camperCat', age: 10 } ].

// Slice method
// The slice method returns a copy of certain elements of an array. It can take two arguments, the first gives the index of where to begin the slice, the second is the index for where to end the slice (and it's non-inclusive). If the arguments are not provided, the default is to start at the beginning of the array through the end, which is an easy way to make a copy of the entire array. The slice method does not mutate the original array, but returns a new one.
// Here's an example:
// const arr = ["Cat", "Dog", "Tiger", "Zebra"];
// const newArray = arr.slice(1, 3);
// newArray would have the value ["Dog", "Tiger"].

// Remove Elements from an Array Using slice Instead of splice
// A common pattern while working with arrays is when you want to remove items and keep the rest of the array. JavaScript offers the splice method for this, which takes arguments for the index of where to start removing items, then the number of items to remove. If the second argument is not provided, the default is to remove items through the end. However, the splice method mutates the original array it is called on. Here's an example:
// const cities = ["Chicago", "Delhi", "Islamabad", "London", "Berlin"];
// cities.splice(3, 1);
// Here splice returns the string London and deletes it from the cities array. cities will have the value ["Chicago", "Delhi", "Islamabad", "Berlin"].
// As we saw in the last challenge, the slice method does not mutate the original array, but returns a new one which can be saved into a variable. Recall that the slice method takes two arguments for the indices to begin and end the slice (the end is non-inclusive), and returns those items in a new array. Using the slice method instead of splice helps to avoid any array-mutating side effects.

// Combine Two Arrays Using the concat Method
// Concatenation means to join items end to end. JavaScript offers the concat method for both strings and arrays that work in the same way. For arrays, the method is called on one, then another array is provided as the argument to concat, which is added to the end of the first array. It returns a new array and does not mutate either of the original arrays. Here's an example:
// [1, 2, 3].concat([4, 5, 6]);
// The returned array would be [1, 2, 3, 4, 5, 6].

// Add Elements to the End of an Array Using concat Instead of push
// Functional programming is all about creating and using non-mutating functions.
// The last challenge introduced the concat method as a way to merge arrays into a new array without mutating the original arrays. Compare concat to the push method. push adds items to the end of the same array it is called on, which mutates that array. Here's an example:
// const arr = [1, 2, 3];
// arr.push(4, 5, 6);
// arr would have a modified value of [1, 2, 3, 4, 5, 6], which is not the functional programming way.
// concat offers a way to merge new items to the end of an array without any mutating side effects.