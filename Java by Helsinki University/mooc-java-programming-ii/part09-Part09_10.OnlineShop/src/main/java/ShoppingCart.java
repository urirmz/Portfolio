
import java.util.HashMap;
import java.util.Map;

public class ShoppingCart {
    private Map<String, Item> items;

    public ShoppingCart() {
        items = new HashMap<>();        
    }
    
    public void add(String product, int price) {
        if (items.get(product) == null) {
            items.put(product, new Item(product, 1, price));
        } else {
            items.get(product).increaseQuantity();
        }      
    }
    
    public int price() {
        int price = 0;
        for (Item item : items.values()) {
            price += item.price();
        }
        return price;
    }
    
    public void print() {
        for (Item item : items.values()) {
            System.out.println(item);
        }
    }
}
