// Вариант 7 - музыкальный каталог

namespace Lab3
{
    internal class Program
    {
        private const string HelpMessage = "Список команд:\n\"help\" - список команд\n\"save\" - сохранение каталога\n\"list\" - отображение всех композиций\n\"search\" - поиск всех подходящих композиций\n\"add\" - добавление новой композиции\n\"del\" - удаление композиции\n\"quit\" - выход";
        static void Main(string[] args)
        {
            string? UserCommand;
            string? saverNum = "";

            while (saverNum == "")
            {
                Console.WriteLine("Способ сохранения и загрузки данных? 1 - JSON, 2 - XML, 3 - SQLLite");
                saverNum = Console.ReadLine();
                switch (saverNum)
                {
                    case "1":
                        Uploader.JSONUpload();
                        break;
                    case "2":
                        Uploader.XMLUpload();
                        break;
                    case "3":
                        Uploader.SQLUpload();
                        break;
                    default:
                        Console.WriteLine("Некорректный ответ");
                        saverNum = "";
                        break;

                }
            }
            CommandsHandler Commander = new CommandsHandler(saverNum);

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
                    case "save":
                        Commander.Save();
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда. Введите \"help\" для просмотра списка комманд");
                        break;
                }
            }
        }

    }
}
