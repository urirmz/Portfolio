
import java.util.ArrayList;
import java.util.Random;

public class LotteryRow {
    private ArrayList<Integer> numbers;

    public LotteryRow() {
        randomizeNumbers();
    }

    public ArrayList<Integer> numbers() {
        return this.numbers;
    }

    public void randomizeNumbers() {
        numbers = new ArrayList<>();
        Random random = new Random();
        
        while (numbers.size() < 7) {
            int number = random.nextInt(40) + 1;
            if (!containsNumber(number)) {
                numbers.add(number);
            }
        }
    }

    public boolean containsNumber(int number) {
        return numbers.contains(number);
    }
}

