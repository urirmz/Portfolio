package dictionary;

public class Main {

    public static void main(String[] args) {
        SaveableDictionary s = new SaveableDictionary("test-51449.txt");
        s.add("tietokone", "computer");
        System.out.println(s.save());
    }
}
