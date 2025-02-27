StringBuilder and StringBuffer
  Strings are inmutable, so in order to change them, a new instance needs to be created,
    which is be traduced in high memory and efficiency cost
  AbstractStringBuilder
    Saves a reference of each part of the string, along with its arrangement, 
      instead of creating a new whole string everytime a modification is needed, 
      saving both time and memory 
    Can be instantiated with an initial String, or a predefined capacity
    Main methods
      compareTo(), append(), insert(), reverse(), repeat(), delete(), 
      deleteChar(), replace(), indexOf(), lastIndexOf(), toString()
  StringBuilder class
    Inherits from AbstractStringBuilder, and it is its default and most popular implementation
  StringBuffer class
    Inherits from AbstractStringBuilder
    It is thread safe, and works essentially the same as StringBuilder
    Its performance is lower compared to StringBuilder


java.util.Optional
  A container of a generic type object, which may or may not contain a non-null value
  Main methods
    isPresent(), isEmpty(), get(), 
    ifPresent(), ifPresentOrElse(), 
    or(), orElse(), orElseGet(), orElseThrow()
    stream(), filter(), map(), flatMap()
  Main static methods
    Contains factory methods that return Optional type
      empty(), of(), ofNullable()
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
    Publisher interface
      Emits a sequence of elements potentially unbounded and distributes them to one or more subscribers
      Declares the method 
        subscribe()
          Adds the given Subscriber if possible
      Main implementations
        SubmissionPublisher
    Subscriber interface
      Consumes elements from a publisher and signals when it can handle more elements
      Main methods
        onSubscribe()
          Is invoked prior to invoking any other Subscriber methods for the given Subscription
        onNext()
          Is invoked with a Subscription's next item
        onError()
          Is invoked upon an unrecoverable error encountered by a Publisher or Subscription, 
            after which no other Subscriber methods are invoked by the Subscription
        onComplete()
          Is invoked when it is known that no additional Subscriber method invocations will occur 
            for a Subscription that is not already terminated by error, 
            after which no other Subscriber methods are invoked by the Subscription
    Subscription interface
      Establishes the link between a subscriber and a publisher
      Main methods
        request()
          Adds the given number n of items to the current unfulfilled demand for this subscription
        cancel()
          Causes the Subscriber to (eventually) stop receiving messages
      Main implementations
        Buffered subscription
    Processor interface
      Extends both Subscriber and Publisher, so is able to act as both
      Facilitates custom data processing within a reactive stream