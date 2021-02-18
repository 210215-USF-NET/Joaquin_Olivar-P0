using System;
using GRModels;

namespace GRUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Vinyl newVinyl = new Vinyl();
            newVinyl.VinylName = "TPAB";
            Console.WriteLine(newVinyl.VinylName);
        }
    }
}
