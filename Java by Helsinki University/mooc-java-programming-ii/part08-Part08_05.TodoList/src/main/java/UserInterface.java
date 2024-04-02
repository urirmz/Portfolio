
import java.util.ArrayList;
import java.util.Scanner;

public class UserInterface {
    private TodoList list;
    private Scanner scan;
            
    public UserInterface(TodoList list, Scanner scan) {
        this.list = list;
        this.scan = scan;
    }
    
    public void start() {
        while (true) {
            String command = scan.nextLine();
            
            if (command.equals("stop")) {
                break;
            } else if (command.equals("add")) {
                System.out.println("To add:");
                String task = scan.nextLine();
                list.add(task);
            } else if (command.equals("list")) {
                list.print();
            } else if (command.equals("remove")) {
                System.out.println("Which one is removed?");
                int index = Integer.valueOf(scan.nextLine());
                list.remove(index);
            }
        }
    }
}
