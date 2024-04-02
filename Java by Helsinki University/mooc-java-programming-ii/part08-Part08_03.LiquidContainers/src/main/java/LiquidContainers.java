
import java.util.Scanner;

public class LiquidContainers {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        LiquidContainer first = new LiquidContainer(100, 0);
        LiquidContainer second = new LiquidContainer(100, 0);
        UserInterface ui = new UserInterface(scan, first, second);
        
        ui.start();        
    }

}
