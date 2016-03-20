namespace Backend.Services.DB
{
    using System;
    using Backend.Contracts;
    using System.Collections.Generic;

    abstract class DBDriver<T>
    {
        public DBDriver()
        {
            
        }
        public abstract T Get(string entry, string field, string table);

        public abstract List<T> GetMany(string table, string entry = "", string field = "");

        public abstract void Save(T item, string table);

        public abstract T Update(string entry, string table, string field = "Id");

        public abstract T Remove(string entry, string field, string table);
    }
}
