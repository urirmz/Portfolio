
import java.io.File;
import java.nio.file.Paths;
import java.util.Scanner;
import java.util.ArrayList;

public class RecipeManager {

    private ArrayList<Recipe> recipes;

    public RecipeManager() {
        this.recipes = new ArrayList<>();
    }

    public void add(Recipe recipe) {
        this.recipes.add(recipe);
    }

    public void readRecipesFromFile(String path) {
        try {
            Recipe newRecipe = new Recipe();

            Scanner scan = new Scanner(Paths.get(path));
            while (scan.hasNextLine()) {
                String line = scan.nextLine();

                if (line.equals("")) {
                    this.recipes.add(newRecipe);
                    newRecipe = new Recipe();
                } else if (newRecipe.getName().equals("")) {
                    newRecipe.setName(line);
                } else if (newRecipe.getCookingTime() == 0) {
                    newRecipe.setCookingTime(Integer.valueOf(line));
                } else {
                    newRecipe.addIngredient(line);
                }
            }
            this.recipes.add(newRecipe);

        } catch (Exception ex) {
            System.out.println("Error: " + ex.getMessage());
        }
    }

    public void findByName(String name) {
        for (Recipe recipe : this.recipes) {
            if (recipe.getName().contains(name)) {
                System.out.println(recipe);
            }
        }
    }

    public void findByCookingTime(int maxCookingTime) {
        for (Recipe recipe : this.recipes) {
            if (recipe.getCookingTime() <= maxCookingTime) {
                System.out.println(recipe);
            }
        }
    }
    
    public void findByIngredient(String ingredient) {
        for (Recipe recipe : this.recipes) {
            if (recipe.getIngredients().contains(ingredient)) {
                System.out.println(recipe);
            }
        }
    }

    public void printRecipes() {
        for (Recipe recipe : this.recipes) {
            System.out.println(recipe);
        }
    }

}
