import java.util.Scanner;

public class UserInterface {
    
    private Scanner scanner;
    private BirdDataBase birds;

    public UserInterface(Scanner scanner, BirdDataBase birds) {
        this.scanner = scanner;
        this.birds = birds;
    }
    
    public void start() {       
        
        while (true) {
            System.out.println("?");
            String command = this.scanner.nextLine();
            
            if (command.equals("Quit")) {
                break;
            } else if (command.equals("Add")) {
                System.out.println("Name:");
                String name = this.scanner.nextLine();
                System.out.println("Name in Latin:");
                String nameInLatin = this.scanner.nextLine();
                birds.addBird(new Bird(name, nameInLatin));
            } else if (command.equals("Observation")) {
                System.out.println("Bird?");
                String birdName = this.scanner.nextLine();
                birds.addObservation(birdName);
            } else if (command.equals("One")) {
                System.out.println("Bird?");
                String birdName = this.scanner.nextLine();
                birds.printOne(birdName);
            } else if (command.equals("All")) {
                birds.printAll();
            }
        }        
    }    
}
