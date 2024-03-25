#! /bin/bash

PSQL="psql --username=freecodecamp --dbname=salon -t -c"

echo -e "\n~~~ Uri's salon ~~~\n"

MAIN_MENU() {
  if [[ $1 ]]
  then
    echo -e "\n$1"
  fi


  SERVICES_MENU=$($PSQL "SELECT * FROM services;")
  echo "$SERVICES_MENU" | while read SERVICE_ID BAR SERVICE_NAME
  do
    echo -e "$SERVICE_ID) $SERVICE_NAME"
  done

  read SERVICE_ID_SELECTED
  SERVICE_ID_RESULT=$($PSQL "SELECT service_id FROM services WHERE service_id = $SERVICE_ID_SELECTED;")
  if [[ -z $SERVICE_ID_RESULT ]]
  then
    MAIN_MENU "Sorry, that service is not available, how can I assist you?"
  else
    SERVICE_NAME=$($PSQL "SELECT name FROM services WHERE service_id = $SERVICE_ID_SELECTED;" | sed 's/^ //')
    echo -e "\nYou have selected $SERVICE_NAME. Please provide your phone number to schedule an appointment:"

    read CUSTOMER_PHONE 
    CUSTOMER_NAME=$($PSQL "SELECT name FROM customers WHERE phone = '$CUSTOMER_PHONE';")
    if [[ -z $CUSTOMER_NAME ]] 
    then 
      echo -e "\nWe don't have a register with that phone, please provide your name:"
      read CUSTOMER_NAME
      INSERT_CUSTOMER_RESULT=$($PSQL "INSERT INTO customers(name, phone) VALUES('$CUSTOMER_NAME', '$CUSTOMER_PHONE')")
    fi

    CUSTOMER_ID=$($PSQL "SELECT customer_id FROM customers WHERE phone = '$CUSTOMER_PHONE';")

    echo -e "\nAt what time would you like your $SERVICE_NAME,$CUSTOMER_NAME?"
    read SERVICE_TIME
    INSERT_SERVICE_RESULT=$($PSQL "INSERT INTO appointments(customer_id, service_id, time) VALUES($CUSTOMER_ID, $SERVICE_ID_SELECTED, '$SERVICE_TIME')")

    echo -e "\nI have put you down for a $SERVICE_NAME at $SERVICE_TIME, $CUSTOMER_NAME."
  fi
  
}

MAIN_MENU "Welcome to Uri's salon, what are you looking for?"
