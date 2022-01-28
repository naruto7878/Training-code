# Group Activity
* Open up the Store App SDD.pdf for your P0 requirements
* Start thinking about what theme you want to follow through for the store app
* :exclamation:**Focus on finishing the functionalities first**:exclamation: before adding any extra features you will like to implement on your store app.

## Creating basic project structure
1. Create a Model **class library** project
2. Create a UI **console** project
3. Create a BL **class library** project
    * For now, just leave this alone
4. Create a DL **class library** project
    * For now, just leave this alone

## Implement possible models required
* Start creating any number of models you think you will need to accomplish the store app
* the PDF file should give you a starting point of what models you will need
* Think about what model will have a collection of another model like my demo
* Make sure your models have proper validation to make your life easier later on

## Implement a basic UI menus
* Like our previous group activity, start creating a menu interface that will navigate through your store app.
* One big difference from our last group activity is that we are making multiple C# files that will correspond to a single menu page.
    * Just follow the general rule that every C# file should have only one responsibilty and should only be change for that one responsibility only
    * Ex: Adding a customer will need a menu to display to the user what they will need to add a customer
* Look at the functionalities required for this project and start thinking of a menu that can accomplish those tasks
* Ex:
    Adding a customer
    - It will need a menu that will take in a couple Console.ReadLine() inputs from the user
    - It will need to save that information into a model
    - It needs proper validation (if one of the fields needs an age to make a customer, it wouldn't make sense if the user can input -30 as their age)
    - It needs proper conversion of datatypes since Console.ReadLine() will always give a string 

## Adding project0 to a separate github remote repository
* Create a new Github repository in the organization
* Naming convention - Firstname-Lastname-P0
* Store anything project 0 related inside of this remote repository
### Tips
* Make sure your project 0 folder is not inside of another local repository that already exist (You should put it on a different folder)
* Then follow the same steps located inside our first group activity

# Phase 2
## Complete Adding Customer function
* Must have Adding Customer menu page completed before starting this step
* Update BL and DL project to also save the customer to a database (A JSON file)
1. Start with the DL project
2. Create a repository interface and start listing potential methods you might need
    * Be sure to add XML documentation
3. Create a repository that inherits the interface and add the actual implementation detail to accomplish the task
    * Just finish one method at a time and test if the method is working
4. Go to the BL project
5. Same workflow, create an interface and a class that inherits the interface
6. Don't forget to include dependency injection in the constructor of class
    * It makes it so when we update the DL project in the future, you don't have to change/refactor any of your other projects but just the DL project
7. If needed, do further data processing within the method
8. Go to the UI project
9. Add dependency injection on the C# file responsible for displaying the add customer UI
10. Update the UI to now store the customer information to the database
11. Run application and check JSON file if it successfully saved their information

### Things to consider
* Data layer should be the only project that can exclusively manipulate our database
* Business layer might do further processing or validation on the data it obtains from the Data Layer
* Be sure to implement Dependency Injection right
    * Will be extremely useful when we go around and updating our projects further
* Don't forget that to reference other C# files from a different project you need to use a CLI command
```
dotnet add reference (project filepath)
```
* Proper documentation with XML comments

# Phase 3
## Add Search function
* Not much different or drastic changes needed to your app architecture
* Due to this reason, I'm sure you can figure it out or check my video on how I added search funtionality

# Phase 4
## Adding Logging functionality to your program
* Make sure you have a functional AddCustomer first
* We will log information based on what the user is doing in our application
    * There are other ways to log information but that will be the premise we will start with
* You can have logger on the different projects if you want, but you can strictly just have logging in the UI project
1. Make sure you have installed the proper packages needed to accomplish this specifically inside of the UI project
```
dotnet add package Serilog
dotnet add package Serilog.Sinks.File
```
* You can confirm if you installed the right packages by looking at the .csproj file
2. Update your program.cs file with creating and configuring the logger
    * Code should look similar to what I did on the demo
    * Make sure to use Serilog namespace for intellisense to detect and work properly
3. Start logging!
    * Log information to where it makes sense to do so
    * What is currently being displayed
    * What is the function the user is trying to do
    * Any potential warning/validation displayed to the user due to the user putting in the wrong thing
    * etc.

# Phase 5
## Add Unit tests validation for the majority of your models
* Start looking into possible methods you can use in Assert to have a good idea what you can cross check to ensure validation is working properly
* Make sure you arrange your unit testing in the AAA (Arrange, Act, Assert) format
* Don't forget the data annotation above the method to treat it as a unit test
```
dotnet test - executes testing process
dotnet new xunit - creates the xunit framework project for testing
```
