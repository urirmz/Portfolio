import java.util.ArrayList;

public class Stack {
    private ArrayList<String> values;
    
    public Stack() {
        this.values = new ArrayList<>();
    }
    
    public boolean isEmpty() {
        return this.values.isEmpty();
    }
    
    public void add(String value) {
        this.values.add(0, value);
    }
    
    public ArrayList<String> values() {
        return this.values;
    }
    
    public String take() {        
        return this.values.remove(0);
    }
}
