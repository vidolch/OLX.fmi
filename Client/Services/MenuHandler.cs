namespace Client.Services
{
    using Client.Constants;
    using Client.Contracts;
    using Client.Models;
    using Renderers;
    using System.Collections.Generic;
    using System.Linq;

    class MenuHandler
    {
        public static Menu menu;
        public MenuHandler()
        {
            if (menu == null)
            {
                this.initializeMenu();
            }
        }

        private void initializeMenu()
        {
            menu = new Menu();
            string[,] configMenuItems = Menus.MenuItems;

            for (int i = 0; i < configMenuItems.GetLength(0) - 1; i++)
            {
                int activator = i + 1;
                MenuItem menuItem = new MenuItem(configMenuItems[i, 0], activator, configMenuItems[i, 1]);
                menu.AddMenuItem(menuItem);
            }

            // Set last item on menu config for back command
            MenuItem backMenuItem = new MenuItem(configMenuItems[configMenuItems.GetLength(0) - 1, 0], Menus.BackActivator, configMenuItems[configMenuItems.GetLength(0) - 1, 1]);
            menu.AddBackMenuItem(backMenuItem);
        }

        public void Call(int activator)
        {
            IList<MenuItem> menuItems = menu.GetMenuItemList();
            MenuItem item = menuItems
                .Where(x => x.Activator == activator)
                .FirstOrDefault();

            if (item != null)
            {
                item.Call();
            }
            else
            {
                if(menu.backMenuItem.Activator == Menus.BackActivator)
                {
                    MenuItem backCommand = menu.backMenuItem;
                    backCommand.Call();
                }
                else
                {
                    IRenderer renderer = new Renderer();

                    renderer.PrintErrorMessage(ErrorMessages.CommandNotFoundError);
                }
            }
        }

        public IList<MenuItem> GetMenuItemList()
        {
            // return menu list esides back button
            IList<MenuItem> menuList = menu.GetMenuItemList();
            //menuList.RemoveAt(menuList.Count - 1);
            return menuList;
        }

        public MenuItem GetBackCommand()
        {
            return menu.backMenuItem;
        }
    }
}
