using System;
using System.Collections.Generic;
using System.Text;

[AttributeUsage(AttributeTargets.Class)]
public class InfernoAttribute : Attribute
{
    public const string Author = "Pesho";
    public const int Revision = 3;
    public const string Description = "Used for C# OOP Advanced Course - Enumerations and Attributes.";
    public const string Reviewers = "Pesho, Svetlio";

}

