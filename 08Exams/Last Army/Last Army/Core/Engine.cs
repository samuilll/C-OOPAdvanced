using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class Engine
    {

    private const string EndCommand = "Enough! Pull back!";
    private GameController gameController;
    private IWriter writer;
    private IReader reader;

    public Engine(GameController gameController,IWriter writer,IReader reader)
    {
        this.gameController = gameController;
        this.writer = writer;
        this.reader = reader;
    }

    public void Run()
    {
        while (true)
        {
            var input = this.reader.ReadLine();

            gameController.ReadCommand(input);

            if (input==EndCommand)
            {
                this.writer.WriteWholeInfo();
                break;
            }
        }
    }
}

