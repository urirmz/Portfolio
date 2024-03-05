
import java.util.Scanner;

public class LineByLine {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        while (true) {
            String phrase = scanner.nextLine();
            
            if (phrase.isEmpty()) {
                break;
            }
            
            String[] splittedPhrase = phrase.split(" ");
            
            for (String word: splittedPhrase) {
                System.out.println(word);
            }
        }
    }
}
