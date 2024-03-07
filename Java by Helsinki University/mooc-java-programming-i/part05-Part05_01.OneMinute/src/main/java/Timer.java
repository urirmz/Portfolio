public class Timer {
    private ClockHand seconds;
    private ClockHand hundredsOfSecond;
    
    public Timer() {
        this.seconds = new ClockHand(60);
        this.hundredsOfSecond = new ClockHand(100);
    }
    
    public void advance() {
        this.hundredsOfSecond.advance();
        
        if (hundredsOfSecond.value() == 0) {
            this.seconds.advance();
        }
    }
    
    public String toString() {
        return this.seconds.toString() + ":" + this.hundredsOfSecond.toString();
    }
}
