
public class Main {

    public static void main(String[] args) {
        // you can write code here for testing your program

        Song song1 = new Song("The Lonely Island", "Jack Sparrow", 196);
        Song song2 = new Song("The Lonely Island", "Jack Sparrow", 196);
        if (song1.equals(song2)) {
            System.out.println("Same!");
        }
        
        System.out.println(song1);
        System.out.println(song2);
    }
}
