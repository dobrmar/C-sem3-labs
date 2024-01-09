using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Uploader
    {
        public static ListOfCompositions JSONUpload()
        {
            string fileName = "ListOfCompositions.json";
            if (!File.Exists(fileName)) { return new ListOfCompositions(); }

            string jsonString = File.ReadAllText(fileName);
            OpenList Olist = JsonSerializer.Deserialize<OpenList>(jsonString)!;
            return new ListOfCompositions(Olist.CompList);
        }

        public static ListOfCompositions XMLUpload()
        {
            string fileName = "ListOfCompositions.xml";
            if (!File.Exists(fileName)) { return new ListOfCompositions(); }
            ListOfCompositions list;
            using (Stream stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(ListOfCompositions));
                list = (ListOfCompositions)ser.ReadObject(stream);
            }
            return list;
        }

        public static ListOfCompositions SQLUpload()
        {
            using (SQLManager db = new SQLManager())
            {
                db.Database.EnsureCreated();
                if (db.CompList.Count() == 0)
                {
                    return new ListOfCompositions();
                }
                return new ListOfCompositions(db.CompList.ToList());
            }
        }
    }
}
