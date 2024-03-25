public class Bird {
    
    private String name;
    private String latinName;
    private int observations;

    public Bird(String name, String latinName) {
        this.name = name;
        this.latinName = latinName;
        this.observations = 0;
    }  

    public String getName() {
        return name;
    }

    public String getLatinName() {
        return latinName;
    }

    public int getObservations() {
        return observations;
    }
    
    public void addObservation() {
        this.observations++;
    }
    
    @Override
    public String toString() {
//        Hawk (Dorkus Dorkus): 2 observations
        return this.name + "(" + this.latinName + "): " + this.observations + " observations";
    }
    
    @Override
    public boolean equals(Object compared) {
        if (this == compared) {
            return true;
        }
        
        if (!(compared instanceof Bird)) {
            return false;
        }
        
        Bird comparedBird = (Bird) compared;        
        return this.name.equals(comparedBird.getName()) &&
                this.latinName.equals(comparedBird.getLatinName());
    }
}
