using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Lab3
{
    internal class JSONSaver :ISaver
    {
        public void Save(ListOfCompositions list)
        {
            string fileName = "ListOfCompositions.json";
            string jsonString = JsonSerializer.Serialize(list);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
