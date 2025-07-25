Collections vs Arrays
  Collections are dynamic size, while arrays are always fixed size
  Collections can work just with reference types, while arrays can work with both primitive and reference types
  Arrays have better performance

Collections 
  The java.util.Collections class contains only static methods for working with collections    
    void sort(List<T>, Comparator<? super T>?)
    int binarySearch(List<? extends Comparable<? super T>>, T)
    void reverse(List<?>)
    void shuffle(List<?>, RandomGenerator?)
    void swap(List<?>, int, int)
    void fill(List<? super T>, T)
    void copy(List<? super T>, List<? extends T>)
    <T extends Comparable> max(Collection<? extends T>, Comparator<? super T>?)
    <T extends Comparable> min(Collection<? extends T>, Comparator<? super T>?)
    Stream<T> stream()
    Collection<T> unmodifiable...(Collection<? extends T>)
    Collection<T> synchronized...(Collection<? extends T>)
  
Collection<T> interface 
  Contains the following methods
    int size()
    boolean isEmpty()
    boolean contains(Object)
    Object[] toArray()
    boolean add(T)
    boolean remove(T), 
    boolean containsAll(Collection<?>)
    boolean addAll(Collection<? extends T>)
    boolean removeAll(Collection<?>)
    boolean retainAll(Collection<?>)
    void clear()
    boolean equals(Object)
    int hashCode()
    It implements the Iterable interface, which contains the Iterator<T> iterator() method
  The main interfaces that inherit the Collection interface are
    List<T> interface
      Keeps objects in an order. Objects can be accessed, inserted or removed using an index
      Duplicate elements as well as nulls are permitted
      Contains the following methods
        T get(int)
        T set(int, T)
        void add(int, T)
        int indexOf(Object)
        int lastIndexOf(Object)
        ListIterator<T> listIterator(int?)
        List<T> sublist(int, int)
          It does not return a new independent list, but a view of the original list,
            thus any change you do to the view is reflected in the original list.
          Furthermore, all structural modifications must be done through the view,
            if you try to modify the list and then try to use the list, results are unpredictable,
            or may throw ConcurrentModificationException
        void replaceAll(UnaryOperator<T>)
        void sort(Comparator<? super E>)
      Its main implementations are
        ArrayList<T>
          Uses an internal array to hold objects
          Default capacity is 10. When full, a new ArrayList is created and objects copied to the new list
          It's main advantage is that allows to return objects in O(1) when using an index
        Vector<T>
          Similar to an ArrayList, the only difference is that all vector methods are synchronized, meaning it is multithread safe
        Stack<T>
          Extends vector, but contains all the methods from the Queue
          It is used to implement a LIFO (Last In, First Out)
          It is deprecated, but kept to maintain backwards compatibility
        LinkedList<T>
          Consist on multiple objects of Node type. Always contains the reference to first and last nodes
          It is double linked, which means each node of the list contains a reference to next and previous nodes
          It is also one of the most popular implementations of the Queue interface
          It's main advantage is that allows to insert, delete and return objects in O(1) from head and tail
    Set<T> interface
      Doesn't introduce any new method
      Contains only unique objects
      Assigns an index using the hashCode() method, this is the reason why members appear to be unordered when added to a set,
        then checks for uniqueness based on the boolean equals() method
      Its main implementations are
        EnumSet<T>
          uses an array of bits to store values (bit vector), which allows for high compactness and efficiency
          The data structure stores objects of only one Enum type, which is specified when an EnumSet instance is created
          All basic operations are performed in constant time (O(1)) and are generally somewhat faster (though not guaranteed) than their       
            counterparts in the HashSet implementation
          Iteration over the EnumSet is carried out according to the order in which the enumeration elements are declared
        HashSet<T>
          Uses a HashMap behind scenes
        LinkedHashSet<T>
          Implements SequencedSet, which extends SequencedCollection
          Has a predictable order, because each element has a reference to the previous and next element
          The elements of the list are ordered according to their insertion order,
            unlike LinkedHashMap, LinkedHashSet doesn't support access order
        TreeSet<T>
          Implements SequencedSet, which extends SequencedCollection,
            however since it orders automatically its elements, 
            it throws UnsupportedOperationException from its addFirst and addLast methods
          When an object is inserted, it's automatically sorted in natural order, following a tree structure
          Does not allow duplicates according to the comparator’s logic, for example
            if comparing two Person by age then name, and the comparator finds that the age is the same as the existing in the set 
            and also the name is the same, this element is considered a duplicate and is not added to the set
    Queue<T> interface      
      Helps to implement LIFO (Last In, First Out) and FIFO (First In, First Out)
        LIFO is commonly used for queues
        FIFO is commonly used for undo operations, history
      Contains the following methods
        boolean add(T) 
          Adds an element to the end to the queue
          Throws an exception if operation exceeds capacity restrictions
        boolean offer(T) 
          Adds an element to the end to the queue and returns true
          Returns false if operation exceeds capacity restrictions
        T remove() 
          Retrieves and removes the first element of this queue
          Throws an exception if this queue is empty 
        T poll()
          Retrieves, but does not remove, the head of this queue  
          Returns null if this queue is empty
        T element()
          Retrieves, but does not remove, the head of this queue
          Throws an exception if this queue is empty
        T peek()
          Retrieves, but does not remove, the head of this queue 
          Returns null if this queue is empty
      Its main implementations are
        ArrayDeque<T>
        LinkedList<T>
        PriorityQueue<T>
          Automatically orders the elements added to it
          The order is based in the comparator of the class if it implements the comparable interface,
            or can be provided as a class or lambda function
      Deque<T> interface 
        Implements Queue and Iterable interfaces, and also contains the stack methods
        Contains the additional methods
          void addFirst(T)
          void addLast(T)
          boolean offerFirst(T)
          boolean offerLast(T)
          T removeFirst()
          T removeLast()
          T pollFirst()
          T pollLast(),
          T getFirst()
          T getLast()
          T peekFirst()
          T peekLast()
          boolean removeFirstOcurrence(Object)
          boolean removeLastOcurrence(Object)

Map<K, V> interface
  Map doesn't belong to Collection interface because some methods of the Collection interface cannot be used in Map
  Allows key-value pairs, called entries, where all keys must be unique
  Includes the inner class Map.Entry
  Assigns an index using the keys hashCode() method, 
    this is the reason why members appear to be unordered when added to a Map
  Uniqueness check is based on the equals() method,
    so key must be Object type, not primitive
  Contains the methods
    int size()
    boolean isEmpty()
    boolean containsKey(Object)
    boolean containsValue(Object)
    V get(Object)
    V put(K, V)
    void putAll(Map<? extends K, ? extends V>)
    boolean remove(Object)
    void clear()
    Set<K> keySet()
    Collection<V> values()
    Set<Map.Entry<K, V>> entrySet()
    V getOrDefault(Object, V)
    V putIfAbsent(K, V)
    boolean replace(K, V, V)
    V computeIfAbsent(K, Function<? super K, ? extends V>)
    V computeIfAbsent(K, BiFunction<? super K, ? super V, ? extends V>)
    V compute(K, BiFunction<? super K, ? super V, ? extends V>)
    V merge(K, V, BiFunction<? super V, ? super V, ? extends V>)
      Replaces the current value with the results of the given remapping function, or removes if the result is null
      If there is no current value, or current value is null, it appends the new value directly without executing the remapping function
      Example, to either create or append a String msg to a value mapping:
        map.merge(key, msg, String::concat);
  Its main implementations are
    HashMap<K, V>
      One null key is allowed and null values are also allowed
      Accepts an initial capacity (default is 16)
      Accepts a loadFactor (default is 0.75). 
        This means when HashMap is filled with more than 75% its capacity, auto rehashing occurs
    HashTable<K, V>
      All methods are synchronized, which means it is multithread safe
      Null keys and new values are not allowed
    LinkedHashMap<K, V>
      Has a predictable order, because each element has a reference to the previous and next element
      Can be configured to sort its elements in 
        Access-order, where least recently readed or modified element will be first
        Insertion-order, where first inserted element will be first
      Contains the method removeEldestElement() which can be overrided to specify when the eldest element should be removed
      It is commonly used to implement caches, configuring removeEldestElement() to a certain capacity
    SortedMap<K, V>
      Automatically orders the elements added to it
      The order is based in the comparator of the class if it implements the comparable interface,
        or can be provided as a class or lambda function
      Contains the methods 
        Comparator<? super K> comparator()
        SortedMap<K,V> subMap(K, K)
        SortedMap<K,V> headMap(K)
        SortedMap<K,V> tailMap(K)
        K firstKey()
        K lastKey()
    NavigableMap<K, V>
      Extends SortedMap, with navigation methods returning the closest matches for given search targets
      Contains the methods
        Map.Entry<K,V> lowerEntry(K)
        K lowerKey(K)
        Map.Entry<K,V> floorEntry(K)
        K floorKey(K)
        Map.Entry<K,V> ceilingEntry(K)
        K ceilingKey(K)
        Map.Entry<K,V> higherEntry(K)
        K higherKey(K)
        Map.Entry<K,V> firstEntry()
        Map.Entry<K,V> lastEntry()
        Map.Entry<K,V> pollFirstEntry()
        Map.Entry<K,V> pollLastEntry()
        NavigableMap<K,V> descendingMap()
        NavigableSet<K> navigableKeySet()
        NavigableSet<K> descendingKeySet()
      Its more popular implementation is TreeMap (based in a red-black binary tree)
    IdentityHashMap<K, V>
      Implements the Map interface but uses reference comparison instead of the equals() method when comparing keys (values)
    WeakHashMap<K, V>
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

Comparator<T> and Comparable<T> interfaces
  Comparation methods are used when sorting a collection of objects
  They return negative, positive or 0 values based on the result of the comparation
    Example
      Supposing ascending order: Objects.compare(comparable1, comparable2, Comparator.naturalOrder()) returns ->
        -1 // comparable1 goes before comparable2
         0 // comparable1 and comparable2 go at the same level
         1 // comparable1 goes after comparable2
  Comparable<T> interface
    Declares the int compareTo(object) method
  Comparator interface  
    Contains the int compare(object1, object2) method, which uses the boolean boolean Object.equals() method for comparation
  Comparation can be performed in one of the following ways
    Creating a lambda expression
    Creating an anonymous class implementing comparator interface
    Creating a class implementing comparator interface
    Adding the comparable interface and int compareTo() method to the comparing class
  String natural lexicographical order (follows ASCII table)
    1. Space, symbols ! " # $ % ' ( ) * + , - . /
    2. Numbers 0 1 2 3 4 5 6 7 8 9
    3. Symbols : ; < = > ? @
    4. Uppercase letters
    5. Symols [ \ ] ^ _ `
    6. Lowercase letters

Iterator<T>, Iterable<T> and ListIterator<T> interfaces
  Iterable interface contains the methods Iterator<T> iterator(), void forEach() and Spliterator<T> spliterator()
  Iterator
    Is a type able to go through each member of a collection
    Iterator can't go backwards, a new instance of iterator has to be created once it has iterated through all members
    Iterator interface contains the following methods
      boolean hasNext()
        Tells wether a next element is present
      T next()
        Returns the next element of the collection
      void remove() 
        Removes the next element of the collection
        By default it throws an exception, so it has to be overrided in order to work
      void forEachRemaining(Consumer<? super T>)
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
  ListIterator<T>
    Unlike Iterator, ListIterator can go backwards
    List iterator can be created in a specific position
      ListIterator<Integer> integers = integers.listIterator(2);
    A ListIterator has no current element,
      its cursor position always lies between the element that would be returned by a call to previous() 
      and the element that would be returned by a call to next()
    Contains the methods
      boolean hasNext()
      T next()
      boolean hasPrevious()
      T previous()
      int nextIndex()
      int previousIndex()
      void remove()
      void set()
      void add()
    The void remove() and void set(Object) methods are not defined in terms of the cursor position,
      they are defined to operate on the last element returned by a call to T next() or T previous()

Spliterator<T> interface
  Traverse and partition elements of a source
  Main methods
    boolean tryAdvance(Consumer<? super T>)
      If a remaining element exists: performs the given action on it, returning true; 
        else returns false
    void forEachRemaining(Consumer<? super T>)
      Performs the given action for each remaining element, sequentially in the current thread, 
        until all elements have been processed or the action throws an exception.
    Spliterator<T> trySplit()
      Returns a Spliterator covering some portion of the elements, 
        or null if this spliterator cannot be split
      The exact division of elements is not always predictable