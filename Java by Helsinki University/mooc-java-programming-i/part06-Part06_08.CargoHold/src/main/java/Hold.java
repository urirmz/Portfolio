import java.util.ArrayList;

public class Hold {
    
    private int maximumWeight;
    private ArrayList<Suitcase> luggage;
    
    public Hold(int maximumWeight) {
        this.maximumWeight = maximumWeight;
        this.luggage = new ArrayList<>();
    }
    
    public int getCarriedWeight() {
        int carriedWeight = 0;
        for (Suitcase suitcase : this.luggage) {
            carriedWeight += suitcase.totalWeight();
        }
        return carriedWeight;
    }
    
    public void addSuitcase(Suitcase suitcase) {
        if (this.getCarriedWeight() + suitcase.totalWeight() <= this.maximumWeight) {
            luggage.add(suitcase);
        }
    }

    @Override
    public String toString() {
        return this.luggage.size() + " suitcases (" + this.getCarriedWeight() + " kg)";
    }
    
    public void printItems() {
        for (Suitcase suitcase : this.luggage) {
            suitcase.printItems();
        }
    }    
}
