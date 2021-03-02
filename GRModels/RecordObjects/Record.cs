using System;
namespace GRModels
{
    public class Record
    {
        public int RecID;
        private string recordName;

        public string RecordName{
            get {return recordName;}
            set{
                if (value.Equals(null)){
                    throw new ArgumentNullException("Record must have a name.");
                }
                recordName = value;
            }
        }

        public Genre GenreType{get; set;}
        public Condition daCondition{get; set;}

        public Format daFormat{get; set;}
        public float Price {get; set;}
        public string Artist{get;set;}

        public override string ToString() => $"{this.daCondition} {this.daFormat}: \n\t Album Name: {this.RecordName} \n\t Artist: {this.Artist} \n\t Genre: {this.GenreType} \n\t Price: ${this.Price} \n\t ID: {this.RecID}";

    }
}
