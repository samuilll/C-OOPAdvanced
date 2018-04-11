using System;
using System.Collections.Generic;
using System.Text;

namespace Ex01EventImplementation
{
   public interface INameChangeable:INameable
    {
         event NameChangeEventHandler NameChange;

        void OnNameChange(NameChangeEventArgs args);
    }
}
