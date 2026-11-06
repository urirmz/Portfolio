# WRITE YOUR SOLUTION HERE:

from signal import pause
class LunchCard:
    def __init__(self, balance: float):
        self.balance = balance

    def deposit_money(self, amount: float):
        self.balance += amount

    def subtract_from_balance(self, amount: float) -> bool:
        if self.balance < amount:
            return False
        else:
            self.balance -= amount
            return True

class PaymentTerminal:
    def __init__(self):
        self.funds = 1000
        self.lunches = 0
        self.specials = 0

    def eat_lunch(self, payment: float):
        if payment < 2.5:
            return payment
        self.funds += 2.5
        self.lunches += 1
        return payment - 2.5

    def eat_special(self, payment: float):
        if payment < 4.3:
            return payment
        self.funds += 4.3
        self.specials += 1
        return payment - 4.3

    def eat_lunch_lunchcard(self, card: LunchCard):
        is_payment_done = card.subtract_from_balance(2.5)
        if is_payment_done: self.lunches += 1
        return is_payment_done

    def eat_special_lunchcard(self, card: LunchCard):
        is_payment_done = card.subtract_from_balance(4.3)
        if is_payment_done: self.specials += 1
        return is_payment_done

    def deposit_money_on_card(self, card: LunchCard, amount: float):
        card.deposit_money(amount)