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
        public abstract List<T> Get(string table);

        public abstract void Save(T item, string table);

        public abstract void Update(T item, string table);
    }
}
