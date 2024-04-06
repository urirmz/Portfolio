public class Item {
    private String name;
    private int quantity;
    private int price;
            
    public Item(String product, int qty, int unitPrice) {
        name = product;
        quantity = qty;
        price = unitPrice;
    }
    
    public int price() {
        return price * quantity;
    }
    
    public void increaseQuantity() {
        quantity++;
    }
    
    @Override
    public String toString() {
        return name + ": " + quantity;
    }

}
