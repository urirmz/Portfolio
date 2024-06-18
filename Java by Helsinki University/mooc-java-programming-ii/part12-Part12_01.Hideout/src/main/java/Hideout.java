public class Hideout<T> {
    private T hidden;
    
    public void putIntoHideout(T toHide) {
        if (hidden == toHide) {
            hidden = null;
        } else {
            hidden = toHide;
        }        
    }
    
    public T takeFromHideout() {
        T taken = hidden;
        hidden = null;
        return taken;
    }
    
    public boolean isInHideout() {
        return hidden != null;
    }
}
