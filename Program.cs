using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.CardCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a filename");
            string fileName = Console.ReadLine();
            CardCatalog c = new CardCatalog(fileName);
            Console.Clear();
            int option = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1. List All Books");
                Console.WriteLine("2. Add A Book");
                Console.WriteLine("3. Save and Exit");
                string inputChoice = Console.ReadLine();
                int.TryParse(inputChoice, out option);
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        foreach(var book in c.ListBooks())
                        {
                            Console.WriteLine("{0} by {1}", book.Title, book.Author);
                        }
                        Console.WriteLine("Press return to go back");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter a title");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter an author");
                        string author = Console.ReadLine();
                        c.AddBook(new Book { Author = author, Title = title });
                        break;
                    case 3:
                        Console.Clear();
                        c.Save();
                        break;
                    
                }

            } while (option != 3);
        }
    }
}
