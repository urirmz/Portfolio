
import java.util.ArrayList;
import java.util.HashMap;

public class DictionaryOfManyTranslations {
    private HashMap<String, ArrayList<String>> translations;

    public DictionaryOfManyTranslations() {
        translations = new HashMap<String, ArrayList<String>>();
    } 
    
    public void add(String word, String translation) {
        translations.putIfAbsent(word, new ArrayList<>());
        
        if (!translations.get(word).contains(word)) {
            translations.get(word).add(translation);
        }
    }
    
    public ArrayList<String> translate(String word) {
        ArrayList<String> list = translations.get(word); 
        if (translations.get(word) == null) {
            return new ArrayList<>();
        }
        return translations.get(word);
    }
    
    public void remove(String word) {
        translations.remove(word);
    }
}
