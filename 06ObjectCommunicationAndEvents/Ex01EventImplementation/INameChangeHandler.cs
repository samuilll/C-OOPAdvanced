using System;
using System.Collections.Generic;
using System.Text;

namespace Ex01EventImplementation
{
    interface INameChangeHandler
    {
        void OnDispatcherNameChange(object sender, NameChangeEventArgs args);
    }
}
