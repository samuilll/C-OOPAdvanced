using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    public class ViewCategoryMenuCommand : ICommand
    {
        public ViewCategoryMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        private IMenuFactory menuFactory;

        public IMenu Execute(params string[] args)
        {
            int categoryId = int.Parse(args[0]);

            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0,commandName.Length-"Command".Length);

            IIdHoldingMenu menu = (IIdHoldingMenu)this.menuFactory.CreateMenu(menuName);
            menu.SetId(categoryId);

            return menu;
        }
    }
}
