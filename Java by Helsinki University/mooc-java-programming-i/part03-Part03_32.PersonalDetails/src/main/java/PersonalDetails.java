
import java.util.ArrayList;
import java.util.Scanner;

public class PersonalDetails {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        
        ArrayList<String> names = new ArrayList<>();
        ArrayList<Integer> birthYears = new ArrayList<>();
        while (true) {
            String nameAndBirthYear = scanner.nextLine();

            if (nameAndBirthYear.isEmpty()) {
                break;
            }

            String[] splittedNameAndBirthYear = nameAndBirthYear.split(",");
            names.add(splittedNameAndBirthYear[0]);
            birthYears.add(Integer.valueOf(splittedNameAndBirthYear[1]));
        }
        
        String longestName = names.get(0);
        for (String name : names) {
            if (name.length() > longestName.length()) {
                longestName = name;
            }
        }
        
        int birthYearsSum = 0;
        for (int birthYear : birthYears) {
            birthYearsSum += birthYear;
        }
        double birthYearsAverage = birthYearsSum / (double) birthYears.size();
        
        System.out.println("Longest name: " + longestName);
        System.out.println("Average of the birth years: " + birthYearsAverage);
    }
}
