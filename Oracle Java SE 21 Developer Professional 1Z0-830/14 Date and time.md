GMT
  Greenwich Mean Time, based on the time provided by the Royal Observatory of Greenwich
  Before UTC, it was considered the universal time
UTC
  Universal Time Coordinated
  Is based on Earth's rotation relative to distant celestial objects, stars, and quasars
    with a scaling factor and other adjustments to make them closer to solar time

Unix epoch time
  Instants in time are represented by a millisecond value that is an offset from the 
    January 1st 1970s midnight GMT

Calendar class abstract class 
  Provides methods for converting between a specific instant in time and a 
    set of calendar fields such as YEAR, MONTH, DAY_OF_MONTH, HOUR, and so on, and 
    for manipulating the calendar fields, such as getting the date of the next week
  Is not thread safe
  Main methods
    getInstance()
      Gets a calendar using the default time zone and locale
      The Calendar returned is based on the current time in the default time zone with the default FORMAT locale,
        unless a custom Locale or TimeZone is specified
    getTime()
      Returns a Date object representing this Calendar's time value
    get()
      Returns the value of the given calendar field
    set()
      Sets the given calendar field to the given value
    isSet()
      Determines if the given calendar field has a value set, 
        including cases that the value has been set by internal fields calculations triggered by a get method call
    clear()
      Sets all the calendar field values and the time value (millisecond offset from the Epoch) of this Calendar undefined
      isSet() will return false for all the calendar fields
    getDisplayName()
      Returns the string representation of the calendar field value in the given style and locale
      If no string representation is applicable
    add()
      Adds or subtracts the specified amount of time to the given calendar field
    roll()
      Adds or subtracts (up/ down) a single unit of time on the given time field without changing larger fields
  Main static fields
    YEAR, MONTH, WEEK_OF_YEAR, WEEK_OF_MONTH, DATE, DAY_OF_MONTH, DAY_OF_WEEK, DAY_OF_MONTH, AM_PM, HOUR_OF_YEAR, 
    HOUR, MINUTE, SECOND, MILLISECOND, MONDAY...SUNDAY, JANUARY...DECEMBER
  Main subclasses
    GregorianCalendar
      Provides the standard calendar system used by most of the world

SimpleDateFormat
  Allows formatting and parsing dates in a locale-sensitive manner
  Allows for formatting (date → text), parsing (text → date), and normalization
  Takes a pattern and a Locale as optional arguments, if these are not specified, it will use system default values
  Main methods
    format()
      Formats the given Date into a date/ time string and appends the result to the given StringBuffer
    parse()
      Parses text from a string to produce a Date

TimeZone class
  Represents a time zone offset, and also figures out daylight savings
  Main methods
    getTimeZone()
      Gets the TimeZone for the given ID
    toZoneId()
      Converts this TimeZone object to a ZoneId

java.time package
  Use nanosecond precision
  Machine scale time classes
    Instant class
      Represent an instant on the time line
    Duration class
      Represent a duration of time
  Human scale time classes
    Classes represent a time without a time zone in the ISO-8601 calendar system
      LocalDate
      LocalTime
      LocalDateTime
    Classes that store all date and time fields, as well as the offset from GMT UTC
      OffsetTime
      OffsetDateTime
      ZonedDateTime
    ZoneOffset
      A time-zone offset from Greenwich/ UTC, such as +02:00
    ZoneId class
      A time-zone ID, such as Europe/ Paris
      Is used to identify the rules used to convert between an Instant and a LocalDateTime
      Main methods
        getAvailableZoneIds()
          Gets the set of available zone IDs
        of()
          Obtains an instance of {@code ZoneId} from an ID ensuring that the ID is valid and available for use
  Common method naming for java.time package classes (API naming convention)
    get
      Gets the specified value with
    with
      Returns a copy of the object with the specified value changed. 
        For example such methods as withHour, withSecond that set the specific value to a particular time unit
    plus/minus
      Returns a copy of the object with the specified value added/subtracted
    multipliedBy/dividedBy/negated
      Returns a copy of the object with the specified value multiplied/divided/negated
    to
      Converts the object to another related type
    at
      Returns a new object consisting of this date-time at the specified argument, acting as the builder pattern
    of 
      Factory methods that don't involve data conversion
    from 
      Factory methods that do involve data conversion
  TemporalUnit interface
    A unit of date-time, such as Days or Hours
    Contains the methods
      getDuration(), isDurationEstimated(), isDateBased(), isTimeBased(), 
      isSupportedBy(), addTo(), beetween(), toString()
  TemporalAmount interface
    Framework-level interface defining an amount of time, such as "6 hours", "8 days" or "2 years and 3 months"
    Contains the methods
      get(), getUnits(), addTo(), subtractFrom()
  ChronoUnit enum
    Implements TemporalUnit
    Contains a standard set of date periods units
      NANOS, MICROS, MILLIS, SECONDS, MINUTES, HOURS, HALF_DAYS, DAYS, WEEKS, 
      MONTHS, YEARS, DECADES, CENTURIES, MILLENNIA, ERAS, FOREVER
  Clock abstract class
    A clock providing access to the current instant, date and time using a time-zone
    Can be interpreted using the stored time-zone to find the current date and time
      Clock can be used instead of System.currentTimeMillis() and TimeZone.getDefault()
    Main static methods
      systemUTC()
        Obtains a clock that returns the current instant using the best available system clock, 
          converting to date and time using the UTC time-zone
      systemDefaultZone()
        Obtains a clock that returns the current instant using the best available system clock, 
          converting to date and time using the default time-zone
      offset()
        Obtains a clock that returns instants from the specified clock with the specified duration added
      fixed()
        Obtains a clock that always returns the same instant
  Period interface
    Similar to duration, but this class models a quantity or amount of time in terms of years, months and days,
      unlike hours, seconds and milliseconds