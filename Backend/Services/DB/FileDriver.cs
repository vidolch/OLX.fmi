namespace Backend.Services.DB
{
    using Backend.Contracts;
    using System.IO;
    using System;
    using System.Collections.Generic;

    class FileDriver<T> : DBDriver<T>
    {
        public override List<T> Get(string table)
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

            FileStream stream = new FileStream(table + ".json", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(stream);
            
            sw.WriteLine(jsonToSave);

            sw.Close();
            stream.Close();
        }

        public override void Update(T item, string table)
        {
            throw new NotImplementedException();
        }
    }
}
