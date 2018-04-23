using System;
using System.Text;

public class ConsoleWriter:IWriter
{
    private StringBuilder data;

    public ConsoleWriter()
    {
        this.data = new StringBuilder();
    }
    public void AddMessage(string message)
    {
        this.data.AppendLine(message.TrimEnd('\r','\n'));
    }
    public void WriteWholeInfo()
    {
        this.WriteLine(this.data.ToString().TrimEnd('\n'));
    }
    public void WriteLine(string output)
    {
        Console.WriteLine(output);
    }
}
