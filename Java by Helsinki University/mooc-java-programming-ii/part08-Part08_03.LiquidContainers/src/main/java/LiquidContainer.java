public class LiquidContainer {
    private final int capacity;
    private int amount;
    
    public LiquidContainer(int capacity, int amount) {
        this.capacity = capacity;
        this.amount = amount;
    }
    
    public void add(int amount) {
        if (amount > 0) {
            if (this.amount + amount >= capacity) {
                this.amount = capacity;
            } else {
                this.amount += amount;            
            }
        }        
    }
    
    public int remove(int amount) {   
        int removed = 0;
        if (amount > 0) {
            if (this.amount - amount <= 0) {
                removed = this.amount;
                this.amount = 0;
            } else {                
                removed = amount;
                this.amount -= amount;  
            }
        }  
        return removed;
    }
    
    @Override
    public String toString() {
        return String.valueOf(amount) + "/" + String.valueOf(capacity);
    }
}
