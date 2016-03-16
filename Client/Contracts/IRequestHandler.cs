namespace Client.Contracts
{
    using System.Collections.Generic;
    using Client.Models;

    interface IRequestHandler
    {
        List<Product> Index();
        List<Product> Search(string input);
        void Add(string name, double price);
    }
}
