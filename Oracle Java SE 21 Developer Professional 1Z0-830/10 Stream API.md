Streams provide the ability to process a sequence of elements by executing one or more operations, 
  which can be performed either sequentially or in parallel. 
Example
    int sum = widgets.stream()                  
                .filter(w -> w. getColor() == RED)                  
                .mapToInt(w -> w. getWeight())                  
                .sum();

Sequantial vs parallel streams
  Sequential Streams
    By default, all streams created are sequantial streams
    Sequential streams run each operation one after one
  Parallel streams
    Creates many Threads to run the stream operations, 
      so the next operations are performed in parallel
    Only works in multithread machines
    Makes use of java.util.concurrent.ForkJoinPool

Terminal short-circuit operation
  When this operation has already obtained a result, it terminates the rest of the iteration  

Stream Interface
  Most of the methods in stream interface methods require Functional interfaces as input
  Stream methods are chained one after the other, like a conveyor belt, 
    and perform operations on the elements
  Operations
    Intermediate operations
      Return a stream after performing the operation, so that another operation can be chained after
      Some of the most important methods it declares are
        parallel()
          Converts a serial stream into a parallel stream
        filter()
          It creates a new stream, which, when completed, contains the elements of the original stream that match the given predicate
        map()
          Converts elements of type T into elements of type R and returns a stream with elements of R
        flatMap()
          Returns a stream consisting of the results of replacing each element of this stream 
            with the contents of a mapped stream produced by applying the provided mapping function to each element
          Example
            orders.flatMap(order -> order.getLineItems().stream()); // Returns a stream of the lineItems inside all the orders
        skip()
          Returns a stream consisting of the remaining elements of this stream after discarding the first n elements of the stream
          If this stream contains fewer than n elements then an empty stream will be returned
        distinct()
          Returns a stream consisting only in unique elements 
          Checks for uniqueness using Object.equals()
        peek()
          Takes a Consumer functional interface, and performs that action to each element of the stream
        limit()
          Leaves only maxSize elements in the stream
        sorted()
          Returns a sorted stream based on the passed comparator
    Terminal operations
      Return void, an object, value, collection or array
        findFirst()
          Returns an Optional with the first element of this stream
          It is a short-circuit operation
        findAny()
          Returns an Optional with any element of this stream
          It is a short-circuit operation
        anyMatch()
          Returns whether any elements of this stream match the provided predicate
        noneMath()
          Returns whether none elements of this stream match the provided predicate
        allMatch()
          Returns whether all the elements of this stream match the provided predicate
        reduce()
          Performs a reduction on the elements of this stream, using an associative accumulation function
          Declares an acumulator and then performs operations on the accumulator based on values from the stream
          Example 
            // 0 is the initial value of the accumulator
            Integer sum = integers.reduce(0, (previousElement, currentElement) -> previousElement + currentElement); 
        count()
          Returns the count of elements in this stream
          It is an special case of reduce
        min() 
          Returns the minimum element of this stream according to the provided Comparator
          This is a special case of a reduction
        max()
          Returns the maximum element of this stream according to the provided Comparator
          This is a special case of a reduction
        foreach()
          Takes a Consumer functional interface, and performs that action to each element of the stream
          Does not guarantee the sequence of elements in a parallel stream
        forEachOrdered()
          Takes a Consumer functional interface, and performs that action to each element of the stream
          Guarantee the sequence of elements in a parallel stream
        collect()
          Transform the stream into a collection following the provided Collector
        toArray()
          Returns an array containing the elements of this stream

How to create a Stream?
  From Collections interface 
    Stream<String> streamFromCollection = List.of("a", "b", "c").stream();
  From Arrays class 
    Stream<String> streamFromArray = Arrays.stream(new String[] {"a", "b", "c"});
  Stream of values
    Stream<String> streamFromValues = Stream.of("a", "b", "c");
  From file
    Stream<String> streamFromFiles = Files.lines(Paths.get("file.txt"));
  From String
    IntStream streamFromString = "abc".chars()
  With Stream builder
    Stream.builder().add("a").add("b").add("c").build()
  With parallelStrem method
    Stream<String> stream = collection.parallelStream();
  With Stream iterate
    Stream<Integer> streamFromlterate = Stream.iterate(1, n -> n + 1)
  With Stream generate
    Stream<String> streamFromGenerate = Stream.generate(() -> "a1")
