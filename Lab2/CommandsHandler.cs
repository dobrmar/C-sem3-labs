using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class CommandsHandler
    {
        private ListOfCompositions listOfCompositions;
        public CommandsHandler() 
        { 
            listOfCompositions = new ListOfCompositions();
        }

        public void ShowList()
        {
            listOfCompositions.ShowList();
        }

        public void SearchComposition()
        {
            Console.WriteLine("Введите часть для поиска:");
            string? str = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("Некорректный ввод");
                return;
            }
            listOfCompositions.SearchComposition(str);
        }

        public void AddComposition()
        {
            Console.WriteLine("Введите автора:");
            string? author = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("Некорректный автор");
                return;
            }
            Console.WriteLine("Введите название:");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Некорректное название");
                return;
            }
            listOfCompositions.AddComposition(new Composition(author, name));
            Console.WriteLine("Композиция добавлена");
        }

        public void RemoveComposition()
        {
            Console.WriteLine("Введите автора:");
            string? author = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("Некорректный автор");
                return;
            }
            Console.WriteLine("Введите название:");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Некорректное название");
                return;
            }
            listOfCompositions.RemoveComposition(new Composition(author, name));
        }

        public void Quit() 
        {
            Environment.Exit(0); 
        }
    }
}
