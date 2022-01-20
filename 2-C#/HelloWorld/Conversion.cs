namespace ConversionFunction
{
    public class Conversion
    {

        //Static fields are shared between all objects from this class
        //In this way if you need a universal information that needs to be stored and shared to every object from this
        //Use a static field
        public static int _num;

        //static methods will make using that method without creating an object
        public static void ConversionMain()
        {
            //Implicit - just means something is done automatically (mostly it is the compiler)
            //Explicit - just means you have to write something to do it (essentially tell the compiler to do it anyway)

            Console.WriteLine("===Conversion Demo===");
            int x = 10;
            double y = 85.67;
            string str = "Hello World";
            string doubleStr = "10.19";

            //Implicit conversion
            //The general rule is if you are going from a datatype to another datatype without losing information
            double anotherDouble = x;
            Console.WriteLine(anotherDouble);

            //Explicit conversion
            //The general rule is if you are going to lose information if you are trying to convert something
            //The compiler won't do it for you for obvious reason
            int anotherInt = (int)y;
            Console.WriteLine(anotherInt);

            //Another way of explicit conversion
            double anotherDouble2 = Convert.ToDouble(doubleStr);
        }

        public int GiveMeNumber()
        {
            return _num;
        }
    }
}