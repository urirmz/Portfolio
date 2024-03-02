
public class AdvancedAstrology {

    public static void printStars(int number) {
        for (int i = 1; i <= number; i++) {
            System.out.print("*");
        }
        System.out.println("");
    }

    public static void printSpaces(int number) {
        for (int i = 1; i <= number; i++) {
            System.out.print(" ");
        }
    }

    public static void printTriangle(int size) {
        for (int i = 1; i <= size; i++) {
            printSpaces(size - i);
            printStars(i);
        }
    }

    public static void christmasTree(int height) {
        int spaces = height - 1;
        int stars = 1;
        
        for (int i = 1; i <= height; i++) {
            printSpaces(spaces);
            printStars(stars);
            spaces--;
            stars += 2;
        }
        
        int logWidth = 3;
        int logHeight = 2;
        int logStart = ((stars - logWidth - 2) / 2);
        for (int i = 1; i <= logHeight; i++) {
            printSpaces(logStart);
            printStars(logWidth);
        }
    }

    public static void main(String[] args) {
        // The tests are not checking the main, so you can modify it freely.

        printTriangle(5);
        System.out.println("---");
        christmasTree(4);
        System.out.println("---");
        christmasTree(10);
    }
}
