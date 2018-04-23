using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class WareHouseCommand : Command
{
    private IWareHouse wareHouse;
  
    public WareHouseCommand(IReadOnlyList<string> arguments, IWareHouse wareHouse)
        : base(arguments)

    {
        this.wareHouse = wareHouse;
    }
    public override void Execute()
    {
        string name = Arguments[0];
        int number = int.Parse(Arguments[1]);

        this.wareHouse.AddAmmunitions(name, number);
    }
}

