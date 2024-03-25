import java.util.Scanner;

public class UserInterface {
    
    private Scanner scan;
    private Statistics stats;

    public UserInterface(Scanner scan, Statistics stats) {
        this.scan = scan;
        this.stats = stats;
    }
    
    public void start() {
        System.out.println("Enter point totals, -1 stops:");
        while (true) {            
            int input = this.scan.nextInt();
            
            if (input == -1) {
                break;
            }
            
            this.stats.addPoints(input);
        }
        
        System.out.println("Point average (all): " + this.stats.getAverage());
        
        double passingAverage = this.stats.getPassingAverage();
        if (passingAverage > 0) {
            System.out.println("Point average (passing): " + passingAverage);
        } else {
            System.out.println("Point average (passing): -");
        }
        
        System.out.println("Pass percentage: " + this.stats.passPercentage());
        System.out.println("Grade distribution:");
        this.stats.printGradeDistribution();
    }
}
