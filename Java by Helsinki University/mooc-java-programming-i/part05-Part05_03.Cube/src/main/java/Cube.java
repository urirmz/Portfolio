public class Cube {
    private int edgeLength;
    private int volume;
    
    public Cube(int edgeLength) {
        this.edgeLength = edgeLength;
        this.volume = edgeLength * edgeLength * edgeLength;
    }
    
    public int volume() {
        return this.volume;
    }
    
    public String toString() {
        return "The length of the edge is " + this.edgeLength + " and the volume " + this.volume;
    }
}
