Concepts
  First-class functions
    Can be treated like any other variable
  Pure functions
    Are completely independent from outside state
    Doesn't modify any state variable outside the function
    The same input returns always the same output
  Recursion
    A function that calls itself
  Referential transparency
    You can replace an expression with its result without changing the program's behavior
  Lazy evaluation
    The evaluation of an expression is delayed until its value is needed

Functional interface
  Interface that has a single abstract method declared in it,
    though it can contain any number of default and static methods
  Can be declared with the annotation @FunctionalInterface
  Must have exactly one abstract method and it should not be java.lang.Object methods
  Example
    @FunctionalInterface
    public interface DistanceCalculator() {
      double calculateDistance(City1 city1, City2 city2);
      default void someDefaultMethod() {}
      static void someStatictMethod() {}
    }

Lambda expressions
  Also called anonymous function, its used to declare a function that not necessarily have a name,
    and can be implement right in a method body
  It is used to implement the abstract method of any FunctionalInterface, in the way
    DistanceCalculator distanceCalculator = (city1, city2) -> city1.getLogitude() - city2.getLogitude();

Method references
  Lambda functions and method references are interchangeable
  Functional interfaces can also be implemented and passed to a function by method reference
  Method reference can be used in the way 
    Reference to a static method
      ContainingClass::staticMethodName
    Reference to a concrete object method
      ContainingObject::instanceMethodName
    Reference to constructor
      ClassName::new, for generics (generics) Class< T >::new.
  Example
    public class GoogleDistanceCalculator {
      public static double getDistanceBetweenCities(City1 city1, City2 city2) {
        return city1.getLogitude() - city2.getLogitude();
      }
    }
    DistanceCalculator distanceCalculator = GoogleDistanceCalculator::getDistanceBetweenCities;

Function<InputType, ResultType> and BiFunction<Input1Type, Input2Type, ResultType> functional interfaces
  Function<InputType, ResultType>
    Is a functional interface that accepts one parameter and returns one result
    "ResultType apply(input)" is the abstract method that defines, 
      which when called will execute the declared lambda function and will return the result
    Example
      Function<Double, Double> multiplyByTwo = number -> number * 2;
      Double result = multiplyByTwo.apply(5.0); // Returns 10      
  BiFunction<Input1Type, Input2Type, ResultType>
    Is a functional interface that accepts two parameter and returns one result
    "ResultType apply(input1, input2)" is the abstract method that defines, 
      which when called will execute the declared lambda function and will return the result
    Example
      BiFunction<Double, Double, Double> multiply = (number1, number2) -> number1 * number2;
      Double result = multiply.apply(2.0, 5.0); // Returns 10
  Function<InputType, ResultType> andThen(), BiFunction<Input1Type, Input2Type, ResultType> andThen()
    Offers the posibility to chain different Function and BiFunction interfaces, 
      applying the next function to the result of the previous function
    When chaining through this method, 
      the arguments of the input lambda function must match the result of the previous function
    Example
      Function<Double, Double> addTen = number -> number + 10;
      Double result = multiplyByTwo
                .andThen(addTen)
                .apply(1.0); // Returns 12
  Function<InputType, ResultType> compose()
    It's not present in BiFunction interface
    Allows to create a new lambda expression chaining existing lambda expression
    The input lambda expression will be executed first
    Example
      Function<Double, Double> multiplyByTwoAndAddTen = addTen.compose(multiplyByTwo);
      Double result = multiplyByTwoAndAddTen.apply(1.0); // Returns 12
  Function<InputType, ResultType> identity()
    Returns the exact input of the lambda function
    Example
      Arrays.asList("a", "b", "c")
                .stream()
                .map(Function.identity())
                .forEach(System.out::println); // Prints a b c

Supplier<OutputType> functional interface
  Represents a supplier of results
  There is no requirement that a new or distinct result be returned 
    each time the supplier is invoked
  OutputType get()
    Is the abstract method that Predicate interface defines
    Returns a result

Predicate<InputType> and BiPredicate<Input1Type, Input2Type> functional interfaces
  Are designed to verify if an object matches certain specification
  Predicate<InputType>
    boolean test() 
      Is the abstract method that Predicate interface defines
      Performs an verification and returns boolean
      Example 
        soap.setPrice(15.0);
        Predicate<Product> isMoreExpensiveThanTen = product -> product.getPrice() > 10.0;
        boolean result = isMoreExpensiveThanTen.test(soap); // Returns true
    Predicate<InputType> negate()
      Allows to add logic and combine different predicates
      Example
        soap.setPrice(15.0);
        Predicate<Product> isCheaperOrEqualToTen = isMoreExpensiveThanTen.negate();
        isCheaperOrEqualToTen.test(soap); // Returns false
    Predicate<InputType> and()
      Allows to add logic and combine different predicates
      Example
        soap.setCategory("Cleaners");
        Predicate<Product> isCategoryEqualToCleaners = product -> product.getCategory() === "Cleaners";
        Predicate<Product> isCategoryEqualToCleanersAndMoreExpensiveThanTen = isMoreExpensiveThanTen.and(isCategoryEqualToCleaners);
        isCategoryEqualToCleanersAndMoreExpensiveThanTen.test(soap); // Returns true
    Predicate<InputType> or()
      Allows to add logic and combine different predicates
      Example
        Predicate<Product> isCategoryEqualToHomeCare = product -> product.getCategory() === "HomeCare";
        Predicate<Product> isCategoryEqualToCleanersOrHomeCare = isCategoryEqualToHomeCare.or(isCategoryEqualToCleaners);
        isCategoryEqualToCleanersAndMoreExpensiveThanTen.test(soap); // Returns true
    Static methods
      Predicate contains the following static methods, that helps to create new predicates based on existing ones
      Predicate<InputType> isEqual()
        Returns a predicate that tests if two arguments are equal according to Objects.equals(Object, Object)
        Example
          Predicate<Product> isEqual = Predicate.isEqual(soap);
      Predicate<InputType> not()
        Returns a predicate that negates the input predicate
        Example
          Predicate<Product> isCheaperOrEqualToTen = Predicate.not(isMoreExpensiveThanTen);
  BiPredicate<Input1Type, Input2Type>
    Similar to Predicates, but can take two inputs    
    boolean test() 
      Is the abstract method that Predicate interface defines
      Performs an verification and returns boolean
      Example 
        soap.setPrice(15.0);
        BiPredicate<Product, Double> isMoreExpensiveThan = (product, price) -> product.getPrice() > price;
        boolean result = isMoreExpensiveThan.test(soap, 10.0); // Return true
    BiPredicate<Input1Type, Input2Type> negate()
      Allows to add logic and combine different predicates
      Example
        soap.setPrice(15.0);
        BiPredicate<Product, Double> isCheaperOrEqualTo = isMoreExpensiveThan.negate();
        isCheaperOrEqual.test(soap, 10.0); // Returns false
    BiPredicate<Input1Type, Input2Type> and()
      Allows to add logic and combine different predicates
      Both BiPredicates must to have the same generic types
    BiPredicate<Input1Type, Input2Type> or()
      Allows to add logic and combine different predicates
      Both BiPredicates must to have the same generic types

Consumer<Input1Type> and BiConsumer<Input1Type, Input2Type> functional interfaces
  Are is designed to modify state and return void
  Consumer<InputType>
    void accept() 
      Is the abstract method that defines
      Performs an action and returns void
      Example
        Product soap = new Product("soap");
        soap.setPrice(10.0);
        double increment = 10.0;
        Consumer<Product> increasePrice = product -> product.setPrice(product.getPrice() + increment);
        increasePrice.accept(soap); // soap.price will be set to 20
  BiConsumer<Input1Type, Input2Type>
    void accept() 
      Is the abstract method that defines
      Performs an action and returns void
      Example
        soap.setPrice(10.0);
        Consumer<Product, Double> increasePrice = (product, increment) -> product.setPrice(product.getPrice() + increment);
        increasePrice.accept(soap, 10.0); // soap.price will be set to 20

Summary of functional operations
  Function
    Takes an argument and returns a value/object
  Supplier
    Takes no arguments and returns a value/object
  Predicate
    Takes an arguments and returns a boolean
  Consumer
    Takes an objects and change its state