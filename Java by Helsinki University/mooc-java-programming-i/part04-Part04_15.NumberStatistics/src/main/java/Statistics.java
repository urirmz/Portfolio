import java.util.ArrayList;

public class Statistics {
    private ArrayList<Integer> numbers;
    
    public Statistics() {
        this.numbers = new ArrayList<>();
    }
    
    public void addNumber(int number) {
        this.numbers.add(number);
    }
    
    public int getCount() {
        return this.numbers.size();
    }
    
    public int sum() {
        int sum = 0;
        for (int number : this.numbers) {
            sum += number;
        }
        return sum;
    }
    
    public double average() {
        if (this.getCount() == 0) {
            return 0;
        } else {
            return this.sum() / (double) this.getCount();
        }
    }
}
