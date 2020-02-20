using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeUI
{
    public interface IConsole
    {
        string ReadLine();
        void Write(string str);  
        void WriteLine(string str); 
        void WriteLine(object obj);  
        void Clear();
        ConsoleKeyInfo ReadKey();  

    }
}
