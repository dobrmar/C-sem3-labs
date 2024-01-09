using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab3
{
    internal class XMLSaver :ISaver
    {
        public void Save(ListOfCompositions list)
        {
            string fileName = "ListOfCompositions.xml";
            if (File.Exists(fileName)) { File.Delete(fileName); }
            DataContractSerializer xmlSerializer = new DataContractSerializer(typeof(ListOfCompositions));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.WriteObject(fs, list);
            }
        }
    }
}
