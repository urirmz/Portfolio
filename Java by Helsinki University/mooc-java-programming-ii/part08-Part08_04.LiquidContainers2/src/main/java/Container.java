public class Container {
    private final int capacity;
    private int amount;

    public Container() { capacity = 100;}
    
    public int contains() {
        return amount;
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
    
    public void remove(int amount) {   
        if (amount > 0) {
            if (this.amount - amount <= 0) {
                this.amount = 0;
            } else {                
                this.amount -= amount;  
            }
        }  
    }
    
    @Override
    public String toString() {
        return String.valueOf(amount) + "/" + String.valueOf(capacity);
    }
}
