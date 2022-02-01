using System.Data.SqlClient;
using PokeModel;

namespace PokeDL
{
    public class SQLRepository : IRepository
    {
        public Pokemon AddPokemon(Pokemon p_poke)
        {
            //@ before the string will ignore special characters like \n
            //This is where you specify the sql statement required to do whatever operation you need based on the method
            //
            string sqlQuery = @"insert into Pokemon 
                            values(@pokeName, @pokeLevel, @pokeAttack, @pokeDefense,@pokeHealth)";

            //using block is different from our normal using statement
            //It is used to automatically close any resource you stated inside of the parenthesis
            //If an exception occurs, it will still automatically close any resources
            using (SqlConnection con = new SqlConnection("PUT YOUR CONNECTION STRING HERE"))
            {
                //Opens the connection to the database
                con.Open();

                //SqlCommand class is a class specialized in executing SQL statements
                //Command will how the sqlQuery that will execute on the currently connection we have in the con object
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@pokeName", p_poke.Name);
                command.Parameters.AddWithValue("@pokeLevel", p_poke.Level);
                command.Parameters.AddWithValue("@pokeAttack", p_poke.Attack);
                command.Parameters.AddWithValue("@pokeDefense", p_poke.Defense);
                command.Parameters.AddWithValue("@pokeHealth", p_poke.Health);

                //Executes the SQL statement
                command.ExecuteNonQuery();
            }

            return p_poke;
        }

        public List<Pokemon> GetAllPokemon()
        {
            List<Pokemon> listOfPokemon = new List<Pokemon>();

            string sqlQuery = @"select * from Pokemon";

            using (SqlConnection con = new SqlConnection("PUT YOUR CONNECTION STRING HERE"))
            {
                //Opens connection to the database
                con.Open();

                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);

                //SqlDataReader is a class specialized in reading outputs that came from a sql statement
                //Usually this outputs are in a form of a table and keep that in mind
                SqlDataReader reader = command.ExecuteReader();

                //Read() methods checks if you have more rows to go through
                //If there is another row = true, if not = false
                while (reader.Read())
                {
                    listOfPokemon.Add(new Pokemon(){
                        //Zero-based column index
                        PokeId = reader.GetInt32(0), //It will get column PokeId since that is the very first column of our select statement
                        Name = reader.GetString(1), //it will get the pokeName column since it is the second column of our select statement
                        Level = reader.GetInt32(2),
                        Attack = reader.GetInt32(3),
                        Defense = reader.GetInt32(4),
                        Health = reader.GetInt32(5)
                    });
                }
            }

            return listOfPokemon;
        }
    }
}