Programming paradigms
A programming paradigm is a way of thinking about and structuring a program's functionality. Programming paradigms differ from one another, for example in how the program's execution and control are defined and what components the programs consist of.
Most programming languages ​​that are currently in use support multiple programming paradigms. Part of a programmer's growth involves the ability, through experience, to choose the appropriate programming language and paradigm; there currently is no single ubiquitous programming language and programming paradigm.
The most common programming paradigms today are object-oriented programming, procedural programming, and functional programming. The first two of these are briefly discussed in what follows.

Object-Oriented Programming
In object-oriented programming, information is represented as classes that describe the concepts of the problem domain and the logic of the application. Classes define the methods that determine how information is handled. During program execution, objects are instantiated from classes that contain runtime information and that also have an effect on program execution: program execution typically proceeds through a series of method calls related to the objects. As mentioned a few weeks ago, "the program is built from small, clear, and cooperative entities."
One of the major benefits of object-oriented programming is how problem-domain concepts are modeled through classes and objects, which makes programs easier to understand. In addition, structuring the problem domain into classes facilitates the construction and maintenance of programs. However, object-oriented programming is not inherently suited to all problems: for example, scientific computing and statistics applications typically make use of languages, such as R and Python.

Procedural programming
Whereas in object-oriented programming, the structure of a program is formed by the data it processes, in procedural programming, the structure of the program is formed by functionality desired for the program: the program acts as a step-by-step guide for the functionality to be performed. The program is executed one step at a time, and subroutines (methods) are called whenever necessary.
In procedural programming, the state of the program is maintained in variables and tables, and any methods handle only the values provided to them as parameters. The program tells the computer what should happen. As an example, the code below demonstrates the swapping of values for two variables a and b
int a = 10;
int b = 15;
// let's swap the values of variables a and b
int c = b;
b = a;
a = c;
When comparing object-oriented programming with procedural programming, a few essential differences emerge. In object-oriented programming, the state of an object can, in principle, change with any object method, and that change of state can also affect the working of the methods of other objects. As a consequence, other aspects of a program's execution may also be affected since objects can be used in multiple places within the program.

Algorithms
Algorithms, precise instructions on how to to accomplish a specific task, are at the core of computer science. In the context of programming, algorithms are typically defined using source code.
The concept of efficiency is often associated with algorithms. A programs efficiency, i.e, the computation of required information fast enough, is an integral part of a programs usability. If it took two days for an algorithm designed for forecasting tomorrows weather run, the results wouldn't be very useful! Similarly, a user viewing a TVs program guide won't get any use out of it, if the tv-shows info only loads after the show already ended.
In a more general sense, retrieving and displaying information quickly is an integral part of any applications function.

Selection sort
The idea of selection sort is:
Move the smallest number in the array to index 0.
Move the second smallest number to index 1.
Move the third smalles number in the array to index 2.
Etc.
In other words:
Examine the array starting from index 0. Swap the following two numbers with each other: the number at index 0, and the smallest number in the array starting from index 0.
Examine the array starting from index 1. Swap the following two numbers with each other: the number at index 1, and the smallest number in the array starting from index 1.
Examine the array starting from index 2. Swap the following two numbers with each other: the number at index 2, and the smallest number in the array starting from index 2.
Etc.

Static or not
Methods in Java can be divided into two groups, based on whether they have the static modifier or not. Methods without the static modifier are instance methods. Methods with the static modifier are class methods
Instance methods are methods that are associated with an object, can process the objects variables and can call the object's other methods. Instance methods specifically CAN use the this modifier, which refers to the variables associated with the specific object, that is calling the instance method. Class methods can't use the this modifier, meaning that they can only access the variables they are given as parameters or that they create themselves.

Built-in sorting algorithms in Java
Java offers a significant amount of ready to use sorting algorithms. Arrays can be sorted (into their natural order) using the class method sort of the Arrays-class. Lists can be sorted (into their natural order) using the class method sort of the Collections class.
int[] numbers = {8, 3, 7, 9, 1, 2, 4};
System.out.println(Arrays.toString(numbers));
Arrays.sort(numbers);
System.out.println(Arrays.toString(numbers));
Sample output
[8, 3, 7, 9, 1, 2, 4]
[1, 2, 3, 4, 7, 8, 9]

Linear search
Linear search is a search algorithm that searches for information in an array by going through every value in the array one by one. When the value that was searched for is found, its index is immediately returned. If the requested value cannot be found, linear search returns the information that the value was not found — typically this means returning -1 instead of a valid index.
public class Algorithms {
    public static int linearSearch(int[] array, int searched) {
        for (int i = 0; i < array.length; i++) {
            if (array[i] == searched) {
                return i;
            }
        }
        return -1;
    }
}
In the worst case scenario, i.e when the value searched for isn't found, the algorithm has to do as many comparisons as there are values in the array. In an array containing, say, 10 million values, this means 10 million comparisons. If we are doing more than one search, it makes sense to try and improve efficiency.

Binary search (aka half-interval search or logarithmic search )
When the data searched is in order, searching can be implemented a lot more efficiently than in linear search. The idea behind Binary Search is to start looking for the searched value in the middle index of the array (or list), compare the value found there to the searched value, and if needed (i.e, when the value isn't found there) eliminate half of the search area. The algorithm is more thoroughly introduced in the following slideshow.