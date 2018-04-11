using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Lake : IEnumerable
{

    private readonly List<int> stones;
    public Lake(IEnumerable<int> stones)
    {
        this.stones = new List<int>(stones);
    }
    public IEnumerator GetEnumerator()
    {
        var ascendingEvens = new List<int>();

        for (int i = 0; i < this.stones.Count; i+=2)
        {
            ascendingEvens.Add(this.stones[i]);
        }
        var reversedOdds = new List<int>();

        for (int i = 1; i < this.stones.Count; i += 2)
        {
            reversedOdds.Add(this.stones[i]);
        }

        reversedOdds.Reverse();
        var outputList = Enumerable.Concat(ascendingEvens, reversedOdds).ToList();

        for (int i = 0; i < outputList.Count(); i++)
        {
            yield return outputList[i];
        }
    }
}

