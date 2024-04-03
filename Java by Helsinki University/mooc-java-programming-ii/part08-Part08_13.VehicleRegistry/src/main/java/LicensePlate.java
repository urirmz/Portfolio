

public class LicensePlate {
    // don't modify existing parts of this class

    // these instance variables have been defined as final, meaning 
    // that once set, their value can't be changed
    private final String liNumber;
    private final String country;

    public LicensePlate(String country, String liNumber) {
        this.liNumber = liNumber;
        this.country = country;
    }

    @Override
    public String toString() {
        return country + " " + liNumber;
    }
    
    @Override
    public boolean equals(Object object) {
        if (object == this) {
            return true;
        }
        
        if (object.getClass() != this.getClass()) {
            return false;
        }
        
        LicensePlate plate = (LicensePlate) object;
        
        return this.country.equals(plate.country) &&
               this.liNumber.equals(plate.liNumber);
    }
    
    @Override
    public int hashCode() {
        return liNumber.hashCode() + country.hashCode();
    }
}
