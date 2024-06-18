Type parameters
Generics relates to how classes that store objects can store objects of a freely chosen type. The choice is based on the generic type parameter in the definition of the classes, which makes it possible to choose the type(s) at the moment of the object's creation. Using generics is done in the following manner: after the name of the class, follow it with a chosen number of type parameters. Each of them is placed between the 'smaller than' and 'greater than' signs, like this: public class Class<TypeParameter1, TypeParameter2, ...>. The type parameters are usually defined with a single character.
Let's implement our own generic class Locker that can hold one object of any type.
public class Locker<T> {
private T element;
    public void setValue(T element) {
        this.element = element;
    }
    public T getValue() {
        return element;
    }
}
The definition public class Locker<T> indicates that the Locker class must be given a type parameter in its constructor. After the constructor call is executed, all the variables stored in that object are going to be of the type that was given with the constructor. Let's create a locker for storing strings.
Locker<String> string = new Locker<>();
string.setValue(":)");
System.out.println(string.getValue());
Sample output
:)
In the program above, the runtime implementation of the Locker object named string looks like the following.
public class Locker<String> {
private String element;
    public void setValue(String element) {
        this.element = element;
    }
    public String getValue() {
        return element;
    }
}
Changing the type parameter allows for creating lockers that store objects of other types. You could store an integer in the following manner.
Locker<Integer> integer = new Locker<>();
integer.setValue(5);
System.out.println(integer.getValue());
Sample output
5
Similarly, here is how to create a locker for storing a Random object.
Locker<Random> random = new Locker<>();
random.setValue(new Random());
System.out.println(random.getValue().nextDouble());
There is no maximum on the number of type parameters, it's all dependent on the implementation. The programmer could implement the following Pair class that is able to store two objects of specified types.
public class Pair<T, K> {
private T first;
private K second;
    public void setValues(T first, K second) {
        this.first = first;
        this.second = second;
    }
    public T getFirst() {
        return this.first;
    }
    public K getSecond() {
        return this.second;
    }
}

There are two ways for a class to implement a generic interface. One is to decide the type parameter in the definition of the class, and the other is to define the implementing class with a type parameter as well. Below, the class MovieList defines the type parameter when it implements List. The MovieList is meant only for handling movies.
public class MovieList implements List<Movie> {
// object variables
    @Override
    public void add(Movie value) {
        // implementation
    }
    @Override
    public Movie get(int index) {
        // implementation
    }
    @Override
    public Movie remove(int index) {
        // implementation
    }
}
The alternative is to use a type parameter in the class defintion, in which case the parameter is passed along to the interface. Now this concrete implementation of the interface remains generic.
public class GeneralList<T> implements List<T> {
// object variables
    @Override
    public void add(T value) {
        // implementation
    }
    @Override
    public T get(int index) {
        // implementation
    }
    @Override
    public T remove(int index) {
        // implementation
    }
}

On search performance
Let's compare the performance of searching from a list or a hash map. To evaluate performance we can use the System.nanotime() method and the value it returns, which represents the time as nanoseconds. 

Randomness
Encryption algorithms, machine learning and making computer games less predictable all require randomness. We can model randomness using random numbers. Java offers ready-made Random class for creating random numbers. An instance of the Random class can be used as follows:
import java.util.Random;
public class Raffle {
public static void main(String[] args) {
Random ladyLuck = new Random(); // create Random object ladyLuck
        for (int i = 0; i < 10; i++) {
            // Draw and print a random number
            int randomNumber = ladyLuck.nextInt(10);
            System.out.println(randomNumber);
        }
    }
}
Above we create an instance of the Randomclass. It has nextInt method, which gets an integer as a parameter. The method returns a random number between [0, integer[ or 0..(integer -1).
The program output is not always the same. One possible output is the following:
Sample output
2
2
4
3
4
We can use the nextInt method to create diverse randomness. For example, we might need a program to give us a temperature between [-30,50]. We can do this by first creating random a number between 0 and 80 and then subtracting 30 from it.
Random weatherMan = new Random();
int temperature = weatherMan.nextInt(81) - 30;
System.out.println(temperature);
A Random object can also be used to create random doubles. These can for example be used for calculating probabilities. Computers often simulate probabilities using doubles between [0..1].
The nextDouble method of the Random class creates random doubles.
The random.nextGaussian() returns a normally distributed number (normally distributed numbers can be used to for example model the heights and weights of people)

Multidimensional data
We can also create multidimensional arrays. Then we need the indexes of a value in each dimension to access the value. This comes handy when our data is multidimensional, for example when dealing with coordinates.
A two dimensional array with two rows and three columns can be created like so:
int rows = 2;
int columns = 3;
int[][] twoDimensionalArray = new int[rows][columns];
In the array we created above, each row refers to an array with a certain number of columns. We can iterate over a two dimensional array using two nested for loops like so:
int rows = 2;
int columns = 3;
int[][] twoDimensionalArray = new int[rows][columns];
System.out.println("row, column, value");
for (int row = 0; row < twoDimensionalArray.length; row++) {
    for (int column = 0; column < twoDimensionalArray[row].length; column++) {
        int value = twoDimensionalArray[row][column];
        System.out.println("" + row + ", " + column + ", " + value);
    }
}
The program output is as follows:
Sample output
row, column, value
0, 0, 0
0, 1, 0
0, 2, 0
1, 0, 0
1, 1, 0
1, 2, 0
We can see that the default value of variables type int is 0.
We can change the values in the array just like before. Below we set new values to three elements of the array.
int rows = 2;
int columns = 3;
int[][] twoDimensionalArray = new int[rows][columns];
twoDimensionalArray[0][1] = 4;
twoDimensionalArray[1][1] = 1;
twoDimensionalArray[1][0] = 8;
System.out.println("row, column, value");
for (int row = 0; row < twoDimensionalArray.length; row++) {
    for (int column = 0; column < twoDimensionalArray[row].length; column++) {
        int value = twoDimensionalArray[row][column];
        System.out.println("" + row + ", " + column + ", " + value);
    }
}
The program output is as follows:
Sample output
row, column, value
0, 0, 0
1, 0, 4
2, 0, 0
0, 1, 8
1, 1, 1
2, 1, 0