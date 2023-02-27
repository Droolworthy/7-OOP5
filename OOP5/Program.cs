using System;

namespace OOP5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddBook = "1";
            const string CommandRemoveBook = "2";
            const string CommandShowAllBooks = "3";
            const string CommandShowAllBooksSpecifiedParameter = "4";
            const string CommandExit = "5";

            Repository repository = new();

            bool isWorking = true;

            Console.WriteLine($"{CommandAddBook} - ДОБАВИТЬ КНИГУ" + $"\n{CommandRemoveBook} - УБРАТЬ КНИГУ" + $"\n{CommandShowAllBooks} - ПОКАЗАТЬ ВСЕ КНИГИ" + 
                $"\n{CommandShowAllBooksSpecifiedParameter} - ПОКАЗАТЬ ВСЕ КНИГИ ПО УКАЗАННОМУ ПАРАМЕТРУ" + $"\n{CommandExit} - ВЫХОД");

            while (isWorking)
            {
                Console.Write("\nВведите команду: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddBook:
                        repository.AddBook();
                        break;

                    case CommandRemoveBook:
                        repository.RemoveBook();
                        break;

                    case CommandShowAllBooks:
                        repository.ShowAllBooks();
                        break;

                    case CommandShowAllBooksSpecifiedParameter:
                        repository.ShowAllBooksSpecifiedParameter();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine($"\nВведите {CommandAddBook}, {CommandRemoveBook}, {CommandShowAllBooks}, {CommandShowAllBooksSpecifiedParameter} или {CommandExit}");
                        break;
                }
            }              
        }
    }

    class Repository
    {
        private List<Book> _volumeStorage = new();

        public void AddBook()
        {
            Console.WriteLine("Порядковый номер добавлен.");

            Console.Write("Введите название книги: ");
            string bookTitle = Console.ReadLine();

            Console.Write("Введите автора книги: ");
            string writer = Console.ReadLine();

            Console.Write("Введите год выпуска книги: ");
            int issueDate = Convert.ToInt32(Console.ReadLine());

            _volumeStorage.Add(new Book(bookTitle, writer, issueDate));
        }

        public void RemoveBook()
        {
            Console.Write("Введите порядковый номер, чтобы убрать из хранилища - ");
            string userInput = Console.ReadLine();

            bool isSuccess = int.TryParse(userInput, out int serialNumber);

            if (isSuccess)
            {
                for (int i = 0; i < _volumeStorage.Count; i++)
                {
                    if (serialNumber == _volumeStorage[i].SequenceNumber)
                    {
                        _volumeStorage.RemoveAt(i);
                        Console.WriteLine("Вы убрали книгу.");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка. Попробуйте ещё раз.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Ошибка. Неверный ввод.");
            }
        }

        public void ShowAllBooks()
        {
            for(int i = 0; i < _volumeStorage.Count; i++)
            {
                Console.WriteLine("\nПорядковый номер - " + _volumeStorage[i].SequenceNumber + "\nНазвание книги - " + _volumeStorage[i].Name + 
                    "\nАвтор - " + _volumeStorage[i].Author + "\nГод выпуска - " + _volumeStorage[i].YearIssue);
            }
        }

        public void ShowAllBooksSpecifiedParameter() 
        {
            const string CommandFindBookNumber = "1";
            const string CommandFindBookTitle = "2"; 
            const string CommandFindBookAuthor = "3";
            const string CommandFindBookReleaseYear = "4";
            const string CommandGoToMainMenu = "5";

            bool isWorking = true;

            Console.WriteLine("\nПо какому параметру вы хотите найти книгу?" + $"\n{CommandFindBookNumber} - По порядковому номеру." + $"\n{CommandFindBookTitle} - По названию книги." 
                + $"\n{CommandFindBookAuthor} - По автору книги." + $"\n{CommandFindBookReleaseYear} - По году выпуска книги." + $"\n{CommandGoToMainMenu} - Выйти в главное меню."); 

            while (isWorking)
            {
                Console.Write("\nВвод: ");
                string userInput = Console.ReadLine();

                if (CommandFindBookNumber == userInput)
                {
                    for (int i = 0; i < _volumeStorage.Count; i++)
                    {
                        Console.WriteLine("Найден порядковый номер - " + _volumeStorage[i].SequenceNumber);
                    }

                    Console.Write("Введите порядковый номер для поиска книги - ");
                    string searchSequenceNumber = Console.ReadLine();

                    bool isSuccess = int.TryParse(searchSequenceNumber, out int SequenceNumber);

                    if (isSuccess)
                    {
                        for (int i = 0; i < _volumeStorage.Count; i++)
                        {
                            if (SequenceNumber == _volumeStorage[i].SequenceNumber)
                            {
                                Console.WriteLine("\nПорядковый номер - " + _volumeStorage[i].SequenceNumber + "\nНазвание книги - " + _volumeStorage[i].Name
                                    + "\nАвтор книги - " + _volumeStorage[i].Author + "\nГод выпуска книги - " + _volumeStorage[i].YearIssue);
                            }
                            else
                            {
                                Console.WriteLine("Ошибка. Неверный ввод.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка. Неверный ввод.");
                    }
                }
                else if (CommandFindBookTitle == userInput)
                {
                    for (int i = 0; i < _volumeStorage.Count; i++)
                    {
                        Console.WriteLine("Найдено название книги - " + _volumeStorage[i].Name);
                    }

                    Console.Write("Введите название для поиска книги - ");
                    string searchName = Console.ReadLine();

                    for (int i = 0; i < _volumeStorage.Count; i++)
                    {
                        if (searchName == _volumeStorage[i].Name)
                        {
                            Console.WriteLine("\nПорядковый номер - " + _volumeStorage[i].SequenceNumber + "\nНазвание книги - " + _volumeStorage[i].Name
                                + "\nАвтор книги - " + _volumeStorage[i].Author + "\nГод выпуска книги - " + _volumeStorage[i].YearIssue);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка. Такого названия нет в хранилище. Попробуйте ещё раз.");
                        }
                    }
                }
                else if (CommandFindBookAuthor == userInput)
                {
                    for (int i = 0; i < _volumeStorage.Count; i++)
                    {
                        Console.WriteLine("Найден автор - " + _volumeStorage[i].Author);
                    }

                    Console.Write("Введите автора для поиска книги - ");
                    string searchAuthor = Console.ReadLine();

                    for (int i = 0; i < _volumeStorage.Count; i++)
                    {
                        if (searchAuthor == _volumeStorage[i].Author)
                        {
                            Console.WriteLine("\nПорядковый номер - " + _volumeStorage[i].SequenceNumber + "\nНазвание книги - " + _volumeStorage[i].Name
                                + "\nАвтор книги - " + _volumeStorage[i].Author + "\nГод выпуска книги - " + _volumeStorage[i].YearIssue);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка. Такого автора нет в хранилище. Попробуйте ещё раз.");
                        }
                    }
                }
                else if (CommandFindBookReleaseYear == userInput)
                {
                    for (int i = 0; i < _volumeStorage.Count; i++)
                    {
                        Console.WriteLine("Найден год выпуска - " + _volumeStorage[i].YearIssue);
                    }

                    Console.Write("Введите год выпуска для поиска книги - ");
                    string searchYearIssue = Console.ReadLine();

                    bool isSuccess = int.TryParse(searchYearIssue, out int YearIssue);

                    if (isSuccess)
                    {
                        for (int i = 0; i < _volumeStorage.Count; i++)
                        {
                            if (YearIssue == _volumeStorage[i].YearIssue)
                            {
                                Console.WriteLine("\nПорядковый номер - " + _volumeStorage[i].SequenceNumber + "\nНазвание книги - " + _volumeStorage[i].Name
                                    + "\nАвтор книги - " + _volumeStorage[i].Author + "\nГод выпуска книги - " + _volumeStorage[i].YearIssue);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка. Неверный ввод.");
                    }
                }
                else if (CommandGoToMainMenu == userInput)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Ошибка. Попробуйте ещё раз.");
                }              
            }
        }
    }

    class Book
    {
        private static int _identifications;

        public Book(string bookTitle, string writer, int issueDate)
        {
            SequenceNumber = ++_identifications;
            Name = bookTitle;
            Author = writer;
            YearIssue = issueDate;
        }

        public int SequenceNumber { get; private set; }

        public string Name { get; private set; }

        public string Author { get; private set; }

        public int YearIssue { get; private set; }
    }
}