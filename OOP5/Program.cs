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
            Console.Write("Введите название книги: ");
            string bookTitle = Console.ReadLine();
            Console.WriteLine("Название добавлено.");

            Console.Write("Введите автора книги: ");
            string writer = Console.ReadLine();
            Console.WriteLine("Автор добавлен.");

            Console.Write("Введите год выпуска книги: ");
            string userInput = Console.ReadLine();

            bool isSuccess = int.TryParse(userInput, out int issueDate);

            if (isSuccess)
            {
                Console.WriteLine("Год добавлен.");
            }
            else
            {
                Console.WriteLine("Ошибка. Неверный ввод");
            }

            _volumeStorage.Add(new Book(bookTitle, writer, issueDate));
        }

        public void RemoveBook()
        {
            Console.Write("Введите номер, чтобы убрать книгу из хранилища - ");
            string userInput = Console.ReadLine();

            bool isSuccess = int.TryParse(userInput, out int serialNumber);

            if (isSuccess)
            {
                for (int i = 0; i < _volumeStorage.Count; i++)
                {
                    if (serialNumber == i)
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
                Console.WriteLine("\nНомер - " + i + "\nНазвание книги - " + _volumeStorage[i].Name + "\nАвтор - " 
                    + _volumeStorage[i].Author + "\nГод выпуска - " + _volumeStorage[i].YearIssue);
            }
        }

        public void ShowAllBooksSpecifiedParameter() 
        {
            const string CommandFindNameBook = "1"; 
            const string CommandFindBookAuthor = "2";
            const string CommandFindBookReleaseYear = "3";
            const string CommandGoToMainMenu = "4";

            bool isWorking = true;

            Console.WriteLine("\nПо какому параметру вы хотите найти книгу?" + $"\n{CommandFindNameBook} - По названию книги." + $"\n{CommandFindBookAuthor} " +
                $"- По автору книги." + $"\n{CommandFindBookReleaseYear} - По году выпуска книги." + $"\n{CommandGoToMainMenu} - Выйти в главное меню."); 

            while (isWorking)
            {
                Console.Write("\nПоиск по параметру: ");
                string userInput = Console.ReadLine();

                if (CommandFindNameBook == userInput)
                {
                    for (int i = 0; i < _volumeStorage.Count; i++)
                    {
                        Console.WriteLine("Найдено название книги - " + _volumeStorage[i].Name);
                    }

                    Console.Write("Введите название для поиска книги - ");
                    string searchNameBook = Console.ReadLine();

                    for (int i = 0; i < _volumeStorage.Count; i++)
                    {
                        if (searchNameBook == _volumeStorage[i].Name)
                        {
                            Console.WriteLine("\nНазвание книги - " + _volumeStorage[i].Name+ "\nАвтор книги - " 
                                + _volumeStorage[i].Author + "\nГод выпуска книги - " + _volumeStorage[i].YearIssue);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка. Такого названия нет в хранилище книг. Попробуйте ещё раз.");
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
                    string searchAuthorBook = Console.ReadLine();

                    for (int i = 0; i < _volumeStorage.Count; i++)
                    {
                        if (searchAuthorBook == _volumeStorage[i].Author)
                        {
                            Console.WriteLine("\nНазвание книги - " + _volumeStorage[i].Name+ "\nАвтор книги - " 
                                + _volumeStorage[i].Author + "\nГод выпуска книги - " + _volumeStorage[i].YearIssue);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка. Такого автора нет в хранилище книг. Попробуйте ещё раз.");
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

                    bool isSuccess = int.TryParse(searchYearIssue, out int yearIssue);

                    if (isSuccess)
                    {
                        for (int i = 0; i < _volumeStorage.Count; i++)
                        {
                            if (yearIssue == _volumeStorage[i].YearIssue)
                            {
                                Console.WriteLine("\nНазвание книги - " + _volumeStorage[i].Name + "\nАвтор книги - " 
                                    + _volumeStorage[i].Author + "\nГод выпуска книги - " + _volumeStorage[i].YearIssue);
                            }
                            else
                            {
                                Console.WriteLine("Ошибка. Такого года нет в списке.");
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
        public Book(string bookTitle, string writer, int issueDate)
        {
            Name = bookTitle;
            Author = writer;
            YearIssue = issueDate;
        }

        public string Name { get; private set; }

        public string Author { get; private set; }

        public int YearIssue { get; private set; }
    }
}
