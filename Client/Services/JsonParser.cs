namespace Client.Services
{
    using Client.Models;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Script.Serialization;
    using System;

    class JsonParser
    {
        public List<Product> ToProductList(string json)
        {
            List<Product> products = new JavaScriptSerializer().Deserialize<List<Product>>(json);

            return products;
        }

        public string ToJson(Product newProduct)
        {
            string json = new JavaScriptSerializer().Serialize(newProduct);

            return json;
        }
    }
}
