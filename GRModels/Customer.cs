namespace GRModels
{
    public class Customer
    {
        private string firstName;
        public string FirstName 
        {
            get;
            set;
        }
        public string LastName {get; set;}
        public string Email {get; set;}

        public string Address {get;set;}

        public int ZipCode {get; set;}
    }
}