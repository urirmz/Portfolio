A log file is a file that records either events that occur in operating system or application
A log in a computing context is automatically produced and time stamped
Loging is the act of keeping a log
Most of software applications and systems produce log files

Logging levels
  Even despite the fact that levels are named differently across log libraries, the concept is almost the same
  Default logging levels in SL4J
    Fatal 
      Indicates that the application encountered an event that prevents it from working or performing a crucial part of it
    Error (Severe in java.util.logging)
      Indicates an issue with a system that prevents certain functionality from working
    Warn (Warning in java.util.logging)
      Indicates a state of the application that might be problematic or that an unusual execution is detected
    Info (Info and Config in java.util.logging)
      The standard level of log information that indicates normal application action
    Debug (Fine and Finer in java.util.logging)
      Less granular than TRACE level, but still more granular than INFO level, 
        and more detailed than need in your normal, everyday use
    Trace (Finest and All in java.util.logging)
      Very fine-grained information only used in a rare case where you need the full visibility of what is happening

java.util.logging (Java Logging Framework)
  Built in into the JDK, recommended by Oracle
  Key elements
    Logger class
      Entity on which applications make logging calls
      Logger object is used for a single class or a single component to provide context bound,
        and log messages for a specific system or application component
      Main methods
        setLevel()
          Set the log level specifying which message levels will be logged by this logger
          Message levels lower than this value will be discarded
        addHandler()
          Add a log Handler to receive logging messages
        removeHandler()
          Remove a log Handler. Throws exeption if provided handler is not found
        getHandlers()
          Returns an array of all registered Handlers
        severe(), warning(), info(), config(), fine(), finer(), finest()
          Logs a message in the associated log level
    Level class
      Defines a set of standards login levels that can be used to control login output
      Programs can be configured to output login for some levels while ignoring output for others
      Static properties (from highest to lowest value)
        SEVERE, WARNING, INFO, CONFIG, FINE, FINER, FINEST
    LogRecord class
      Passes logging requests between the logging framework and individual log handlers
    Handler abstract class
      Exports log records objects to a variety of destinations, including, memory, output streams, consoles, files, and sockets
      Additional handlers may be developed by third parties and delivered on top of the core platform, by extending this class
      Main methods
        publish()
          Publish a LogRecord
          The logging request was made initially to a Logger object, which initialized the LogRecord and forwarded it here
        flush()
          Flush any buffered output
        close()
          Close the Handler and free all associated resources
        getFormatter(), setFormatter(), getEncoding(), setEncoding(), getLevel(), setLevel(),
        getFilter(), setFilter(), getErrorManager(), setErrorManager()
      Main implementations
        ConsoleHandler
          Records all the log messages to System.err. By default, a Logger is associated with this handler
        FileHandler
          Records all the log messages to a specific file or to a rotating set of files
				StreamHandler
          Publishes all the log messages to an OutputStream
        SocketHandler
          Publish the LogRecords to a network stream connection
		    MemoryHandler
          It is used to keep the LogRecords into a memory buffer
          If the buffer gets full, the new LogRecords starts overwriting the old LogRecords
    Formatter abstract class
      Provides support for formatting LogRecord objects
      Typically each logging Handler will have a Formatter associated with it. The Formatter takes a LogRecord and converts it to a string
      As with handlers, additional formatters may be developed by third parties by extending this class
      Methods
        format(), getHead(), getTail(), formatMessage()
      Implementations
        SimpleFormatter, XMLFormatter
    Filter
      Provides fine grained control over what gets logged, beyond the control provided by log levels

Log4J
  Supports logging to files, output streams, and other targets
  Allows the configuration via config files

Logback
  Intended to be the successor of Log4j2. Developed by the original Log4j2 developer
  Features a lightweight architecture

SLF4
  Acts as a simple interface for various other logging libraries, 
    allowing developers to plug in the desired implementation at deployment time