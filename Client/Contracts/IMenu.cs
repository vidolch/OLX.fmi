using Client.Models;
using System.Collections.Generic;

namespace Client.Contracts
{
    interface IMenu
    {
        IList<MenuItem> GetMenuItemList();
        MenuItem GetMenuItem(int index);
        void AddMenuItem(MenuItem item);
        void RemoveMenuItem(int index);

    }
}
