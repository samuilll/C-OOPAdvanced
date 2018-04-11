using System;
using System.Collections.Generic;
using System.Text;
using Task01Logger.Interfaces;

namespace Task01Logger.Entities
{
    public abstract class Layout : ILayout
    {
       
        public abstract string GetInfo(IError error);
        
    }
}
