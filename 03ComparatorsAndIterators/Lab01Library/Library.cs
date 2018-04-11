using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Library:IEnumerable<Book>
{

    private SortedSet<Book> books;

    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(books,new BookComparator());
    }
    public IEnumerator<Book> GetEnumerator()
    {
        List<Book> temp = new List<Book>(this.books);

        for (int i = 0; i < this.books.Count; i++)
        {
            yield return temp[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }  
    //private class LibraryIterator : IEnumerator<Book>
    //{
    //    public Book Current => books[index];

    //    object IEnumerator.Current => (Book)Current;

    //    private IReadOnlyList<Book> books;

    //    private int index;

    //    public LibraryIterator(IReadOnlyList<Book> books)
    //    {
    //        this.books = books;
    //        index = -1;
    //    }

    //    public void Dispose()
    //    {
    //    }

    //    public bool MoveNext()
    //    {
    //        index++;

    //        return index < books.Count;
    //    }

    //    public void Reset()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

}


