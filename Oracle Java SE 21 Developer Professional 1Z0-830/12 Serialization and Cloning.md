Serialization is the process of converting objects to a stream of bytes
  Example of serialization method
    public static byte[] serializeProduct(Product product) {
        try (var byteArrayOutputStream = new ByteArrayOutputStream();
             var objectOutputStream = new ObjectOutputStream(byteArrayOutputStream)) {
            objectOutputStream.writeObject(product);
            return byteArrayOutputStream.toByteArray();
        } catch (Exception exception) {
            System.out.println(exception);
        }
        return  null;
    }

Deserialization is the process of converting a stream of bytes into objects
  Example of deserialization method
    private static Product deserializeProduct(byte[] serializedProduct) {
        try (var byteArrayInputStream = new ByteArrayInputStream(serializedProduct);
             var objectInputStream = new ObjectInputStream(byteArrayInputStream);) {
            return (Product) objectInputStream.readObject();
        } catch (Exception exception) {
            System.out.println(exception);
        }
        return null;
    }

Serialization in different variable types
  Al primitives are serializable
  String and wrapper classes (Integer, Double, etc.) implement serializable
  Static fields
    Since static fields do not constitute the state of an object, 
      they are never serialized

Serializable interface
  It is a marker interface, does not provide any method
  Classes that do not implement this interface will not have any of their state serialized or deserialized 
  Making a class serializable is important from security perspective,
    because an object's state may comprise confidential information 
    and the developer may not want it shared outside the JVM
  All subclasses of a serializable class are themselves serializable,
    unless it contains a non-serializable member object not marked as transient
    Example
      class A {} // Not serializable
      class B {} // Not serializable
      class C extends A implements Serializable {} // Serializable
      class D extends C {} // Serializable
      class E extends C { B b = new B(); } // Not serializable
      class E extends C { transient B b = new B(); } // Serializable
  If a serializable class extends a non-serializable class, then the no-args constructor
    of the non-serializable super class will be executed.
    This means that a non-serializable super class of a serializable class must have a no-args constructor

serialVersionUID property
  The serialization runtime associates with each serializable class a version number, called a serialVersionUID, 
    which is used during deserialization to verify that the sender and receiver of a serialized object have loaded classes 
    for that object that are compatible with respect to serialization. 
    If the receiver has loaded a class for the object that has a different serialVersionUID than that of the corresponding sender's class, 
    then deserialization will result in an InvalidClassException
  It can have any access modifier, but private is recommended
  It can be initialized to any value but conventionally it is set to 1L

transient keyword
  Tells to ignore this property during serialization
  Typically, such fields store the intermediate state of the object, 
    which, for example, is easier to calculate than to serialize and then deserialize
  Another example of such a field is a reference to an instance of an object that does not require or cannot be serialized
  Deserializing an object with transient fields will create them with the default type value of the field,
    for example, a transient String field will be null when deserialized

Customizing object serialization
  In case you want to tweak the logic when writing or reading serialized objects, you can implement the methods
  private void writeObject(ObjectOutputStream) throws IOException 
  private void readObject(ObjectInputStream) throws IOException, ClassNotFoundException 
  private void readObjectNoData() throws ObjectStreamException

Externalizable interface
  Can be implement by a class, to add a custom logic when an object of the class is serialized or deserialized,
    it can be used for example to encrypt and decrypt passwords
  Contains the methods
    void writeExternal()
      Will be called when object is serialized
        Example
          @Override
          public void writeExternal(ObjectOutput out) throws IOException {
              out.writeObject(this.name + "zote");
              out.writeObject(this.price + 10);
              out.writeObject(this.category + " Special");
          }
    void readExternal()
      Will be called when object is deserialized
        Example
          @Override
          public void readExternal(ObjectInput in) throws IOException, ClassNotFoundException {
              this.name = (String) in.readObject();
              this.price = (double) in.readObject();
              this.category = (String) in.readObject();
          }
    void readResolve()
      Serialization makes possible to create a new Singleton object, 
        which violates the purpose of a Singleton
      The purpose of this method is to return a replacement object instead of the object on which it is called
      To use it in a class, it is needed to define a method with the following signature
        <ANY_ACCESS_MODIFIER> readResolve() throws ObjectStreamException;

Record serialization
  Records too can be serialized if it implements Serializable
  Records are not allowed to customize their serialization
  The canonical constructor of a record is invoked even when it is being created by deserialization

Enum serialization
  All enums extend java.lang.Enum which implements Serializable,
    therefore all enums are serializable

Cloning
  Object Object.clone()
    Is inherited from Object class, however it has the protected access modifier, 
      so it can only be called inside an class inheriting from Object
    It returns a shallow copy of the object containing all the fields with exactly the same values of this instance
  Cloneable interface
    Contains the clone() method, so it guarantees that any class implementing it can be cloned
    By default, super.clone() method will return shallow copies, so if a deep copy is needed,
      the implementation of the clone() method must return new instances of any reference object inside the cloned class
  Shallow copy
    A shallow copy is a new object with
      Different memory reference 
      Same primitive values
      Same internal references 
    This means, if an object contains another object as a property, 
      both shallow copies will contain the same reference and point to the same internal object
      For example, in a shallow copy of an object containing a list, 
      both objects will contain a reference to the same list, 
      thus modyfing the list in one object will modify it for both
  Deep copy
    A deep copy also creates deep clones for any internal reference an object may hold
    For example, in a deep copy of an object containing a list, 
      both objects will contain a different lists, initially with the same values, 
      thus modyfing the list in one object won't modify it for both