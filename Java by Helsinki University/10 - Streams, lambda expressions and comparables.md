Handling collections as streams
Stream is a way of going through a collection of data such that the programmer determines the operation to be performed on each value. No record is kept of the index or the variable being processed at any given time.
ith streams, the programmer defines a sequence of events that is executed for each value in a collection. An event chain may include dumping some of the values, converting values ​​from one form to another, or calculations. A stream does not change the values ​​in the original data collection, but merely processes them. If you want to retain the transformations, they need to be compiled into another data collection.
Consider the following problem:
Write a program that reads input from a user and prints statistics about those inputs. When the user enters the string "end", the reading is stopped. Other inputs are numbers in string format. When you stop reading inputs, the program prints the number of positive integers divisible by three, and the average of all values.
// We initialise the scanner and the list into which the input is read
Scanner scanner = new Scanner(System.in);
List<String> inputs = new ArrayList<>();
// reading inputs
while (true) {
    String row = scanner.nextLine();
    if (row.equals("end")) {
        break;
    }
    inputs.add(row);
}
// counting the number of values divisible by three
long numbersDivisibleByThree = inputs.stream()
    .mapToInt(s -> Integer.valueOf(s))
    .filter(number -> number % 3 == 0)
    .count();
// working out the average
double average = inputs.stream()
    .mapToInt(s -> Integer.valueOf(s))
    .average()
    .getAsDouble();
// printing out the statistics
System.out.println("Divisible by three " + numbersDivisibleByThree);
System.out.println("Average number: " + average);
Let's take a closer look at the part of the program above where the inputs are dealt as streams.
// counting the number of values divisible by three
long numbersDivisibleByThree = inputs.stream()
    .mapToInt(s -> Integer.valueOf(s))
    .filter(number -> number % 3 == 0)
    .count();
A stream can be formed from any object that implements the Collection interface (e.g., ArrayList, HashSet, HashMap, ...) with the stream() method. The string values ​​are then converted ("mapped") to integer form using the stream's mapToInt(value -> conversion) method. The conversion is implemented by the valueOf method of the Integer class, which we've used in the past. We then use the filter (value -> filter condition) method to filter out only those numbers that are divisible by three for further processing. Finally, we call the stream's count() method, which counts the number of elements in the stream and returns it as a long type variable.
Let's now look at the part of the program that calculates the average of the list elements.
// working out the average
double average = inputs.stream()
    .mapToInt(s -> Integer.valueOf(s))
    .average()
    .getAsDouble();
Calculating the average is possible from a stream that has the mapToInt method called on it. A stream of integers has an average method that returns an OptionalDouble-type object. The object has getAsDouble() method that returns the average of the list values as a double type variable.

Lambda Expressions
Stream values ​​are handled by methods related to streams. Methods that handle values ​​get a function as a parameter that determines what is done with each element. What the function does is specific to the method in question. For instance, the filter method used for filtering elements is provided a function which returns a boolean true or false, depending on whether to keep the value in the stream or not. The mapToInt method used for transformation is, on the other hand, provided a function which converts the value to an integer, and so on.
Why are the functions written in the form value -> value > 5?
The expression above, i.e., a lambda expression, is shorthand provided by Java for anonymous methods that do not have an "owner", i.e., they are not part of a class or an interface. The function contains both the parameter definition and the function body. The same function can be written in several different ways. See below.
// original
*stream*.filter(value -> value > 5).*furtherAction*
// is the same as
*stream*.filter((Integer value) -> {
    if (value > 5) {
        return true;
    }
    return false;
}).*furtherAction*
The same can be written explicitly so that a static method is defined in the program, which gets used within the function passed to the stream as a parameter.
public class Screeners {
    public static boolean greaterThanFive(int value) {
        return value > 5;
    }
}
// original
*stream*.filter(value -> value > 5).*furtherAction*
// is the same as
*stream*.filter(value -> Screeners.greaterThanFive(value)).*furtherAction*
The function can also be passed directly as a parameter. The syntax found below Screeners::greaterThanFive is saying: "use the static greaterThanFive method that's in the Screeners class".
// is the same as
*stream*.filter(Screeners::greaterThanFive).*furtherAction*
Functions that handle stream elements ​​cannot change values ​​of variables outside of the function. This has to do with how static methods behave - during a method call, there is no access to any variables outside of the method. With functions, the values ​​of variables outside the function can be read, assuming that those values of those variables do not change in the program.
The program below demonstrates the situation in which a function attempts to make use of a variable outside the function. It doesn't work.
// initializing a scanner and a list to which values are read
Scanner scanner = new Scanner(System.in);
List<String> inputs = new ArrayList<>()
// reading inputs
while (true) {
    String row = scanner.nextLine();
    if (row.equals("end")) {
        break;
    }
    inputs.add(row);
}
int numberOfMappedValues = 0;
// determining the number of values divisible by three
long numbersDivisibleByThree = inputs.stream()
    .mapToInt(s -> {
        // variables declared outside of an anonymous function cannot be used, so this won't work
        numberOfMappedValues++;
        return Integer.valueOf(s);
    }).filter(value -> value % 3 == 0)
    .count();

Stream Methods
Stream methods can be roughly divided into two categories: (1) intermediate operations intended for processing elements ​​and (2) terminal operations that end the processing of elements. Both of the filter and mapToInt methods shown in the previous example are intermediate operations. Intermediate operations return a value that can be further processed - you could, in practice, have an infinite number of intermediate operations chained sequentially (& separated by a dot). On the other hand, the average method seen in the previous example is a terminal operation. A terminal operation returns a value to be processed, which is formed from, for instance, stream elements.

Terminal Operations
Let's take a look at four terminal operations: the count method for counting the number of values on a list, the forEach method for going a through list values, the collect method for gathering the list values ​​into a data structure, and the reduce method for combining the list items.

The count method informs us of the number of values in the stream as a long-type variable.
List<Integer> values = new ArrayList<>();
values.add(3);
values.add(2);
values.add(17);
values.add(6);
values.add(8);
System.out.println("Values: " + values.stream().count());
Sample output
Values: 5

The forEach method defines what is done to each list value and terminates the stream processing. In the example below, we first create a list of numbers, after which we only print the numbers that are divisible by two.
List<Integer> values = new ArrayList<>();
values.add(3);
values.add(2);
values.add(17);
values.add(6);
values.add(8);
values.stream()
    .filter(value -> value % 2 == 0)
    .forEach(value -> System.out.println(value));
Sample output
2
6
8

You can use the collect method to collect stream values into another collection. The example below creates a new list containing only positive values. The collect method is given as a parameter to the Collectors object to which the stream values ​​are collected - for example, calling Collectors.toCollection(ArrayList::new) creates a new ArrayList object that holds the collected values.
List<Integer> values = new ArrayList<>();
values.add(3);
values.add(2);
values.add(-17);
values.add(-6);
values.add(8);
ArrayList<Integer> positives = values.stream()
    .filter(value -> value > 0)
    .collect(Collectors.toCollection(ArrayList::new));

positives.stream()
    .forEach(value -> System.out.println(value));
Sample output
3
2
8

The reduce method is useful when you want to combine stream elements to some other form. The parameters accepted by the method have the following format: reduce(*initialState*, (*previous*, *object*) -> *actions on the object*).
As an example, you can calculate the sum of an integer list using the reduce method as follows.
ArrayList<Integer> values = new ArrayList<>();
values.add(7);
values.add(3);
values.add(2);
values.add(1);
int sum = values.stream()
    .reduce(0, (previousSum, value) -> previousSum + value);
System.out.println(sum);
Sample output
13
In the same way, we can form a combined row-separated string from a list of strings.
ArrayList<String> words = new ArrayList<>();
words.add("First");
words.add("Second");
words.add("Third");
words.add("Fourth");
String combined = words.stream()
    .reduce("", (previousString, word) -> previousString + word + "\n");
System.out.println(combined);
Sample output
First
Second
Third
Fourth

Intermediate Operations
Intermediate stream operations are methods that return a stream. Since the value returned is a stream, we can call intermediate operations sequentially. Typical intermediate operations include converting a value from one form to another using map and its more specific form mapToInt used for converting a stream to an integer stream. Other ones include filtering values with filter, identifying unique values with distinct, and arranging values with sorted (if possible).
Problem 1: You'll receive a list of persons. Print the number of persons born before the year 1970.
We'll use the filter method for filtering through only those persons who were born before the year 1970. We then count their number using the method count.
// suppose we have a list of persons
// ArrayList<Person> persons = new ArrayList<>();
long count = persons.stream()
    .filter(person -> person.getBirthYear() < 1970)
    .count();
System.out.println("Count: " + count);
Problem 2: You'll receive a list of persons. How many persons' first names start with the letter "A"?
Let's use the filter-method to narrow down the persons to those whose first name starts with the letter "A". Afterwards, we'll calculate the number of persons with the count-method.
// suppose we have a list of persons
// ArrayList<Person> persons = new ArrayList<>();
long count = persons.stream()
    .filter(person -> person.getFirstName().startsWith("A"))
    .count();
System.out.println("Count: " + count);
Problem 3: You'll receive a list of persons. Print the number of unique first names in alphabetical order
First we'll use the map method to change a stream containing person objects into a stream containing first names. After that we'll call the distinct-method, that returns a stream that only contains unique values. Next, we call the method sorted, which sorts the strings. Finally, we call the method forEach, that is used to print the strings.
// suppose we have a list of persons
// ArrayList<Person> persons = new ArrayList<>();
persons.stream()
    .map(person -> person.getFirstName())
    .distinct()
    .sorted()
    .forEach(name -> System.out.println(name));
The distinct-method described above uses the equals-method that is in all objects for comparing whether two strings are the same. The sorted-method on the other hand is able to sort objects that contain some kind of order — examples of this kind of objects are for example numbers and strings.

Files and Streams
Streams are also very handy in handling files. The file is read in stream form using Java's ready-made Files class. The lines method in the files class allows you to create an input stream from a file, allowing you to process the rows one by one. The lines method gets a path as its parameter, which is created using the get method in the Paths class. The get method is provided a string describing the file path.
The example below reads all the lines in "file.txt" and adds them to the list.
List<String> rows = new ArrayList<>();
try {
    Files.lines(Paths.get("file.txt")).forEach(row -> rows.add(row));
} catch (Exception e) {
    System.out.println("Error: " + e.getMessage());
}
// do something with the read lines
If the file is both found and read successfully, the lines of the "file.txt" file will be in the rows list variable at the end of the program. However, if a file cannot be found or read, an error message will be displayed. Below is one possibility:
Sample output
Error: file.txt (No such file or directory)

The Comparable Interface
The Comparable interface defines the compareTo method used to compare objects. If a class implements the Comparable interface, objects created from that class can be sorted using Java's sorting algorithms.
The compareTo method required by the Comparable interface receives as its parameter the object to which the "this" object is compared. If the "this" object comes before the object received as a parameter in terms of sorting order, the method should return a negative number. If, on the other hand, the "this" object comes after the object received as a parameter, the method should return a positive number. Otherwise, 0 is returned. The sorting resulting from the compareTo method is called natural ordering.
Let's take a look at this with the help of a Member class that represents a child or youth who belongs to a club. Each club member has a name and height. The club members should go to eat in order of height, so the Member class should implement the Comparable interface. The Comparable interface takes as its type parameter the class that is the subject of the comparison. We'll use the same Member class as the type parameter.
public class Member implements Comparable<Member> {
    private String name;
    private int height;
    public Member(String name, int height) {
        this.name = name;
        this.height = height;
    }
    public String getName() {
        return this.name;
    }
    public int getHeight() {
        return this.height;
    }
    @Override
    public String toString() {
        return this.getName() + " (" + this.getHeight() + ")";
    }
    @Override
    public int compareTo(Member member) {
        if (this.height == member.getHeight()) {
            return 0;
        } else if (this.height > member.getHeight()) {
            return 1;
        } else {
            return -1;
        }
    }
}
The compareTo method required by the interface returns an integer that informs us of the order of comparison.
As returning a negative number from compareTo() is enough if the this object is smaller than the parameter object, and returning zero is sufficient when the lengths are the same, the compareTo method described above can also be implemented as follows.
@Override
public int compareTo(Member member) {
    return this.height - member.getHeight();
}
Since the Member class implements the Comparable interface, it is possible to sort the list by using the sorted method. In fact, objects of any class that implement the Comparable interface can be sorted using the sorted method. Be aware, however, that a stream does not sort the original list - only the items in the stream are sorted.
If a programmer wants to organize the original list, the sort method of the Collections class should be used. This, of course, assumes that the objects on the list implement the Comparable interface.
Sorting club members is straightforward now.
List<Member> member = new ArrayList<>();
member.add(new Member("mikael", 182));
member.add(new Member("matti", 187));
member.add(new Member("ada", 184));
member.stream().forEach(m -> System.out.println(m));
System.out.println();
// sorting the stream that is to be printed using the sorted method
member.stream().sorted().forEach(m -> System.out.println(m));
member.stream().forEach(m -> System.out.println(m));
// sorting a list with the sort-method of the Collections class
Collections.sort(member);
member.stream().forEach(m -> System.out.println(m));
Sample output
mikael (182)
matti (187)
ada (184)
mikael (182)
ada (184)
matti (187)
mikael (182)
matti (187)
ada (184)
mikael (182)
ada (184)
matti (187)

Implementing Multiple Interfaces
A class can implement multiple interfaces. Multiple interfaces are implemented by separating the implemented interfaces with commas (public class ... implements *FirstInterface*, *SecondInterface* ...). Implementing multiple interfaces requires us to implement all of the methods for which implementations are required by the interfaces.

Sorting with lambda expressions
Both the sort method of the Collections class and the stream's sorted method accept a lambda expression as a parameter that defines the sorting criteria. More specifically, both methods can be provided with an object that implements the Comparator interface, which defines the desired order - the lambda expression is used to create this object.
ArrayList<Person> persons = new ArrayList<>();
persons.add(new Person("Ada Lovelace", 1815));
persons.add(new Person("Irma Wyman", 1928));
persons.add(new Person("Grace Hopper", 1906));
persons.add(new Person("Mary Coombs", 1929));
persons.stream().sorted((p1, p2) -> {
    return p1.getBirthYear() - p2.getBirthYear();
}).forEach(p -> System.out.println(p.getName()));
System.out.println();
persons.stream().forEach(p -> System.out.println(p.getName()));
System.out.println();
Collections.sort(persons, (p1, p2) -> p1.getBirthYear() - p2.getBirthYear());
persons.stream().forEach(p -> System.out.println(p.getName()));
Sample output
Ada Lovelace
Grace Hopper
Irma Wyman
Mary Coombs
Ada Lovelace
Irma Wyman
Grace Hopper
Mary Coombs
Ada Lovelace
Grace Hopper
Irma Wyman
Mary Coombs
When comparing strings, we can use the compareTo method provided by the String class. The method returns an integer that describes the order of both the string given to it as a parameter and the string that's calling it.
ArrayList<Person> persons = new ArrayList<>();
persons.add(new Person("Ada Lovelace", 1815));
persons.add(new Person("Irma Wyman", 1928));
persons.add(new Person("Grace Hopper", 1906));
persons.add(new Person("Mary Coombs", 1929));
persons.stream().sorted((p1, p2) -> {
    return p1.getName().compareTo(p2.getName());
}).forEach(p -> System.out.println(p.getName()));
Sample output
Ada Lovelace
Grace Hopper
Irma Wyman
Mary Coombs

Sorting By Multiple Criteria
We sometimes want to sort items based on a number of things. Let's look at an example in which films are listed in order of their name and year of release. We'll make use of Java's Comparator class here, which offers us the functionality required for sorting. Let's assume that we have the class Film at our disposal.
public class Film {
    private String name;
    private int releaseYear;
    public Film(String name, int releaseYear) {
        this.name = name;
        this.releaseYear = releaseYear;
    }
    public String getName() {
        return this.name;
    }
    public int getReleaseYear() {
        return this.releaseYear;
    }
    public String toString() {
        return this.name + " (" + this.releaseYear + ")";
    }
}
The Comparator class provides two essential methods for sorting: comparing and thenComparing. The comparing method is passed the value to be compared first, and the thenComparing method is the next value to be compared. The thenComparing method can be used many times by chaining methods, which allows virtually unlimited values ​​to be used for comparison.
When we sort objects, the comparing and thenComparing methods are given a reference to the object's type - the method is called in order and the values ​​returned by the method are compared. The method reference is given as Class::method. In the example below, we print movies by year and title in order.
List<Film> films = new ArrayList<>();
films.add(new Film("A", 2000));
films.add(new Film("B", 1999));
films.add(new Film("C", 2001));
films.add(new Film("D", 2000));
for (Film e: films) {
    System.out.println(e);
}
Comparator<Film> comparator = Comparator
              .comparing(Film::getReleaseYear)
              .thenComparing(Film::getName);
Collections.sort(films, comparator);
for (Film e: films) {
    System.out.println(e);
}
Sample output
A (2000)
B (1999)
C (2001)
D (2000)
B (1999)
A (2000)
D (2000)
C (2001)

StringBuilder
Let's look at the following program.
String numbers = "";
for (int i = 1; i < 5; i++) {
    numbers = numbers + i;
}
System.out.println(numbers);
Sample output
1234
The program structure is straightforward. A string containing the number 1234 is created, and the string is then outputted.
The program works, but there is a small problem invisible to the user. Calling numbers + i creates a new string. Let's inspect the program line-by-line with the repetition block unpacked.
String numbers = ""; // creating a new string: ""
int i = 1;
numbers = numbers + i; // creating a new string: "1"
i++;
numbers = numbers + i; // creating a new string: "12"
i++;
numbers = numbers + i; // creating a new string: "123"
i++;
numbers = numbers + i; // creating a new string: "1234"
i++;
System.out.println(numbers); // printing the string
In the previous example, five strings are created in total.
Let's look at the same program where a new line is added after each number.
String numbers = "";
for (int i = 1; i < 5; i++) {
    numbers = numbers + i + "\n";
}
System.out.println(numbers);
Sample output
1
2
3
4
Each +-operation forms a new string. On the line numbers + i + "\n"; a string is first created, after which another string is created joining a new line onto the previous string. Let's write this out as well.
String numbers = ""; // creating a new string: ""
int i = 1;
// first creating the string "1" and then the string "1\n"
numbers = numbers + i + "\n";
i++;
// first creating the string "1\n2" and then the string "1\n2\n"
numbers = numbers + i + "\n"
i++;
// first creating the string "1\n2\n3" and then the string "1\n2\n3\n"
numbers = numbers + i + "\n"
i++;
// and so on
numbers = numbers + i + "\n"
i++;
System.out.println(numbers); // outputting the string
In the previous example, a total of nine strings is created.
String creation - although unnoticeable at a small scale - is not a quick operation. Space is allocated in memory for each string where the string is then placed. If the string is only needed as part of creating a larger string, performance should be improved.
Java's ready-made StringBuilder class provides a way to concatenate strings without the need to create them. A new StringBuilder object is created with a new StringBuilder() call, and content is added to the object using the overloaded append method, i.e., there are variations of it for different types of variables. Finally, the StringBuilder object provides a string using the toString method.
In the example below, only one string is created.
StringBuilder numbers = new StringBuilder();
for (int i = 1; i < 5; i++) {
    numbers.append(i);
}
System.out.println(numbers.toString());
Using StringBuilder is more efficient than creating strings with the + operator.

Regular Expressions
A regular expression defines a set of strings in a compact form. Regular expressions are used, among other things, to verify the correctness of strings. We can assess whether or not a string is in the desired form by using a regular expression that defines the strings considered correct.
Let's look at a problem where we need to check if a student number entered by the user is in the correct format. A student number should begin with "01" followed by 7 digits between 0–9.
You could verify the format of the student number, for instance, by going through the character string representing the student number using the charAt method. Another way would be to check that the first character is "0" and call the Integer.valueOf method to convert the string to a number. You could then check that the number returned by the Integer.valueOf method is less than 20000000.
Checking correctness with the help of regular expressions is done by first defining a suitable regular expression. We can then use the matches method of the String class, which checks whether the string matches the regular expression given as a parameter. For the student number, the appropriate regular expression is "01[0-9]{7}", and checking the student number entered by a user is done as follows:
System.out.print("Provide a student number: ");
String number = scanner.nextLine();
if (number.matches("01[0-9]{7}")) {
    System.out.println("Correct format.");
} else {
    System.out.println("Incorrect format.");
}
Let's go through the most common characters used in regular expressions.
Alternation (Vertical Line)
A vertical line indicates that parts of a regular expressions are optional. For example, 00|111|0000 defines the strings 00, 111 and 0000. The respond method returns true if the string matches any one of the specified group of alternatives.
String string = "00";
if (string.matches("00|111|0000")) {
    System.out.println("The string contained one of the three alternatives");
} else {
    System.out.println("The string contained none of the alternatives");
}
Sample output
The string contained one of the three alternatives
The regular expression 00|111|0000 demands that the string is exactly it specifies it to be - there is no "contains" functionality.
String string = "1111";
if (string.matches("00|111|0000")) {
    System.out.println("The string contained one of the three alternatives");
} else {
    System.out.println("The string contained none of the three alternatives");
}
Sample output
The string contained none of the three alternatives
Affecting Part of a String (Parentheses)
You can use parentheses to determine which part of a regular expression is affected by the rules inside the parentheses. Say we want to allow the strings 00000 and 00001. We can do that by placing a vertical bar in between them this way 00000|00001. Parentheses allow us to limit the option to a specific part of the string. The expression 0000(0|1) specifies the strings 00000 and 00001.
Similarly, the regular expression car(|s|) defines the singular (car) and plural (cars) forms of the word car.
Quantifiers
What is often desired is that a particular sub-string is repeated in a string. The following expressions are available in regular expressions:
The quantifier * repeats 0 ... times, for example;
String string = "trolololololo";
if (string.matches("trolo(lo)*")) {
    System.out.println("Correct form.");
} else {
    System.out.println("Incorrect form.");
}
Sample output
Correct form.
The quantifier + repeats 1 ... times, for example;
String string = "trolololololo";
if (string.matches("tro(lo)+")) {
    System.out.println("Correct form.");
} else {
    System.out.println("Incorrect form.");
}
Sample output
Correct form.
String string = "nananananananana Batmaan!";
if (string.matches("(na)+ Batmaan!")) {
    System.out.println("Correct form.");
} else {
    System.out.println("Incorrect form.");
}
Sample output
Correct form.
The quantifier ? repeats 0 or 1 times, for example:
String string = "You have to accidentally the whole meme";
if (string.matches("You have to accidentally (delete )?the whole meme")) {
    System.out.println("Correct form.");
} else {
    System.out.println("Incorrect form.");
}
Sample output
Correct form.
The quantifier {a} repeats a times, for example:
String string = "1010";
if (string.matches("(10){2}")) {
    System.out.println("Correct form.");
} else {
    System.out.println("Incorrect form.");
}
Sample output
Correct form.
The quantifier {a,b} repeats a ... b times, for example:
String string = "1";

if (string.matches("1{2,4}")) {
    System.out.println("Correct form.");
} else {
    System.out.println("Incorrect form.");
}
Sample output
Incorrect form.
The quantifier {a,} repeats a ... times, for example:
String string = "11111";

if (string.matches("1{2,}")) {
    System.out.println("Correct form.");
} else {
    System.out.println("Incorrect form.");
}
Sample output
Correct form.
You can use more than one quantifier in a single regular expression. For example, the regular expression 5{3}(1|0)*5{3} defines strings that begin and end with three fives. An unlimited number of ones and zeros are allowed in between.
Character Classes (Square Brackets)
A character class can be used to specify a set of characters in a compact way. Characters are enclosed in square brackets, and a range is indicated with a dash. For example, [145] means (1|4|5) and [2-36-9] means (2|3|6|7|8|9). Similarly, the entry [a-c]* defines a regular expression that requires the string to contain only a, b and c.

Enumerated Type - Enum
If we know the possible values ​​of a variable in advance, we can use a class of type enum, i.e., enumerated type to represent the values. Enumerated types are their own type in addition to being normal classes and interfaces. An enumerated type is defined by the keyword enum. For example, the following Suit enum class defines four constant values: DIAMOND, SPADE, CLUB and HEART.
public enum Suit {
    DIAMOND, SPADE, CLUB, HEART
}
In its simplest form, enum lists the constant values ​​it declares, separated by a comma. Enum types, i.e., constants, are conventionally written with capital letters.
An Enum is (usually) written in its own file, much like a class or interface. In NetBeans, you can create an Enum by selecting new/other/java/java enum from project.
The following is a Card class where the suit is represented by an enum:
public class Card {
    private int value;
    private Suit suit;
    public Card(int value, Suit suit) {
        this.value = value;
        this.suit = suit;
    }
    @Override
    public String toString() {
        return suit + " " + value;
    }
    public Suit getSuit() {
        return suit;
    }
    public int getValue() {
        return value;
    }
}
The card is used in the following way:
Card first = new Card(10, Suit.HEART);
System.out.println(first);
if (first.getSuit() == Suit.SPADE) {
    System.out.println("is a spade");
} else {
    System.out.println("is not a spade");
}
The output:
Sample output
HEARTS 10
is not a spade
Comparing Enums
In the example above, two enums were compared with equal signs. How does this work?
Each enum field gets a unique number code, and they can be compared using the equals sign. Just as other classes in Java, these values also inherit the Object class and its equals method. The equals method compares this numeric identifier in enum types too.
The numeric identifier of an enum field value can be found with ordinal(). The method actually returns an order number - if the enum value is presented first, its order number is 0. If its second, the order number is 1, and so on.
public enum Suits {
    DIAMOND, CLUB, HEART, SPADE
}
System.out.println(Suit.DIAMOND.ordinal());
System.out.println(Suit.HEART.ordinal());
Sample output
0
3
Object References In Enums
Enumerated types may contain object reference variables. The values ​​of the reference variables should be set in an internal constructor of the class defining the enumerated type, i.e., within a constructor having a private access modifier. Enum type classes cannot have a public constructor.
In the following example, we have an enum Color that contains the constants ​​RED, GREEN and BLUE. The constants have been declared with object reference variables referring to their color codes:
public enum Color {
    // constructor parameters are defined as
    // the constants are enumerated
    RED("#FF0000"),
    GREEN("#00FF00"),
    BLUE("#0000FF");
    private String code;        // object reference variable
    private Color(String code) { // constructor
        this.code = code;
    }
    public String getCode() {
        return this.code;
    }
}
The enum Color can be used like so:
System.out.println(Color.GREEN.getCode());
Sample output
#00FF00

Iterator
Let's look at the following Hand class that represents the set of cards that a player is holding:
public class Hand {
    private List<Card> cards;
    public Hand() {
        this.cards = new ArrayList<>();
    }
    public void add(Card card) {
        this.cards.add(card);
    }
    public void print() {
        this.cards.stream().forEach(card -> {
            System.out.println(card);
        });
    }
}
The print method of the class prints each card in the current hand.
ArrayList and other "object containers" that implement the Collection interface implement the Iterable interface, and they can also be iterated over with the help of an iterator - an object specifically designed to go through a particular type of object collection. The following is a version of printing the cards that uses an iterator:
public void print() {
    Iterator<Card> iterator = cards.iterator();
    while (iterator.hasNext()) {
        System.out.println(iterator.next());
    }
}
The iterator is requested from the cards list containing cards. The iterator can be thought of as a "finger" that always points to a particular object inside the list. Initially it points to the first item, then to the next, and so on... until all the objects have been gone through with the help of the "finger".
The iterator offers a few methods. The hasNext() method is used to ask if there are any objects still to be iterated over. If there are, the next object in line can be requested from the iterator using the next() method. This method returns the next object in line to be processed and moves the iterator, or "finger", to point to the following object in the collection.
The object reference returned by the iterator's next method can of course also be stored in a variable. As such, the print method could also be written in the following way.
public void print(){
    Iterator<Card> iterator = cards.iterator();
    while (iterator.hasNext()) {
        Card nextInLine = iterator.next();
        System.out.println(nextInLine);
    }
}
Let's now consider a use case for an iterator. We'll first approach the issue problematically to provide motivation for the coming solution. We attempt to create a method that removes cards from a given stream with a value lower than the given value.
public class Hand {
    // ...
    public void removeWorst(int value) {
        this.cards.stream().forEach(card -> {
            if (card.getValue() < value) {
                cards.remove(card);
            }
        });
    }
}
Executing the method results in an error.
Sample output
Exception in thread "main" java.util.ConcurrentModificationException
at ...
Java Result: 1
The reason for this error lies in the fact that when a list is iterated over using the forEach method, it's assumed that the list is not modified during the traversal. Modifying the list (in this case deleting elements) causes an error - we can think of the forEach method as getting "confused" here.
If you want to remove some of the objects from the list during a traversal, you can do so using an iterator. Calling the remove method of the iterator object neatly removes form the list the item returned by the iterator with the previous next call. Here's a working example of the version of the method:
public class Hand {
    // ...
    public void removeWorst(int value) {
        Iterator<Card> iterator = cards.iterator();
        while (iterator.hasNext()) {
            if (iterator.next().getValue() < value) {
                // removing from the list the element returned by the previous next-method call
                iterator.remove();
            }
        }
    }
}

Alternative sorting systems
Alternative sorting systems are possible through different sorting classes. Such a class must have the Comparator<Card> interface. An object of the sorting class will then compare two cards give as parameters. The class only has one method, compare(Card c1, Card c2), which returns a negative value if the card c1 should be sorted before card c2, a positive value if card c2 comes before card c1, and zero if they are equal.
The idea is to create a different sorting class for each different way of sorting the cards, e.g. cards of the same suit in a row.:
import java.util.Comparator;
public class SortBySuit implements Comparator<Card> {
    public int compare(Card c1, Card c2) {
        return c1.getSuit().ordinal() - c2.getSuit().ordinal();
    }
}
When sorting the cards by suit, use the same order as with the compareTo method: clubs first, diamonds second, hearts third, spades last.
Sorting still works with the sort method of Collections class. As its other parameter, the method now receives the object that has the sorting logic.
ArrayList<Card> cards = new ArrayList<>();
cards.add(new Card(3, Suit.SPADE));
cards.add(new Card(2, Suit.DIAMOND));
cards.add(new Card(14, Suit.SPADE));
cards.add(new Card(12, Suit.HEART));
cards.add(new Card(2, Suit.SPADE));
SortBySuit sortBySuitSorter = new SortBySuit();
Collections.sort(cards, sortBySuitSorter);
cards.stream().forEach(c -> System.out.println(c));
Output:
Sample output
DIAMOND 2
HEART Q
SPADE 3
SPADE A
SPADE 2
The sorting object can also be created directly when sort method is called.
Collections.sort(cards, new SortBySuit());
It can even be done with a lambda function, without ever creating the sorting class.
Collections.sort(cards, (c1, c2) -> c1.getSuit().ordinal() - c2.getSuit().ordinal());