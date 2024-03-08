import java.util.ArrayList;

public class Suitcase {

    private ArrayList<Item> items;
    private int maximumWeightCapacity;

    public Suitcase(int maximumWeightCapacity) {
        this.items = new ArrayList<>();
        this.maximumWeightCapacity = maximumWeightCapacity;
    }
    
    public int totalWeight () {
        int carriedWeight = 0;
        for (Item item : items) {
            carriedWeight += item.getWeight();
        }
        return carriedWeight;
    }
    
    public void addItem(Item item) {
        if (this.totalWeight() + item.getWeight() <= this.maximumWeightCapacity) {
            items.add(item);
        }        
    }

    @Override
    public String toString() {
        if (this.items.isEmpty()) {
            return "no items (0 kg)";
        } else if (this.items.size() == 1) {
            return this.items.size() + " item (" + this.totalWeight() + " kg)";
        } else {
            return this.items.size() + " items (" + this.totalWeight() + " kg)";
        }        
    }
    
    public void printItems() {
        for (Item item : items) {
            System.out.println(item);
        }
    }
    
    public Item heaviestItem() {
        if (this.items.isEmpty()) {
            return null;
        }
        
        Item heaviest = this.items.get(0);
        for (Item item : items) {
            if (item.getWeight() > heaviest.getWeight()) {
                heaviest = item;
            }
        }
        return heaviest;
    }
    
}
