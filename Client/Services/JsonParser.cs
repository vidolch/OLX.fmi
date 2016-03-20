namespace Client.Services
{
    using Client.Models;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Script.Serialization;
    using System;

    class JsonParser<T>
    {
        public List<T> ToObjectList(string json)
        {
            List<T> products = new JavaScriptSerializer().Deserialize<List<T>>(json);

            return products;
        }

        public string ToJson(T newT)
        {
            string json = new JavaScriptSerializer().Serialize(newT);

            return json;
        }

        internal T ToObject(string json)
        {
            T item = new JavaScriptSerializer().Deserialize<T>(json);

            return item;
        }
    }
}
