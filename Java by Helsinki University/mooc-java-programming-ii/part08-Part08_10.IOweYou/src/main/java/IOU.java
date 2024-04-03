
import java.util.HashMap;

public class IOU {
    private HashMap<String, Double> owes;
    
    public IOU() { owes = new HashMap<>(); }
    
    public void setSum(String toWhom, double amount) {
        owes.put(toWhom, amount);
    }
    
    public double howMuchDoIOweTo(String toWhom) {
        return owes.getOrDefault(toWhom, 0.0);
    }
}
