using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeUI
{
    class Program
    {
       static void Main(string[] args)
        {
            RealConsole console = new RealConsole(); 
            CafeKomodoUI ui = new CafeKomodoUI(console); 
            ui.Run();

        }
    }
}
