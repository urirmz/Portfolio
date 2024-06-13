
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class AverageOfSelectedNumbers {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        
        List<String> inputs = new ArrayList<>();
        System.out.println("Input numbers, type \"end\" to stop.");
        
        while (true) {
            String input = scanner.nextLine();
        
            if (input.equals("end")) {
                break;
            }
            
            inputs.add(input);
        }
        
        System.out.println("Print the average of the negative numbers or the positive numbers? (n/p)");
        String input = scanner.nextLine();
        
        double average = 0;
        
        if (input.equals("n")) {
            average = inputs.stream()
                    .mapToInt(number -> Integer.valueOf(number))
                    .filter(number -> number < 0)
                    .average()
                    .getAsDouble();
        } else if (input.equals("p")) {
            average = inputs.stream()
                    .mapToInt(number -> Integer.valueOf(number))
                    .filter(number -> number > 0)
                    .average()
                    .getAsDouble();
        }
        
        System.out.println("Average of the negative numbers: " + average);

    }
}
