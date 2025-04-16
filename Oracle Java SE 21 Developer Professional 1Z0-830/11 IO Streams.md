java.io package provides for system input and output through data streams, serialization and the file system
java.nio package defines buffers, which are containers for data, and other structures, such as charsets, channels, and selectable channels

System.lineSeparator()
  Returns the default system-dependent line separator 
    Line separator is the character that tells the system to break the line (like \n)

java.io.File class
  Is an abstract representation of file and directory pathnames
  Can be created in the way
    File file = new File("testDirectory"); // testDirectory is converted into an abstract pathname
  Contains the static fields
    separator  
      The system-dependent default name-separator character, represented as a string
    pathSeparator
      The system-dependent path-separator character, represented as a string
    separatorChar
      The system-dependent name-separator character
    pathSeparatorChar
      The system-dependent path-separator character
  The main methods of File class are
    mkdir()
      Creates the directory named by this abstract pathname
    mkdirs()
      Creates the directory named by this abstract pathname, including any necessary but nonexistent parent directories
    createNewFile()
      Creates a new, empty file named by this abstract pathname if and only if a file with this name does not yet exist
    exists()
      Tests whether the file or directory denoted by this abstract pathname exists
    isDirectory()
      Tests whether the file denoted by this abstract pathname exists and is a directory
    listFiles()
      If this is a directory, returns the array of files it contains
      Can take a FileFilter as an argument, so that it just returns the files that match it
    isFile()
      Tests whether the file denoted by this abstract pathname exists and is a file
    isHidden()
      Tests whether the file named by this abstract pathname is a hidden file
    canExecute()
      Tests whether the application can execute the file denoted by this abstract pathname
    getAbsolutePath()
      Returns the absolute pathname string of this abstract pathname
    walk()
      Return a Stream that is lazily populated with Path by walking the file tree rooted at a given starting fil
      The file tree is traversed depth-first, 
        the elements in the stream are Path objects that are obtained as if by resolving the relative path against start
    walkFileTree()
      Walks a file tree rooted at a given starting file
      The file tree traversal is depth-first with the given FileVisitor invoked for each file encountered. 
      File tree traversal completes when all accessible files in the tree have been visited, 
        or a visit method returns a result of TERMINATE
      Can handle symbolic links that create cycles
        If a symbolic link causes a loop in the file hierarchy, the method detects it and skips that part of the traversal
        

java.nio.Path class
  An interface used to locate a file in a file system. It will typically represent a system dependent file path
  The main methods of Path interface are
    of()
      Returns a Path by converting a path string, or a sequence of strings
    toFile()
      Returns a File object representing this path
    isAbsolute()
      Tells whether or not this path is absolute
    toAbsolutePath()
      Returns a Path object representing the absolute path of this path
    resolve()
      Resolve the given path against this path, for example
        if this path represents “c/drive/files”, then invoking this method with the string “file1” will result in the Path “c/drive/files/file1”

java.nio.Files class
  Consists exclusively of static methods that operate on files, directories, or other types of files
  The main methods of Files class are
    createFile()
      Creates a new and empty file in the provided Path, failing if the file already exists, and returns Path
    createDirectory()
      Creates a new directory and returns Path
    createDirectories()
      Creates a directory in the provided Path, by creating all nonexistent parent directories first, returns Path
    isDirectory()
      Tests whether a file in the provided Path is a directory
    isRegularFile()
      Tests whether a file in the provided Path is a regular file
    delete()
      Deletes the file in the provided path
    copy()
      Copy the file in the source path to the target path and returns Path
    move()
      Copy the file in the source path to the target path and returns Path
    exists()
      Tests whether a file exists in the provided path
    read()
      Reads all the bytes from an input stream and returns a byte[]
    readAllBytes()
      Reads all the bytes from a file and returns a byte[]
    readAllLines()
      Read all lines from a file and returns a List<String>
    readAttributes()
      Reads a file's attributes as a bulk operation and returns a type extending BasicFileAttributes
    lines()
      Read all lines from a file as a Stream
      Populates lazily as the stream is consumed
    write()
      Writes bytes to a file
    writeString()
      Write a CharSequence to a file

java.nio.file.attribute.BasicFileAttributes
  Methods
    creationTime()
      This method is used to get the creation time of the file
    lastAccessTime()
      This method is used to get the last access time of the file
    lastModifiedTime()
      This method is used to get the last modified time of the file
    size()
      This method is used to get the size of the file
    isDirectory()
      This method is used to check whether the file is a directory or not
    isSymbolicLink()
      This method is used to check whether the file is a symbolic link or not
    isRegularFile()
      This method is used to check whether the file is regular or not
    isOther()
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
        read()
          Read bytes from the input stream
          Accepts parameters to read just certain bytes
        readAll()
          Read all the bytes from the input stream
        skip()
          Skips over and discards n bytes of data from this input stream
        available()
          Returns an estimate of the number of bytes that can be read (or skipped over) from this input stream without blocking
        mark()
          Marks the current position in this input stream
        reset()
          Repositions this stream to the position at the time the mark method was last called on this input stream
        close()
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
        write()
          Writes bytes to the output stream
          Accepts parameters to write just certain bytes
        flush()
          Flushes this output stream and forces any buffered output bytes to be written out
          Bytes are not written if this method is not called
        close()
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
        read()
          Reads characters from the stream, writes them to the argument char[]
            and returns the number of characters read, or -1 if the end of the stream has been reached
        skip()
          Skips the number of characters provided
        ready()
          Tells whether this stream is ready to be read
        markSupported()
          Tells whether this stream supports the mark()
        mark()
          Marks the present position in the stream
        reset()
          If the stream has been marked, then attempt to reposition it at the mark. 
          If the stream has not been marked, then attempt to reset it in some way appropriate to the particular stream, 
            for example by repositioning it to its starting point
        close()    
          Closes the stream and releases any system resources associated with it
        transferTo()
          Reads all characters from this reader and writes the characters to the given writer in the order that they are read
      Its main subclasses are 
        FileReader, StringReader
    Writer abstract class
      Abstract class for writing to character streams
      Its main methods are
        write()
          Write characters or strings to the stream
        append()
          Appends the specified character sequence to this writer
        flush()
          If the stream has saved any characters from the various write() methods in a buffer, 
            write them immediately to their intended destination
          Characters or strings are not written if this method is not called
        close()
          Closes the stream, flushing it first
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