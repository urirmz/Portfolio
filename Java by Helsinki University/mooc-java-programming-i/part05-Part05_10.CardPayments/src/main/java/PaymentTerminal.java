
public class PaymentTerminal {

    private double money;  // amount of cash
    private int affordableMeals; // number of sold affordable meals
    private int heartyMeals;  // number of sold hearty meals

    public PaymentTerminal() {
        this.money = 1000;
    }

    public double eatAffordably(double payment) {
        if (payment >= 2.50) {
            this.money += 2.5;
            return payment - 2.5;
        } else {
            return payment;
        }
    }

    public double eatHeartily(double payment) {
        if (payment >= 4.3) {
            this.money += 4.3;
            return payment - 4.3;
        } else {
            return payment;
        }
    }

    public boolean eatAffordably(PaymentCard card) {
        return card.takeMoney(2.5);
    }

    public boolean eatHeartily(PaymentCard card) {
        return card.takeMoney(4.3);
    }
    
    public void addMoneyToCard(PaymentCard card, double sum) {
        this.money += sum;
        card.addMoney(sum);
    }

    @Override
    public String toString() {
        return "money: " + money + ", number of sold affordable meals: " + affordableMeals + ", number of sold hearty meals: " + heartyMeals;
    }
}
