using System;
/*
Class members:

    in c#
    fields, properties, methods, constructors
    fields - characteristics of your object
    method - behavior of your object
    constructors - special methods that create object instances
        - if there's no constructor, there's a default one that gets created for you
    properties - "smart fields"
        in C#, wrapper for a field, works as a getter & setter for a private backing field (actual object char)

    POCO - plain old c# object; class that holds data
*/
namespace GRModels
{
    public class Vinyl
    {
        /// <summary>
        /// Data structure used for creating a vinyl.
        /// </summary>
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

        public Genre GenreType{get; set;}
        public Condition daCondition{get; set;}
        public float price {get; set;}
        public string Artist{get;set;}
    }
}
