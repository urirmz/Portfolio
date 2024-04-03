Hashmap
A HashMap is, in addition to ArrayList, one of the most widely used of Java's pre-built data structures. The hash map is used whenever data is stored as key-value pairs, where values can be added, retrieved, and deleted using keys.
In the example below, a HashMap object has been created to search for cities by their postal codes, after which four postal code-city pairs have been added to the HashMap object. At the end, the postal code "00710" is retrieved from the hash map. Both the postal code and the city are represented as strings.
HashMap<String, String> postalCodes = new HashMap<>();
postalCodes.put("00710", "Helsinki");
postalCodes.put("90014", "Oulu");
postalCodes.put("33720", "Tampere");
postalCodes.put("33014", "Tampere");
System.out.println(postalCodes.get("00710"));
Sample output
Helsinki
If the hash map does not contained the key used for the search, its get method returns a null reference.

Using hashmaps
Using a hash map requires the import java.util.HashMap; statement at the beginning of the class.
Two type parameters are required when creating a hash map - the type of the key and the type of the value added. If the keys of the hash map are of type string, and the values of type integer, the hash map is created with the following statement HashMap<String, Integer> hashmap = new HashMap<>();
Adding to the hash map is done through the put(*key*, *value*) method that has two parameters, one for the key, the other for the value. Retrieving from a hash map happens with the help of the get(*key*) method that is passed the key as a parameter and returns a value.

Hash Map Keys Correspond to a Single Value at Most
The hash map has a maximum of one value per key. If a new key-value pair is added to the hash map, but the key has already been associated with some other value stored in the hash map, the old value will vanish from the hash map.

A Reference Type Variable as a Hash Map Value
Let's take a look at how a spreadsheet works using a library example. You can search for books by book title. If a book is found with the given search term, the library returns a reference to the book.
Let's create a hash map that uses the book's name as a key, i.e., a String-type object, and the book we've just created as the value.
HashMap<String, Book> directory = new HashMap<>();
The hash map above uses aString object as a key. Let's expand the example so that two books are added to the directory, "Sense and Sensibility" and "Pride and Prejudice".
Book senseAndSensibility = new Book("Sense and Sensibility", 1811, "...");
Book prideAndPrejudice = new Book("Pride and Prejudice", 1813, "....");
HashMap<String, Book> directory = new HashMap<>();
directory.put(senseAndSensibility.getName(), senseAndSensibility);
directory.put(prideAndPrejudice.getName(), prideAndPrejudice);
Books can be retrieved from the directory by book name. A search for "Persuasion" will not produce any results, in which case the hash map returns a null-reference. The book "Pride and Prejudice" is found, however.
Book book = directory.get("Persuasion");
System.out.println(book);
System.out.println();
book = directory.get("Pride and Prejudice");
System.out.println(book);
Sample output
null
Name: Pride and Prejudice (1813)
Content: ...

When Should Hash Maps Be Used?
The hash map is implemented internally in such a way that searching by a key is very fast. The hash map generates a "hash value" from the key, i.e. a piece of code, which is used to store the value of a specific location. When a key is used to retrieve information from a hash map, this particular code identifies the location where the value associated with the key is. In practice, it's not necessary to go through all the key-value pairs in the hash map when searching for a key; the set that's checked is significantly smaller.
When a book is searched for in a list, the worst-case scenario involves going through all the books in the list. In a hash map, it isn't necessary to check all of the books as the key determines the location of a given book in a hash map. The difference in performance depends on the number of books - for example, the performance differences are negligible for 10 books. However, for millions of books, the performance differences are clearly visible. The difference in performance in our example is over a thousandfold.
Does this mean that we'll only be using hash maps going forward? Of course not. Hash maps work well when we know exactly what we are looking for. If we wanted to identify books whose title contains a particular string, the hash map would be of little use.
The hash maps also have no internal order, and it is not possible to search the hash map based on the indexes. The items in a list are in the order they were added to the list.
Typically, hash maps and lists are used together. The hash map provides quick access to a specific key or keys, while the list is used, for instance, to maintain order.
The implementation of hashmaps does not guarantee the order of the objects in it.

Hash Map as an Instance Variable
The example considered above on storing books is problematic in that the book's spelling format must be remembered accurately.
 Since we want to allow for minor misspellings, such as capitalized or lower-cased strings, or ones with spaces at the beginning and/or end, the key - the title of the book - is converted to lowercase, and spaces at the beginning and end are removed
public class Library {
    private HashMap<String, Book> directory;
    public Library() {
        this.directory = new HashMap<>();
    }
    public void addBook(Book book) {
        String name = book.getName()
        if (name == null) {
            name = "";
        }
        name = name.toLowerCase();
        name = name.trim();
        if (this.directory.containsKey(name)) {
            System.out.println("Book is already in the library!");
        } else {
            directory.put(name, book);
        }
    }
}
The containsKey method of the hash map is being used above to check for the existence of a key. The method returns true if any value has been added to the hash map with the given key. Otherwise, the method returns false.

Going Through A Hash Map's Keys
We may sometimes want to search for a book by a part of its title. The get method in the hash map is not applicable in this case as it's used to search by a specific key. Searching by a part of a book title is not possible with it.
We can go through the values ​​of a hash map by using a for-each loop on the set returned by the keySet() method of the hash map.
Below, a search is performed for all the books whose names contain the given string.
public ArrayList<Book> getBookByPart(String titlePart) {
    titlePart = sanitizedString(titlePart);
    ArrayList<Book> books = new ArrayList<>();
    for(String bookTitle : this.directory.keySet()) {
        if(!bookTitle.contains(titlePart)) {
            continue;
        }
        // if the key contains the given string
        // we retrieve the value related to it
        // and add it tot the set of books to be returned
        books.add(this.directory.get(bookTitle));
    }
    return books;
}
This way, however, we lose the speed advantage that comes with the hash map. The hash map is implemented in such a way that searching by a single key is extremely fast. The example above goes through all the book titles when looking for the existence of a single book using a particular key.

Going Through A Hash map's Values
The preceding functionality could also be implemented by going through the hash map's values. The set of values can be retrieved with the hash map's values​​() method. This set of values can also be iterated over ​​with a for-each loop.
public ArrayList<Book> getBookByPart(String titlePart) {
    titlePart = sanitizedString(titlePart);
    ArrayList<Book> books = new ArrayList<>();
    for(Book book : this.directory.values()) {
        if(!book.getName().contains(titlePart)) {
            continue;
        }
        books.add(book);
    }
    return books;
}
As with the previous example, the speed advantage that comes with the hash map is lost.

Primitive Variables In Hash Maps
A hash map expects that only reference-variables are added to it (in the same way that ArrayList does). Java converts primitive variables to their corresponding reference-types when using any Java's built in data structures (such as ArrayList and HashMap). Although the value 1 can be represented as a value of the primitive int variable, its type should be defined as Integer when using ArrayLists and HashMaps.

HashMap<Integer, String> hashmap = new HashMap<>(); // works
hashmap.put(1, "Ole!");
HashMap<int, String> map2 = new HashMap<>(); // doesn't work
A hash map's key and the object to be stored are always reference-type variables. If you want to use a primitive variable as a key or value, there exists a reference-type version for each one. A few have been introduced below.
Primitive	Reference-type Equivalent
int     	Integer
double	    Double
char	    Character
Java converts primitive variables to reference-types automatically as they are added to either a HashMap or an ArrayList. This automatic conversion to a reference-type variable is termed auto-boxing in Java, i.e. putting something in a box automatically. The automatic conversion is also possible in the other direction.
int key = 2;
HashMap<Integer, Integer> hashmap = new HashMap<>();
hashmap.put(key, 10);
int value = hashmap.get(key);
System.out.println(value);
Sample output
  10
The following examples describes a class used for counting the number of vehicle number-plate sightings. Automatic type conversion takes place in the addSighting and timesSighted methods.
public class registerSightingCounter {
    private HashMap<String, Integer> allSightings;
    public registerSightingCounter() {
        this.allSightings = new HashMap<>();
    }
    public void addSighting(String sighted) {
        if (!this.allSightings.containsKey(sighted)) {
            this.allSightings.put(sighted, 0);
        }
        int timesSighted = this.allSightings.get(sighted);
        timesSighted++;
        this.allSightings.put(sighted, timesSighted);
    }
    public int timesSighted(String sighted) {
        return this.allSightings.get(sighted);
    }
}
There is, however, some risk in type conversions. If we attempt to convert a null reference - a sighting not in HashMap, for instance - to an integer, we witness a java.lang.reflect.InvocationTargetException error. Such an error may occur in the timesSighted method in the example above - if the allSightings hash map does not contain the value being searched, it returns a null reference and the conversion to an integer fails.
When performing automatic conversion, we should ensure that the value to be converted is not null. For example, the timesSighted method in the program program should be fixed in the following way. ->
public int timesSighted(String sighted) {
    return this.allSightings.getOrDefault(sighted, 0);
}
The getOrDefault method of the HashMap searches for the key passed to it as a parameter from the HashMap. If the key is not found, it returns the value of the second parameter passed to it. The one-liner shown above is equivalent in its function to the following.
public int timesSighted(String sighted) {
    if (this.allSightings.containsKey(sighted)) {
        return this.allSightings.get(sighted);
    }
    return 0;
}

Method to Test For Equality - "equals"
The equals method checks by default whether the object given as a parameter has the same reference as the object it is being compared to. In other words, the default behaviour checks whether the two objects are the same. If the reference is the same, the method returns true, and false otherwise.
This can be illustrated with the following example. The Book class does not have its own implementation of the equals method, so it falls back on the default implementation provided by Java.
Book bookObject = new Book("Book object", 2000, "...");
Book anotherBookObject = bookObject;
if (bookObject.equals(anotherBookObject)) {
    System.out.println("The books are the same");
} else {
    System.out.println("The books aren't the same");
}
// we now create an object with the same content that's nonetheless its own object
anotherBookObject = new Book("Book object", 2000, "...");
if (bookObject.equals(anotherBookObject)) {
    System.out.println("The books are the same");
} else {
    System.out.println("The books aren't the same");
}
Sample output
The books are the same
The books aren't the same
If we want to compare our own classes using the equals method, then it must be defined inside the class. The method created accepts an Object-type reference as a parameter, which can be any object. The comparison first looks at the references. This is followed by checking the parameter object's type with the instanceof operation - if the object type does not match the type of our class, the object cannot be the same. We then create a version of the object that is of the same type as our class, after which the object variables are compared against each other.
public boolean equals(Object comparedObject) {
    // if the variables are located in the same place, they're the same
    if (this == comparedObject) {
        return true;
    }
   // if comparedObject is not of type Book, the objects aren't the same
   if (!(comparedObject instanceof Book)) {
        return false;
    }
    // let's convert the object to a Book
    Book comparedBook = (Book) comparedObject;
    // if the instance variables of the objects are the same, so are the objects
    if (this.name.equals(comparedBook.name) &&
        this.published == comparedBook.published &&
        this.content.equals(comparedBook.content)) {
        return true;
    }
    // otherwise, the objects aren't the same
    return false;
}
This reliance on default methods such as equals is actually the reason why Java demands that variables added to ArrayList and HashMap are of reference type. Each reference type variable comes with default methods, such as equals, which means that you don't need to change the internal implementation of the ArrayList class when adding variables of different types. Primitive variables do not have such default methods.

Approximate Comparison With HashMap
In addition to equals, the hashCode method can also be used for approximate comparison of objects. The method creates from the object a "hash code", i.e, a number, that tells a bit about the object's content. If two objects have the same hash value, they may be equal. On the other hand, if two objects have different hash values, they are certainly unequal.
Hash codes are used in HashMaps, for instance. HashMap's internal behavior is based on the fact that key-value pairs are stored in an array of lists based on the key's hash value. Each array index points to a list. The hash value identifies the array index, whereby the list located at the array index is traversed. The value associated with the key will be returned if, and only if, the exact same value is found in the list (equality comparison is done using the equals method). This way, the search only needs to consider a fraction of the keys stored in the hash map.
So far, we've only used String and Integer-type objects as HashMap keys, which have conveniently had ready-made hashCode methods implemented. Let's create an example where this is not the case: we'll continue with the books and keep track of the books that are on loan. We'll implement the book keeping with a HashMap. The key is the book and the value attached to the book is a string that tells the borrower's name:
HashMap<Book, String> borrowers = new HashMap<>();
Book bookObject = new Book("Book Object", 2000, "...");
borrowers.put(bookObject, "Pekka");
borrowers.put(new Book("Test Driven Development", 1999, "..."), "Arto");
System.out.println(borrowers.get(bookObject));
System.out.println(borrowers.get(new Book("Book Object", 2000, "...")));
System.out.println(borrowers.get(new Book("Test Driven Development", 1999, "...")));
Sample output
Pekka
null
null
We find the borrower when searching for the same object that was given as a key to the hash map's put method. However, when searching by the exact same book but with a different object, a borrower isn't found, and we get the null reference instead. The reason lies in the default implementation of the hashCode method in the Object class. The default implementation creates a hashCode value based on the object's reference, which means that books having the same content that are nonetheless different objects get different results from the hashCode method. As such, the object is not being searched for in the right place.
For the HashMap to work in the way we want it to, that is, to return the borrower when given an object with the correct content (not necessarily the same object as the original key), the class that the key belongs to must overwrite the hashCode method in addition to the equals method. The method must be overwritten so that it gives the same numerical result for all objects with the same content. Also, some objects with different contents may get the same result from the hashCode method. However, with the HashMap's performance in mind, it is essential that objects with different contents get the same hash value as rarely as possible.
We've previously used String objects as HashMap keys, so we can deduce that the String class has a well-functioning hashCode implementation of its own. We'll delegate, i.e., transfer the computational responsibility to the String object.
public int hashCode() {
    return this.name.hashCode();
}
The above solution is quite good. However, if name is null, we see a NullPointerException error. Let's fix this by defining a condition: if the value of the name variable is null, we'll return the year of publication as the hash value.
public int hashCode() {
    if (this.name == null) {
        return this.published;
    }

    return this.name.hashCode();
}
Now, all of the books that share a name are bundled into one group. Let's improve it further so that the year of publication is also taken into account in the hash value calculation that's based on the book title.
public int hashCode() {
    if (this.name == null) {
        return this.published;
    }

    return this.published + this.name.hashCode();
}
It's now possible to use the book as the hash map's key. This way the problem we faced earlier gets solved and the book borrowers are found:
HashMap<Book, String> borrowers = new HashMap<>();
Book bookObject = new Book("Book Object", 2000, "...");
borrowers.put(bookObject, "Pekka");
borrowers.put(new Book("Test Driven Development",1999, "..."), "Arto");
System.out.println(borrowers.get(bookObject));
System.out.println(borrowers.get(new Book("Book Object", 2000, "...")));
System.out.println(borrowers.get(new Book("Test Driven Development", 1999)));
Output:
Sample output
Pekka
Pekka
Arto

Grouping data using hash maps
A hash map has at most one value per each key. In the following example, we store the phone numbers of people into the hash map.
HashMap<String, String> phoneNumbers = new HashMap<>();
phoneNumbers.put("Pekka", "040-12348765");
System.out.println("Pekka's Number " + phoneNumbers.get("Pekka"));
phoneNumbers.put("Pekka", "09-111333");
System.out.println("Pekka's Number " + phoneNumbers.get("Pekka"));
Sample output
Pekka's number: 040-12348765
Pekka's number: 09-111333
What if we wanted to assign multiple values ​​to a single key, such as multiple phone numbers for a given person?
Since keys and values ​​in a hash map can be any variable, it is also possible to use lists as values in a hash map. You can add more values ​​to a single key by attaching a list to the key. Let's change the way the numbers are stored in the following way:
HashMap<String, ArrayList<String>> phoneNumbers = new HashMap<>();
Each key of the hash map now has a list attached to it. Although the new command creates a hash map, the hash map initially does not contain a single list. They need to be created separately as needed.
HashMap<String, ArrayList<String>> phoneNumbers = new HashMap<>();
// let's initially attatch an empty list to the name Pekka
phoneNumbers.put("Pekka", new ArrayList<>());
// and add a phone number to the list at Pekka
phoneNumbers.get("Pekka").add("040-12348765");
// and let's add another phone number
phoneNumbers.get("Pekka").add("09-111333");
System.out.println("Pekka's numbers: " + phoneNumbers.get("Pekka"));
Sample output
Pekka's number: [040-12348765, 09-111333]
We define the type of the phone number as HashMap<String, ArrayList<String>>. This refers to a hash map that uses a string as a key and a list containing strings as its value. As such, the values added to the hash map are concrete lists.
// let's first add an empty ArrayList as the value of Pekka
phoneNumbers.put("Pekka", new  ArrayList<>());
// ...