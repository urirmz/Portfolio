
import java.util.Scanner;

public class FromWhereToWhere {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        // Write your program here
        System.out.println("Where to?");
        int toNumber = Integer.valueOf(scanner.nextLine());
        System.out.println("Where from?");
        int fromNumber = Integer.valueOf(scanner.nextLine());
        
        for (int i = fromNumber; i <= toNumber; i++) {
            System.out.println(i);
        }
    }
}
