using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class ListOfCompositions
    {
        public List<Composition> CompList { get; }

        public ListOfCompositions() { CompList = new List<Composition>();}

        public bool AddComposition(Composition newComp)
        {
            if (CompList.Contains(newComp))
            {
                return false;
            }
            else
            {
                CompList.Add(newComp);
                return true;
            }
        }

        public bool RemoveComposition(Composition Comp)
        {
            if (!CompList.Contains(Comp))
            {
                return false;
            }
            else
            {
                CompList.Remove(Comp);
                return true;
            }
        }

        public void ShowList()
        {
            if (CompList.Count > 0)
            {
                foreach (Composition comp in CompList)
                {
                    comp.Print();
                }
                Console.WriteLine("Конец списка");
            }
            else
            {
                Console.WriteLine("Здесь пока пусто");
            }
        }

        public List<Composition> SearchComposition(string str)
        {
            List<Composition> compList = new List<Composition>();
            foreach (Composition comp in CompList)
            {
                if (comp.containsString(str)) {
                    compList.Add(comp);
                }
            }
            return compList;
        }

    }
}
