namespace Client.Models
{
    using System;
    using System.Collections.Generic;
    using Client.Contracts;
    class Menu : IMenu
    {
        public List<MenuItem> menuItems;
        public MenuItem backMenuItem;

        public Menu()
        {
            this.menuItems = new List<MenuItem>();
        }

        public void AddMenuItem(MenuItem item)
        {
            this.menuItems.Add(item);
        }

        public void AddBackMenuItem(MenuItem item)
        {
            this.backMenuItem = item;
        }

        public MenuItem GetMenuItem(int index)
        {
            return this.menuItems[index];
        }

        public IList<MenuItem> GetMenuItemList()
        {
            return this.menuItems;
        }

        public void RemoveMenuItem(int index)
        {
            this.menuItems.RemoveAt(index);
        }
    }
}
