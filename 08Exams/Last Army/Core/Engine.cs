using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Engine
    {

    private GameController gameConstroller;

    private StringBuilder result = new StringBuilder();
    public StringBuilder Result => this.result;

    public Engine()
    {
        this.gameConstroller = new GameController(this.result);
    }

    public void Run()
    {
        string input = string.Empty;

        while (true)
        {
             input = Console.ReadLine();

            if (input== "Enough! Pull back!")
            {
                break;
            }
            try
            {
                this.gameConstroller.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                result.AppendLine(arg.Message);
            }
        }

       result.AppendLine(gameConstroller.RequestResult());
    }
}

