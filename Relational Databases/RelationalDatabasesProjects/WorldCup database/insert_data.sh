#! /bin/bash

if [[ $1 == "test" ]]
then
  PSQL="psql --username=postgres --dbname=worldcuptest -t --no-align -c"
else
  PSQL="psql --username=freecodecamp --dbname=worldcup -t --no-align -c"
fi

# Do not change code above this line. Use the PSQL variable above to query your database.

echo "$($PSQL "TRUNCATE games, teams;")"
GAME_SEQUENCE_RESTART_RESULT=$($PSQL "ALTER SEQUENCE games_game_id_seq RESTART WITH 1;")
if [[ $GAME_SEQUENCE_RESTART_RESULT = "ALTER SEQUENCE" ]]
then
  echo Restarted game id sequence
fi
TEAMS_SEQUENCE_RESTART_RESULT=$($PSQL "ALTER SEQUENCE teams_team_id_seq RESTART WITH 1;")
if [[ $TEAMS_SEQUENCE_RESTART_RESULT = "ALTER SEQUENCE" ]]
then
  echo Restarted teams id sequence
fi

cat games.csv | while IFS=',' read YEAR ROUND WINNER OPPONENT WINNER_GOALS OPPONENT_GOALS
do
  if [[ $YEAR != 'year' ]]
  then

    # Insert teams
    TEAM_ID=$($PSQL "SELECT team_id FROM teams WHERE name = '$WINNER'")
    if [[ -z $TEAM_ID ]]
    then
      INSERT_TEAM_RESULT=$($PSQL "INSERT INTO teams(name) VALUES('$WINNER')")
      if [[ $INSERT_TEAM_RESULT = "INSERT 0 1" ]]
      then
        echo Inserted into teams, $WINNER
      fi
    fi
    TEAM_ID=$($PSQL "SELECT team_id FROM teams WHERE name = '$OPPONENT'")
    if [[ -z $TEAM_ID ]]
    then
      INSERT_TEAM_RESULT=$($PSQL "INSERT INTO teams(name) VALUES('$OPPONENT')")
      if [[ $INSERT_TEAM_RESULT = "INSERT 0 1" ]]
      then
        echo Inserted into teams, $OPPONENT
      fi
    fi

    # Insert games
    WINNER_ID=$($PSQL "SELECT team_id FROM teams WHERE name='$WINNER'")
    OPPONENT_ID=$($PSQL "SELECT team_id FROM teams WHERE name='$OPPONENT'")
    INSERT_GAME_RESULT=$($PSQL "INSERT INTO games(year, round, winner_id, opponent_id, winner_goals, opponent_goals) VALUES($YEAR, '$ROUND', $WINNER_ID, $OPPONENT_ID, $WINNER_GOALS, $OPPONENT_GOALS)")
    if [[ $INSERT_GAME_RESULT = "INSERT 0 1" ]]
    then
    echo Inserted into games, $YEAR $ROUND : $WINNER $WINNER_GOALS $OPPONENT_GOALS $OPPONENT
    fi
  fi
done