
public class Money {

    private final int euros;
    private final int cents;

    public Money(int euros, int cents) {

        if (cents > 99) {
            euros = euros + cents / 100;
            cents = cents % 100;
        }

        this.euros = euros;
        this.cents = cents;
    }

    public int euros() {
        return this.euros;
    }

    public int cents() {
        return this.cents;
    }

    public String toString() {
        String zero = "";
        if (this.cents < 10) {
            zero = "0";
        }

        return this.euros + "." + zero + this.cents + "e";
    }

    @Override
    public Money clone() {
        return new Money(this.euros, this.cents);
    }

    public Money plus(Money addition) {
        return new Money(this.euros + addition.euros, this.cents + addition.cents);
    }
    
    public boolean lessThan(Money compared) {
        return this.getTotalCents() < compared.getTotalCents();
    }
    
    public Money minus(Money decreaser) {
        Money newMoney = new Money(0, this.getTotalCents() - decreaser.getTotalCents());
        if (newMoney.getTotalCents() < 0) {
            return new Money(0, 0);
        } else {
            return newMoney;
        }
    }
    
    public int getTotalCents() {
        return (this.euros * 100) + this.cents;
    }
}
