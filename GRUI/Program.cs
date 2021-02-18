using System;
using GRModels;

namespace GRUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu menu = new MainMenu();
            menu.Start();

            //Test vinyl get.
            Vinyl newVinyl = new Vinyl();
            newVinyl.VinylName = "TPAB";
            Console.WriteLine(newVinyl.VinylName);
        }
    }
}
