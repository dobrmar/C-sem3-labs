using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class SQLSaver :ISaver 
    {
        public void Save(ListOfCompositions list)
        {
            using (SQLManager db =  new SQLManager())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                foreach (Composition composition in list.CompList)
                {
                    db.CompList.Add(composition);
                }
                db.SaveChanges();
            }
        }
    }
}
