using System;
using System.Collections.Generic;
using System.Text;
using Task01Logger.Entities;

namespace Task01Logger.Interfaces
{
   public interface IAppender
    {
        ILayout layout { get; }

        int ErrorCount { get; }
        ErrorLevel ErrorLevel { get; }
         void Append(IError error);

        void IncreaseMessageNumber();

    }
}
