
import java.util.ArrayList;

public class ChangeHistory {
    private ArrayList<Double> history;
    
    public ChangeHistory() {
        history = new ArrayList<>();
    }
    
    public void add(double status) {
        history.add(status);
    }
    
    public void clear() {
        history.clear();
    }
    
    public double maxValue() {
        double max = Double.MIN_VALUE;
        
        if (history.size() < 1) {
            return 0;
        }
        
        for (double value : history) {
            if (value > max) {
                max = value;
            }
        }
        
        return max;
    }
    
    public double minValue() {
        double min = Double.MAX_VALUE;
        
        if (history.size() < 1) {
            return 0;
        }
        
        for (double value : history) {
            if (value < min) {
                min = value;
            }
        }
        
        return min;
    }
    
    public double average() {
        double sum = 0;
        int count = history.size();
        
        if (count < 1) {
            return 0;
        }
        
        for (double value : history) {
            sum += value;
        }
        
        return sum / count;
    }
    
    @Override
    public String toString() {
        return history.toString();
    }
}
