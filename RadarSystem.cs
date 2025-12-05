using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDL
{
    class RadarSystem : ISensorSystem
    {
        public async Task<string> GetData()
        {
            await Task.Delay(50);
            string message = "Target Detected";
            return message;
        }
    }
}
