import java.util.ArrayList;

public class Statistics {
    
    private ArrayList<Integer> points;
    private ArrayList<Integer> grades;
    
    public Statistics() {
        this.points = new ArrayList<>();
        this.grades = new ArrayList<>();
    }
    
    public void addPoints(int points) {
        if (points >= 0 && points <= 100) {
            this.points.add(points);
            this.grades.add(pointsToGrade(points));
        }        
    }
    
    public int pointsToGrade(int points) {
        if (points < 50) {
            return 0;
        } else if (points < 60) {
            return 1;
        } else if (points < 70) {
            return 2;
        } else if (points < 80) {
            return 3;
        } else if (points < 90) {
            return 4;
        } else {
            return 5;
        }        
    }
    
    public int getSum() {
        int sum = 0;
        for (int point : this.points) {
            sum  += point;
        }
        return sum;
    }
    
    public double getAverage() {
        return (double) this.getSum() / this.points.size();
    }
    
    public int getPassingSum() {
        int sum = 0;
        for (int point : this.points) {
            if (point >= 50) {
                sum  += point;
            }            
        }
        return sum;
    }
    
    public int getPassedCourses() {
        int passed = 0;
        for (int point : this.points) {
            if (point >= 50) {
                passed++;
            }
        }
        return passed;
    }

    public double getPassingAverage() {
        return (double) this.getPassingSum() / this.getPassedCourses();
    }
    
    public double passPercentage() {
        return (double) this.getPassedCourses() * 100 / this.points.size();
    }
    
    public void printGradeDistribution() {
        int grade = 5;
        while (grade >= 0) {
            String stars = "";
            for (int comparedGrade : this.grades) {
                if (comparedGrade == grade) {
                    stars += "*";
                }
            }
            System.out.println(grade + ": " + stars);
            grade--;
        }        
    }
}
