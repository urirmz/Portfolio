
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Hand implements Comparable<Hand> {
    private List<Card> cards;

    public Hand() {
        cards = new ArrayList<>();
    }

    public List<Card> getCards() {
        return cards;
    }
    
    public void add(Card card) {
        cards.add(card);
    }
    
    public void print() {
        for (Card card : cards) {
            System.out.println(card);
        }
    }
    
    public void sort() {
        Collections.sort(cards);
    }
    
    @Override
    public int compareTo(Hand hand) {
        int thisSum = cards.stream()
                .mapToInt(card -> card.getValue())
                .sum();
        int comparedSum = hand.getCards().stream()
                .mapToInt(card -> card.getValue())
                .sum();
        
        return thisSum - comparedSum;
    }
    
    public void sortBySuit() {
        BySuitInValueOrder comparator = new BySuitInValueOrder();
        Collections.sort(cards, comparator);
    }
}
