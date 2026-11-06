# Write your solution here
import random

class WordGame():
    def __init__(self, rounds: int):
        self.wins1 = 0
        self.wins2 = 0
        self.rounds = rounds

    def round_winner(self, player1_word: str, player2_word: str):
        # determine a random winner
        return random.randint(1, 2)

    def play(self):
        print("Word game:")
        for i in range(1, self.rounds+1):
            print(f"round {i}")
            answer1 = input("player1: ")
            answer2 = input("player2: ")

            if self.round_winner(answer1, answer2) == 1:
                self.wins1 += 1
                print("player 1 won")
            elif self.round_winner(answer1, answer2) == 2:
                self.wins2 += 1
                print("player 2 won")
            else:
                pass # it's a tie

        print("game over, wins:")
        print(f"player 1: {self.wins1}")
        print(f"player 2: {self.wins2}")

class LongestWord(WordGame):
    def __init__(self, rounds: int):
        super().__init__(rounds)

    def round_winner(self, player1_word: str, player2_word: str):
        length_1 = len(player1_word)
        length_2 = len(player2_word)
        if length_1 == length_2:
            return 0
        elif length_1 > length_2:
            return 1
        else:
            return 2

class MostVowels(WordGame):
    def __init__(self, rounds: int):
        super().__init__(rounds)

    @classmethod
    def __count_vowels(cls, word: str):
        return sum([1 if character in "aeiou" else 0 for character in word.lower()])
        
    def round_winner(self, player1_word: str, player2_word: str):
        vowels_1 = MostVowels.__count_vowels(player1_word)
        vowels_2 = MostVowels.__count_vowels(player2_word)
        if vowels_1 == vowels_2:
            return 0
        elif vowels_1 > vowels_2:
            return 1
        else:
            return 2

class RockPaperScissors(WordGame):
    def __init__(self, rounds: int):
        super().__init__(rounds)

    def round_winner(self, player1_word: str, player2_word: str):
        valid_words = ["rock", "paper", "scissors"]
        is_word_valid_1 = player1_word in valid_words
        is_word_valid_2 = player2_word in valid_words
        if (not is_word_valid_1 and not is_word_valid_2) or player1_word == player2_word:
            return 0
        elif not is_word_valid_2 or (player1_word == "rock" and player2_word == "scissors") or (player1_word == "paper" and player2_word == "rock") or (player1_word == "scissors" and player2_word == "paper"):
            return 1
        else:
            return 2
    

