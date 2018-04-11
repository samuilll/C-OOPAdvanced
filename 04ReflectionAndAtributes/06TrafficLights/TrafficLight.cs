using System;
using System.Collections.Generic;
using System.Text;


public class TrafficLight
{

    public TrafficLight(string signal)
    {
        this.Signal = signal;
    }

    private Color signal;

    public string Signal
    {
        get
        {
            return signal.ToString();
        }

      private  set
        {
            this.signal = (Color)Enum.Parse(typeof(Color), value);
        }
    }

    public void ChangeLight()
    {

        var colors = Enum.GetValues(typeof(Color));
        this.signal = (Color)colors.GetValue(((int)this.signal+1)%colors.Length);
    }

    public override string ToString()
    {
        return this.Signal;
    }

}

