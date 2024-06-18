
public class Program {

    public static void main(String[] args) {
        MagicSquareFactory msFactory = new MagicSquareFactory();
        MagicSquare square = msFactory.createMagicSquare(5);
        
        System.out.println(square);
        System.out.println(square.sumsOfColumns());
        System.out.println(square.sumsOfRows());
        System.out.println(square.sumsOfDiagonals());
        System.out.println(square.isMagicSquare());
    }
}
