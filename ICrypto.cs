using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDL
{
    public interface ICrypto
    {
        Task<byte[]> Encrypt(string rawData);
        Task<string> Decrypt(byte[] encryptedData);
    }


}
