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

            var json = new JsonParser();

            string jsonString = json.ToJson(newProduct);

            var request = new Backend.Requests.RequestHandler();

            request.Add(jsonString);
        }

        public List<Product> Index()
        {
            var request = new Backend.Requests.RequestHandler();

            var parser = new JsonParser();

            var products = parser.ToProductList(request.Index());

            return products;
        }

        public List<Product> Search(string input)
        {
            var request = new Backend.Requests.RequestHandler();

            var parser = new JsonParser();

            var products = parser.ToProductList(request.Search(input));

            return products;
        }
    }
}
