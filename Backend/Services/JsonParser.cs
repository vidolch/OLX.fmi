namespace Backend.Services
{
    using System;
    using Backend.Models;

    using System.Web.Script.Serialization;
    using System.Collections.Generic;

    class JsonParser<T>
    {
        public string ToJson(object obj)
        {
            string jsonString = new JavaScriptSerializer().Serialize(obj);

            return jsonString;
        }

        public T ToObject(string json)
        {
            T item = new JavaScriptSerializer().Deserialize<T>(json);

            return item;
        }

        public List<T> ToObjectList(string json)
        {
            List<T> products = new JavaScriptSerializer().Deserialize<List<T>>(json);

            return products;
        }
    }
}
