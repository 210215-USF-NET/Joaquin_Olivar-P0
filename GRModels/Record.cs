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
    public class Record
    {
        /// <summary>
        /// Data structure used for creating a vinyl.
        /// </summary>
        private string recordName;

        public string RecordName{
            get {return recordName;}
            set{
                if (value.Equals(null)){
                    //write exception jawn
                }
                recordName = value;
            }
        }

        public Genre GenreType{get; set;}
        public Condition daCondition{get; set;}

        public Format daFormat{get; set;}
        public float Price {get; set;}
        public string Artist{get;set;}

        public override string ToString() => $"Record Details: \n\t Album Name: {this.RecordName} \n\t Artist: {this.Artist} \n\t Genre: {this.GenreType} \n\t Format: {this.daFormat} \n\t Condition: {this.daCondition} \n\t Price: {this.Price}";

    }
}
