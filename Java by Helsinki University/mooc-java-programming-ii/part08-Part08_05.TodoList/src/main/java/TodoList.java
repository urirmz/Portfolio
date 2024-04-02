
import java.util.ArrayList;

public class TodoList {
    private ArrayList<String> tasks;
    
    public TodoList() { tasks = new ArrayList<>(); }
    
    public void add(String task) {
        tasks.add(task);
    }
    
    public void print() {
        for (int i = 0; i < tasks.size(); i++) {
            String number = String.valueOf(i + 1) + ": ";
            System.out.println(number + tasks.get(i));
        }
    }
    
    public void remove(int number) {
        tasks.remove(number - 1);
    }
}
