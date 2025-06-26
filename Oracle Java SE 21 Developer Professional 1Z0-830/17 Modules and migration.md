Module 
  A module is a uniquely named reusable group of related packages, as well as resources such as images 
    and XML files and module descriptor specifying name and dependencies, that is, other modules
  Is packaged as a modular Jar file
  The packages in the module are accessible to other modules only if the module explicitly exports them
    and even then, another module can't use those packages unless it explicitly states that it requires
  It is recommended to name a Java module the same as the name of the root Java package contained in the
    module, if that is possible, because some modules might contain multiple root packages

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
    Appears on the module path but does not contain a module-info.java file. It is simply a regular JAR
    Unofficial modules added to the module path in the form of existing Jar files
    The name of the module will be derived from the name of the jar
    Have full read access to every other module loaded
    Automatic modules will have full read access to every other module loaded by the pass
  Unnamed module
    When a class or jar is loaded into the classpath but not the module pass, 
      it's automatically added to the unnamed module
    It's a catch all module to maintain backward compatibility with previously written Java code
    Unnamed modules have access to all packages and can use any other modules, 
      but they themselves are not treated as named modules and cannot provide reliable module encapsulation 
      or export packages to other modules explicitly

Module descriptor 
  Compiled version of a module declaration that's defined in a file named module-info.java
  The name of module in the descriptor must be the same as name of its root folder

Module directives
  requires
    Allows us to declare model dependencies
    Requiring a module multiple times will NOT cause a compile error
  requires static
    Compile time only dependency
  requires transitive
    Force any downstream consumers to also read required dependencies of a dependency
  exports
    Expose all public members of the named package
    Only the listed package itself is exported. No sub packages of the exported package are exported.
    The same Java package can only be exported by a single Java module at runtime,
      it is compile-time error if there are two exports of package with same name
  exports ... to ...
    Similar to the exports directive, declares a package as exported, 
      but also list which modules allowed to import this package as a class
  uses
    Specifies a service used by this module, making the module a service
  provides ... with ...
    Ensures this module is a service provider that other modules can consume
    It is needed to specify the interface or abstract class of the provided service, 
      along with the implementation
  opens
    Indicates that a specific package, public types, nested public and protected types 
      are accessible to code in other modules at runtime only
      Also, all the types in the specified package and all of the type members are accessible via reflection
  opens ... to ...
    Same that opens, but specifying to which modules are accesible

What happens if a module descriptor contains both "opens" and "opens ... to ..."?
  This behavior is not a compilation error, nor is the more restrictive directive applied
  The general directive "opens" takes precedence, and the package becomes open to all modules, 
    not just modules described by "opens ... to ..." directive

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

Command line options
  module-path 
    Specify the module path, this is a list of one or more directories that contain our modules
  add-reads
    Command line equivalent of the requires directive
  add-exports
    Command line replacement for the exports directive
  add-opens
    Replace the open clause in the module declaration file
  add-modules
    Adds the list of modules into the default set of modules
  list-modules
    Prints a list of all modules and their version strings
  patch-module
    Add or override classes in modules
  illegal-access=permit| warn/deny 
    Either relax strong encapsulation by showing a single global warning, shows every warning, or
      fails with errors. The default is permit

Migration algorithm
  1. Create reliable suite of tests
  2. Identify goals of our migration and measure them
  3. Download the updated JDK version
  4. Run application with new JDK
  5. Update third-party dependencies if needed
  6. Identify dependencies inside the project - Run jdeps against your project
  7. Identify deprecated API - Run jdeprscan against your project
  8. Select Migration Strategy
  9. Migration execution
  10. Regression Testing
  11. Measure the results to confirm that goals of migration are achieved

jdeps
  Java dependency analysis tool
  Example command to generate a .jar.dot file with module dependencies from a single module application
    jdeps -dotoutput . -recursive --class-path "C:\Users\Uriel\Downloads" jarexport.jar
  Example command to generate a .jar.dot file with module dependencies from a multi module application
    jdeps --module-path modules --add-modules=ALL-MODULE-PATH -dotoutput .

webgraphviz.com
  Helps to visualize dependencies in a graphic way

jlink
  Allows to assemble and optimize a set of modules and their dependencies into a custom runtime image
  Generates a custom Java runtime image that contains only the platform-specific modules that are required for a given application
  Runtime images
    Contain only the modules picked and the dependencies they need to function
    Include the necessary Java Runtime Environment (JRE) components required to run the application, 
      so a separate JVM installation is not necessary

jmod 
  Allows to create JMOD files and list the content of existing JMOD files

jdeprscan 
  Allows to scan a jar file (or some other aggregation of class files) for uses of deprecated API elements