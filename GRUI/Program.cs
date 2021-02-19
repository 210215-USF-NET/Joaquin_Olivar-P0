using System;
using GRModels;

namespace GRUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Basic menu test.
            IMenu menu = new MainMenu();
            menu.Start();
        }
    }
}
