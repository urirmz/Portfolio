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

Serializable interface
  It is a marker interface, does not provide any method
  Classes that do not implement this interface will not have any of their state serialized or deserialized 
  All subtypes of a serializable class are themselves serializable

serialVersionUID property
  The serialization runtime associates with each serializable class a version number, called a serialVersionUID, 
    which is used during deserialization to verify that the sender and receiver of a serialized object have loaded classes 
    for that object that are compatible with respect to serialization. 
    If the receiver has loaded a class for the object that has a different serialVersionUID than that of the corresponding sender's class, 
    then deserialization will result in an InvalidClassException

transient keyword
  Tells to ignore this property during serialization
  Typically, such fields store the intermediate state of the object, 
    which, for example, is easier to calculate than to serialize and then deserialize
  Another example of such a field is a reference to an instance of an object that does not require or cannot be serialized

Externalizable interface
  Can be implement by a class, to add a custom logic when an object of the class is serialized or deserialized,
    it can be used for example to encrypt and decrypt passwords
  Contains the methods
    writeExternal()
      Will be called when object is serialized
        Example
          @Override
          public void writeExternal(ObjectOutput out) throws IOException {
              out.writeObject(this.name + "zote");
              out.writeObject(this.price + 10);
              out.writeObject(this.category + " Special");
          }
    readExternal()
      Will be called when object is deserialized
        Example
          @Override
          public void readExternal(ObjectInput in) throws IOException, ClassNotFoundException {
              this.name = (String) in.readObject();
              this.price = (double) in.readObject();
              this.category = (String) in.readObject();
          }

readResolve()
  Serialization makes possible to create a new Singleton object, 
    which violates the purpose of a Singleton
  The purpose of this method is to return a replacement object instead of the object on which it is called
  To use it in a class, it is needed to define a method with the following signature
    <ANY_ACCESS_MODIFIER> readResolve() throws ObjectStreamException;

Cloning
  Object.clone()
    Is inherited from Object class, however it has the protected access modifier, 
      so it can only be called inside an class inheriting from Object
    It returns a shallow copy of the object
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