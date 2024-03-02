
public class Greatest {

    public static int greatest(int number1, int number2, int number3) {
        int[] numbers = new int[] {number1, number2, number3};
        int greatest = numbers[0];
        
        for (int i = 0; i < numbers.length; i++) {
            if (greatest < numbers[i]) {
                greatest = numbers[i];
            }
        }
        return greatest;
    }

    public static void main(String[] args) {
        int result = greatest(2, 7, 3);
        System.out.println("Greatest: " + result);
    }
}
