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
-- Inside those parenthesis you can put columns for a table so you don't need to add them with a separate command, like this: 
-- CREATE TABLE table_name
-- (
--   column1 datatype [ NULL | NOT NULL ],
--   column2 datatype [ NULL | NOT NULL ],
--   ...
--   CONSTRAINT constraint_name UNIQUE (uc_col1, uc_col2, ... uc_col_n)
-- );
-- You can delete tables with: DROP TABLE table_name;

-- Constraints
-- To create set a NOT NULL to a column of a table you can use: ALTER TABLE table ALTER COLUMN column SET NOT NULL;
-- The syntax for creating a unique constraint using an ALTER TABLE statement in PostgreSQL is:
-- ALTER TABLE table_name
-- ADD CONSTRAINT constraint_name UNIQUE (column1, column2, ... column_n);

-- Primary Keys
-- A primary key it's a column that uniquely identifies each row in the table. Here's an example of how to set a PRIMARY KEY: ALTER TABLE table_name ADD PRIMARY KEY(column_name); You should set a primary key on every table and there can only be one per table. 
-- You can create a primary key from two columns, known as a composite primary key. Here's an example: ALTER TABLE table_name ADD PRIMARY KEY(column1, column2);
-- You can drop a constraint with: ALTER TABLE table_name DROP CONSTRAINT constraint_name;

-- Columns
-- Tables need columns to describe the data in them, yours doesn't have any yet. Here's an example of how to add one: ALTER TABLE table_name ADD COLUMN column_name DATATYPE;
-- You can add a constraint by putting it right after the data type. 
-- You can remove columns with: ALTER TABLE table_name DROP COLUMN column_name;
-- Here's how you can rename a column: ALTER TABLE table_name RENAME COLUMN column_name TO new_name;
-- You can change the data type of a column with: 
-- ALTER TABLE table_name
-- ALTER COLUMN column_name [SET DATA] TYPE new_data_type;

-- Rows
-- Rows are the actual data in the table. You can add one like this: INSERT INTO table_name(column_1, column_2) VALUES(value1, value2);
-- Adding rows one at a time is quite tedious. Here's an example of how you could have added the previous three rows at once:
-- INSERT INTO characters(name, homeland, favorite_color)
-- VALUES('Mario', 'Mushroom Kingdom', 'Red'),
-- ('Luigi', 'Mushroom Kingdom', 'Green'),
-- ('Peach', 'Mushroom Kingdom', 'Pink');
-- You can view the data in a table by querying it with the SELECT statement. Here's how it looks: SELECT columns FROM table_name;
-- You can separate the column names with a comma to view more than one column.
-- You can use an asterisk (*) to denote that you want to see all the columns. Like this: SELECT * FROM table_name;
-- You can view a row with a WHERE condition. Here's an example: SELECT columns FROM table_name WHERE condition;
-- Here's an example of how to delete a row: DELETE FROM table_name WHERE condition;
-- You can change a value in a row like this: UPDATE table_name SET column_name=new_value WHERE condition;
-- To order rows in a table, you can use: SELECT columns FROM table_name ORDER BY column_name;
-- You can left a value from a row in blank giving it the value NULL.

-- Data types
-- A common data type is VARCHAR. It's a short string of characters. You need to give it a maximum length when using it like this: VARCHAR(30). Make sure to use single quotes where needed when adding a VARCHAR type value
-- The SERIAL type will make your column an INT with a NOT NULL constraint, and automatically increment the integer when a new row is added.
-- NUMERIC(a, b) is a data type for decimals. NUMERIC(4, 1) has up to four digits and one of them has to be to the right of the decimal.
-- DATE values need a string with the format: 'YYYY-MM-DD'.

-- Relating tables
-- You need to set a foreign key so you can relate rows from a table to rows from another table. Here's an example that creates a column as a foreign key: ALTER TABLE table_name ADD COLUMN column_name DATATYPE REFERENCES referenced_table_name(referenced_column_name); 
-- You can also set a foreign key to an existing column with: ALTER TABLE table_name ADD FOREIGN KEY(column_name) REFERENCES referenced_table(referenced_column);
-- These tables have a "one-to-one" relationship. One row in the characters table will be related to exactly one row in more_info and vice versa. Enforce that by adding the UNIQUE constraint to your foreign key. Here's an example: ALTER TABLE table_name ADD UNIQUE(column_name);
-- The column should also be NOT NULL since you don't want to have a row that is for nobody. Here's an example: ALTER TABLE table_name ALTER COLUMN column_name SET NOT NULL;
-- One-to-many relationship. This means a row from one table can have many rows from another
-- "Many-to-many" relationships usually use a junction table to link two tables together, forming two "one-to-many" relationships
-- When you foreign key, you can get all the data from both tables with a JOIN command: SELECT columns FROM table_1 FULL JOIN table_2 ON table_1.primary_key_column = table_2.foreign_key_column;
-- You can also join more than two tables with: 
-- SELECT columns FROM junction_table
-- FULL JOIN table_1 ON junction_table.foreign_key_column = table_1.primary_key_column
-- FULL JOIN table_2 ON junction_table.foreign_key_column = table_2.primary_key_column;

-- Creating and retriving dumps
-- You can make a dump of a created database by entering pg_dump -cC --inserts -U freecodecamp universe > universe.sql in a bash terminal (not the psql one). It will save the commands to rebuild your database in universe.sql. The file will be located where the command was entered. If it's anything inside the project folder, the file will be saved in the VM. You can rebuild the database by entering psql -U postgres < universe.sql in a terminal where the .sql file is.

INSERT INTO star(name, age_in_millions_of_years, distance_from_earth, size_in_ligthyears, description, has_life, is_spherical, galaxy_id) 
VALUES('Sun', 4500, 0, 0, 'Our sun', false, true, 1), 
('Polaris', 70, 433, 0, 'North star', false, false, 1),
('Sirius', 242, 8611, 0, 'Brightest star', false, false, 1),
('Alpha Centauri', 485000, 4637, 0, 'Closest solar system', false, false, 1),
('Rigel', 864, 0, 8005, 'Super giant', false, false, 4),
('Vega', 455, 25, 0, 'Once the polar star', false, false, 1);

INSERT INTO moon(moon_id, name, age_in_millions_of_years, distance_from_earth, size_in_ligthyears, description, has_life, is_spherical, planet_id) 
VALUES(), 
(),
(),
(),
(),
();

INSERT INTO moon(moon_id, name, age_in_millions_of_years, distance_from_earth, size_in_ligthyears, description, has_life, is_spherical, planet_id) 
VALUES(), 
(),
(),
(),
(),
();