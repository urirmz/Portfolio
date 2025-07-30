java.io package 
  Provides for system input and output through data streams, serialization and the file system
java.nio package 
  Defines buffers, which are containers for data, and other structures, such as charsets, channels, and selectable channels

String System.lineSeparator()
  Returns the default system-dependent line separator 
    Line separator is the character that tells the system to break the line (like \n)

Current directory
  The current directory is the path from where the program is run
  When you execute a jar file, Windows sets the current directory 
    as the directory in which the file is located.
    On older versions, Windows sets the current directory to C:\windows\system32
  All relative paths are resolved against the current directory by default  

Dot (.) and dot-dot (..)
  All directories in Unix and DOS based files systems automatically get two children named. and .., 
    where . refers to the same directory as the one in which it exists 
    and .. refers to its parent directory
  Canonical path
    Absolute path that doesn't contain redundant path fragments
      for example, the canonical path of "C:\temp\a\..\test.txt" is "C:\temp\test.txt"
    Some operating systems allow you to create symbolic links to other files,
      a canonical path resolves such links as well

java.io.File class
  Is an abstract representation of file and directory pathnames
  It is immutable
  The purpose of this class is not to operate the data inside the file, 
    but to work with the file itself in a platform independent manner
  Notably it does not have methods to copy and move a file
  Can be created in the way
    File file = new File("testDirectory"); // testDirectory is converted into an abstract pathname
  Contains the static fields
    String separator  
      The system-dependent default name-separator character
    String pathSeparator
      The system-dependent path-separator character
    char separatorChar
      The system-dependent name-separator
    char pathSeparatorChar
      The system-dependent path-separator
  The main methods of File class are
    boolean mkdir()
      Creates the directory named by this abstract pathname
    boolean mkdirs()
      Creates the directory named by this abstract pathname, including any necessary but nonexistent parent directories
    boolean createNewFile()
      Creates a new, empty file named by this abstract pathname if and only if a file with this name does not yet exist
    boolean exists()
      Tests whether the file or directory denoted by this abstract pathname exists
    boolean isDirectory()
      Tests whether the file denoted by this abstract pathname exists and is a directory
    File[] listFiles()
      If this is a directory, returns the array of files it contains
      Can take a FileFilter as an argument, so that it just returns the files that match it
    boolean isFile()
      Tests whether the file denoted by this abstract pathname exists and is a file
    boolean isHidden()
      Tests whether the file named by this abstract pathname is a hidden file
    boolean canExecute()
      Tests whether the application can execute the file denoted by this abstract pathname
    String getAbsolutePath()
      Returns the absolute pathname string of this abstract pathname
    
java.nio.Path interface
  An interface used to locate a file in a file system. It will typically represent a system dependent file path
  There is no publicly accessible class that implements the Path interface, 
    which means Path objects cannot be instantiated directly
  The only static method in Path interface is
    Path of(String...)
      Returns a Path by converting a path string, or a sequence of strings
  The main methods of Path interface are
    File toFile()
      Returns a File object representing this path
    boolean isAbsolute()
      Tells whether or not this path is absolute
    Path toAbsolutePath()
      Returns a Path object representing the absolute path of this path
    Path resolve(Path) | Path resolve(String)
      If the argument to the resolve method is a relative path,
        the resolve method assumes that the given path is relative to the path on which the method is called
        therefore it just joins the two paths to create the actual path to the file, for example
        if this path represents “c/drive/files”, then invoking this method with the string “file1” will result in the Path “c/drive/files/file1”
      If the argument is an absolute path, there is nothing to resolve and it returns the same path as argument
    Path relativize(Path)
      Finds a path to the given file relative fo the path on which it is invoked

java.nio.Files class
  Consists exclusively of static methods that operate on files, directories, or other types of files
  The main methods of Files class are
    InputStream Files.newInputStream(Path)
      Opens a file, returning an input stream to read from the file
    OutputStream Files.newOutputStream(Path)
      Opens or creates a file, returning an output stream that may be used to write bytes to the file
    Path createFile(Path, FileAttribute...)
      Creates a new and empty file in the provided Path, failing if the file already exists, and returns Path
    Path createDirectory(Path, FileAttribute...)
      Creates a new directory and returns Path
    Path createDirectories(Path, FileAttribute...)
      Creates a directory in the provided Path, by creating all nonexistent parent directories first, returns Path
    boolean isDirectory(Path, LinkOption...)
      Tests whether a file in the provided Path is a directory
    boolean isRegularFile(Path, LinkOption...)
      Tests whether a file in the provided Path is a regular file
    void delete(Path)
      Deletes the file in the provided path
    void deleteIfExists(Path)
      Deletes the file in the provided path, if exists
    Path copy(Path, Path, CopyOption...)
      Copy the file in the source path to the target path and returns Path
    Path move(Path, Path, CopyOption...)
      Copy the file in the source path to the target path and returns Path
    boolean exists(Path, LinkOption...)
      Tests whether a file exists in the provided path=
    byte[] readAllBytes(Path)
      Reads all the bytes from a file and returns a byte[]
    List<String> readAllLines(Path, Charset?)
      Read all lines from a file and returns a List<String>
    <T extends BasicFileAttributes> T readAttributes(Path, Class<T>, LinkOption...)
      Reads a file's attributes as a bulk operation and returns a type extending BasicFileAttributes
    Stream<String> lines(Path, Charset?)
      Read all lines from a file as a Stream
      Populates lazily as the stream is consumed
    Path write(Path, byte[], OpenOption...) | Path write(Path, Iterable<? extends Charsequence>, OpenOption...)
      Writes bytes to a file
    Path writeString(Path, CharSequence, OpenOption...)
      Write a CharSequence to a file
    Stream<Path> walk(Path, FileVisitOption...)
      Return a Stream that is lazily populated with Path by walking the file tree rooted at a given starting fil
      The file tree is traversed depth-first, 
        the elements in the stream are Path objects that are obtained as if by resolving the relative path against start
    Path walkFileTree(Path, FileVisitor<? super Path>)
      Walks a file tree rooted at a given starting file
      The file tree traversal is depth-first with the given FileVisitor invoked for each file encountered. 
      File tree traversal completes when all accessible files in the tree have been visited, 
        or a visit method returns a result of TERMINATE
      Can handle symbolic links that create cycles
        If a symbolic link causes a loop in the file hierarchy, the method detects it and skips that part of the traversal

java.nio.file.attribute.BasicFileAttributes interface
  Methods
    FileTime creationTime()
      This method is used to get the creation time of the file
    FileTime lastAccessTime()
      This method is used to get the last access time of the file
    FileTime lastModifiedTime()
      This method is used to get the last modified time of the file
    boolean long size()
      This method is used to get the size of the file
    boolean isDirectory()
      This method is used to check whether the file is a directory or not
    boolean isSymbolicLink()
      This method is used to check whether the file is a symbolic link or not
    boolean isRegularFile()
      This method is used to check whether the file is regular or not
    boolean isOther()
      This method is used to check whether the file is something other than a regular file, or directory, or symbolic link

FileFilter interface
  Is used to check if a File object matches a certain condition
  Contains a single boolean accept(File pathName) method, which must be overridden and implemented

IO Streams
  Streams are the sequence of data that are read from the source and written to the destination
  Input streams read data from the source, while output streams write data to a destination
  Byte streams
    Read byte by byte
    A byte stream is suitable for processing raw data like binary files, images or audio
    InputStream interface
      Abstract class that represents an input stream of bytes
      Its main methods are
        int read()
          Reads the next byte of data from the input stream. 
          The value byte is returned as an int in the range 0 to 255. 
          If no byte is available because the end of the stream has been reached, the value -1 is returned,
            this is the reason why read() method returns an int instead of a byte: it need to represent negative values 
          This method blocks until input data is available, the end of the stream is detected, or an exception is thrown
        int read(byte[], int?, int?)
          Reads some number of bytes from the input stream and stores them into the input buffer array
          The number of bytes actually read is returned as an integer
          This method blocks until input data is available, the end of the stream is detected, or an exception is thrown
        byte[] readAllBytes()
          Read all the bytes from the input stream
          This method does not close the input stream,
            when this stream reaches end of stream, 
            further invocations of this method will return an empty byte array
        long skip(long)
          Skips over and discards n bytes of data from this input stream
        int available()
          Returns an estimate of the number of bytes that can be read (or skipped over) from this input stream without blocking
        void mark(int)
          Marks the current position in this input stream
          It may take an integer parameter that will work as a read-ahead limit,
            meaning thed reset method will reset the stream to this position
            as long as you don't read more than the read-ahead limit bytes after marking
        void reset()
          Repositions this stream to the position at the time the mark method was last called on this input stream
        void close()
          Closes this input stream and releases any system resources associated
      Its main subclasses are
        FileInputStream
          Obtains input bytes from a file in a file system
        ByteArrayInputStream
          Converts a byte[] into a stream of bytes
        ObjectInputStream
          Obtains Java objects contained in a byte array (used to deserialize)
        DataInputStream
          Obtains primitive data types from an input bytestream
    OutputStream interface
      Abstract class that represents an output stream of bytes
      Its main methods are
        void write(int)
          Writes the input byte to the output stream
        void write(byte[], int?, int?)
          Writes the specified number of bytes from the specified byte array to this output stream
        void flush()
          Flushes this output stream and forces any buffered output bytes to be written out
          Bytes are not written if this method is not called
        void close()
          Closes this output stream and releases any system resources associated
          Some implementations call the flush() method when the close() method is called
      Its main subclasses are
        ByteArrayOutputStream          
          Converts a stream of bytes into a byte[] 
        FileOutputStream
          Writes a stream of bytes into a file
        ObjectOutputStream
          Converts java objects into a stream of bytes (used to serialize)
        DataOutputStream
          Converts primitive data types into a bytestream
  Character streams
    Read character by character, so is useful to process text files
    Character size is typically 16 bits
    Reader abstract class
      Abstract class for reading character streams 
      Its main methods are
        int read()
          Reads a single character and returns it as int
          This method will block until a character is available, an I/O error occurs, or the end of the stream is reached
        int read(char[], int?, int?)
          Reads characters from the stream, writes them to the argument char[]
            and returns the number of characters read, or -1 if the end of the stream has been reached
          This method will block until some input is available, an I/O error occurs, or the end of the stream is reached
        long skip(long)
          Skips the number of characters provided
        boolean ready()
          Tells whether this stream is ready to be read
        boolean markSupported()
          Tells whether this stream supports the mark()
        void mark(int)
          Marks the present position in the stream
          Subsequent calls to reset() will attempt to reposition the stream to this point
        void reset()
          If the stream has been marked, then attempt to reposition it at the mark
          If the stream has not been marked, then attempt to reset it in some way appropriate to the particular stream, 
            for example by repositioning it to its starting point
        void close()    
          Closes the stream and releases any system resources associated with it
          Once the stream has been closed, further read(), ready(), mark(), reset(), or skip() invocations will throw an IOException
          Closing a previously closed stream has no effect
        long transferTo(Writer)
          Reads all characters from this reader and writes the characters to the given writer in the order that they are read
      Its main subclasses are 
        FileReader, StringReader
    Writer abstract class
      Abstract class for writing to character streams
      Its main methods are
        void write(char[]) | void write(String)
          Writes characters or strings to the stream
        void write(char[], int, int) | void write(String, int, int)
          Writes a portion of characters or a String to the stream
        Writer append(CharSequence, int?, int?)
          Appends the specified character sequence to this writer
        void flush()
          If the stream has saved any characters from the various write() methods in a buffer, 
            write them immediately to their intended destination
          Characters or strings are not written if this method is not called
        void close()
          Closes the stream, flushing it first
          Once the stream has been closed, further write() or flush() invocations will cause an IOException to be thrown
          Closing a previously closed stream has no effect
      Its main subclasses are 
        FileWriter, StringWriter, PrintWriter
  BufferedInputStream, BufferedOutputStream, BufferedReader and BufferedWriter
    Are I/O wrapper classes, which means they wrap an existing I/O stream
    Create a buffer (default size 8192 bytes) for input, output, reading or writing
    It performs most of operations within the buffer, and without a call to the underlying system
    Without a buffer, the stream has to make a system call for every single byte, which affects performance

Charset
  A Charset is a named mapping between sequences of sixteen-bit Unicode code units and sequences of bytes
  Charset abstract class
  StandardCharsets class
    Contains static constants definitions for the standard charsets, which are:
      US_ASCII
      ISO_8859_1
      UTF_8
      UTF_16BE
      UTF_16LE
      UTF_16

RandomAccessFile class
  Is a class that inherits directly from Object and not from any IO classes
  It is designed to work with files, supporting random access to their contents
  It implements DataInput and DataOutput interfaces, 
    so working with this class is similar to using the DataInputStream and DataOutputStream streams combined
  Read / write modes 
    Read ("r") 
    Read/write ("rw") mode. 
    "rws" mode 
      The file is opened for read/write operations and every change to the file's data is immediately written to the physical device

System.out
  Is a final public static variable
  Refers to java.io.PrintStream object that represents the console
  Unlike other I/O stream class, methods of PrintStream do not throw any checked exception
    to check if any error occurred, its checkError() method can be called
System.in
  Is a final public static variable
  Refers to an InputStream object that is usually connected to keyboard input of the machine
  Since methods of InputStream may throw IO exception, a call to read requires code to handle that exception
  The keys pressed by the user do not flow until the user presses the enter key
java.io.Console
  Provides a higher level of abstraction for the console associated with the Java program
  Console class does not have any public constructor. There is only one Console object for the entire application
  Can be acquired by calling System.console(), that may return null if no console is associated with the JVM
  Has the methods
    Console format(String, Object...)
      Writes a formatted string to the console output string using the specified format string and arguments
    Console printf(String, Object...)
      Convenience method that works exactly the same as format() method
    String readLine()
      Reads a single line of text from the console
    String readLine(String, Object...)
      Provides a formatted prompt, then reads a single line of text from the console
    char[] readPassword(String, Object...)
      Reads a password or passphrase from the console with echoing disabled
    char[] readPassword(String, Object...)
      Provides a formatted prompt, then reads a password or passphrase from the console with echoing disable