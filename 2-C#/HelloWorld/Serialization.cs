using System.Text.Json;
using CarFunction;

namespace SerializationFunction
{
    /*
        -Serialization is the process of converting your C# objects into a JSON file or 110001101 (stream of bytes) or other formats
        -We will be using JSON because it is the most commonly used file format when comes to transfering/storing data
        -Main reason why is because collection memory is temporary and you might need to save that data later on to be used
    */
    public class Serialization
    {
        //The period on the file path means to auto put the entire filepath of where this current file is at in your hard drive
        private static string _filepath = "./Dataase/Car.json";
        public static void SerialMain()
        {
            Console.WriteLine("===Serialization Demo===");
            
            // Console.WriteLine("=Converting object to JSON=");
            // //Created a list of cars
            // List<Car> listOfCars = new List<Car>();
            // Car car1 = new Car()
            // {
            //     Color = "Silver",
            //     Fuel = 50,
            //     Owner = "Stephen"
            // };

            // //Added car1 twice inside of our list of cars
            // listOfCars.Add(car1);
            // listOfCars.Add(car1);

            // //Converting C# object into a JSON formatted string datatype
            // //Just means converting C# object into a string
            // string jsonString = JsonSerializer.Serialize(listOfCars, new JsonSerializerOptions {WriteIndented = true});
            // Console.WriteLine(jsonString);

            // //File class will create a JSON file (if there isn't one already) or overwrite
            // File.WriteAllText(_filepath, jsonString);

            Console.WriteLine("=Converting JSON to object=");
            //File.ReadAllText() static method will read our JSON file and store it in our jsonString2

            //Try block is used to have lines of code that you might expect to run into some sort of an exception
            try
            {
                string jsonString2 = File.ReadAllText(_filepath);

                //JsonSerializer converts the JSON object into a C# object
                List<Car> car2 = JsonSerializer.Deserialize<List<Car>>(jsonString2);

                Console.WriteLine(car2[0].Color);
                Console.WriteLine(car2[0].Fuel);
                Console.WriteLine(car2[0].Owner);
            }
            //Catch block will execute if it did run into that specific exception
            // First catch block should be the most specific exception you expect to happen
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found. Creating a new file for you!");
                //Creates a file if a file was not found
                List<Car> genericList = new List<Car>();
                genericList.Add(new Car());

                string jsonString3 = JsonSerializer.Serialize(genericList);

                File.WriteAllText(_filepath, jsonString3);

                //Reads from that file that was just created
                jsonString3 = File.ReadAllText(_filepath);

                //JsonSerializer converts the JSON object into a C# object
                List<Car> car2 = JsonSerializer.Deserialize<List<Car>>(jsonString3);

                Console.WriteLine(car2[0].Color);
                Console.WriteLine(car2[0].Fuel);
                Console.WriteLine(car2[0].Owner);
            }
            //Last catch block will be the most generic exception that you can possibly run into
            catch (System.Exception)
            {
                    
            }
            //Finally block will execute the lines of code regardless if an exception is found or not
            //Usually used for "clean up" process in your code
            finally
            {

            }



            
        }
    }
}