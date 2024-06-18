
import java.util.ArrayList;

public class Pipe<T> {
    ArrayList<T> elements;
    
    public Pipe() {
        elements = new ArrayList<>();
    }
    
    public void putIntoPipe(T value) {
        elements.add(value);
    }

    public T takeFromPipe() {
        if (!elements.isEmpty()) {
            return elements.remove(0);
        }
        return null;
    }
    
    public boolean isInPipe() {
        return !elements.isEmpty();
    }
}
