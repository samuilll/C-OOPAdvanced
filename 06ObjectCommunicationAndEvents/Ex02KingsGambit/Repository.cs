using Ex02KingsGambit.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02KingsGambit
{
    public delegate void RespondHandler();
 public   class Repository:IEnumerable
    {
        public event RespondHandler RespondEvent;

        private List<IFigure> figures;

        public Repository()
        {
            this.figures = new List<IFigure>();
        }

        public void AddFigure(IFigure figure)
        {         
                this.figures.Add(figure);
            this.RespondEvent += figure.Respond;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.figures.Count; i++)
            {
                yield return this.figures[i];
            }
        }

        public void RemoveFigure(string name)
        {
            IFigure figure =this.figures.FirstOrDefault(f=>f.Name==name);

           
            if (figure!=null)
            {
                IMortal  figureAsMortal = (IMortal)figure;

                figureAsMortal.TakeDamage();

                if (!figureAsMortal.IsAlive)
                {
                    this.RespondEvent -= figure.Respond;
                    this.figures.Remove(figure);
                }               
            }
        }

        public void Respond()
        {
            this.RespondEvent.Invoke();
        }
    }
}
