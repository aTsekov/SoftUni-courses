using System;
using System.Collections.Generic;
using System.Linq;

namespace _003_Articles_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            

            int n = int.Parse(Console.ReadLine());
            List<Articles> articles = new List<Articles>();




            for (int i = 0; i < n; i++)
            {
                List<string> article = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string title = article[0];
                string content = article[1];
                string author = article[2];


                Articles newArticle = new Articles(title, content, author); // правим нов обект по този начин, защото имаме конструктор
                articles.Add(newArticle);

            }
            string command = Console.ReadLine();
            List<Articles> orderedArticles = new List<Articles>();

            if (command == "title")
            {
                orderedArticles = articles.OrderBy(title => title.Title).ToList();
            }
            else if (command == "content")
            {
                orderedArticles = articles.OrderBy(content => content.Content).ToList();
            }
            else if (command == "author")
            {
                orderedArticles = articles.OrderBy(author => author.Author).ToList();
            }

            foreach (Articles article in orderedArticles)
            {
                Console.WriteLine(article);
            }
            

        }

        class Articles
        {
            public Articles(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
                this.articles = new List<Articles>();
                
            }
            public List<Articles> articles { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

             
            public override string ToString()
            {
                return $"{this.Title} - {this.Content}: {this.Author}";
            }
  
        }
}   }

