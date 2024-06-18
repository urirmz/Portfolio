
import java.util.ArrayList;
import java.util.Collections;

public class MagicSquare {

    private int[][] square;

    // ready constructor
    public MagicSquare(int size) {
        if (size < 2) {
            size = 2;
        }

        this.square = new int[size][size];
    }

    public ArrayList<Integer> sumsOfRows() {
        ArrayList<Integer> sumsOfRows = new ArrayList<>();

        for (int row = 0; row < square.length; row++) {
            int sumOfRow = 0;
            for (int column = 0; column < square[row].length; column++) {
                sumOfRow += square[row][column];
            }
            sumsOfRows.add(sumOfRow);
        }

        return sumsOfRows;
    }

    public ArrayList<Integer> sumsOfColumns() {
        ArrayList<Integer> sumsOfColumns = new ArrayList<>();
        int columnsInSquare = square[0].length;

        for (int column = 0; column < columnsInSquare; column++) {
            int sumOfColumn = 0;
            for (int row = 0; row < square.length; row++) {
                sumOfColumn += square[row][column];
            }
            sumsOfColumns.add(sumOfColumn);
        }

        return sumsOfColumns;
    }

    public ArrayList<Integer> sumsOfDiagonals() {
        ArrayList<Integer> sumsOfDiagonals = new ArrayList<>();
                
        int rowDiagonal1 = 0;
        int columnDiagonal1 = 0;
        int sumDiagonal1 = 0;
        
        int rowDiagonal2 = square.length - 1;
        int columnDiagonal2 = 0;
        int sumDiagonal2 = 0;
        
        while (rowDiagonal1 < square.length) {
            sumDiagonal1 += square[rowDiagonal1][columnDiagonal1];
            rowDiagonal1++;
            columnDiagonal1++;
            
            sumDiagonal2 += square[rowDiagonal2][columnDiagonal2];
            rowDiagonal2--;
            columnDiagonal2++;
        }
        
        sumsOfDiagonals.add(sumDiagonal1);
        sumsOfDiagonals.add(sumDiagonal2);
        
        return sumsOfDiagonals;
    }

    // ready-made helper methods -- don't touch these
    public boolean isMagicSquare() {
        return sumsAreSame() && allNumbersDifferent();
    }

    public ArrayList<Integer> giveAllNumbers() {
        ArrayList<Integer> numbers = new ArrayList<>();
        for (int row = 0; row < square.length; row++) {
            for (int col = 0; col < square[row].length; col++) {
                numbers.add(square[row][col]);
            }
        }

        return numbers;
    }

    public boolean allNumbersDifferent() {
        ArrayList<Integer> numbers = giveAllNumbers();

        Collections.sort(numbers);
        for (int i = 1; i < numbers.size(); i++) {
            if (numbers.get(i - 1) == numbers.get(i)) {
                return false;
            }
        }

        return true;
    }

    public boolean sumsAreSame() {
        ArrayList<Integer> sums = new ArrayList<>();
        sums.addAll(sumsOfRows());
        sums.addAll(sumsOfColumns());
        sums.addAll(sumsOfDiagonals());

        if (sums.size() < 3) {
            return false;
        }

        for (int i = 1; i < sums.size(); i++) {
            if (sums.get(i - 1) != sums.get(i)) {
                return false;
            }
        }

        return true;
    }

    public int readValue(int x, int y) {
        if (x < 0 || y < 0 || x >= getWidth() || y >= getHeight()) {
            return - 1;
        }

        return this.square[y][x];
    }

    public void placeValue(int x, int y, int value) {
        if (x < 0 || y < 0 || x >= getWidth() || y >= getHeight()) {
            return;
        }

        this.square[y][x] = value;
    }

    public int getWidth() {
        return this.square.length;
    }

    public int getHeight() {
        return this.square.length;
    }

    @Override
    public String toString() {
        StringBuilder result = new StringBuilder();
        for (int row = 0; row < square.length; row++) {
            for (int col = 0; col < square[row].length; col++) {
                result.append(square[row][col]).append("\t");
            }

            result.append("\n");
        }

        return result.toString();
    }
}
