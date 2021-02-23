using System;
using GRModels;
using GRBL;
using GRDL;

namespace GRUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Basic menu test.
            IMenu menu = new MainMenu(new RecordBL(new RecordRepoFile()));
            menu.Start();
        }
    }
}
