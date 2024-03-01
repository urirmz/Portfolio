
import java.util.Scanner;

public class SumOfASequence {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Last number?");
        int lastNumber = Integer.valueOf(scanner.nextLine());
        
        int sumOfSequence = 0;
        for (int i = 1; i <= lastNumber; i++) {
            sumOfSequence += i;
        }
        System.out.println(sumOfSequence);
    }
}
