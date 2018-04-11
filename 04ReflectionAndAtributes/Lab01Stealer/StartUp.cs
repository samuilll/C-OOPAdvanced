using System;
using System.Collections;
using System.Linq;
using System.Reflection;

class StartUp
{
    static void Main(string[] args)
    {
        //Spy spy = new Spy();

        ////  Console.WriteLine(spy.StealFieldInfo("Hacker","username","password"));
        //// Console.WriteLine(spy.AnalyzeAcessModifiers("Hacker"));
        //// Console.WriteLine(spy.RevealPrivateMethods("Hacker"));
        //Console.WriteLine(spy.CollectGettersAndSetters("Hacker"));


        //State state = State.LiterateAndBad;

        //var str = state.ToString();

        //if (state.HasFlag(State.Write) && state.HasFlag(State.Steal))
        //{
        //    Console.WriteLine("Yeeeeeeeee");
        //}
        //else
        //{
        //    Console.WriteLine("No");
        //}

        var method = typeof(Person).GetProperties(BindingFlags.NonPublic|BindingFlags.Instance).First().Name;

        Console.WriteLine(method);

    }

}

public class Person
{
    private int Age { get; set; }
}
[Flags]
public enum State
{
    Read = 1,
    Write = 2,
    Steal = 4,
    LiterateAndBad = 7,
    Lie = 8,
    All=15
}



