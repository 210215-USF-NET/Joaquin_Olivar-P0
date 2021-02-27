using System;

namespace GRUI
{
    public class ManagerMenu : IMenu
    {
        public void Start()
        {
            Console.WriteLine("You made it! Press any key to continue.");
            Console.ReadLine();
        }
    }
}