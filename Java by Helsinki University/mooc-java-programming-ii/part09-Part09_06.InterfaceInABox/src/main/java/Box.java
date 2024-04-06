
import java.util.ArrayList;

public class Box implements Packable {
    private double weight;
    private double capacity;
    private ArrayList<Packable> items;
    
    public Box(double capacity) {
        this.capacity = capacity;
        weight = 0;
        items = new ArrayList<Packable>();
    }
    
    public double weight() {
        weight = 0;
        for (Packable item : items) {
            weight += item.weight();
        }
        return weight;
    }
    
    public void add(Packable item) {
        if (this.weight() + item.weight() <= capacity) {
            items.add(item);
        }       
    }
    
    @Override
    public String toString() {
        return "Box: " + items.size() + " items, total weight " + weight() + " kg";
    }
}
