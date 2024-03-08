import java.util.ArrayList;
import java.util.Random;

public class JokeManager {
    
    private ArrayList<String> jokes = new ArrayList<>();

    public JokeManager() {
        this.jokes = new ArrayList<>();
    }
    
    public void addJoke(String joke) {
        this.jokes.add(joke);
    }
    
    public String drawJoke() {
        if (this.jokes.isEmpty()) {
            return "Jokes are in short supply.";
        } 
        int random = new Random().nextInt(this.jokes.size());
        return this.jokes.get(random);
    }
    
    public void printJokes() {
        for (String joke : this.jokes) {
            System.out.println(joke);
        }
    }
}
