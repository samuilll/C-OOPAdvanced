﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Writer : IWriter
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message.Trim('\n'));
    }
}

