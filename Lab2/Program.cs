// Вариант 7 - музыкальный каталог

namespace Lab2
{
    internal class Program
    {
        private const string HelpMessage = "Список команд:\n\"help\" - список команд\n\"list\" - отображение всех композиций\n\"search\" - поиск всех подходящич композиций\n\"add\" - добавление новой композиции\n\"del\" - удаление композиции\n\"quit\" - выход";
        static void Main(string[] args)
        {
            string? UserCommand;
            CommandsHandler Commander = new CommandsHandler();
            Console.WriteLine(HelpMessage);
            while (true)
            {
                UserCommand = Console.ReadLine();
                switch (UserCommand)
                {
                    case "list":
                        Commander.ShowList();
                        break;
                    case "search":
                        Commander.SearchComposition();
                        break;
                    case "add":
                        Commander.AddComposition();
                        break;
                    case "del":
                        Commander.RemoveComposition();
                        break;
                    case "quit":
                        Commander.Quit();
                        break;
                    case "help":
                        Console.WriteLine(HelpMessage);                      
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда. Введите \"help\" для просмотра списка комманд");
                        break;
                }
            }
        }

    }
}
