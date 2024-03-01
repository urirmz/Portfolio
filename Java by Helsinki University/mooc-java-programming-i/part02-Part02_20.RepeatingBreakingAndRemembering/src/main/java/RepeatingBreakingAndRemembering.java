
import java.util.Scanner;

public class RepeatingBreakingAndRemembering {

    public static void main(String[] args) {
        
        // This exercise is worth five exercise points, and it is 
        // gradually extended part by part.
        
        // If you want, you can send this exercise to the server
        // when it's just partially done. In that case the server will complain about 
        // the parts you haven't done, but you'll get points for the finished parts.
        
        Scanner scanner = new Scanner(System.in);
        
        System.out.println("Give numbers:");
        
        int sumOfNumbers = 0;
        int numberOfNumbers = 0;
        int numberOfEvens = 0;
        int numberOfOdds = 0;
        while (true) {
            int number = Integer.valueOf(scanner.nextLine());
            if (number == -1) {
                break;
            }
            sumOfNumbers += number;
            numberOfNumbers++;
            if (number % 2 == 0) {
                numberOfEvens++;
            } else {
                numberOfOdds++;
            }
        }
        System.out.println("Thx! Bye!");
        System.out.println("Sum:" + sumOfNumbers);
        System.out.println("Numbers: " + numberOfNumbers);
        System.out.println("Average: " + sumOfNumbers / (double) numberOfNumbers);
        System.out.println("Even: " + numberOfEvens);
        System.out.println("Odd: " + numberOfOdds);
    }
}
