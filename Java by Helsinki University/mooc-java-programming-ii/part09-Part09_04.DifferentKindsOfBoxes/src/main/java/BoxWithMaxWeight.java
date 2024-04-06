
import java.util.ArrayList;

public class BoxWithMaxWeight extends Box {
    private int capacity;
    private ArrayList<Item> items;
    
    public BoxWithMaxWeight(int capacity) {
        super();
        this.capacity = capacity;
        items = new ArrayList<>();
    }
    
    @Override
    public void add(Item item) {
        int carriedWeight = 0;
        for (Item carriedItem : items) {
            carriedWeight += carriedItem.getWeight();
        }
        if (carriedWeight + item.getWeight() <= capacity) {
            items.add(item);
            carriedWeight += item.getWeight();
        }
    }    
    
    @Override
    public boolean isInBox(Item item) {
        return items.contains(item);
    }
}
