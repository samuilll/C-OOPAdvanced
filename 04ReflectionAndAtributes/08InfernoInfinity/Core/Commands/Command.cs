using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


public abstract class Command : IExecutable
{

    public virtual void Execute(string[] data)
    {
        string fieldName = data[0];

        Attribute attribute = typeof(Weapon).GetCustomAttribute(typeof(InfernoAttribute));

        var field = attribute.GetType().GetField(fieldName,BindingFlags.Public|BindingFlags.Static);

        var value = field.GetRawConstantValue();


        Console.WriteLine($"{field.Name}: {value}");

    }
}

