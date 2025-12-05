using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace TDL
{
    class Link16Crypto : ICrypto
    {
        public async Task<string> Decrypt(byte[] encryptedData)
        {
            await Task.Delay(150);
            byte[] reverse = encryptedData.Reverse().ToArray();
            string decode = Encoding.UTF8.GetString(reverse);
            return decode;
        }

        public async Task<byte[]> Encrypt(string rawData)
        {
            await Task.Delay(150);
            byte[] encoding = Encoding.UTF8.GetBytes(rawData);
            byte[] encrypted = encoding.Reverse().ToArray();
            return encrypted;
        }
    }
}
