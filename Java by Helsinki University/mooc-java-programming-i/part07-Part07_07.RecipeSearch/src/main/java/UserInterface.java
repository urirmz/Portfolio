import java.util.Scanner;

public class UserInterface {
    
    private Scanner scanner;
    private RecipeManager recipeManager;

    public UserInterface(Scanner scanner, RecipeManager recipeManager) {
        this.scanner = scanner;
        this.recipeManager = recipeManager;
    }
    
    public void start() {
        System.out.println("File to read:");
        String filename = this.scanner.nextLine();
        this.recipeManager.readRecipesFromFile(filename);
        
        this.printCommands();
        
        while (true) {
            System.out.println("Enter command:");
            String command = this.scanner.nextLine();
            
            if (command.equals("stop")) {
                break;
            } else if (command.equals("list")) {
                this.recipeManager.printRecipes();
            } else if (command.equals("find name")) {
                System.out.println("Searched word:");
                String name = this.scanner.nextLine();
                System.out.println("Recipes:");
                this.recipeManager.findByName(name);
            } else if (command.equals("find cooking time")) {
                System.out.println("Max cooking time:");
                int time = Integer.valueOf(this.scanner.nextLine());
                System.out.println("Recipes:");
                this.recipeManager.findByCookingTime(time);
            } else if (command.equals("find ingredient")) {
                System.out.println("Ingredient:");
                String ingredient = this.scanner.nextLine();
                System.out.println("Recipes:");
                this.recipeManager.findByIngredient(ingredient);
            }
        }
        
    }
    
    public void printCommands() {
        System.out.println("\nCommands:");
        System.out.println("list - lists the recipes");
        System.out.println("stop - stops the program");
        System.out.println("find name - searches recipes by name");
        System.out.println("find cooking time - searches recipes by cooking time");
        System.out.println("find ingredient - searches recipes by ingredient");
        System.out.println("");
    }
    
}
