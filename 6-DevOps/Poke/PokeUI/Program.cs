// See https://aka.ms/new-console-template for more information
// using PokeModel;
global using Serilog;//global using will implicitly import that namespace to the rest of your C# files inside of this project
using Microsoft.Extensions.Configuration;
using PokeBL;
using PokeDL;
using PokeModel;
using PokeUI;

// Console.WriteLine("Hello, World!");
// Ability ab = new Ability();
// ab.PP = -1; //Validation is working since can't input a negative value

//Creating and configuring our logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt") //We configure our logger to save in this file
    .CreateLogger();

bool repeat = true;
IMenu menu = new MainMenu();
FactoryMenu factory = new FactoryMenu();

Pokemon poke = new Pokemon();
poke.Name = "12937";


while (repeat)
{
    Console.Clear();
    menu.Display();
    MenuType ans = menu.UserChoice();
    if (ans != MenuType.Exit)
    {
        menu = factory.CreateMenu(ans);
    }
    else
    {
        repeat = false;
    }
    
    // switch (ans)
    // {
    //     case MenuType.GetPokeAbility:
    //         menu = new GetPokeAbility(new PokemonBL(new SQLRepository(_connectionString)));
    //         break;
    //     case MenuType.SearchPokemon:
    //         Log.Information("Displaying SearchPokemon Menu to user");
    //         menu = new SearchPokemonMenu(new PokemonBL(new SQLRepository(_connectionString)));
    //         break;
    //     case MenuType.AddPoke:
    //         Log.Information("Displaying AddPokemon Menu to user");
    //         menu = new AddPokeMenu(new PokemonBL(new SQLRepository(_connectionString)));
    //         break;
    //     case MenuType.MainMenu:
    //         Log.Information("Displaying MainMenu to user");
    //         menu = new MainMenu();
    //         break;
    //     case MenuType.Exit:
    //         Log.Information("Exiting application");
    //         Log.CloseAndFlush(); //To close our logger resource
    //         repeat = false;
    //         break;
    //     default:
    //         Console.WriteLine("Page does not exist!");
    //         Console.WriteLine("Please press Enter to continue");
    //         Console.ReadLine();
    //         break;
    // }
}
