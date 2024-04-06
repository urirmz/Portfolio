
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

public class Warehouse {
    private Map<String, Integer> prices;
    private Map<String, Integer> stocks;

    public Warehouse() {
        prices = new HashMap<>();
        stocks = new HashMap<>();
    }
    
    public void addProduct(String product, int price, int stock) {
        prices.put(product, price);
        stocks.put(product, stock);
    }
    
    public int price(String product) {
        if (prices.get(product) == null) {
            return -99;
        }
        return prices.get(product);
    }
    
    public int stock(String product) {
        if (stocks.get(product) == null) {
            return 0;
        }
        return stocks.get(product);
    }
    
    public boolean take(String product) {        
        if (stocks.get(product) == null) {
            return false;
        } 
        int stock = stocks.get(product);
        if (stock <= 0) {
            return false;
        }
        stocks.put(product, stock - 1);
        return true;
    }
    
    public Set<String> products() {
        return prices.keySet();
    }
}
