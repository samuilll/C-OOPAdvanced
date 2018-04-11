using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


  public  class CommandInterpreter
    {


    public CommandInterpreter()
    {
        this.list = new CustomList<string>();
    }
    private ICustomList<string> list = new CustomList<string>();

    public bool IsInProcess { get; private set; } = true;


    public void ReadCommand(List<string> args)
    {
        string command = args[0];

        switch (command)
        {
            case "Add":
                {
                    string element = args[1];

                    this.list.Add(element);

                    break;
                }
            case "Remove":
                {
                    int index = int.Parse(args[1]);

                    string element = this.list.Remove(index);

                    break;
                }
            case "Contains":
                {
                    string element = args[1];

                    Console.WriteLine(this.list.Contains(element));

                    break;
                }
            case "Swap":
                {
                    int index1 = int.Parse(args[1]);
                    int index2 = int.Parse(args[2]);

                    this.list.Swap(index1, index2);

                    break;
                }
            case "Greater":
                {
                    string element = args[1];

                    Console.WriteLine(this.list.CountGreaterThan(element));

                    break;
                }
            case "Max":
                {
                    Console.WriteLine(this.list.Max());

                    break;
                }
            case "Min":
                {
                    Console.WriteLine(this.list.Min());

                    break;
                }
            case "Print":
                {
                    foreach (var element in this.list)
                    {
                        Console.WriteLine(element);
                    }
                    break;
                }
            case "Sort":
                {
                  Sorter<string>.Sort(this.list);
                    break;
                }
            case "END":
                {
                    this.IsInProcess = false;
                    break;
                }
            default:
                break;
        }
    }
    }

