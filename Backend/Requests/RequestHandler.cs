namespace Backend.Requests
{
    using System;
    using System.Collections.Generic;
    using Backend.Contracts;
    using Models;
    using Controllers;

    using System.Web.Script.Serialization;
    using Services;

    public class RequestHandler : IRequestHandler
    {
        public string Index()
        {
            ProductController productController = new ProductController();

            var json = new JavaScriptSerializer().Serialize(productController.Index());

            return json;
        }

        public string Search(string query)
        {
            ProductController productController = new ProductController();
            var json = new JsonParser<Product>();
            var jsonString = json.ToJson(productController.Search(query));

            return jsonString;
        }

        public void Add(string jsonString)
        {
            var json = new JsonParser<Product>();

            Product product = json.ToObject(jsonString);

            ProductController productController = new ProductController();
            productController.Add(product);

        }
    }
}
