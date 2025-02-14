Enums are used to specify a list of non-infinite keywords that match a given type

Enums can be declared in the way: "${accesModifier} Enum ${enumName} { ${components} }", for example:
  public enum Priority {
    HIGH, MEDIUM, LOW
  }

Each member of the Enum has an ordinal value associated, that can be retrieved like Priority.HIGH.ordinal();

Enum members can also contain each own properties and methods, like:
  public enum Month {

    JANUARY(31), FEBRUARY(28), MARCH(31), APRIL(30), MAY(31), JUNE(30), JULY(31), AUGUST(31), SEPTEMBER(30), OCTUBER(31), NOVEMBER(30), DECEMBER(31)

    private int daysAmount;

    Moth(int daysAmount) {
      this.daysAmount = daysAmount;
    }

    getDaysAmount() {
      return daysAmount;
    }
    
  }