
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Scanner;

public class LiteracyComparison {
    
    public static void main(String[] args) {
        
        try {
            Files.lines(Paths.get("literacy.csv"))  
                    .sorted((actualRow, nextRow) -> {
                        String[] actualColumns = actualRow.split(",");
                        String[] nextColumns = nextRow.split(",");
                        
                        return actualColumns[5].compareTo(nextColumns[5]);
                    })
                    .map(row -> {
                        String[] columns = row.split(",");
                        columns[2] = columns[2].replace("(%)", "").trim();
                        
                        return columns[3] + " (" + columns[4] + "), " + columns[2] + ", " + columns[5];
                    })
                    .forEach(row -> System.out.println(row));
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
        }
        
    }
}
