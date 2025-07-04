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
    Sequential streams run each operation one after one, item by item, and then one after one in the next item
    Example
      List<String> names = Arrays.asList("Anna", "Bob", "Cathy", "Adam", "Eve");
      names.stream()
            .filter(name -> {
                System.out.println("Filtering: " + name + ", ");
                return name.startsWith("A"); })
            .map(name -> {
                System.out.println("Mapping: " + name + ", ");
                return name.toUpperCase(); })
            .forEach(name -> System.out.println("Consuming: " + name + ", "));
      // Will always print Filtering: Anna, Mapping: Anna, Consuming: ANNA, Filtering: Bob, 
          Filtering: Cathy, Filtering: Adam, Mapping: Adam, Consuming: ADAM, Filtering: Eve
  Parallel streams
    Creates many Threads to run the stream operations, so the next operations are performed in parallel
    Only works in multithread machines
    Makes use of java.util.concurrent.ForkJoinPool
    Example
      List<String> names = Arrays.asList("Anna", "Bob", "Cathy", "Adam", "Eve");
      names.stream()
            .parallel()
            .filter(name -> {
                System.out.println("Filtering: " + name + ", ");
                return name.startsWith("A"); })
            .map(name -> {
                System.out.println("Mapping: " + name + ", ");
                return name.toUpperCase(); })
            .forEach(name -> System.out.println("Consuming: " + name + ", "));
      // May print, though the order is never guaranteed: Filtering: Anna, Filtering: Eve, Filtering: Cathy, 
        Filtering: Adam, Filtering: Bob, Mapping: Anna, Mapping: Adam, Consuming: ANNA, Consuming: ADAM, 

Terminal short-circuit operation
  When this operation has already obtained a result, it terminates the rest of the iteration  

Stream<T> interface
  Most of the methods in stream interface methods require Functional interfaces as input
  Intermediate operations do not modify the underlying data source,
    however, the stream itself might produce a modified view of the data (like with map())
  Stream methods are chained one after the other, like a conveyor belt, 
    and perform operations on the elements
  Operations
    Intermediate operations
      Return a stream after performing the operation, so that another operation can be chained after
      Main methods
        Stream<T> parallel()
          Converts a serial stream into a parallel stream
        Stream<T> filter(Predicate<? super T>)
          It creates a new stream, which, when completed, contains the elements of the original stream that match the given predicate
        Stream<R> map(Function<? super T, ? extends R>)
          Converts elements of type T into elements of type R and returns a stream with elements of R
        Stream<R> flatMap(Function<? super T, ? extends Stream<? extends R>>)
          Returns a stream consisting of the results of replacing each element of this stream 
            with the contents of a mapped stream produced by applying the provided mapping function to each element
          Or returns an Optional. If a value is present, returns the result of applying the given Optional-bearing mapping 
            function to the value, otherwise returns an empty Optional. 
            If invoked in an optional, flatMap does not wrap it within an additional Optional
          Examples
            orders.flatMap(order -> order.getLineItems().stream()); // Returns a stream of the lineItems inside all the orders
            optional.flatMap(optional -> optional.map(j -> i + j)); // Returns an Optional of a value calculated with the mapping function
        Stream<T> skip(long)
          Returns a stream consisting of the remaining elements of this stream after discarding the first n elements of the stream
          If this stream contains fewer than n elements then an empty stream will be returned
        Stream<T> distinct()
          Returns a stream consisting only in unique elements 
          Checks for uniqueness using Object.equals()
        Stream<T> peek(Consumer<? super T>)
          Takes a Consumer functional interface, and performs that action to each element of the stream
        Stream<T> limit(long)
          Leaves only maxSize elements in the stream
        Stream<T> sorted(Comparator<? super T>?)
          Returns a sorted stream based on the passed comparator
    Terminal operations
      Return void, an object, value, collection or array
      After calling terminal operation, stream can't be used again
        R collect(Collector<? super T, A, R>)
          Transform the stream into a collection following the provided Collector
        Object[] toArray()
          Returns an array containing the elements of this stream
        boolean anyMatch()
          Returns whether any elements of this stream match the provided predicate
        boolean noneMatch()
          Returns whether none elements of this stream match the provided predicate
        boolean allMatch()
          Returns whether all the elements of this stream match the provided predicate
        T reduce(T, BinaryOperator<T>)
          Performs a reduction on the elements of this stream, using an associative accumulation function
          Declares an acumulator and then performs operations on the accumulator based on values from the stream
          Returns an Optional
          Example 
            // 0 is the initial value of the accumulator
            Integer sum = integers.reduce(0, (previousElement, currentElement) -> previousElement + currentElement); 
        long count()
          Returns the count of elements in this stream
          It is an special case of reduce
        Optional<T> findFirst()
          Returns an Optional with the first element of this stream
          It is a short-circuit operation
        Optional<T> findAny()
          Returns an Optional with any element of this stream
          It is a short-circuit operation
        Optional<T> min() 
          Returns an Optional describing the minimum element of this stream, or an empty Optional if the stream is empty
          This is a special case of a reduction
        Optional<T> max()
          Returns the maximum element of this stream according to the provided Comparator
          This is a special case of a reduction
        void foreach(Consumer<? super T>)
          Takes a Consumer functional interface, and performs that action to each element of the stream
          Does not guarantee the sequence of elements in a parallel stream
        void forEachOrdered(Consumer<? super T>)
          Takes a Consumer functional interface, and performs that action to each element of the stream
          Guarantee the sequence of elements in a parallel stream

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

SummaryStatistics
  A state object for collecting statistics such as count, min, max, sum, and average
  This class is designed to work with (though does not require) streams
  There are DoubleSummaryStatistics, LongSummaryStatistics and IntSummaryStatistics, which work essentially the same,
    but require DoubleStream, LongStream and IntStream respectively
  java.util.IntSummaryStatistics
    Main methods
      void accept(int)
        Records a new value into the summary information
      void combine(IntSummaryStatistics)
        Combines the state of another IntSummaryStatistics into this one
      long getCount()
      long getSum()
      int getMin()
      int getMax()
      double getAverage()
    Example
      IntSummaryStatistics statistics = IntStream.range(1, 6).summaryStatistics();
      double average = statistics.getAverage();