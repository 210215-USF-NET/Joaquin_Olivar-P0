using System;
namespace GRModels
{
    public class Order
    {
        public int OrdID {get; set;}
        public int CartID {get; set;}
        public int localID {get; set;}
        public DateTime OrDate {get; set;}
        public Customer Customer {get; set;}
        public int CusID {get; set;}
    }
}