using System;
using System.Security.Cryptography;

namespace MachineKeyError
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyParams = new CngKeyCreationParameters
            {
                ExportPolicy = CngExportPolicies.None,
                KeyCreationOptions = CngKeyCreationOptions.MachineKey, 
                Provider = new CngProvider("Microsoft Platform Crypto Provider"),
            };

            CngKey key = CngKey.Create(CngAlgorithm.Rsa, $"TPM-Import-Key", keyParams);

            Console.WriteLine($"Is the key a machine key? {key.IsMachineKey}");

            key.Delete();   // just for cleanup, not necessary for reproduction
        }
    }
}
