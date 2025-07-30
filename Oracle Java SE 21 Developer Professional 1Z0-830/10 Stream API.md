Streams provide the ability to process a sequence of elements by executing one or more operations, 
  which can be performed either sequentially or in parallel. 
Example
    int sum = widgets.stream()                  
                .filter(w -> w. getColor() == RED)                  
                .mapToInt(w -> w. getWeight())                  
                .sum();

Sequential vs parallel streams
  It doesn't matter how many times you add parallel() or sequential() operations to the stream pipeline,
    the fate of the stream is decided by the last operation you add, because this operations just set or unset an internal flag
  Sequential Streams
    By default, all streams created are sequential streams
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
  Can terminate the processing of infinite streams

Stream<T> interface
  Most of the methods in stream interface methods require Functional interfaces as input
  Intermediate operations do not modify the underlying data source,
    however, the stream itself might produce a modified view of the data (like with map())
  Stream methods are chained one after the other, like a conveyor belt, 
    and perform operations on the elements
  Streams does not store or keep elements within itself, 
    it merely gets them on by one from an underlying source.
    For this reason, streams don't have the concept of size or length,
    and are not modifiable either
  Operations
    Intermediate operations
      Return a stream after performing the operation, so that another operation can be chained after
      Are always lazy, and do not actually do anything until they are force to execute by a terminal operation
      Are classified in
        Stateless operations
          Process each element independently without considering any information derived from the elements processed earlier
          Examples: filter, map, foreach
        Stateful operations
          Keep a state that incorporates information from each element as it is processed and that state, in turn,
            affects the processing of subsequent elements
          Have serious performance implications, as they may require to hold a significant amount of data
          Can cause bottlenecks when the execution of a stream pipeline is parallelized
          Examples: sorted, distinct
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
  There is no publicly accessible class in the JDK that implements Stream, 
    so you cannot directly instantiate a Stream object.
  Instead, streams can be created in the following ways
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

Primitive streams
  Offer better performance as compared to regular Stream of primitive wrapper objects
  Do not extend Stream, but they define all the methods of Stream, 
    only changing the return types and the types of the parameters,
    for example, 
      IntStream.findAny() returns an OptionalInt(), which has getAsInt() instead of get()
      DoubleStream.findAny() an OptionalDouble(), which has getAsDouble() instead of get(),
      IntStream.filter() accepts an IntPredicate(), 
      IntStream.generate() accepts an IntSupplier
  Classes
    IntStream
    DoubleStream
    LongStream
  Besides the static of() and generate() methods that can be used to create any of this primitive streams,
    IntStream and LongStream have two additional static methods for creation:
    IntStream range(int, int) and LongStream range(int, int)
    IntStream rangeClosed(int, int) and LongStream rangeClosed(int, int) 
  Another way to create primitive streams is to use the 
    mapToInt(), mapToLong(), mapToDouble methods of the regular Stream interface
    these methods take a ToIntFunction, ToLongFunction and ToDoubleFunction

java.util.stream.Collectors
  Interface that acts as a repository of the three functions required by the mutable reduction operation
    which are supplier, accumulator and combiner functions. 
    Sometimes it also provides a "finisher" function, which performs the final transformation
  Instead of supplying the functions separately, we ask the collect method to get the functions from this repository
  A collector can be created with a reference to a "downstream" Collector, 
    to enable this, many of the methods of the Collectors class are overloaded to accept an extra parameter of type Collector,
    so when a Collector is created with a reference to a downstream Collector, 
    instead of returning the final result, it passes the results of the operation to that nested downstream Collector
  Main methods
    Collector<T, ?, C> toCollection(Supplier<C>)
      Collects all the items in the provided collection
    Collector<T, ?, List<T>> toList()
      Collects all the items in a list
    Collector<T, ?, Set<T>> toSet()
      Collects all the items in a set
    Collector< CharSequence, ?, String> joining (Collector<CharSequence, ?, String> s joining(CharSequence)
      Joins all the elements in a single String
    Collector<T, ?, R> mapping(Function‹? super T, ? extends U>, Collector‹? super U, A, R>)
      Adapts a Collector accepting elements of type U to one accepting elements of type T 
        by applying a mapping function to each input element before accumulation.
    Collector<T, ?, R>  flatMapping (Function‹? super T, ? extends Stream‹? extends U>>)
      Collect the elements in a new stream
    Collector<T, ?, R>  filtering (Predicate‹? super T>, Collector‹? super T, A, R>)
      Adapts a Collector to one accepting elements of the same type T by applying the predicate to each input element 
        and only accumulating if the predicate returns true.
    Collector<T, ?, R>  collectingAndThen (Collector<T, A, R>, Function<R, RR>)
      Adapts a Collector to perform an additional finishing transformation
    Collector<T, ?, Long> counting()
      Returns the count of elements as a long
    Collector<T, ?, Optional<T>> minBy(Comparator‹? super T>)
      Returns the min of elements according to the provided comparator
    Collector<T, ?, Optional<T>> maxBy(Comparator‹? super T>)
      Returns the max of elements according to the provided comparator
    Collector<T, ?, Integer> summingToInt(Function<? super T>)
      Returns the sum of a property of the elements as an int
    Collector<T, ?, Long> summingLong(ToLongFunction‹? super T>)
      Returns the sum of a property of the elements as a long
    Collector<T, ?, Double> sumWithCompensation(double, double)  
    Collector<T, ?, Double> summingDouble(ToDoubleFunction‹? super T>)
    Collector<T, ?, Double> averagingInt(ToIntFunction‹? super T>)
    Collector<T, ?, Double> averagingLong(ToLongFunction‹? super T>)
    Collector<T, ?, Double: averagingDouble(ToDoubleFunction<? super T>)
    Collector<T, ?, Optional<T>> reducing(BinaryOperator<T>)
    Collector<T, ?, U> groupingBy(Function‹? super T, ? extends K>)
    Collector<T,?, Ma<K, List<T>>> groupingBy(Function‹? super T, ? extends K>, Collector<? super T, A, D>)
      Groups the elements into one or more parts using a Function
    Collector<T, ?, Map<Boolean, List<T>>> partitioningBy(Predicate‹? super T>)
      Separates the elements of a stream into two parts, one which satisfies a Predicate and one that don't 
    Collector<T, ?, Мар<K, U>> toMap(Function‹? super T, ? extends K>, Function‹? super T, ? extends U>, BinaryOperator<U>)
    Collector<T,?, ConcurrentMap<K, U>> toConcurrentMap(Function‹? super T, ? extends K>, Function‹? super T, ? extends U>, BinaryOperator<U>)
    Collector<T, 3, M> summarizingInt(ToIntFunction<? super T>)
    Collector<T, 3, IntSummaryStatistics> summarizingLong(ToLongFunction<? super T>)
    Collector<T, ?, LongSummaryStatistics> summarizingDouble(ToDoubleFunction<? super T>)
    Collector<T,?, DoubleSummaryStatistics> teeing(Collector<? super T,?, R1>, Collector<? super T, ?, R2>, BiFunction<? super R1, ? super R2, R>)
    Collector<T, ?, R> teeing(Collector<? super T, A1, R1>, Collector<? super T, A2, R2>, BiFunction<? super R1, ? super R2, R>)
      Returns a Collector that is a composite of two downstream collectors. 
      Every element passed to the resulting collector is processed by both downstream collectors, 
        then their results are merged using the specified merge function into the final resul

Ordering
  The order of the stream depends on the order of the source,
    there's no method in a Stream to check whether is ordered or not
  A stream created using a generator functions, like Stream.generate(), is always unordered
  A stream operation may impose its own order on the elements, in which case, the original order will be lost
  forEach() and findAny() operations are explicitly defined non-deterministic, 
    which means they may process the elements in any order,
    however there is a forEachOrdered() operation that can be used to process the elements in order
  Adding the unordered() operation makes the stream free to ignore the order,
    this may help increase the performance when the stream execution is parallelized
  For an ordered stream, both sequential and parallel execution of a stream pipeline 
    are guaranteed to produce the same result, 
    however there is no guarantee on the order of execution of individual stream operations