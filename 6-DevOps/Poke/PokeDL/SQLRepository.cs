using System.Data.SqlClient;
using PokeModel;

namespace PokeDL
{
    public class SQLRepository : IRepository
    {
        //SQLRepository now requires you to provide a connectionstring to an existing database to create an object out of it
        //It will also allow SQLRepository to dynamically point to different databases as long as you have the connection string fo rit
        private readonly string _connectionStrings;
        public SQLRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }

        public Pokemon AddPokemon(Pokemon p_poke)
        {
            //@ before the string will ignore special characters like \n
            //This is where you specify the sql statement required to do whatever operation you need based on the method
            //
            string sqlQuery = @"insert into Pokemon
                            values(@pokeName, @pokeAttack, @pokeDefense,@pokeHealth, @pokeSpeed, @pokeType)";

            //using block is different from our normal using statement
            //It is used to automatically close any resource you stated inside of the parenthesis
            //If an exception occurs, it will still automatically close any resources
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens the connection to the database
                con.Open();

                //SqlCommand class is a class specialized in executing SQL statements
                //Command will how the sqlQuery that will execute on the currently connection we have in the con object
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@pokeName", p_poke.Name);
                command.Parameters.AddWithValue("@pokeAttack", p_poke.Attack);
                command.Parameters.AddWithValue("@pokeDefense", p_poke.Defense);
                command.Parameters.AddWithValue("@pokeHealth", p_poke.Health);
                command.Parameters.AddWithValue("@pokeSpeed", p_poke.Speed);
                command.Parameters.AddWithValue("@pokeType", p_poke.Type);

                //Executes the SQL statement
                command.ExecuteNonQueryAsync();
            }

            return p_poke;
        }

        public List<Ability> GetAbilitiesByPokeId(int p_pokeId)
        {
            List<Ability> listOfAbility = new List<Ability>();
            
            string sqlQuery = @"select a.abId ,a.abName , a.abPP , a.abPower , a.abAccuracy from Pokemon p 
                            inner join pokemons_abilities pa on p.pokeId = pa.pokeId 
                            inner join Ability a on a.abId = pa.abId 
                            where p.pokeId = @pokeId";
            
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@pokeId", p_pokeId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfAbility.Add(new Ability(){
                        //Reader column is NOT based on table structure but based on what your select query statement is displaying
                        AbId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        PP = reader.GetInt32(2),
                        Power = reader.GetInt32(3),
                        Accuracy = reader.GetInt32(4)
                    });
                }
            }
            return listOfAbility;
        }

        public Pokemon UpdatePokemon(Pokemon p_poke)
        {
            string sqlQuery = @"UPDATE Pokemon
                            SET pokeName=@name, pokeAttack=@attack, pokeDefense=@defense, pokeHealth=@health
                            WHERE pokeId=@id;";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);

                com.Parameters.AddWithValue("@name", p_poke.Name);
                
                com.Parameters.AddWithValue("@attack", p_poke.Attack);
                
                com.Parameters.AddWithValue("@defense", p_poke.Defense);
                
                com.Parameters.AddWithValue("@health", p_poke.Health);
                
                com.Parameters.AddWithValue("@id", p_poke.PokeId);

                com.ExecuteNonQuery();
            }

            return p_poke;
        }

        public List<Pokemon> GetAllPokemon()
        {
            List<Pokemon> listOfPokemon = new List<Pokemon>();

            string sqlQuery = @"select * from Pokemon";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
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
                        Attack = reader.GetInt32(2),
                        Defense = reader.GetInt32(3),
                        Health = reader.GetInt32(4),
                        Speed = reader.GetInt32(5),
                        Type = reader.GetString(6)
                        // Abilities = GetAbilitiesByPokeId(reader.GetInt32(0))
                    });
                }
            }

            return listOfPokemon;
        }

        public async Task<List<Pokemon>> GetAllPokemonAsync()
        {
            List<Pokemon> listOfPokemon = new List<Pokemon>();

            string sqlQuery = @"select * from Pokemon";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens connection to the database
                await con.OpenAsync();

                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);

                //SqlDataReader is a class specialized in reading outputs that came from a sql statement
                //Usually this outputs are in a form of a table and keep that in mind
                SqlDataReader reader = await command.ExecuteReaderAsync();

                //Read() methods checks if you have more rows to go through
                //If there is another row = true, if not = false
                while (reader.Read())
                {
                    listOfPokemon.Add(new Pokemon(){
                        //Zero-based column index
                        PokeId = reader.GetInt32(0), //It will get column PokeId since that is the very first column of our select statement
                        Name = reader.GetString(1), //it will get the pokeName column since it is the second column of our select statement
                        Attack = reader.GetInt32(2),
                        Defense = reader.GetInt32(3),
                        Health = reader.GetInt32(4),
                        Speed = reader.GetInt32(5),
                        Type = reader.GetString(6)
                        // Abilities = GetAbilitiesByPokeId(reader.GetInt32(0))
                    });
                }
            }

            return listOfPokemon;
        }
    }
}