using GradeBook.GradeBooks;
using System;

namespace GradeBook.UserInterfaces
{
    public static class StartingUserInterface
    {
        public static bool Quit = false;
        public static void CommandLoop()
        {
            while (!Quit)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(">> What would you like to do?");
                var command = Console.ReadLine().ToLower();
                CommandRoute(command);
            }
        }

        public static void CommandRoute(string command)
        {
            if (command.StartsWith("create"))
                CreateCommand(command);
            else if (command.StartsWith("load"))
                LoadCommand(command);
            else if (command == "help")
                HelpCommand();
            else if (command == "quit")
                Quit = true;
            else
                Console.WriteLine("{0} was not recognized, please try again.", command);
        }

        //Operację które teraz będę przeprowadzał, będą miały miejsce w metodzie "CreateCommand" w klasie "StartingUserInterface". "CreateCommand" przyjmuje parametr "command" typu string.
        public static void CreateCommand(string command)
        {
            //Tworzenie tablicy "parts" przy użyciu metody "Split" na obiekcie "command" z separatorem " ' ' ".
            var parts = command.Split(' ');
            //Sprawdzenie czy długość tablicy "parts" jest różna od 3, jeżeli tak to wyświetlany jest komunikat o treści: "Command not valid, Create requires a name and type of gradebook".
            //Aktualizujemy warunek sprawdzający długość tablicy "parts" na 4.
            if (parts.Length != 4)
            {
                //Aktualizacja komunikatu wyświetlanego w przypadku niepoprawnej długości tablicy "parts".
                Console.WriteLine("Command not valid, Create requires a name, type of gradebook, if it's weighted (true / false)..");
                return;
            }
            //Przypisanie wartości "name" jako drugi element tablicy "parts".
            var name = parts[1];
            //Przypisanie wartości "type" jako trzeci element tablicy "parts" z małymi literami, w celu właściwej interpretacji przypadków z sekcji switch.
            var type = parts[2].ToLower();
            //Przypisanie wartości "isWeighted" jako czwarty element tablicy "parts" z konwersją na typ bool poprzez Parse.
            bool isWeighted = bool.Parse(parts[3]);

            //Utworzenie zmiennej "gradeBook" typu "BaseGradeBook".
            BaseGradeBook gradeBook; 

            //Instrukcja switch, która sprawdza wartość zmiennej "type".
            switch (type)
            {
                //Jeżeli wartość zmiennej "type" to "standard", to przypisz do zmiennej "gradeBook" nowy obiekt klasy "StandardGradeBook" z parametrem "name".
                case "standard": 
                    gradeBook = new StandardGradeBook(name, isWeighted);
                    break;
                //Jeżeli wartość zmiennej "type" to "ranked", to przypisz do zmiennej "gradeBook" nowy obiekt klasy "RankedGradeBook" z parametrem "name".
                case "ranked":
                    gradeBook = new RankedGradeBook(name, isWeighted);
                    break;
                case "wsei":
                    gradeBook = new WseiGradeBook(name, isWeighted);
                    break;
                case "esnu":
                    gradeBook = new ESNUGradeBook(name, isWeighted);
                    break;
                case "one2four":
                    gradeBook = new OneToFourGradeBook(name, isWeighted);
                    break;
                case "sixPoint":
                    gradeBook = new SixPointGradeBook(name, isWeighted);
                    break;
                //Jeżeli wartość zmiennej "type" to żadna z powyższych, to wyświetl komunikat o treści: "This is not a supported type of gradebook, please try again", po tym następuje wyjście z metody.
                default:
                    Console.WriteLine($"{type} is not a supported type of gradebook, please try again");
                    return;
            }

            //Wyświetlenie komunikatu o treści: "Created gradebook {0}.", gdzie "{0}" to wartość zmiennej "name".
            Console.WriteLine("Created gradebook {0}.", name);
            //Wywołanie metody "CommandLoop" z klasy "GradeBookUserInterface" z parametrem "gradeBook", powoduje to uruchomienie pętli głównej programu dla utworzonego dziennika ocen. 
            GradeBookUserInterface.CommandLoop(gradeBook);
        }

        public static void LoadCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 2)
            {
                Console.WriteLine("Command not valid, Load requires a name.");
                return;
            }
            var name = parts[1];
            var gradeBook = BaseGradeBook.Load(name);

            if (gradeBook == null)
                return;

            GradeBookUserInterface.CommandLoop(gradeBook);
        }

        public static void HelpCommand()
        {
            Console.WriteLine();
            Console.WriteLine("GradeBook accepts the following commands:");
            Console.WriteLine();
            Console.WriteLine("Create 'Name' 'Type' 'Weighted' - Creates a new gradebook where 'Name' is the name of the gradebook, 'Type' is what type of grading it should use, and 'Weighted' is whether or not grades should be weighted (true or false).");
            Console.WriteLine();
            Console.WriteLine("Load 'Name' - Loads the gradebook with the provided 'Name'.");
            Console.WriteLine();
            Console.WriteLine("Help - Displays all accepted commands.");
            Console.WriteLine();
            Console.WriteLine("Quit - Exits the application");
        }
    }
}
