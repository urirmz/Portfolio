#! /bin/bash

PSQL="psql --username=freecodecamp --dbname=periodic_table -t --no-align -c"

if [[ ! $1 ]]
then
  echo Please provide an element as an argument.
  exit
else 
  if [[ $1 =~ ^[0-9]+$ ]]; then # Argument is a number
    ATOMIC_NUMBER=$1;
  elif [[ ${#1} -le 2 ]]; then # Argument is a symbol
    SYMBOL=$1
    ATOMIC_NUMBER=$($PSQL "SELECT atomic_number FROM elements WHERE symbol = '$1';")
  else # Argument is a name
    NAME=$1
    ATOMIC_NUMBER=$($PSQL "SELECT atomic_number FROM elements WHERE name = '$1';")
  fi

  if ! [[ $ATOMIC_NUMBER ]]; then
    echo "I could not find that element in the database."
    exit
  fi

  # Get the rest of the properties
  if [[ -z $NAME ]]; then 
  NAME=$($PSQL "SELECT name FROM elements WHERE atomic_number = '$ATOMIC_NUMBER';")
  fi
  if [[ -z $SYMBOL ]]; then 
  SYMBOL=$($PSQL "SELECT symbol FROM elements WHERE atomic_number = '$ATOMIC_NUMBER';")
  fi
  TYPE=$($PSQL "SELECT type FROM properties INNER JOIN types USING(type_id) WHERE atomic_number = '$ATOMIC_NUMBER';")
  MASS=$($PSQL "SELECT atomic_mass FROM properties WHERE atomic_number = '$ATOMIC_NUMBER';")
  MELTING_POINT=$($PSQL "SELECT melting_point_celsius FROM properties WHERE atomic_number = '$ATOMIC_NUMBER';")
  BOILING_POINT=$($PSQL "SELECT boiling_point_celsius FROM properties WHERE atomic_number = '$ATOMIC_NUMBER';")

  # Echo the output
  echo "The element with atomic number $ATOMIC_NUMBER is $NAME ($SYMBOL). It's a $TYPE, with a mass of $MASS amu. $NAME has a melting point of $MELTING_POINT celsius and a boiling point of $BOILING_POINT celsius."
fi

