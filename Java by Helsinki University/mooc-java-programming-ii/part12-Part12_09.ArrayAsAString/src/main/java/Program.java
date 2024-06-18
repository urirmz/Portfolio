
public class Program {

    public static void main(String[] args) {
        int[][] matrix = {
            {3, 2, 7, 6},
            {2, 4, 1, 0},
            {3, 2, 1, 0}
        };

        System.out.println(arrayAsString(matrix));
    }

    public static String arrayAsString(int[][] array) {
        StringBuilder arrayAsStringBuilder = new StringBuilder();

        for (int i = 0; i < array.length; i++) {
            StringBuilder rowBuilder = new StringBuilder();

            for (int j = 0; j < array[i].length; j++) {
                rowBuilder.append(array[i][j]);
            }

            arrayAsStringBuilder.append(rowBuilder.toString() + "\n");
        }

        return arrayAsStringBuilder.toString();
    }
}
