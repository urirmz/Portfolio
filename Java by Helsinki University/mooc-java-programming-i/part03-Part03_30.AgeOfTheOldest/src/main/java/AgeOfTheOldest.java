import java.util.ArrayList;
import java.util.Scanner;

public class AgeOfTheOldest {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        
        ArrayList<Integer> ages = new ArrayList<>();
        while (true) {
            String nameAndAge = scanner.nextLine();
            
            if (nameAndAge.isEmpty()) {
                break;
            }
            
            String[] splittedNameAndAge = nameAndAge.split(",");
            ages.add(Integer.valueOf(splittedNameAndAge[1]));
        }
        
        int ageOfOldest = ages.get(0);
        for (int age: ages) {
            if (age > ageOfOldest) {
                ageOfOldest = age;
            }
        }
        
        System.out.println("Age of oldest: " + ageOfOldest);
    }
}
