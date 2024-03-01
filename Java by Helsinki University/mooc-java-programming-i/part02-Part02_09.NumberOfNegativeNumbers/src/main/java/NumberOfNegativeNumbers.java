
import java.util.Scanner;

public class NumberOfNegativeNumbers {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        
        
        int inputtedNegativeValues = 0;
        while (true) {
            System.out.println("Give a number:");
            int inputValue = Integer.valueOf(scanner.nextLine());
            
            if (inputValue == 0) {
                System.out.println("Number of negative numbers: " + inputtedNegativeValues);
                break;
            } else if (inputValue < 0) {
                inputtedNegativeValues++;
            }
        }
    }
}
