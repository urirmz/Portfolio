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

java.nio.Path 
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

java.nio.Files
  Consists exclusively of static methods that operate on files, directories, or other types of files
  The main methods of Files class are
    createFile()
      Creates a new and empty file in the provided Path, failing if the file already exists
    createDirectory()
      Creates a new directory
    createDirectories()
      Creates a directory in the provided Path, by creating all nonexistent parent directories first
    isDirectory()
      Tests whether a file in the provided Path is a directory
    isRegularFile()
      Tests whether a file in the provided Path is a regular file
    delete()
      Deletes the file in the provided path
    copy()
      Copy the file in the source path to the target path
    move()
      Copy the file in the source path to the target path
    exists()
      Tests whether a file exists in the provided path

IO Streams
  Streams are the sequence of data that are read from the source and written to the destination
  Input streams read data from the source, while output streams write data to a destination
  Byte streams
    Read byte by byte
    A byte stream is suitable for processing raw data like binary files, images or audio
    InputStream
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
        ByteArrayInputStream, StringBufferInputStream, FileInputStream
    OutputStream
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
        BufferedOutputStream, ByteArrayOutputStream, DataOutputStream
  Character streams
    Read character by character, so is useful to process text files
    Character size is typically 16 bits
    Reader
    Writer