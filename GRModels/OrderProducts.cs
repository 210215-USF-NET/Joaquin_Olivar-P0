namespace GRModels
{
    public class OrderProducts
    {
        public int OrdProdId {get; set;}
        public int RecID {get; set;}
        public int OrdID {get; set;}
        public int RecQuan {get; set;}
        public override string ToString() => $"\tRecord#:{RecID}\n\tQuantity:{RecQuan}";
    }
}