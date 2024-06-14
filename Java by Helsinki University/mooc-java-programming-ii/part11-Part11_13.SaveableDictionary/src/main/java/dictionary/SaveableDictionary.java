package dictionary;

import java.io.PrintWriter;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Scanner;

public class SaveableDictionary {
    private HashMap<String, String> dictionary;
    private String filePath;

    public SaveableDictionary() {
        dictionary = new HashMap<>();
    }

    public SaveableDictionary(String file) {
        dictionary = new HashMap<>();
        filePath = file;
    }

    public boolean load() {
        try {
            Scanner fileReader = new Scanner(Paths.get(filePath));   
            while (fileReader.hasNextLine()) {
                String line = fileReader.nextLine();
                String[] parts = line.split(":");
                this.add(parts[0], parts[1]);
            }
            return true;
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return false;
        }        
    }

    public void add(String word, String translation) {
        if (dictionary.containsKey(word) || dictionary.containsKey(translation)) {
            return;
        }
        dictionary.put(word, translation);
        dictionary.put(translation, word);
    }

    public String translate(String word) {
        if (dictionary.containsKey(word)) {
            return dictionary.get(word);
        }
        return null;
    }

    public void delete(String word) {
        String translation = dictionary.get(word);

        dictionary.remove(word);
        dictionary.remove(translation);
    }
    
    public boolean save() {
        try {
            PrintWriter writer = new PrintWriter(filePath);
            HashSet<String> alreadySaved = new HashSet<>();
            
            for (String word : dictionary.keySet()) {
                if (!alreadySaved.contains(word)) {
                    String translation = dictionary.get(word);
                    writer.println(word + ":" + translation);                    
                    System.out.println(word + ":" + translation);
                    alreadySaved.add(word);
                    alreadySaved.add(translation);
                }
            }
            writer.close();
            
            return true;
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            return false;
        }
    }
}
