using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2077MM
{
    public class Error
    {

        public static void UnexpectedError(string message)
        {
            string msg = "[ERROR]: An unexpected error occured at: " + message;
            Console.WriteLine(msg);
            MessageBox.Show(msg, "Error");
        }
    }
}
