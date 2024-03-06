
public class YourFirstAccount {

    public static void main(String[] args) {
        Account uriAccount = new Account("Uri's account", 100);
        
        uriAccount.deposit(20);
        
        System.out.println(uriAccount);
    }
}
