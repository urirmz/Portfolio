
import java.util.ArrayList;
import java.util.HashMap;

public class StorageFacility {
    private HashMap<String, ArrayList<String>> storage;

    public StorageFacility() {
        storage = new HashMap<>();
    }    
    
    public void add(String unit, String item) {
        if (!storage.containsKey(unit)) {
            storage.put(unit, new ArrayList<>());
        }        
        storage.get(unit).add(item);
    }
    
    public ArrayList<String> contents(String storageUnit) {
        if (!storage.containsKey(storageUnit)) {
            return new ArrayList<>();
        }  
        return storage.get(storageUnit);
    }
    
    public void remove(String storageUnit, String item) {
        storage.get(storageUnit).remove(item);
        if (storage.get(storageUnit).size() < 1) {
            storage.remove(storageUnit);
        }
    }
    
    public ArrayList<String> storageUnits() {
        ArrayList<String> unitsList = new ArrayList<>();
        
        for (String unit : storage.keySet()) {
            if (storage.get(unit).size() > 0) {
                unitsList.add(unit);
            }
        }
        
        return unitsList;
    }
}
