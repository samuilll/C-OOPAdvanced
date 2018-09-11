using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    using Contracts;
    public class CategoriesMenuCommand : NavigationCommand, ICommand
    {

        public CategoriesMenuCommand(IMenuFactory menuFactory):base(menuFactory)
        {
        }

        
    }
}
