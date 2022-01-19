# This is comment to add more information to your code
# echo ThisISAComment

echo ThisIsNotComment

# Variables
# They are a way for us to store information for our code to use at later time
msg="Hello World" # a equal sign is a way for us to create variables to store something
echo $msg # $ syntax is the way we can call on a variable

# Control Flow
# They are a way for us to tell the program what line of code we want to run
# or how many times we want to run that line of code


# IF statements
# Like the english word if, it will only run the line of code if a condition is true

ten=10
five=5
thirteen=13

# 10 > 5 then run these lines of code
echo "===First IF==="
if [ "$ten" -ge "$five" ]
then
echo "greater!"
echo "$ten > $five"
fi

# 5 > 10 then run these lines of code
echo "===Second IF==="
if [ "$five" -ge "$ten" ]
then
echo "lesser!"
echo "$five > $ten"
fi

# check if 5 > 10 and if not, check if 10 > 5
echo "===Third IF==="
if [ "$five" -ge "$ten" ]
then
echo "lesser!"
echo "$five > $ten"
elif [ "$ten" -ge "$five" ]
then
echo "greater!"
echo "$ten > $five"
fi

echo "===Fourth IF==="
if [ "$five" -ge "$ten" ]
then
echo "lesser!"
echo "$five > $ten"
elif [ "$ten" -ge "$thirteen" ]
then
echo "greater!"
echo "$ten > $thirteen"
else
echo "Nothing Works!"
fi

# Loop statements
# It will run that line of code multiple times as long as the condition you set is true

# For loop
# Will repeat the amount of code x amount of times (you determine how many times you want)
# Useful if you know how many times you want to repeat your code

echo "===For Loop==="
for num in 1 3 1 7 10 stephen
do
echo "Repeating!"
echo $num
done

echo "===Second For Loop==="
for num in {1..10}
do
echo $num
done

# While loop
# Will repeat the code multiple times as long as the condition is true

echo "===While loop==="
while [ "$ten" -ge "$five" ]
do
echo "Greater!"
echo $five
five=$(($five+1)) #$((mathematical operation)) is the syntax needed
done

# Input and Output
# We can ask the input for user that is currently using the shell script for some
# sort of information we will use

echo "What is your name?"
# read name
echo "Hello $name, Welcome to programming!"


# We will combine everything to create a menu-like interface of our terminal that
# will ask the user information and process that information based on whatever they
# want

clear # This will clear our terminal
repeat="true"

while [ "$repeat" == true ]
do
echo "Welcome to shell script!"
echo "What do you want to do today"
echo "enter 1 if  you want to add two numbers"
echo "enter 2 if you want to exit out of the program"
read ans

if [ "$ans" == "1" ]
then
echo "Give me two numbers"
read num1
read num2
echo "this is your number $(($num1+$num2))"
echo "Press Enter to continue"
read flkwije
elif [ "$ans" == "2" ]
then
echo "Goodbye!"
repeat="false"
else
echo "Command not found"
fi

clear
done
