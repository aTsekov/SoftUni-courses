using System;
using System.Collections.Generic;
using System.Linq;

namespace _002_Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> article = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).ToList();
            string title = article[0];
            string content  = article[1];
            string author = article[2];

            int n = int.Parse(Console.ReadLine());

            Articles newArticle = new Articles(title, content, author); // правим нов обект по този начин, защото имаме конструктор
            

            for (int i = 0; i < n; i++)
            {
                List<string> command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                if (command[0] == "Edit:")
                {
                    command.RemoveAt(0);
                    string newContent = string.Join(" ",command); // ТУК МИ ЛИПСВАТ ОСТАНАЛИТЕ ДУМИ ОТ ПОДАДЕНАТА КОМАНДА. КАК ДА ГИ ДОБАВЯ? 
                    newArticle.Edit(newContent);
                   
                }
                else if (command [0] == "ChangeAuthor:")
                {
                    command.RemoveAt(0);
                    string newAuthor = string.Join(" ", command);
                    newArticle.ChangeAuthor(newAuthor);
                    
                }
                else if (command[0] == "Rename:")
                {
                    command.RemoveAt(0);
                    string rename = string.Join(" ", command);
                    newArticle.Rename(rename);
                }



            }
            Console.WriteLine(newArticle);
            


        }

        class Articles
        {
            public Articles(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }        

            public void Edit( string newContent)
            {
                this.Content = newContent;                
            }
            public void ChangeAuthor(string newAuthor)
            {
                this.Author = newAuthor;
            }
            public void Rename(string rename)
            {
                this.Title = rename;
            }
            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
    }
}
