using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class CommandsHandler
    {
        private ListOfCompositions listOfCompositions;
        private bool SAVED;
        private ISaver saver;

        public CommandsHandler(string saverNum) 
        {            
            if (saverNum == "1")
            {
                listOfCompositions = Uploader.JSONUpload();
                saver = new JSONSaver();
            }
            else if (saverNum == "2")
            {
                listOfCompositions = Uploader.XMLUpload();
                saver = new XMLSaver();
            }
            else if (saverNum == "3")
            {
                listOfCompositions = Uploader.SQLUpload();
                saver = new SQLSaver();
            }
            SAVED = true;
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
            SAVED = false;
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
            SAVED = false;
        }

        public void Save()
        {
            saver.Save(listOfCompositions);
            SAVED = true;
        }

        public void Quit() 
        {
            while (!SAVED)
            {
                Console.WriteLine("Сохранить изменения? 1 - да, 0 - нет");
                string? response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        Save(); SAVED = true; break;
                    case "0":
                        SAVED = true; break;
                    default:
                        Console.WriteLine("Некорректный ответ");
                        break;
                }
            }
            Environment.Exit(0); 
        }
    }
}
