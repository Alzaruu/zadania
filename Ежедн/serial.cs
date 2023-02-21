using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ежедн
{
    class serial
    {
        public string name;
        public string description;
        public string data;
        public static void MySeriali<T>(T serials)
        {
            string json = JsonConvert.SerializeObject(serials);
            File.WriteAllText("C:\\Users\\Tenru\\OneDrive\\Рабочий стол\\C#\\Ежедн\\json1.json", json);
        }

        public static T MyDeser<T>()
        {
            string json = File.ReadAllText("C:\\Users\\Tenru\\OneDrive\\Рабочий стол\\C#\\Ежедн\\json1.json");
            T serials = JsonConvert.DeserializeObject<T>(json);
            return serials;
        }
    }
   
}
