// Splice 
// splice() allows us to do just that: remove any number of consecutive elements from anywhere in an array.
// splice() can take up to 3 parameters, but for now, we'll focus on just the first 2. The first two parameters of splice() are integers which represent indexes, or positions, of items in the array that splice() is being called upon. And remember, arrays are zero-indexed, so to indicate the first element of an array, we would use 0. splice()'s first parameter represents the index on the array from which to begin removing elements, while the second parameter indicates the number of elements to delete. For example:
// let array = ['today', 'was', 'not', 'so', 'great'];
// array.splice(2, 2);
// Here we remove 2 elements, beginning with the third element (at index 2). array would have the value ['today', 'was', 'great'].
// splice() not only modifies the array it's being called on, but it also returns a new array containing the value of the removed elements:
// let array = ['I', 'am', 'feeling', 'really', 'happy'];
// let newArray = array.splice(3, 2);
// newArray has the value ['really', 'happy'].
// you can use the third parameter, comprised of one or more element(s), to add to the array. This can be incredibly useful for quickly switching out an element, or a set of elements, for another.
// const numbers = [10, 11, 12, 12, 15];
// const startIndex = 3;
// const amountToDelete = 1;
// numbers.splice(startIndex, amountToDelete, 13, 14);
// console.log(numbers);
// The second occurrence of 12 is removed, and we add 13 and 14 at the same index. The numbers array would now be [ 10, 11, 12, 13, 14, 15 ].
// Here, we begin with an array of numbers. Then, we pass the following to splice(): The index at which to begin deleting elements (3), the number of elements to be deleted (1), and the remaining arguments (13, 14) will be inserted starting at that same index. Note that there can be any number of elements (separated by commas) following amountToDelete, each of which gets inserted.

// Slice() copies or extracts a given number of elements to a new array, leaving the array it is called upon untouched. slice() takes only 2 parameters — the first is the index at which to begin extraction, and the second is the index at which to stop extraction (extraction will occur up to, but not including the element at this index). Consider this:
// let weatherConditions = ['rain', 'snow', 'sleet', 'hail', 'clear'];
// let todaysWeather = weatherConditions.slice(1, 3);
// todaysWeather would have the value ['snow', 'sleet'], while weatherConditions would still have ['rain', 'snow', 'sleet', 'hail', 'clear'].
// In effect, we have created a new array by extracting elements from an existing array.

// Spread operator 
// ES6's new spread operator allows us to easily copy all of an array's elements, in order, with a simple and highly readable syntax. The spread syntax simply looks like this: ...
// In practice, we can use the spread operator to copy an array like so:
// let thisArray = [true, true, undefined, false, null];
// let thatArray = [...thisArray];
// thatArray equals [true, true, undefined, false, null]. thisArray remains unchanged and thatArray contains the same elements as thisArray.
// Another huge advantage of the spread operator is the ability to combine arrays, or to insert all the elements of one array into another, at any index. With more traditional syntaxes, we can concatenate arrays, but this only allows us to combine arrays at the end of one, and at the start of another. Spread syntax makes the following operation extremely simple:
// let thisArray = ['sage', 'rosemary', 'parsley', 'thyme'];
// let thatArray = ['basil', 'cilantro', ...thisArray, 'coriander'];
// thatArray would have the value ['basil', 'cilantro', 'sage', 'rosemary', 'parsley', 'thyme', 'coriander'].
// Using spread syntax, we have just achieved an operation that would have been more complex and more verbose had we used traditional methods.

// indexOf()
// Since arrays can be changed, or mutated, at any time, there's no guarantee about where a particular piece of data will be on a given array, or if that element even still exists. Luckily, JavaScript provides us with another built-in method, indexOf(), that allows us to quickly and easily check for the presence of an element on an array. indexOf() takes an element as a parameter, and when called, it returns the position, or index, of that element, or -1 if the element does not exist on the array.
// For example:
// let fruits = ['apples', 'pears', 'oranges', 'peaches', 'pears'];
// fruits.indexOf('dates');
// fruits.indexOf('oranges');
// fruits.indexOf('pears');
// indexOf('dates') returns -1, indexOf('oranges') returns 2, and indexOf('pears') returns 1 (the first index at which each element exists).

// Keyvalue pairs 
// At their most basic, objects are just collections of key-value pairs. In other words, they are pieces of data (values) mapped to unique identifiers called properties (keys). Take a look at an example:
// const tekkenCharacter = {
//     player: 'Hwoarang',
//     fightingStyle: 'Tae Kwon Doe',
//     human: true
//   };
//   The above code defines a Tekken video game character object called tekkenCharacter. It has three properties, each of which map to a specific value. If you want to add an additional property, such as "origin", it can be done by assigning origin to the object:
//   tekkenCharacter.origin = 'South Korea';
//   This uses dot notation. If you were to observe the tekkenCharacter object, it will now include the origin property. Hwoarang also had distinct orange hair. You can add this property with bracket notation by doing:
//   tekkenCharacter['hair color'] = 'dyed orange';
//   Bracket notation is required if your property has a space in it or if you want to use a variable to name the property. In the above case, the property is enclosed in quotes to denote it as a string and will be added exactly as shown. Without quotes, it will be evaluated as a variable and the name of the property will be whatever value the variable is. Here's an example with a variable:
//   const eyes = 'eye color';
//   tekkenCharacter[eyes] = 'brown';
//   After adding all the examples, the object will look like this:
//   {
//     player: 'Hwoarang',
//     fightingStyle: 'Tae Kwon Doe',
//     human: true,
//     origin: 'South Korea',
//     'hair color': 'dyed orange',
//     'eye color': 'brown'
//   };

// Delete object properties
// we can remove a key-value pair from an object.
// If we wanted to remove the apples key, we can remove it by using the delete keyword like this:
// delete foods.apples;

// Check if an object has a property 
// avaScript provides us with two different ways to do this. One uses the hasOwnProperty() method and the other uses the in keyword. If we have an object users with a property of Alan, we could check for its presence in either of the following ways:
// users.hasOwnProperty('Alan');
// 'Alan' in users;
// Both of these would return true.

// Iterate Through the Keys of an Object with a for...in Statement
// Sometimes you need to iterate through all the keys within an object. You can use a for...in loop to do this. The for...in loop looks like:
// const refrigerator = {
//   'milk': 1,
//   'eggs': 12,
// };
// for (const food in refrigerator) {
//   console.log(food, refrigerator[food]);
// }
// This code logs milk 1 and eggs 12, with each key-value pair on its own line.
// We defined the variable food in the loop head and this variable was set to each of the object's keys on each iteration, resulting in each food's name being printed to the console.
// NOTE: Objects do not maintain an ordering to stored keys like arrays do; thus a key's position on an object, or the relative order in which it appears, is irrelevant when referencing or accessing that key.

// Object.keys 
// We can also generate an array which contains all the keys stored in an object with the Object.keys() method. This method takes an object as the argument and returns an array of strings representing each property in the object. Again, there will be no specific order to the entries in the array.