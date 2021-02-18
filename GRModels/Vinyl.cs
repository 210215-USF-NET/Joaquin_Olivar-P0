using System;

namespace GRModels
{
    public class Vinyl
    {
        private string vinylName;

        public string VinylName{
            get {return vinylName;}
            set{
                if (value.Equals(null)){
                    //write exception jawn
                }
                vinylName = value;
            }
        }
    
    }
}
