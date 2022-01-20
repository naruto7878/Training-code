# Introduction to .NET 6.0
* It is a free, open-souce development platform for a variety of applications (Games, websites, console, etc)
* Essentially, it is a collection of languages and libraries that can work together to build many different types of applications
## Different types of open-source developer platform
* They decided to group certain functionalities with different names in .NET
1. .NET 6.0
    * The one you have right now
    * It supports the most types of apps and platforms since it is the combination of both .NET Core and .NET Framework
2. .NET Core
    * Just the older version of .NET 6.0
3. .NET Framework
    * It is used to exclusively create windows-only desktop applications
## What is C#?
* It is an object-oriented and type-safe programming language
    * Object-oriented means everythign is based on objects and classes and the relationships between them
    * Type-safe meaning once you set a datatype you can't change the datatype (unless you use certain techniques to do it)

# What is Object-Oriented programming?
* It is a methodology we use to design our programs just using classes and objects
* It makes it a lot easier to develop and maintain your project as it gets bigger
## Classes
* They are templates that are used to create objects and define the object's functions and current state (essentially what information they currently store)
## Objects
* It is any entity that has a state and behavior
* They are made from classes and will copy whatever state and behavior the class has defined
## Overall
* Classes are blueprints and Objects is the actual object from the blueprint
* Ex: 
    A blueprint of a car, tells you how to make a car but it isn't the car itself (The Class)
    The multiple cars you make from same blueprint (The Objects of that Class)

# DataTypes
* We can use datatypes to structure what kind of information we are storing and tell the program how we intend to use that data
## Value Types
* They are datatypes that stores value directly and not a reference to where the value is stored
* They are stored in the **stack** and not the heap
* Stack is always faster to retrieve data than heap
* Every value type has a set of memory set aside for it to occupy (Ex: int can only store 32-bits while a double can store 64-bits) and stack memory is all about structure for efficiency and how data cannot be dynamically changing in size
* Ex: int, double, char, bool, float, etc.
    There are special value types:
    * Structs - like a class but gets stored in the stack for memory retrieval efficiency 
    * Enums - defines a set of named integral constants
## Reference Types
* They are datatypes that are stored in the heap and reference variables that are stored in the stack
* Think of reference variables as having the address of a house since an address only holds the info on where the house is and not the actual house itself
* When you declare a variable of a reference type and not have it point to anything in the beginning, it will have a null value
    * Null in the coding world means lack of value or there isn't any value at all
* Reference variables are stored in the stack while the actual object itself is stored in the heap
* Why the heap? since memory in the heap can be dynamically changing
* Ex: classes, arrays, interfaces, strings, etc.

# What happens when you run your code?
* Well the computer doesn't understand english language and the keywords we have written in our source code (source codes are any files that we write code in)
* Instead, a compiler is the one responsible that will look into your source code and convert them into machine code (machine code are just a bunch of 1s and 0s or binary)

# Arrays
* Used to store a datatype and have fixed sizes
* Zero-based index
    * 0 is the starting position of the array
* Other arrays you can make:
    * Multidimensional arrays - int[,] ex = new int[4,2]; would create
    [ [0, 0],
      [0, 0],
      [0, 0],
      [0, 0] ]
    * Jagged arrays - arrays inside of an array are different sizes
    [ [0, 0, 0], 
      [0, 0],
      [0, 0, 0],
      [0, 0 , 0, 0]
    ]
# Collections
* It is a data structure that can hold many values
* All collection has methods to add, remove, or find items since they all inherit from IEnumerable Interface
* In C#, there are two major types of collections: Generic and Non-generic
## Generic
* They are collections that store specific datatype
* The "T" you see in documentation is where you put what data type that collection will hold
### List
* Zero-based index
* Used to store a datatype and have dynamically changing sizes
* The most generic collection that is like an array but doesn't have a fixed size
### HashSet
* There is no particular order to the elements (Not zero-based index)
    * It is harder to find specific elements unless you use LINQ (that's later on)
* Every element is unique (Cannot have duplicated elements)
* Useful since you can perform set operations on two HashSets
* Example of set operations:
    * UnionWith - Lets you combine two Hashsets
    * ExceptWith - Substracts a Hashset from another Hashset
    * etc.
### Dictionary
* Stores info through key-value pairs
* There is also no particular order
* You can specify what datatype you want both the key and value to be
* Useful if you want to find specific information if you know the key
    * Think about your contacts, to find someone's phone number (Value) you just have to search for the person's name (Key) instead of trying to figure out what position that person might be located in like a List collection or an Array