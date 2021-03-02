namespace GRModels
{
    public class Cart
    {
        public int CartID {get; set;}
        public int CustomerID {get; set;}
        public override string ToString() => $"Cart Details: \n\t CartID: {this.CartID} \n\t CustomerID: {this.CustomerID}";
    }
}