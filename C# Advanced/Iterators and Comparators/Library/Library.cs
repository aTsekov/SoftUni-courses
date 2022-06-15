using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{


    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books) // With params when we create an instance of the object, we can give a few books at the same time. 
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator() // this is the useless methods and we just tell this method to returs the GetEnumerator() (as this is the one that we need. We just have to ignore it after we tell it to retunr the GetEnumerator() method. 
           => this.GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;
            public LibraryIterator(IEnumerable<Book> books)
            {
                this.books = books.ToList();
                this.Reset();
            }
            public void Dispose() { } // This is not needed for the moment. 
            public bool MoveNext() =>
              ++this.currentIndex < this.books.Count;
            public void Reset() => this.currentIndex = -1; // Always start from the 0 index. We put it to - 1 because when we move it the first time it will become 0. This way we make sure that we will always start from 0 (or the first index. 
            public Book Current => this.books[this.currentIndex];
            object IEnumerator.Current => this.Current;
        }
    }

}
