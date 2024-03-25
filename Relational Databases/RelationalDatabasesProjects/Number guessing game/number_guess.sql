#! /bin/bash

PSQL="psql --username=freecodecamp --dbname=number_guess -t --no-align -c"

echo Enter your username:
read USERNAME

GAMES_PLAYED=$($PSQL "SELECT COUNT(*) FROM games INNER JOIN users USING(user_id) WHERE name = '$USERNAME';")

if [[ $GAMES_PLAYED -gt 0 ]]; then # User already registered
  USER_ID=$($PSQL "SELECT user_id FROM users WHERE name = '$USERNAME';")
  BEST_GAME=$($PSQL "SELECT MIN(number_of_guesses) FROM games WHERE user_id = '$USER_ID';")

  echo "Welcome back, $USERNAME! You have played $GAMES_PLAYED games, and your best game took $BEST_GAME guesses."
else # User not registered
  USER_REGISTER_RESULT=$($PSQL "INSERT INTO users(name) VALUES('$USERNAME')")
  USER_ID=$($PSQL "SELECT user_id FROM users WHERE name = '$USERNAME';")
  echo "Welcome, $USERNAME! It looks like this is your first time here."
fi

RANDOM_NUMBER=$((1 + RANDOM % 1000))
TRIES=0

echo Guess the secret number between 1 and 1000:
while ! [[ $NUMBER -eq $RANDOM_NUMBER ]]
do
  read NUMBER
  TRIES=$(( $TRIES + 1 ))
  if ! [[ $NUMBER =~ ^[0-9]+$ ]]; then
    echo "That is not an integer, guess again:" 
  elif [[ $NUMBER -lt $RANDOM_NUMBER ]]; then 
    echo "It's higher than that, guess again:"
  elif [[ $NUMBER -gt $RANDOM_NUMBER ]]; then
    echo "It's lower than that, guess again:"
  else
    INSERT_GAME_RESULT=$($PSQL "INSERT INTO games(user_id, number_of_guesses) VALUES($USER_ID, $TRIES);")

    echo "You guessed it in $TRIES tries. The secret number was $RANDOM_NUMBER. Nice job!"
    break
  fi
done 
