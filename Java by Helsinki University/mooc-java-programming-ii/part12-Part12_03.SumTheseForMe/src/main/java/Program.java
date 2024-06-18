
import java.util.Scanner;

public class Program {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        
        int[] numbers = {8, 2, 9, 1, 1};
        System.out.println(sum(numbers, 0, numbers.length, 0, 999));

    }

    public static int sum(int[] array, int fromWhere, int toWhere, int smallest, int largest) {
        int sum = 0;

        fromWhere = Math.max(0, fromWhere);
        toWhere = Math.min(array.length, toWhere);

        for (int i = fromWhere; i < toWhere; i++) {
            int number = array[i];
            
            if (number <= largest && number >= smallest) {
                sum += number;
            }
        }

        return sum;
    }
}
