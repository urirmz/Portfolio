
import java.util.ArrayList;
import java.util.Scanner;

public class UniqueLastNames {

    public static void main(String[] args) {
        ArrayList<Person> persons = new ArrayList<>();
        Scanner scanner = new Scanner(System.in);

        while (true) {
            System.out.println("Continue personal information input? \"quit\" ends:");
            String input = scanner.nextLine();

            if (input.equals("quit")) {
                System.out.println("");
                break;
            }

            System.out.println("Input first name: ");
            String firstName = scanner.nextLine();

            System.out.println("Input last name: ");
            String lastName = scanner.nextLine();

            System.out.println("Input the year of birth: ");
            int birthYear = Integer.valueOf(scanner.nextLine());

            persons.add(new Person(firstName, lastName, birthYear));
            System.out.println("");

        }

        System.out.println("Unique last names in alphabetical order:");
        persons.stream()
                .map(person -> person.getLastName())
                .distinct()
                .sorted()
                .forEach(lastName -> System.out.println(lastName));
    }
}
