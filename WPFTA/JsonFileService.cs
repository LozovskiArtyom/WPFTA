using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace WPFTA
{
    public class JsonFileService : IFileService
    {
        public List<UserDay> Open(string filename)
        {
            List<UserDay> phones = new List<UserDay>();
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<UserDay>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                phones = jsonFormatter.ReadObject(fs) as List<UserDay>;
            }

            return phones;
        }

        public void Save(string filename, List<UserDay> phonesList)
        {
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<UserDay>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, phonesList);
            }
        }
    }
}
