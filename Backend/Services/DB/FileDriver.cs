namespace Backend.Services.DB
{
    using Backend.Contracts;
    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Services;

    class FileDriver<T> : DBDriver<T>
    {
        public override T Get(string entry, string field, string table)
        {
            string fileContent = File.ReadAllText(table + ".json");

            var jsonParser = new JsonParser<T>();
            try
            {
                List<T> items = jsonParser.ToObjectList(fileContent);

                T item = items.Where(p => (p.GetType().GetProperty(field).GetValue(p, null) as string) == entry)
                                .First();

                return item;
            }
            catch (InvalidOperationException)
            {
                return default(T);
            }
            
        }
        public override List<T> GetMany(string table, string entry = "", string field = "")
        {
            string fileContent = File.ReadAllText(table + ".json");

            var jsonParser = new JsonParser<T>();

            List<T> items = jsonParser.ToObjectList(fileContent);

            return items;
        }

        public override void Save(T item, string table)
        {
            string fileContent = File.ReadAllText(table + ".json");

            var jsonParser = new JsonParser<T>();

            List<T> items = jsonParser.ToObjectList(fileContent);

            items.Add(item);

            var jsonToSave = jsonParser.ToJson(items);

            File.WriteAllText(table + ".json", jsonToSave);
        }

        public override T Update(string entry, string table, string field = "Id")
        {
            string fileContent = File.ReadAllText(table + ".json");

            var jsonParser = new JsonParser<T>();

            List<T> items = jsonParser.ToObjectList(fileContent);
            T item = jsonParser.ToObject(entry);

            string valueToLookFor = (item.GetType().GetProperty(field).GetValue(item, null)).ToString();

            int indexToUpdate = items.IndexOf<T>(valueToLookFor, field);

            items[indexToUpdate] = item;

            var jsonToSave = jsonParser.ToJson(items);

            File.WriteAllText(table + ".json", jsonToSave);

            return item;
        }

        public override T Remove(string entry, string field, string table)
        {
            string fileContent = File.ReadAllText(table + ".json");

            var jsonParser = new JsonParser<T>();
            try
            {
                List<T> items = jsonParser.ToObjectList(fileContent);

                T item = items.Where(p => (p.GetType().GetProperty(field).GetValue(p, null) as string) == entry)
                    .First();

                items.Remove(item);

                var jsonToSave = jsonParser.ToJson(items);

                File.WriteAllText(table + ".json", jsonToSave);

                return item;
            }
            catch (InvalidOperationException)
            {
                return default(T);
            }
            
        }
    }
}
