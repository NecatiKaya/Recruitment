using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.API.Cryptography
{
    internal class CryptoHelper
    {
        public static string ComputeSha256Hash(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj), "Parameter can not be null to calculate SHA256");
            }

            using (SHA256 sha256Hash = SHA256.Create())
            {
                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                string objectwithJson = JsonConvert.SerializeObject(obj, serializerSettings);
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(objectwithJson));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
