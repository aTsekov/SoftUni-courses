using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book
    {
        public Book(string title, int year, params string[] authors) // With params when we create an instance of the object, we can give a few authors at the same time. 
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
        }

        public string Title { get; private set; }

        public int Year { get; private set; }

        public List<string> Authors { get; private set; }
    }
}
