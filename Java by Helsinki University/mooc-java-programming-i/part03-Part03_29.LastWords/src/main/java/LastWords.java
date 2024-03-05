
import java.util.Scanner;

public class LastWords {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        while (true) {
            String phrase = scanner.nextLine();
            
            if (phrase.isEmpty()) {
                break;
            }
            
            String[] splittedPhrase = phrase.split(" ");
            
            System.out.println(splittedPhrase[splittedPhrase.length - 1]);
        }
    }
}
