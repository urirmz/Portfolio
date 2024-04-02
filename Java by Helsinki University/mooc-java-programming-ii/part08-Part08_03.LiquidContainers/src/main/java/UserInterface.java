import java.util.Scanner;

public class UserInterface {
    private final Scanner scan;
    private final LiquidContainer first;
    private final LiquidContainer second;
    
    public UserInterface(Scanner scan, LiquidContainer first, LiquidContainer second) {
        this.scan = scan;
        this.first = first;
        this.second = second;
    }
    
    public void start() {
        while (true) {
            System.out.println("First: " + first);
            System.out.println("Second: " + second);
            
            String[] commandAndAmount = scan.nextLine().split(" ");            
            String command = commandAndAmount[0];            
            
            if (command.equals("quit")) {
                break;
            }
            
            int amount = Integer.valueOf(commandAndAmount[1]);
            
            if (command.equals("add")) {
                first.add(amount);
            } else if (command.equals("move")) {
                second.add(first.remove(amount));
            } else if (command.equals("remove")) {
                second.remove(amount);
            }
        }
    }
}
