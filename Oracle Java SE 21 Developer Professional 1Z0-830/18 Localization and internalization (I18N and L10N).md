Internazionalization (I18N) 
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
        For example, what calendar to use when displaying dates, Gregorian, Arab, Japanese, etc
  Some static constants
    ENGLISH, FRENCH, GERMAN, ITALIAN, JAPANESE, KOREAN, CHINESE, SIMPLIFIED_CHINESE,
    TRADITIONAL_CHINESE, FRANCE, GERMANY, ITALY, JAPAN, KOREA, UK, US, CANADA
    ROOT
      The root locale is the locale whose language, country, and variant are empty ("") strings
  Main methods
    getLanguage(), getScript(), getCountry(), getVariant(), hasExtensions(), getExtension(), toLanguageTag(),
    getDisplayLanguage(), getDisplayScript(), getDisplayCountry(), getDisplayString(), getDisplayVariant(), getDisplayName()
  Main static methods
    of(), getDefault(), setDefault(), getInstance(), getAvailableLocales(), getISOCountries(), getISOLanguages(),
    filter(), filterTags(), lookup(), lookupTag()
  Examples
    Locale locale1 = new Locale("en"); // Creates local of english language
    Locale locale2 = new Locale("en", "US"); // Creates local of english language and US country
    Locale locale3 = new Locale("en", "US", "SiliconValley"); // Creates local of english language, US country and variant SiliconValley

Methods that return an array of available Locale
  DateFormat.getAvailableLocales()
    Returns all date format locales
  NumberFormat.getAvailableLocales()
    Returns all number format locales
  Locale.getAvailableLocales()
    Returns all locales

Resource bundles
  When a program needs a locale-specific resource, a String for example, 
    the program can load it from the resource bundle that is appropriate for the current user's locale. 
    In this way, program code is largely independent of the user's locale isolating most, if not all, 
    of the locale-specific information in resource bundles
  java.util.ResourceBundle abstract class
    Contain locale-specific objects
    Main methods
      getBaseBundleName, getString(), getStringArray(), getObject(), getLocale(), getKeys(), containsKey(), keySet()
    Main static methods
      getBundle()
        Gets a resource bundle using the specified base name, the default locale, and the caller module
        Takes a bundle based on default Locale, for example supposing specified base name is MyLabels,
          if default Locale is ru_RU, it will load from MyLabels_ru_RU.prop,
          if default Locale is en_US, it will load from MyLabels_en_US.prop,
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
      getContents(), handleKeySet(), getKeys(), handleGetObject()
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