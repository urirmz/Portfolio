Module 
  A module is a uniquely named reusable group of related packages, as well as resources such as images 
    and XML files and module descriptor specifying name and dependencies, that is, other modules
  Is packaged as a modular Jar file
  The packages in the module are accessible to other modules only if the module explicitly exports them
    and even then, another module can't use those packages unless it explicitly states that it requires
  Naming
    It is recommended to name a Java module the same as the name of the root Java package contained in the
      module, if that is possible, because some modules might contain multiple root packages
    Module name must be a valid Java identifier (so special characters such as dash and slash are out, but underscore and dot are in)

Jar Hell
  Term coined to describe hard to debug behavior of applications due to the presence of multiple versions
    of a class library on the classpath and/or due to the use of different versions of a library used by different parts of the application

Java Platform Module System
  Known as JSR 376 where, JSR stands for Java Specification Request
  Before Java Platform Module system, all of the Java Platform APIs were packaged in each Java application,
    now only the modules used by the application are packaged
  Multimodule projects can be created from a main application and several library modules.
    however, there can exist just one module per jar file
  Modules are not mandatory

Module types
  System modules
    Are listed with java list modules command
    Include the Java SE and JDK modules
  Application modules
    Are named and defined in the compiled module info class file included in the assembled jar
  Automatic modules
    If you put a non-modular jar on the module-path, Java will consider the non-module jar to be a module
      without needing to contain a module-info.java file. Such module is called "automatic module"
    The name of the module will be derived from the name of the jar,
      where hyphens are converted into dots and the trailing version and extension part of the file are ignored
      for example, mysql-driver-6.0.jar will be loaded as an automatic module with name mysql.driver
    It is possible for a non-modular jar to specify its future name using the
      Automatic-Module-Name:<module name> entry to the jar's MANIFEST.MF
    An automatic module exports as well as opens all of its packages
    An automatic module is allowed to read all exported packages of modules available in the module path
      as well as all classes available in the classpath
  Unnamed module
    When a class or jar is loaded into the classpath but not the module path, 
      it's automatically added to the unnamed module
    It's a catch-all module to maintain backward compatibility with previously written Java code
    Classes of the unnamed module are allowed to read all exported packages 
      of all modules in the module path and all the classes available in the classpath
    Since it is unnamed, it is not possible  to include this module in the requires clause of any module

Module descriptor 
  Compiled version of a module declaration that's defined in a file named module-info.java
  The name of module in the descriptor must be the same as name of its root folder
  module-info.java file cannot be empty
  module-info.java is compiled into module-info.class by the compiler

Module definition vs Source module definition
  If the directory contains the source code, it is called source module definition
  If the directory contains compiled classes, it is called module definition

Module directives
  exports
    Expose all public members of the named package
    Only packages can be exported and not individual classes
    Only the listed package itself is exported. No sub packages of the exported package are exported.
    The same Java package can only be exported by a single Java module at runtime,
      it is compile-time error if there are two exports of package with same name
    Once a package is exported, you cannot stop any other module from accessing it
  exports ... to ...
    Similar to the exports directive, declares a package as exported, 
      but also list which modules allowed to import this package as a class
    The modules for which a package is made readable are called "friendly" modules
  requires
    Allows us to declare model dependencies
    Requiring a module multiple times will NOT cause a compile error
    Java does not permit having duplicate requires clauses in a module-info
    Java does not allow cyclic/circular dependencies in modules,
      however circular dependencies withing classes and packages is allowed
  requires static
    Compile time only dependency
  requires transitive
    Force any downstream consumers to also read required dependencies of a dependency,
      this is called "implied readability"
  opens
    Indicates that a specific package, public types, nested public and protected types 
      are accessible to code in other modules at runtime only, but not at compile time
      Also, all the types in the specified package and all the type members are accessible via reflection
    Java does not allow modular code ot be intruded upon through reflection, 
      unless a module allows such access explicitly using the open or opens/opens-to directives
    Unlike exports/exports-to directives, it is allowed to open a package that does not exist
    Like exports/exports-to directives, it is NOT allowed to have duplicate opens/opens-to clause
  opens ... to ...
    Same that opens, but specifying to which modules are accessible
  open
    If you want to open all public and protected packages of a module, 
      you may apply the open directive to the module declaration itself 
      instead of applying the opens directive to each package individually
    Example
      open module simpleinterest {
        // Can't have any opens directive if the module is open.
      }
  provides ... with ...
    Used to declare that a module provides an implementation of a service
  uses
    Specifies a service that the module consumes

What happens if a module descriptor contains both "opens" and "opens ... to ..."?
  This behavior is not a compilation error, nor is the more restrictive directive applied
  The general directive "opens" takes precedence, and the package becomes open to all modules, 
    not just modules described by "opens ... to ..." directive

Services
  A service is an interface that outlines the functionality that it provides through its methods
  Large projects usually adopt a convention such as appending the word "Service" to the name of services
  Steps to make an application consume a service
    1. Tie the service and the service provider together in the module-info that contains the service provider,
      using the provides-with directive. Example:
        module simpleinterest {
          requires calculators;
          provides calculators.InterestCalculator with simpleintereset.SimpleInterestCalculator;
        }
    2. Use the uses directive in the module-info of the consumer application that wants to use the service. Example:
      module consumerclient {
        requires calculators;
        uses calculators.InterestCalculator;
      }
    3. Use the java.util.ServiceLoader class in the consumer code to get a list of service providers 
      that provide the service you are interested in, and use them. Example:
        package client;
        imports calculators.InterestCalculator;
        import java.util.ServiceLoader;
        public class ConsumerMain {
          public static void main(String[] args){
            ServiceLoader<InterestCalculator> interestCalculators = ServiceLoader.load(InterestCalculator.class);
            for (InterestCalculator calculator : interestCalculators) {
              System.out.println("Got calculator : " + calculator);
              System.out.println(calculator.calculate(100, .05, 3));
            }
          }
        }
  Since an instance of the services provider class is required to perform the service,
    the service loader expects the service to follow some rules:
      1. Service provider must be public and not be an inner class,
        it can be a top level class or a nested static class
      2. Service provider may have a public static method named provider() that takes no arguments
        and has a return type assignable to the service interface or class. 
        This method will be invoked whenever an instance of the service provider is needed
      3. If the service provider does not have a provider method, then 
        it must have a public no-args constructor, that will be used to instantiate the service provider whenever needed

Example module
  module com.itbulls.learnit.javacore {
    requires somemodule.name;
    requires static somemodule.name;
    requires transitive module.name;
    exports com.my.package.name;
    exports com.my.package.name.util;
    exports com.my.package.name to com.specific.package;
    uses class.name;
    provides Mylnterface with Mylnterfacelmpl;
    opens com.my.package;
    opens com.my.package to moduleOne, moduleTwo, etc .;
  }

Standard vs Non-standard modules
  Standard modules
    Are governed by the Java Community Process (JCP)
    Their names start with java. For example, java.base, java.sql, java.logging
    A standard module may contain non-standard packages
  Non-standard modules
    Are specific to a JDK
    Their names start with jdk. For example, jdk.jdeps, jdk.rmic and jdk.javadoc
    Depending on the provider of the jdk, it may have packages reflecting company name,
      for example, sun.net, sun.utils.resource
    A non-standard module does not contain any standard package

Java SE platform
  It is composed only of the standard module and is required to be supported by all Java implementations
  Java SE platform doesn't include all the standard modules,
    however none of the modules included export any non-standard package

Common Java modules
  java.base
    The default module for all JDK and user-defined
    It is the only module required implicitly, so there is no need to require it manually
  java.xml
    Provides support for processing XML documents
    Includes the XML processing APIs like JAXP (Java API for XML Processing), DOM (Document Object Model), and SAX (Simple API for XML), 
      as well as APIs for handling XML Schema and XPath
  java.logging
    Povides the Java Logging API, which allows for logging application events
    Includes classes like Logger, Handler, and Formatter to facilitate logging messages, errors, warnings, 
      and other information to various outputs (like the console, files, etc.)
  java.prefs
    Provides a mechanism for storing and retrieving user and system preferences in a hierarchical structure. 
    The Preferences API allows applications to store settings, preferences, and configuration data in a platform-independent way,
      typically for user preferences or application configurations
  java.sql
    The java.sql module provides the JDBC (Java Database Connectivity) API, which is used for connecting and interacting with relational databases
    Includes classes like Connection, Statement, ResultSet, and DriverManager for executing SQL queries, handling result sets, and managing database connections.
  java.httpserver
    The java.httpserver module provides the HTTP server API for creating simple HTTP-based servers
    It's typically used for lightweight HTTP servers in applications.
    Includes the HttpServer class, which allows for setting up an embedded HTTP server to handle HTTP requests
  java.se
    This is a meta-module that groups together the core modules of the Java SE (Standard Edition) platform
    Is used to ensure that all necessary modules for Java SE applications are included when using the java.se module
    Includes modules like java.base, java.desktop, java.sql, java.xml, and others
  java.desktop
    Provides the Java AWT (Abstract Window Toolkit) and Swing libraries for creating graphical user interfaces (GUIs)
    Includes classes for managing windows, buttons, text fields, event handling, and other GUI components
      It also includes Java's java.awt and javax.swing packages for building desktop applications

javac command options (for compiling modules)
  -d
    Used to specify the output directory
    Is required when you compile a module
  --module or -m
    Used when you want to compile all the source files of a particular module
  --module-source-path
    Used to specify the location of the module source files
  --module-path or -p
    Specifies the location of any other module upen which the module to be compiled depends
  -classpath or --classpath or -cp
    Option used for compilation of non-modular code
  Example command to compile a module (supposing src/simpleinterest/module-info.java exists)
    c:\ocp21 moduletest> javac -d out --module-source-path src --module simpleinterest

java commands options (for running modules)
  --module-path or -p
    Specify the module path, this is a list of one or more directories that contain our modules
    You can specify exploded module directories, directories containing modular jars, or even specific modular or non-modular jars here 
    module-path and classpath are not mutually exclusive, it is possible and sometimes necessary
      to use both switch simultaneously in a command while compiling and executing a module
  --module or -m
    Used to specify the module that you want to run
  -classpath or --classpath or -cp
    Used while executing non-modular code
  --add-reads
    Command line equivalent of the requires directive
  --add-exports
    Command line replacement for the exports directive
  --add-opens
    Replace the open clause in the module declaration file
  --add-modules
    Adds the list of modules into the default set of modules
  --list-modules
    Prints a list of all modules and their version strings
  --patch-module
    Add or override classes in modules
  --illegal-access=permit| warn/deny 
    Either relax strong encapsulation by showing a single global warning, shows every warning, or
      fails with errors. The default is permit
  --show-module-resolution
    Prints the module resolution information 
    Shows module level details only, it doesn't tells which package or class from a module is actually required
  Example command to run a module
    c:\ocp21 moduletest> java --module-path out --module simpleinterest/simpleinterest.SimpleInterestCalculator
  Example command to package a module (-C option is to make the jar tool change its working directory before adding files to the jar)
    c:\ocp21 module-test>jar --create --file simpleinterest.jar --main-class simpleinterest.SimpleInterestCalculator -C out simpleinterest .
  Example command to run a modular .jar file (it is possible to use a modular jar just like a non-modular jar)
    c:\ocp21 moduletest> java --module-path modulejars\simpleinterest.jar;module-jars\calculators.jar --module simpleinterest

Migration algorithm
  Top-down migration
    We first try to convert those parts of the application into modules that do not depend on any other modular part
      and place them on the module-path that the application uses
    This process as a issue, we cannot modularize some parts until all its dependencies are modularizedm
      and since we are not in control of all the dependencies, we are at the mercy of other teams
    Steps:
      1. Dependencies are migrated first and the target application jar is migrated later
      2. Every jar (or every potential module get moved to the module path)
      3. Nothing is left on the classpath
  Bottom-up migration
    We start converting the top most application jar into a module, then we place
      non-modular jars on the module path upon which the topmost module directly dependes,
      turning them into automatic modules
    Since with this approach all teams can work on modularizing their code base as per their convienence,
      this is the preferred approach in most cases. The only issue is
      we may have to edit our module-info if we get a new modular jar
    Steps:
      1. Target application is migrated first and dependencies are migrated later
      2. Not every jar (or potential module) gets moved to the module-path
      3. Some jars may be left on the classpath

jdeps
  Java dependency analysis tool
  Using this tool, you can find out module, package, as well as class level dependencies of a given module
  Example command to generate a .jar.dot file with module dependencies from a single module application
    jdeps -dotoutput . -recursive --class-path "C:\Users\Uriel\Downloads" jarexport.jar
  Example command to generate a .jar.dot file with module dependencies from a multi module application
    jdeps --module-path modules --add-modules=ALL-MODULE-PATH -dotoutput .

webgraphviz.com
  Helps to visualize dependencies in a graphic way

jlink
  Allows to assemble and optimize a set of modules and their dependencies into a custom runtime image,
    called JImage
  Generates a custom Java runtime image that contains only the platform-specific modules that are required for a given application
  Runtime images
    Contain only the modules picked and the dependencies they need to function
    Include the necessary Java Runtime Environment (JRE) components required to run the application, 
      so a separate JVM installation is not necessary

jmod 
  Allows to create JMOD files and list the content of existing JMOD files
  JMOD packaging method is used when you need to package artifacts that can't be put in jar files,
    such as native code
  .jmod file cannot be executed and is therefore, only used at compile and link time
  Basic syntax
    jmod (create | extract | list | describe | hash) [options] jmod-file

jdeprscan 
  Allows to scan a jar file (or some other aggregation of class files) for uses of deprecated API elements