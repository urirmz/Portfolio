
import java.util.Scanner;

public class NumberOfNumbers {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        
        int inputtedValues = 0;
        while (true) {
            System.out.println("Give a number:");
            int inputValue = Integer.valueOf(scanner.nextLine());
            
            if (inputValue == 0) {
                System.out.println("Number of numbers: " + inputtedValues);
                break;
            } else {
                inputtedValues++;
            }
        }
    }
}
