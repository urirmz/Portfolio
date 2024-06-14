package application;

import java.util.Random;

public class TemperatureSensor implements Sensor {
    private boolean on;
    
    public TemperatureSensor() {
        on = false;
    }
    
    public boolean isOn() {
        return on;
    };    
    
    public void setOn() {
        on = true;
    }  
    
    public void setOff() {
        on = false;
    } 
    
    public int read() {
        if (!on) {
            throw new IllegalStateException();
        }
        
        return new Random().nextInt(61) - 30;
    }
}
