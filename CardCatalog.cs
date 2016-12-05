using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Winter.CardCatalog
{

    public class CardCatalog
    {
        public CardCatalog(string fileName)
        {
            _filename = fileName;
            if (File.Exists(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));

                // A FileStream is needed to read the XML document.
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {

                    using (XmlReader reader = XmlReader.Create(fs))
                    {
                        // Use the Deserialize method to restore the object's state.
                        books = (List<Book>)serializer.Deserialize(reader);
                    }
                }
            }
            else
            {
                books = new List<Book>();
            }

        }


        private string _filename;
        /// <summary>
        /// 
        /// </summary>
        private List<Book> books;//This is the private member variable that contains all of the books


        public List<Book> ListBooks()
        {
            return books;
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));

            // A FileStream is needed to read the XML document.
            using (FileStream fs = new FileStream(_filename, FileMode.OpenOrCreate))
            {
                using (XmlWriter writer = XmlWriter.Create(fs))
                {

                    // Use the Deserialize method to restore the object's state.
                    serializer.Serialize(writer, books);
                }
            }

        }
    }
}