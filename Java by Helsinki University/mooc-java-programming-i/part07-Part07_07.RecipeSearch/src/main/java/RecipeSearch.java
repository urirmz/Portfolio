
import java.io.File;
import java.util.ArrayList;
import java.util.Scanner;

public class RecipeSearch {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        RecipeManager recipes = new RecipeManager();
        UserInterface ui = new UserInterface(scanner, recipes);
        
        ui.start();
    }

}
