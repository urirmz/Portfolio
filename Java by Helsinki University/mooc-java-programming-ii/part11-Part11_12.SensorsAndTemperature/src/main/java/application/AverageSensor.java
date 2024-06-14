package application;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class AverageSensor implements Sensor {
    private List<Sensor> sensors;
    private List<Integer> readings;
    
    public AverageSensor() {
        sensors = new ArrayList<>();
        readings = new ArrayList<>();
    }
    
    public boolean isOn() {
        for (Sensor sensor : sensors) {
            if (!sensor.isOn()) {
                return false;
            }
        }
        return true;
    }
    
    public void setOn() {
        for (Sensor sensor : sensors) {
            sensor.setOn();
        }
    }   
    
    public void setOff() {
        for (Sensor sensor : sensors) {
            sensor.setOff();
        }
    }  
    
    public int read() {
        if (!isOn() || sensors.isEmpty()) {
            throw new IllegalStateException();
        }
        
        int reading = (int)sensors.stream()
                .mapToInt(sensor -> sensor.read())
                .average()
                .getAsDouble();
        
        readings.add(reading);
        
        return reading;
    } 
    
    public void addSensor(Sensor toAdd) {
        sensors.add(toAdd);
    }
    
    public List<Integer> readings() {
        return readings;
    }
}
