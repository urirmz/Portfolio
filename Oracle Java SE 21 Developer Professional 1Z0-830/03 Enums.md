Enums are used to specify a list of non-infinite keywords that match a given type
Enums are final and always extend java.lang.Enum<T>, which gives additional functionality, 
  like implementing Comparable and Serializable, or auxiliary methods like String name() or int ordinal()

Enums can be declared in the way: "${accesModifier} Enum ${enumName} { ${components} }", for example:
  public enum Priority {
    HIGH, MEDIUM, LOW
  }

Each member of the Enum has an ordinal zero-based index value associated, that can be retrieved like 
  Priority.HIGH.ordinal();

Enum members can also contain each own properties and methods
A semicolon (;) is required at the end of any enum value list if the enum contains anything after the list, such as a method or constructor
  public enum Month {

    JANUARY(31), FEBRUARY(28), MARCH(31), APRIL(30), MAY(31), JUNE(30), JULY(31), AUGUST(31), 
    SEPTEMBER(30), OCTUBER(31), NOVEMBER(30), DECEMBER(31);

    private int daysAmount;

    Moth(int daysAmount) {
      this.daysAmount = daysAmount;
    }

    getDaysAmount() {
      return daysAmount;
    }
    
  }

Certain Enum members may override methods
  public enum Vehicle {  

    CAR(List.of(4)),  
    TRUCK(List.of(6, 8)),  
    MOTORCYCLE(null) {  
      public int wheelCount() {  
          return wheels.get(0) + 2;  
      }  
    };  
    
    List<Integer> wheels;  
    
    Vehicle(List<Integer> wheels) {  
      this.wheels = wheels;  
    }  

    public int wheelCount() {  
      return wheels.get(0);  
    }

  }