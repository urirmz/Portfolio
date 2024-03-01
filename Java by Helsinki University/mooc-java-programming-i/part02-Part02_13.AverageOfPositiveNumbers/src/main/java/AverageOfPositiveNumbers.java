
import java.util.Scanner;

public class AverageOfPositiveNumbers {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int sumOfNumbers = 0;
        int numberOfPositiveNumbers = 0;
        while (true) {
            System.out.println("Give a number:");
            int number = Integer.valueOf(scanner.nextLine());

            if (number == 0) {
                if (numberOfPositiveNumbers > 0) {
                    System.out.println("Average of the numbers: " + sumOfNumbers / (double) numberOfPositiveNumbers);
                } else {
                    System.out.println("Cannot calculate the average");
                }
                break;
            }

            if (number > 0) {
                sumOfNumbers = sumOfNumbers + number;
                numberOfPositiveNumbers++;
            }
        }
    }
}
