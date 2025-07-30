Internationalization (I18N) 
  Process of designing and developing your software or mobile application product, 
    so it can be adopted and localized to different cultures, regions and languages
  Instead of coding the software for each specific language, the internationalization process replaces that code with keys
    Then, inside a localized configuration file, the same key define content for the localized language

Location (L10N)
  Process of adapting your internationalized software to meet the language, cultural, 
    and other requirements of a specific target market, otherwise known as locale
  Some localized data includes currencies, number format, date format, images, etc.

java.util.Locale
  Represents a specific geographical, political, or cultural region
  An operation that requires a Locale to perform its task is called locale-sensitive and uses the Locale to tailor information for the user
  The local class can't do any internationalization or localization by itself instead this is done by local sensitive classes
  This class contains static constants for multiple Locales, a Builder, 
    the Locale.IsoCountryCode enum, the Locale.Category enum, the Locale.FilteringMode enum and the Locale.LanguageRange enum
  The Locale constructor takes a BaseLocale and a LocaleExtensions arguments
  Contains properties
    language
      Must be a valid ISO 639, alpha two or alpha three code of registered language
      A full list of language codes can be found in the IANA (Internet Assigned Numbers Authority) language Subtag registry
    script
      Represents the written form of the language
      Must be a valid ISO 15924 alpha four code
    region 
      Also known as country
      Is a two character code following the ISO 3166 standard, or an UN M49 numeric area code
      A full list of country codes can be found in the IANA (Internet Assigned Numbers Authority) language Subtag registry
    variant
      Case sensitive value or set of values specifying a variation of a local.
      Describes a variant dialect of a language following the BCP 47 standard extensions
    extension
      Signals extensions to the local in addition to the language and region.
        For example, what calendar to use when displaying dates, Gregorian, Arab, Japanese, etc.
  static enum Locale.Category  
    A Locale also captures a "category" that tells whether locale information is meant for UI or text output
    Contains just two constants
      DISPLAY, FORMAT
  Some static constants
    ENGLISH, FRENCH, GERMAN, ITALIAN, JAPANESE, KOREAN, CHINESE, SIMPLIFIED_CHINESE,
    TRADITIONAL_CHINESE, FRANCE, GERMANY, ITALY, JAPAN, KOREA, UK, US, CANADA
    ROOT
      The root locale is the locale whose language, country, and variant are empty ("") strings
  Main methods
    boolean hasExtensions()
    String getLanguage()
    String getScript()
    String getCountry()
    String getVariant()
    String getExtension(char)
    String toLanguageTag()
    String getDisplayLanguage(Locale?)
    String getDisplayScript(Locale?)
    String getDisplayCountry(Locale?)
    String getDisplayVariant(Locale?)
    String getDisplayName(Locale?)
  Main static methods
    Locale of(String, String?, Locale?)
    Locale getDefault(Category?)
    void setDefault(Category? Locale)
    Locale getInstance(String, String, String)
    Locale[] getAvailableLocales()
    String[] getISOCountries()
    String[] getISOLanguages()
    List<Locale> filter(List<LanguageRange>, Collection<Locale>, FilteringMode?)
    List<String> filterTags(List<LanguageRange>, Collection<String>)
    Locale lookup(List<LanguageRange>, Collection<Locale>)
    String lookupTag(List<LanguageRange>, Collection<String>)
  Examples
    Locale locale1 = new Locale("en"); // Creates local of english language
    Locale locale2 = new Locale("en", "US"); // Creates local of english language and US country
    Locale locale3 = new Locale("en", "US", "SiliconValley"); // Creates local of english language, US country and variant SiliconValley
    Locale locale4 = new Locale.Builder.setLanguage("en").setRegion("US).build(); // Creates local of english language and US country

Methods that return an array of available Locale
  Locale[] DateFormat.getAvailableLocales()
    Returns all date format locales
  Locale[] NumberFormat.getAvailableLocales()
    Returns all number format locales
  Locale[] Locale.getAvailableLocales()
    Returns all locales

java.text.NumberFormat
  Can format a number as per the local standard
    int oneMillion = 1_000_000;
    Locale frFR = Locale.of("fr", "FR");
    System.out.println(NumberFormat.getCurrencyInstance(frFR).format(oneMillion)); // Prints $1 000 000,00 €
    System.out.println(NumberFormat.getPercentageInstance(frFR).format(0.1)); // Prints 10 %
    Locale enUs = Locale.of("en", "US");
    System.out.println(NumberFormat.getCurrencyInstance(enUS).format(oneMillion)); // Prints $1,000,000.00
    System.out.println(NumberFormat.getCurrencyInstance(enUS).format(0.1)); // Prints 10%
  NumberFormat instance can also be used to parse a string containing number written in a locale specific manner
    NumberFormat compactNumberFormat = NumberFormat.getCompactNumberInstance();
    Long number = compactNumberFormat.parse("1M"); // Value is 1000000
  The return type of the parse() method is Number, 
    but it may return a Double or a Long,
    depending on whether the string has digits after decimal or not
  parse() method can potentially throw java.text.ParseException, which is a checked exception

java.text.MessageFormat
  Instead of hardcoding string concatenation, you can specify parameters in the message string,
    and at runtime, format the string by passing values for those parameters
  Example
    String message = "On {0, date, short}, you balance was {1, number, currency}";
    System.out.println(MessageFormat.format(message, new Object[] {new Date(), 100})); // Will print "On 10/05/24, your balance was $100.00"

Resource bundles
  When a program needs a locale-specific resource, a String for example, 
    the program can load it from the resource bundle that is appropriate for the current user's locale. 
    In this way, program code is largely independent of the user's locale isolating most, if not all, 
    of the locale-specific information in resource bundles
  Every ResourceBundle object has a name, 
    and the program uses that name to load files that contain locale specific entries,
    program can just lookup up a key in that resource bundle and use the returned locale specific value
  The name of the keys in the properties file can be anything but the code must use the same key to loop the value
  The backslashes "\" in properties files are required to escape the space character
  Hierarchy
    Resource bundles are hierarchical, meaning a resource bundle always has a parent bundle,
      unless is at the top of the hierarchy, in which case is called "base bundle"
    Hierarchy of a resource bundle is established using a set of resource bundles
      whose name start with a common base name.
      The remaining part of the name is created using the following attributes:
      baseName + "_" + language + "_" + script + "_" + country + "_" + variant,
    Examples:
      app.properties // Base bundle
      app_fr.properties
      app_fr_CA.properties
      app_fr_FR.properties
    When a key is not found in a particular bundle, 
      it is automatically searched for in the parent bundle,
      when not found in any ancestor bundles, MissingResourceException is thrown
    Search for a key only propagates up the hierarchy and never to a child or sibling
    Creation of a ResourceBundle triggers the creation of its parent bundle as well
  java.util.ResourceBundle abstract class
    Contain locale-specific objects
    Main methods
      String getBaseBundleName()
      String getString(String)
      String[] getStringArray(String)
      Object getObject(String)
      Locale getLocale()
      Enumeration<String> getKeys()
      boolean containsKey(String)
      Set<String> keySet()
    Main static methods
      ResourceBundle getBundle(String, Locale?, Module?)
        Gets a resource bundle using the specified base name, the default locale, and the caller module
        Takes a bundle based on default Locale, for example supposing specified base name is MyLabels,
          if default Locale is ru_RU, it will load from MyLabels_ru_RU.properties,
          if default Locale is en_US, it will load from MyLabels_en_US.properties,
          if default Locale file is not found, it will load by default from MyLabels.properties 
    Example
      In program
  		  Locale.setDefault(Locale.of("ru", "RU"));
        ResourceBundle mybundle = ResourceBundle.getBundle("MyLabels");
  		  System.out.println("\"Welcome\" in Russian:\t" + mybundle.getString("welcome.message"));
  		  System.out.println("\"Login Button Text\" in Russian:\t" + mybundle.getString("login.button.text"));

  		  Locale.setDefault(Locale.of("en", "US"));
  		  mybundle = ResourceBundle.getBundle("MyLabels");
  		  System.out.println("\"Welcome\" in English language:\t" + mybundle.getString("welcome.message"));
  		  System.out.println("\"Login Button Text\" in English:\t" + mybundle.getString("login.button.text"));

        Locale.setDefault(Locale.of("hi", "IN"));
        mybundle = ResourceBundle.getBundle("MyLabels");
        System.out.println("\"Welcome\" in default version:\t" + mybundle.getString("welcome.message"));
        System.out.println("\"Login Button Text\" in default version:\t" + mybundle.getString("login.button.text"));
      In bundles
        MyLabels.properties (default bundle)
          # comment
          welcome.message=Welcome!
          ! comment
          login.button.text=Sign in
        MyLabels_en_US.properties
          welcome.message Welcome!
          login.button.text=Sign in        
        MyLabels_ru_RU.properties
          welcome.message=\u041F\u0440\u0438\u0432\u0435\u0442\u0441\u0442\u0432\u0443\u044E!
  java.util.ListResourceBundle abstract class
    Subclass of ResourceBundle that manages resources for a locale in a convenient and easy to use list
    ListResourceBundle can store any serializable object, while PropertyResourceBundle is limited to strings only
    Main methods
      Object[][] getContents()
      Set<String> handleKeySet()
      Enumeration<String> getKeys()
      Object handleGetObject(String)
    Example
      In program
        Locale.setDefault(Locale.of("de", "DE"));
        mybundle = ResourceBundle.getBundle("org.example.MyLabels");
        Integer object = (Integer) mybundle.getObject("integer_value");
        System.out.println(object);
      In org.example.MyLabels
        public class MyLabels_de_DE extends ListResourceBundle {
          @Override
          protected Object[][] getContents() {
            return labels;
          }
          private Object[][] labels = {
            { "integer_value" , 100 },
            { "string_value", "MILES" },
          };
        }
  Priority
    If locale is ru_RU, then priority will be the following one
      1. MyLabels_ru_RU
      2. MyLables_ru
      3. MyLabels
      4. MyLabels_{default language set with Locale.setDefault()}
    Each name represents both .java and .properties files, but the priority will go with java bundles