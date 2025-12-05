using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDL
{
 
    class MissionComputer
    {
        private ICrypto __crypto;
        private ISensorSystem __sensorSystem;
        private IDisplaySystem __displaySystem;

        public MissionComputer(ICrypto Crypto, ISensorSystem sensorSystem, IDisplaySystem displaySystem)
        {
            __crypto = Crypto;
            __sensorSystem = sensorSystem;
            __displaySystem = displaySystem;
        }

        public async Task ProcessOutgoingMessage (string message)
        {
            
            __displaySystem.ShowStatus(message);
            
            byte[] encrypted = await __crypto.Encrypt(message);
            string transmission_message = "Transmitting " + encrypted.Length + " bytes..";
            Console.WriteLine(transmission_message);
            
            string filePath = "outputFile.txt";
            List<string> lines = new List<string> {message, transmission_message };
            File.WriteAllLines(filePath, lines);

        }
    }
}
