Hashmap
A HashMap is, in addition to ArrayList, one of the most widely used of Java's pre-built data structures. The hash map is used whenever data is stored as key-value pairs, where values can be added, retrieved, and deleted using keys.
In the example below, a HashMap object has been created to search for cities by their postal codes, after which four postal code-city pairs have been added to the HashMap object. At the end, the postal code "00710" is retrieved from the hash map. Both the postal code and the city are represented as strings.
HashMap<String, String> postalCodes = new HashMap<>();
postalCodes.put("00710", "Helsinki");
postalCodes.put("90014", "Oulu");
postalCodes.put("33720", "Tampere");
postalCodes.put("33014", "Tampere");
System.out.println(postalCodes.get("00710"));
Sample output
Helsinki
If the hash map does not contained the key used for the search, its get method returns a null reference.

Using hashmaps
Using a hash map requires the import java.util.HashMap; statement at the beginning of the class.
Two type parameters are required when creating a hash map - the type of the key and the type of the value added. If the keys of the hash map are of type string, and the values of type integer, the hash map is created with the following statement HashMap<String, Integer> hashmap = new HashMap<>();
Adding to the hash map is done through the put(*key*, *value*) method that has two parameters, one for the key, the other for the value. Retrieving from a hash map happens with the help of the get(*key*) method that is passed the key as a parameter and returns a value.