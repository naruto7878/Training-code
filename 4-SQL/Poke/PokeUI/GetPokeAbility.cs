using PokeBL;
using PokeModel;

namespace PokeUI
{
    public class GetPokeAbility : IMenu
    {
        private List<Pokemon> _listOfPoke;
        private IPokemonBL _pokeBL;
        public GetPokeAbility(IPokemonBL p_pokeBL)
        {
            _pokeBL = p_pokeBL;
            _listOfPoke = _pokeBL.GetAllPokemon();
        }
        public void Display()
        {
            foreach (var item in _listOfPoke)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("[1] Select Pokemon by Id");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserChoice()
        {
            string userInput = Console.ReadLine();

            //Switch cases are just useful if you are doing a bunch of comparison
            switch (userInput)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.GetPokeAbility;
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return MenuType.GetPokeAbility;
            }
        }
    }
}