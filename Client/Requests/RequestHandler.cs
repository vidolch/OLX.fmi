namespace Client.Requests
{
    using System;
    using System.Collections.Generic;
    using Client.Contracts;
    using Models;
    using Services;

    class RequestHandler : IRequestHandler
    {
        public void Add(string name, double price)
        {
            Product newProduct = new Product(name, price);

            var json = new JsonParser<Product>();

            string jsonString = json.ToJson(newProduct);

            var request = new Backend.Requests.RequestHandler();

            request.Add(jsonString);
        }

        public List<Product> Index()
        {
            var request = new Backend.Requests.RequestHandler();

            var parser = new JsonParser<Product>();

            var products = parser.ToObjectList(request.Index());

            return products;
        }

        public bool Remove(string input)
        {
            var request = new Backend.Requests.RequestHandler();

            bool delete = request.Remove(input);

            return delete;
        }

        public List<Product> Search(string input)
        {
            var request = new Backend.Requests.RequestHandler();

            var parser = new JsonParser<Product>();

            var products = parser.ToObjectList(request.Search(input));

            return products;
        }

        public Product Show(string input)
        {
            var request = new Backend.Requests.RequestHandler();

            var parser = new JsonParser<Product>();

            var product = parser.ToObject(request.Show(input));

            return product;
        }

        public bool Update(string newName, double newPrice, ulong Id)
        {
            Product item = new Product(newName, newPrice, Id);

            var json = new JsonParser<Product>();

            var request = new Backend.Requests.RequestHandler();

            bool updated = request.Update(json.ToJson(item));

            return updated;
        }
    }
}
