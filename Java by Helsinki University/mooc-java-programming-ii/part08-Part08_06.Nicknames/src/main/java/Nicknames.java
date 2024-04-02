
import java.util.HashMap;

public class Nicknames {

    public static void main(String[] args) {
        HashMap<String, String> nicknames = new HashMap<>();
        
        nicknames.put("matt", "Matthew");
        nicknames.put("mix", "Michael");
        nicknames.put("artie", "Arthur");
        
        System.out.println(nicknames.get("matt"));
    }

}
