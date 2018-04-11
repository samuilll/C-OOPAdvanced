﻿using System;
using System.Collections.Generic;
using System.Text;


   public class Book:IComparable<Book>
    {
    public Book(string title, int year,params string[] authors)
    {
        Title = title;
        Year = year;
        this.Authors = new List<string>(authors);
    }

    public string Title { get;private set; }

    public int Year { get;private set; }

    public IReadOnlyList<string> Authors { get; private set; } = new List<string>();

    public int CompareTo(Book other)
    {
        int result = this.Year.CompareTo(other.Year);

        int comparerByYear = this.Year.CompareTo(other.Year);

        if (result==0)
        {
            result = this.Title.CompareTo(other.Title);
        }
       
        return result;
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }
}

