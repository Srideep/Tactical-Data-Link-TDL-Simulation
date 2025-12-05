using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDL
{
    class PilotDisplay : IDisplaySystem
    {
        public void ShowStatus(string message)
        {
            Console.WriteLine(message);
        }
    }
}
