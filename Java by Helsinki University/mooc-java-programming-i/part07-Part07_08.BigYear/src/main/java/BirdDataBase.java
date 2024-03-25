
import java.util.ArrayList;

public class BirdDataBase {

    private ArrayList<Bird> birds;

    public BirdDataBase() {
        this.birds = new ArrayList<>();
    }

    public void addBird(Bird bird) {
        if (!this.birds.contains(bird)) {
            this.birds.add(bird);
        }
    }

    public void addObservation(String birdName) {
        for (Bird bird : this.birds) {
            if (bird.getName().equals(birdName)) {
                bird.addObservation();
                return;
            }
        }
        System.out.println("Not a bird!");        
    }
    
    public void printOne(String birdName) {
        for (Bird bird : this.birds) {
            if (bird.getName().equals(birdName)) {
                System.out.println(bird);
                return;
            }
        }
        System.out.println("Not a bird!");        
    }
    
    public void printAll() {
        if (this.birds.size() > 0) {
            for (Bird bird : this.birds) {
                System.out.println(bird);
            }
        }        
    }
}
