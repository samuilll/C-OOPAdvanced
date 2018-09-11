using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
  public  class SignUpMenuCommand:NavigationCommand
    {
        public SignUpMenuCommand(IMenuFactory menuFactory)
            :base(menuFactory)
        {
        }
    }
}
