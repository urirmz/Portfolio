Collections vs Arrays
  Collections are dynamic size, while arrays are always fixed size
  Collections can work just with reference types, while arrays can work with both primitive and reference types
  Arrays have better performance

Collections 
  The java.util.Collections class contains only static methods for working with collections    
    sort(), binarySearch(), reverse(), shuffle(), swap(), fill(), copy(), max()
    min(), swap(), stream(), unmodifiable...(), synchronized...()
  
Collection interface 
  Contains the following methods
    size(), isEmpty(), contains(), toArray(), add(), remove(), containsAll(), addAll(), removeAll(), 
    retainAll(), clear(), equals(), hashCode()
    It implements the Iterable interface, which contains the iterator() method
  The main interfaces that inherit the Collection interface are
    List interface
      Contains the following methods
        get(), set(), add(), indexOf(), lastIndexOf(), listIterator(), sublist(), replaceAll(), sort()
      Its main implementations are
        ArrayList
          Uses an internal array to hold objects
          Default capacity is 10. When full, a new ArrayList is created and objects copied to the new list
          It's main advantage is that allows to return objects in O(1) when using an index
        Vector
          Similar to an ArrayList, the only difference is that all vector methods are synchronized, meaning it is multithread safe
        Stack
          Extends vector, but contains all the methods from the Queue
          It is used to implement a LIFO (Last In, First Out)
          It is deprecated, but kept to maintain backwards compatibility
        LinkedList
          Consist on multiple objects of Node type. Always contains the reference to first and last nodes
          It is double linked, which means each node of the list contains a reference to next and previous nodes
          It is also one of the most popular implementations of the Queue interface
          It's main advantage is that allows to insert, delete and return objects in O(1) from head and tail
    Set interface
      Doesn't introduce any new method
      Contains only unique objects
      Assigns an index using the hashCode() method, this is the reason why members appear to be unordered when added to a set,
        then checks for uniqueness based on the equals() method
      Its main implementations are
        EnumSet
          uses an array of bits to store values ​​(bit vector), which allows for high compactness and efficiency
          The data structure stores objects of only one Enum type, which is specified when an EnumSet instance is created
          All basic operations are performed in constant time (O(1)) and are generally somewhat faster (though not guaranteed) than their       
            counterparts in the HashSet implementation
          Iteration over the EnumSet is carried out according to the order in which the enumeration elements are declared
        HashSet
          Uses a HashMap behind scenes
        LinkedHashSet
          Has a predictable order, because each element has a reference to the previous and next element
          The elements of the list are ordered according to their insertion order,
            unlike LinkedHashMap, LinkedHashSet doesn't support access order
        TreeSet
          When an object is inserted, it's automatically sorted in descending order, following a tree structure
          Does not allow duplicates according to the comparator’s logic, for example
            if comparing two Person by age then name, and the comparator finds that the age is the same as the existing in the set 
            and also the name is the same, this element is considered a duplicate and is not added to the set
    Queue interface      
      Helps to implement LIFO (Last In, First Out) and FIFO (First In, First Out)
        LIFO is commonly used for queues
        FIFO is commonly used for undo operations, history
      Contains the following methods
        add() 
          Adds an element to the end to the queue
          Throws an exception if operation exceeds capacity restrictions
        offer() 
          Adds an element to the end to the queue and returns true
          Returns false if operation exceeds capacity restrictions
        remove() 
          Retrieves and removes the first element of this queue
          Throws an exception if this queue is empty 
        poll()
          Retrieves, but does not remove, the head of this queue, 
          Returns null if this queue is empty
        element()
          Retrieves, but does not remove, the head of this queue
          Throws an exception if this queue is empty
        peek()
          Retrieves, but does not remove, the head of this queue 
          Returns null if this queue is empty
      Its main implementations are
        ArrayDeque
        LinkedList
        PriorityQueue
          Automatically orders the elements added to it
          The order is based in the comparator of the class if it implements the comparable interface,
            or can be provided as a class or lambda function
      Deque interface 
        Implements Queue and Iterable interfaces, and also contains the stack methods
        Contains the additional methods
          addFirst(), addLast(), offerFirst(), offerLast(), removeFirst(), removeLast(), pollFirst(), pollLast(),
          getFirst(), getLast(), peekFirst(), peekLast(), removeFirstOcurrence(), removeLastOcurrence()

Map interface
  Map doesn't belong to Collection interface because some methods of the Collection interface cannot be used in Map
  Allows key-value pairs, called entries, where all keys must be unique
  Includes the inner class Map.Entry
  Assigns an index using the keys hashCode() method, 
    this is the reason why members appear to be unordered when added to a Map
  Uniqueness check is based on the equals() method,
    so key must be Object type, not primitive
  Contains the methods
    size(), isEmpty(), containsKey(), containsValue(), get(), put(), putAll(),
    remove(), putAll(), clear(), keySet(), values(), entrySet(), getOrDefault(),
    putIfAbsent(), replace(), computeIfAbsent(), compute(), merge()
  Its main implementations are
    HashMap
      One null key is allowed and null values are also allowed
      Accepts an initial capacity (default is 16)
      Accepts a loadFactor (default is 0.75). 
        This means when HashMap is filled with more than 75% its capacity, auto rehashing occurs
    HashTable
      All methods are synchronized, which means it is multithread safe
      Null keys and new values are not allowed
    LinkedHashMap
      Has a predictable order, because each element has a reference to the previous and next element
      Can be configured to sort its elements in 
        Access-order, where least recently readed or modified element will be first
        Insertion-order, where first inserted element will be first
      Contains the method removeEldestElement() which can be overrided to specify when the eldest element should be removed
      It is commonly used to implement caches, configuring removeEldestElement() to a certain capacity
    SortedMap
      Automatically orders the elements added to it
      The order is based in the comparator of the class if it implements the comparable interface,
        or can be provided as a class or lambda function
      Contains the methods 
        comparator(), subMap(), headMap(), tailMap(), firstKey(), lastKey()
    NavigableMap
      Extends SortedMap, with navigation methods returning the closest matches for given search targets
      Contains the methods
        lowerEntry(), lowerKey(), floorEntry(), floorKey(), ceilingEntry(), ceilingKey(), higherEntry(), higherKey()
        firstEntry(), lastEntry(), pollFirstEntry(), pollLastEntry(), descendingMap(), navigableKeySet(), descendingKeySet()
      Its more popular implementation is TreeMap (based in a red-black binary tree)
    IdentityHashMap
      Implements the Map interface but uses reference comparison instead of the equals() method when comparing keys (values)
    WeakHashMap 
      Implements the Map interface and is based on using a WeakReference to store keys
        Thus, the key/value pair will be removed from the WeakHashMap if the key object is no longer strongly referenced

Unmodifiable Collection
  Collection to which items can't be added, removed or replaced
  Can not be modified except it stores items that can mutate
  Collections that are created using unmodifiable factory methods are space efficient
  Static factory methods like List.of(), Map.of(), Set.of() return an unmodifiable collection

List.of() vs Arrays.asList() vs Collections.unmodifiableList()
  Immutability
    List.of() and Collections.unmodifiableList()
      Any attempt to structurally change will result in an UnsupportedOperationException, 
        this includes operations such as add(), set() and remove()
      You can, however, change the contents of the objects in the list (if the objects are not immutable)
    Arrays.asList()
      Is not completely immutable, it does not have a restriction on set()
      However, it is fixed length, so add() and remove() will throw an UnsupportedOperationException
  Null hostility
    listOf.contains(null);  // NullPointerException
    unmodif.contains(null); // allowed
    asList.contains(null);  // allowed

Comparator and Comparable interfaces
  Comparation methods are used when sorting a collection of objects. They return negative, positive or 0 values based on the result of the comparation
  Comparable interface
    Declares the compareTo(object) method
  Comparator interface  
    Ccontains the compare(object1, object2) method, which uses the Object.equals() method for comparation
  Comparation can be performed in one of the following ways
    Creating a lambda expression
    Creating an anonymous class implementing comparator interface
    Creating a class implementing comparator interface
    Adding the comparable interface and compareTo() method to the comparing class
  
Iterator, iterable and ListIterator interfaces
  Iterable interface contains the methods iterator(), foreach() adn spliterator()
  Iterator
    Is a type able to go through each member of a collection
    Iterator can't go backwards, a new instance of iterator has to be created once it has iterated through all members
    Iterator interface contains the following methods
      hasNext()
        Tells wether a next element is present
      next()
        Returns the next element of the collection
      remove() 
        Removes the next element of the collection
        By default it throws an exception, so it has to be overrided in order to work
      forEachRemaining()
        Takes an action as argument, that will be applied to the rest of the elements in the collection      
    Types of iterators
      Fail-Fast
        Is the default Iterator implementation, which means the iterator is not multithread safe and 
          accesing more than once to the same iterator element will throw a ConcurrentModificationException
      Fail-Safe iterators 
        Create a clone of the actual Collection and iterate over it
        If any modification happens after the iterator is created, the copy still remains untouched
        These Iterators continue looping over the Collection even if it’s modified
        Iterators on Collections from java.util.concurrent package are Fail-Safe
      Weakly consistent iterators
        Reflect some but not necessarily all of the changes that have been made to their backing collection since they were created
        Collections which rely on CAS(compare-and-swap) have weakly consistent iterators
  ListIterator
    Unlike Iterator, ListIterator can go backwards
    List iterator can be created in a specific position
      listIterator integers = integers.listIterator(2);
    A ListIterator has no current element,
      its cursor position always lies between the element that would be returned by a call to previous() 
      and the element that would be returned by a call to next()
    Contains the methods
      hasNext(), next(), hasPrevious(), previous(), nextIndex(), previousIndex(), remove(), set(), add()
    The remove and set(Object) methods are not defined in terms of the cursor position,
      they are defined to operate on the last element returned by a call to next or previous()