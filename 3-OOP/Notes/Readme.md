# .NET Architecture Components
* There are many frameworks included in .NET 6.0
    * A framework are just predefined classes and libraries to help us start an application
    * One framework we will be using in the future is ASP.NET (Used to create Web Apis)
## SDK vs Runtime
### SDK
* Software Development Kit
* Includes everything we need to build and run a .NET application
    * Such as Command-Line interface commands to create our projects as well as a bunch of other functionalities
* SDK includes Runtime as well why? Well when you develop an application you of course need to run it to be able to test if everything is working properly
### Runtime
* It includes all the resources we need to run existing .NET application
* A lot less storage required to download and install
* Mostly useful for end-users (people who will be using our application)

# Common Language Infrastructure (CLI)
* This is the  infrastructure of .NET on how it is able to write your application in numerous programming language beyond C# and for your application to be run on any operating system
## General structure of the CLI
* CLS
    * CTS
    * VES
        * CLR
## CLS
* Common Language Specification
* It has defined rules and restrictions that every langauge must follow for it to be able to run the .NET framework
* Essentially a standardization to make sure a language won't do anything that will make it incompatible with .NET framework
## CTS
* Common Type System
* Provides a library of the basic value data types
* It is a standardization of data types to ensure every language will follow the same datatype
    * Ex: int in C# is the same 32-bit memory as the int in Visual Basic
* Helps create **Language Interoperability**
    * Fancy way of saying .NET has the capability to develop application using two or more programming languages
    * You can create apps using Visual Basic, C#, J# (Java-like language that can run in .NET), etc.
        * NEVER SAY JAVA ITSELF J# IS NOT JAVA
## VES
* Run-time system of CLI that provides all the tools it needs to be able to execute your application
### CLR
* Common Language Runtime implements VES so anything in VES, CLR also has it plus more
* Essentially, it is .NET's version of VES
* Run-time environment that provides services that make the development process easier
* Some servies it includes:
    * Automatic memory management (older languages you ahve to manually release unused resources)
    * JIT compilation (Just-inTime compilation that involves compliation during execution for optimization)
        * It just means any new compile code gets executed immediately, it doesn't have to wait until your entire code has been compiled to run your app
    * Exception handling support

# 4 Object-Oriented Pillars
* The core principles of Object Oriented Programming

## Encapsulation
* The process of wrapping code and data together into a single unit
* So any validation and processing of data in your class will be handled by the class itself
* They **prevent unauthorize access** to your object's properties and setting vlaues that shouldn't be there
* **Key note:** this is only possible if you make your fields private so nothing can access it but the class itself

## Inheritance
* It is the mechanism in which a class can acquire all the properties and behavior of a parent class
* It allows us to create classes that are build upon existing classes
    * Essentially the big thing is **code reusability**! Why write the same thing over and over again when you can just inherit it all
### Terminology
* Base class
    * It is the parent class in which the child class inherits from
* Derived class
    * It is the child class that inherits from the parent class
### Different types of inheritance
* Single Inheritance
    * Where the base class only have one derived class
* Multi-level inheritance
    * Like the single inheritance but the derived class gets inherited by another derived class
* Hierarchical Inheritance
    * Where the base class has multiple derived classes and those derived classes have their own multiple derived classes
* :exclamation:**Multiple inheritance does not exist**:exclamation:
### Access Modifiers
* They restrict the scope of classes, methods, fields, etc. to only be accessible in certain areas
* Public
    * Everything has access to it
* Internal
    * Access within the class
    * Access within the derived class
    * Access within the same project
    * Default access modifier for classes
* Protected
    * Access within the class
    * Access within the derived class
* Private
    * Access only within the class
    * This is the default access modifiers for class members

## Polymorphism
* The ability of an object to take on many forms
* It allows you to substitute different implementation details for different needs
* Inheritance allows us to re-use code but with polymorphism, we can add more functionality to our code
### Method Overriding
* When a derived class changes the implementation details of a method from the base class
### Method Overloading
* When there are multiple method but with different parameters and most of the time, different implementation details

## Abstraction
* The process of hiding the implementation details and only showing the functionality to the user
* A way to simplify complex application and not worry about the implementation details and just really focuse on the functionality of something.
* Ex: You know how to send a text with your phone but you don't know the process on how that text gets send over to the other person
* The way we implement abstraction is through the use of interfaces and abstract classes
### Interface
* It contains nothing but abstract methods and properties
    * That just means you don't have to write implementation details when you create an interface
* You can "inherit" multiple interfaces
### Abstract class
* May contain some methods and properties with implementation
* May also contain abstract methods and properties
* You cannot inherit multiple abstract classes

# Test Driven Development (TDD)
* TDD is a software development process that creates test cases for the software requirement **first** before developing the actual program
## The flow of TDD
1. Create a test case - What you expect the feature is suppose to do
2. Running the test case will fail the first time - obviously since you haven't created the actual implementation details to make it pass
3. Write code so the new test case will pass
4. Make sure old test cases won't fail because of the new feature (probably the biggest thing as to why we do unit testing so anything new added will also test our old functionalities to make sure everything is working as intended)
5. Clean up the code and have proper documentation for other developers

## Unit testing
* Like the word "Unit", you will test a small portion of your code to ensure it is working
* Helpful to check that particular section of your code is working

## Arrange, Act, and Assert (The 3 good ole As)
* Arrange
    * This is where you initiliaze objects or some values you will need for the test
* Act
    * Invokes the method/function under the test with the arranged objects/values
* Assert
    * Verifies that the action of the method under the tests behaves as expected

## Code Coverage
* It is the percentage given to you on how much lines of your code is actually covered by unit testing
* Ex: Lets say you have a total of 200 lines of code and your unit testins only covers 70 lines of code. That means you have 35% code coverage (Fancy math - 70/200*100 = 35%)

# Logging
* The systematically way to record a series of events depending on what exactly you are trying to capture
* Ex: Logging user events - you will record every single page they went through, every single customer they have added, every single orders they have made
* The main purpose is for debugging potential bugs since the main problem with debugging is trying to re-create that bug again just to see what exactly did the user did to even get that bug
* Asking for feedback from a user as to what they did is incredibly unreliable so we have a robot to essentially record everything they do
* OF COURSE, that is only limited to what are they doing in the application and highly unethical (maybe illegal I'm not a lawyer) to record everything they do beyond that
## Serilog
* A library we will utilize to add logging functionality with our application
* There are more libraries out there that can accomplish the same task such as NLog but we will stick with Serilog
### Steps to start Serilog
1. Make sure you add the package from Nuget
```
dotnet add package Serilog
dotnet add package Serilog.Sinks.File
```
2. create a Logger using LoggerConfiguration class provided by Serilog
3. Start logging!