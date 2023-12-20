using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class ListOfCompositions
    {
        private List<Composition> CompList;

        public ListOfCompositions() { CompList = new List<Composition>();}

        public void AddComposition(Composition newComp)
        {
            if (CompList.Contains(newComp))
            {
                Console.WriteLine("Композиция уже в списке");
            }
            else
            {
                CompList.Add(newComp);
            }
        }

        public void RemoveComposition(Composition Comp)
        {
            if (!CompList.Contains(Comp))
            {
                Console.WriteLine("Композиция не найдена");
            }
            else
            {
                CompList.Remove(Comp);
                Console.WriteLine("Композиция удалена");
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

        public void SearchComposition(string str)
        {
            bool Found = false;
            foreach (Composition comp in CompList)
            {
                if (comp.containsString(str)) {
                    comp.Print();
                    Found = true;
                }
            }
            if (!Found)
            {
                Console.WriteLine("Подходящих композиций не найдено");
            }
        }

    }
}
