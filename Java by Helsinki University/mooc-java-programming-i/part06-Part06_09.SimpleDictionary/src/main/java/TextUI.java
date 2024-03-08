import java.util.Scanner;

public class TextUI {
    
    private Scanner scanner;
    private SimpleDictionary dictionary;
    
    public TextUI(Scanner scanner, SimpleDictionary dictionary) {
        this.scanner = scanner;
        this.dictionary = dictionary;
    }
    
    public void start() {
        
        while (true) {
            System.out.println("Command:");
            String command = this.scanner.nextLine();
            
            if (command.equals("end")) {
                
                System.out.println("Bye bye!");
                break;
                
            } else if (command.equals("add")) {
                
                System.out.println("Word:");
                String word = this.scanner.nextLine();
                System.out.println("Translation:");
                String translation = this.scanner.nextLine();
                
                this.dictionary.add(word, translation);
                
            } else if (command.equals("search")) {
                
                System.out.println("To be translated:");
                String word = this.scanner.nextLine();
                
                String translation = this.dictionary.translate(word);
                if (translation != null) {
                    System.out.println("Translation: " + translation);
                } else {
                    System.out.println("Word " + word + " was not found");
                }                
                
            } else {
                
                System.out.println("Unknown command");
                
            }
            
        }
        
    }
    
}
