namespace PokeModel
{
    public class Ability
    {
        public string Name { get; set; }
        private int _PP;
        public int PP
        {
            get { return _PP; }
            //You can only set PP above 0
            set 
            {
                if (value > 0)
                {
                    _PP = value; 
                }
                else
                {
                    throw new Exception("You cannot set PP lower than 0!");
                }
            }
        }
        
        public int Power { get; set; }
        public int Accuracy { get; set; }
    }
}