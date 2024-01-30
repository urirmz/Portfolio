# Bash terminal

# The first thing you need to do is start the terminal. Do that by clicking the "hamburger" menu at the top left of the screen, going to the "terminal" section, and clicking "new terminal"
# The echo command lets you print anything to the terminal. Type "echo Hello terminal!". You can print to a file instead of the terminal with echo <text> > <filename>. A single > will create or overwrite the file. Use the same command with >> to append to the file.
# Type pwd into the terminal and press enter to see the path of the folder. pwd stands for "print working directory".
# Type ls into the terminal to see what's in this folder. ls stands for "list".
# You can use cd <folder_name> to go into a folder. cd stands for "change directory".
# You can use cd .. to go back a folder level. The two dots will take you back one level. 
# You can see what's in a file with more <filename>
# You can empty the terminal with clear
# You can add a flag to a command to use it different ways like this: ls <flag>. List the contents of the node_modules folder in "long list format". Do that by adding the -l flag to the "list" command.
# You can go back two folders with cd ../... Each set of dots represents another folder level. 
# You can make a new folder with mkdir <folder_name>. mkdir stands for "make directory".
# You can use touch <filename> to create a new file.
# You might turn this into a git repository. Create .gitignore in the folder with the touch method.
# Most commands have a --help flag to show what the command can do
# Using ls -a you can look the hidden items in the folder.The . takes you to the folder you are in, and .. takes you back, or up, a folder
# You can copy a file with cp <file> <destination>. cp stands for "copy". 
# You can remove a file with rm <filename>. There's a -r flag that says, remove directories and their contents recursively. That will remove the folder and everything in it.
#  You can rename files with mv like this: mv <filename> <new_filename>. mv stands for "move", it can rename or move something.
# You can use find to find things or view a file tree. A single dot represents the actual folder.  You can use find <folder_name> to display the tree of a different folder.
#  You can search for something with find -name <filename>
# You can use rmdir <directory_name> to remove a folder. rmdir stands for "remove directory".

# Scripts 
# You can run commands in the terminal or put them in a file to be run as a script. You can run a script file with command "sh script.sh". sh stands for shell.
# Using sh to run your script uses the shell interpreter. You can also run a script with command "bash script.sh" to use the bash interpreter. bash stands for bourne-again shell
# You can look for the exact path of and interpreter with the "which" command, like "which bash"
# You can tell your program to use an specified interpreter by placing a shebang at the very top of the file like this: #!<path_to_interpreter>
# Instead of using sh or bash to run your script. You can run it by executing the file and it will default to bash. Execute your script with ./script.sh
# You can look for file permissions with "ls -l". Next to your file is -rw-r--r--. All but the first character (-) describe permissions different users have with the file. r means read, w means write, x means execute
# "chmod" command is used to change permissions
# Bash has variables, functions, and other things you might be familiar with. You can create a variable with VARIABLE_NAME=VALUE. There cannot be any spaces around the equal (=) sign. If a variable has any spaces in it, place double quotes around it.
# To use a variable, place $ in front of it like this: $VARIABLE_NAME. Shell scripts run from top to bottom, so you can only use variable below where it's created
# You want to be able to accept input from a user. You can do that with read like this: read VARIABLE_NAME. This will get user input and store it into a new variable.
# Another way to find information about a command is with man. It stands for manual and you can use it like this: man <command>
# Comments in bash look like this: # <comment>. You can create a multiline comment like this:
# : '
#   comment here
#   more comment here
# '
# Programs can take arguments. You can access them a few different ways with $. Add echo $* in your script to print all arguments passed to it.
# To access any one of them, use $<number>
# "help" command in bash prints out some of the bash commands. "help <command>" prints more information about the specified command
# You can view the exit status of the last command with "echo $?". 0 means true and 1 means false. Anything but 0 means there was an error with the command
# You can separate commands on a single line with ;
# A shell comes with environment variables. View them by entering printenv in the terminal.
# You can view all variables in the shell with declare -p. -p stands for print. declare can be used to create variables
# The RANDOM variable will generate a random number between 0 and 32767. You can use the modulus operator to make it in the range you want. In your script, change the NUMBER variable to $RANDOM%75.
# (( ... )) will perform a calculation or operation and output nothing. $(( ... )) will replace the calculation with the result of it.
#  You can view the type of a command with type <command>
# cat is a terminal command for printing the contents of a file. 

# IFS
# There's a default IFS variable in bash. IFS stands for "Internal Field Separator". View it with declare -p IFS. This variable is used to determine word boundaries. It defaults to spaces, tabs, and new lines. This is why the MAJOR variable was set to only the first word on each line from the data. Between the while and read commands, set the IFS to a comma like this: IFS=","

# Patterns 
# An important operator in bash is =~. It allows for pattern matching
# You can use regular expression characters as well, but you can't put the pattern in quotes when you do. Using the same syntax, check if hello world starts with an h by using ^h as the pattern. 
# ^h.+d$ is the pattern to see if the string starts with an h, has at least one character after it, and ends with a d.
# Pattern ^[0-9]$. The ^ signifies the start of the pattern, and $ means the end. So the input will have to start, contain a number 0-9, and end.
# The ^  (^<space>) pattern only replaced the first space. Add * at the end of the matching pattern to replace all spaces at the beginning of text.

# If
# if [[ CONDITION ]]
# then
#   STATEMENTS
# fi
# You can compare integers inside the brackets ([[ ... ]]) of your if with -eq (equal), -ne (not equal), -lt (less than), -le (less than or equal), -gt (greater than), -ge (greater than or equal). 
# You can test if a variable is empty with [[ -z $MAJOR_ID ]]

# Switch case
# case EXPRESSION in
#   PATTERN) STATEMENTS ;;
#   PATTERN) STATEMENTS ;;
#   PATTERN) STATEMENTS ;;
#   *) STATEMENTS ;;
# esac
# The * is for when anything else is entered

# For
# for (( i = 10; i > 0; i-- ))
# do
#   echo $i
# done

# While
# while [[ CONDITION ]]
# do
#   STATEMENTS
# done

# Until loop
# The until loop is very similar to the while loop you used. It will execute the loop until a condition is met. Here's an example:
# until [[ CONDITION ]]
# do
#   STATEMENTS
# done

# Arrays
# You can create an array like this: ARR=("a" "b" "c")
# You can print an item of the array like this: echo ${ARR[1]}
# You were able to print all the arguments of an script with echo $*. echo $@ would have worked as well. Similarly, you can use the * or @ to print your whole array, like this: echo ${ARR[*]}

# Functions
# You can create a function like this:
# FUNCTION_NAME() {
#   STATEMENTS
# }
# You can call it with: FUNCTION_NAME argument

# Standard inputs/outputs
# The echo command lets you print anything to the terminal. Type "echo Hello terminal!". You can print to a file instead of the terminal with echo <text> > <filename>. A single > will create or overwrite the file. Use the same command with >> to append to the file.
# There’s two types of output, stdout (standard out) for when a command is successful, and stderr (standard error) for when it’s not. Both of these will print to the terminal by default. bad_command was not a valid command, so it printed to stderr. You can redirect stderr with 2> <filename>. Similarily, you can use 1> to redirect stdout
# stdout and stderr are for output. stdin (standard in) is the third thing commands can use and is for getting input. The default is the keyboard. Enter read <variable> in the terminal to see a command that uses stdin. The read command is looking at stdin for where to get input, which is pointing to the keyboard. Just like you can redirect output, you can redirect stdin as well. Here's an example: <command> < <filename_for_stdin>
# Another way to set the stdin is by using the pipe (|). It will use the output from one command as input for another. Here's an example: <command_1> | <command_2>. This will take the stdout from command_1 and use it as the stdin for command_2
# cat is another command that takes input. cat will print the contents of a file or input to stdout. cat can take a filename as an argument. 

# Commands
# echo $?  will print the exit code of the last command
# wc prints some info about a file. It can take a file as an argument. wc stands for word count. It shows you how many lines are in the file, how many words, and how many bytes. 
# grep is a command for searching for patterns in text. You can use it like this: grep '<pattern>' <filename>. Without flags, it shows all the lines that contains the pattern in the filename. To search for more than one pattern you can use grep '<pattern1>|<pattern2>'
# sed can replace text like this: sed 's/<pattern_to_replace>/<text_to_replace_it_with>/' <filename>. By default, it won't replace the text in the file. It will output it to stdout. You can add regex flags after the last / in the sed argument. A g, for global, would replace all instances of a matched pattern, or an i to ignore the case of the pattern. You can replace many patterns using sed like this: sed 's/<pattern_1>/<replacement_1>/; s/<pattern_2>/<replacement_2>/'
# diff is a command to view the difference between two files. You can use it like this: diff <file_1> <file_2>

# Sub-shells
# What you put the in subshell ($(...)) will be executed, and the result of it will replace the subshell