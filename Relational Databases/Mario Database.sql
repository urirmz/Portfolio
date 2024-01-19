-- PostgreSQL
-- Log in by typing psql --username=freecodecamp --dbname=postgres into the terminal and pressing enter.
-- Type \l into the prompt to list the databases available.

-- Databases
-- You can make your own data base like this: CREATE DATABASE database_name;
-- The capitalized words are keywords telling PostgreSQL what to do. The name of the database is the lowercase word. Note that all commands need a semi-colon at the end. If you don't get a message after entering a command, it means it's incomplete and you likely forgot the semi-colon
-- If you don't get a message after a command, it is likely incomplete. This is because you can put a command on multiple lines.
-- You can connect to a database by entering \c database_name. You need to connect to add information. 
-- In PostgreSQL, your prompt changes to the database you are connected, like: database=>
-- You can display tables with \d. You can view more details about a table by adding the table name after the display command like this: \d table_name
-- You can rename a database like this: ALTER DATABASE database_name RENAME TO new_database_name;
-- You can delete a data base with: DROP DATABASE database_name; 

-- Tables
-- You can create a table like this: CREATE TABLE table_name();
-- You can delete tables with: DROP TABLE table_name;

-- Columns
-- Tables need columns to describe the data in them, yours doesn't have any yet. Here's an example of how to add one: ALTER TABLE table_name ADD COLUMN column_name DATATYPE;
-- You can add a constraint by putting it right after the data type.
-- You can remove columns with: ALTER TABLE table_name DROP COLUMN column_name;
-- Here's how you can rename a column: ALTER TABLE table_name RENAME COLUMN column_name TO new_name;

-- Rows
-- Rows are the actual data in the table. You can add one like this: INSERT INTO table_name(column_1, column_2) VALUES(value1, value2);
-- Adding rows one at a time is quite tedious. Here's an example of how you could have added the previous three rows at once:
-- INSERT INTO characters(name, homeland, favorite_color)
-- VALUES('Mario', 'Mushroom Kingdom', 'Red'),
-- ('Luigi', 'Mushroom Kingdom', 'Green'),
-- ('Peach', 'Mushroom Kingdom', 'Pink');
-- You can view the data in a table by querying it with the SELECT statement. Here's how it looks: SELECT columns FROM table_name;
-- You can use an asterisk (*) to denote that you want to see all the columns.
-- Here's an example of how to delete a row: DELETE FROM table_name WHERE condition;
-- You can change a value in a row like this: UPDATE table_name SET column_name=new_value WHERE condition;

-- Data types
-- A common data type is VARCHAR. It's a short string of characters. You need to give it a maximum length when using it like this: VARCHAR(30). Make sure to use single quotes where needed when adding a VARCHAR type value
-- The SERIAL type will make your column an INT with a NOT NULL constraint, and automatically increment the integer when a new row is added.