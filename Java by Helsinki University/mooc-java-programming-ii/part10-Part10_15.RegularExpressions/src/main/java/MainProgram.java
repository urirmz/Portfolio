
import java.util.Scanner;

public class MainProgram {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Checker checker = new Checker();
        
        System.out.println("Enter a string:");
        String input = scanner.nextLine();
        
        if (checker.allVowels(input)) {
            System.out.println("The form is correct.");
        } else {
            System.out.println("The form is incorrect.");
        }
    }
}
