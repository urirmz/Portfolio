
import java.util.ArrayList;

public class Herd implements Movable {
    private ArrayList<Movable> movables;
    
    public Herd() {
        movables = new ArrayList();
    }
    
    public String toString() {
        String string = "";
        for (Movable movable : movables) {
            string += movable + "\n";
        }
        return string;
    }
    
    public void addToHerd(Movable movable) {
        movables.add(movable);
    }
    
    public void move(int dx, int dy) {
        for (Movable movable : movables) {
            movable.move(dx, dy);
        }
    }    
}
