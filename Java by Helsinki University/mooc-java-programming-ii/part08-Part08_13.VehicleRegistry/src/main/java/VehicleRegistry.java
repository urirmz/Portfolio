
import java.util.ArrayList;
import java.util.HashMap;

public class VehicleRegistry {  
    private HashMap<LicensePlate, String> registers;

    public VehicleRegistry() {
        registers = new HashMap<>();
    }   
    
    public boolean add(LicensePlate licensePlate, String owner) {
        if (registers.containsKey(licensePlate)) {
            return false;
        }
        
        registers.put(licensePlate, owner);
        return true;
    }
    
    public String get(LicensePlate licensePlate) {
        return registers.get(licensePlate);
    }
    
    public boolean remove(LicensePlate licensePlate) {
        if (!registers.containsKey(licensePlate)) {
            return false;
        }
        
        registers.remove(licensePlate);
        return true;
    }
    
    public void printLicensePlates() {
        for (LicensePlate plate : registers.keySet()) {
            System.out.println(plate);
        }        
    }
    
    public void printOwners() {
        ArrayList<String> printed = new ArrayList<>();
        
        for (String owner : registers.values()) {
            if (!printed.contains(owner)) {
                System.out.println(owner);
                printed.add(owner);
            }            
        }  
    }
}
