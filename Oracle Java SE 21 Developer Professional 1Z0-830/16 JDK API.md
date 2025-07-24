StringBuilder and StringBuffer
  Strings are inmutable, so in order to change them, a new instance needs to be created,
    which is be traduced in high memory and efficiency cost
  AbstractStringBuilder
    Implements CharSequence
    Saves a reference of each part of the string, along with its arrangement, 
      instead of creating a new whole string everytime a modification is needed, 
      saving both time and memory 
    Can be instantiated with an initial String, or a predefined capacity
    In its methods, if the position argument is negative of greater than the length
      of the existent string, the method will throw StringIndexOutOfBoundsException
    Main methods
      int compareTo(Stringbuilder)
      StringBuilder append(Object)
      StringBuilder insert(int, Object)
      StringBuilder repeat(int, int)
      StringBuilder delete(int, int)
      StringBuilder deleteCharAt(int)
      StringBuilder replace(int, int, String)
      StringBuilder reverse()
      int lastIndexOf(String)
      int indexOf(String)
      toString()
      void setLength(int)
        Truncates the existing string to the length passed as argument
  StringBuilder class
    Inherits from AbstractStringBuilder, and it is its default and most popular implementation
    It is final
  StringBuffer class
    Inherits from AbstractStringBuilder
    It is final
    It is thread safe, and works essentially the same as StringBuilder
    Its performance is lower compared to StringBuilder

java.util.Optional<T>
  A container of a generic type object, which may or may not contain a non-null value
  Comparing two empty Optional instances using equals() will return true
  Main methods
    boolean isPresent()
    boolean isEmpty()
    T get()
    void ifPresent(Consumer<? super T>)
    void ifPresentOrElse(Consumer<? super T>, Runnable)
    Optional<T> or(Supplier<? extends Optional<? extends T>>)
    T orElse(T)
    T orElseGet(Supplier<? extends T>)
    T orElseThrow(Supplier<? extends Throwable>?)
    Stream<T> stream()
    Optional<T> filter(Predicate<? super T>)
    Optional<U> map(Function<? super T, ? extends U>)
      If a value is present, returns an Optional describing (as if by ofNullable) the result 
        of applying the given mapping function to the value, otherwise returns an empty Optional
    Optional<U> flatMap(Function<? super T, ? extends Optional<? extends U>>)
      Similar to map(Function), but the mapping function is one whose result is already an Optional, 
        and if invoked, flatMap does not wrap it within an additional Optional
      Throws NullPointerException if the mapping function is null or returns a null result
  Main static methods
    Contains factory methods that return Optional type
      Optional<T> empty()
      Optional<T> of()
      Optional<T> ofNullable()
  Examples
    Optional<User> optional = Optional.of(new User("Yegor", 1990));
		Integer yearOfBirth = optional.map(user -> user.getYearOfBirth())
				.filter(year -> year >= 1960)
				.filter(year -> year <= 2000)
				.orElse(null);

    Optional<String> optional = Optional.of("Learn IT University");
		optional.ifPresent(string -> System.out.println("ifPresent(): " + string));
		optional = Optional.empty();
		optional.ifPresentOrElse(string -> System.out.println(string),
				() -> System.out.println("ifPresentOrElse(): No value found"));

Reactive programming
  Is a paradigm designed for handling asynchronous data streams and managing changes in a system
  Key Characteristics
    Asynchronous and Non-blocking
      Emphasizes asynchronous and non-blocking operations for efficient resource utilization
    Data Streams
      Core concept involves data streams-sequences of events or values occurring over time
    Event-Driven
      Systems are event-driven, responding dynamically to changes or events
    Backpressure
      Involves downstream components signaling their capacity to handle data, preventing overload
    Responsive and Scalable
      Aims to create responsive applications adaptable to varying workloads
    Functional Programming
      Aligns with functional programming principles, promoting immutability and pure functions
    Reactive Extensions (Rx)
      Provides a uniform way to work with reactive programming concepts across multiple languages

Flow API (Reactive Streams)
  Establish a standard for asynchronous stream processing, prioritizing non-blocking backpressure mechanisms
  Key interfaces
    Publisher<T> interface
      Emits a sequence of elements potentially unbounded and distributes them to one or more subscribers
      Declares the method 
        void subscribe(Subscriber<? super T>)
          Adds the given Subscriber if possible
      Main implementations
        SubmissionPublisher
    Subscriber interface
      Consumes elements from a publisher and signals when it can handle more elements
      Main methods
        void onSubscribe(Subscription)
          Is invoked prior to invoking any other Subscriber methods for the given Subscription
        void onNext(T)
          Is invoked with a Subscription's next item
        void onError(Throwable)
          Is invoked upon an unrecoverable error encountered by a Publisher or Subscription, 
            after which no other Subscriber methods are invoked by the Subscription
        void onComplete()
          Is invoked when it is known that no additional Subscriber method invocations will occur 
            for a Subscription that is not already terminated by error, 
            after which no other Subscriber methods are invoked by the Subscription
    Subscription interface
      Establishes the link between a subscriber and a publisher
      Main methods
        void request(long)
          Adds the given number n of items to the current unfulfilled demand for this subscription
        void cancel()
          Causes the Subscriber to (eventually) stop receiving messages
      Main implementations
        Buffered subscription
    Processor interface
      Extends both Subscriber and Publisher, so is able to act as both
      Facilitates custom data processing within a reactive stream