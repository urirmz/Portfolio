
import java.util.ArrayList;
import java.util.Scanner;

public class NameOfTheOldest {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        ArrayList<Integer> ages = new ArrayList<>();
        ArrayList<String> names = new ArrayList<>();
        while (true) {
            String nameAndAge = scanner.nextLine();

            if (nameAndAge.isEmpty()) {
                break;
            }

            String[] splittedNameAndAge = nameAndAge.split(",");
            names.add(splittedNameAndAge[0]);
            ages.add(Integer.valueOf(splittedNameAndAge[1]));
        }

        int indexOfOldest = 0;
        for (int i = 0; i < ages.size(); i++) {
            if (ages.get(indexOfOldest) < ages.get(i)) {
                indexOfOldest = i;
            }
        }

        System.out.println("Age of oldest: " + names.get(indexOfOldest));
    }
}
