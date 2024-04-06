public class CustomTacoBox implements TacoBox{
    private int tacos;

    public CustomTacoBox(int tacos) {
        this.tacos = tacos;
    }

    public void eat() {
        if (tacos >= 1) {
            tacos--;
        }        
    }

    public int tacosRemaining() {
        return tacos;
    }
}
