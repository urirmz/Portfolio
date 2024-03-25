
import java.util.Scanner;

public class mainProgram {

    public static void main(String[] args) {
        String test = "Add\n"
                + "XXX\n"
                + "YYY\n"
                + "Observation\n"
                + "XXX\n"
                + "Add\n"
                + "WWW\n"
                + "ZZZ\n"
                + "Observation\n"
                + "WWW\n"
                + "One\n"
                + "XXX\n"
                + "Observation\n"
                + "XXX\n"
                + "Observation\n"
                + "WWW\n"
                + "One\n"
                + "WWW\n"
                + "Quit";
        
        Scanner scan = new Scanner(System.in);
        BirdDataBase birds = new BirdDataBase();
        UserInterface ui = new UserInterface(scan, birds);

        ui.start();
    }

}
