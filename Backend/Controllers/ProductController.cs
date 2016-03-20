namespace Backend.Controllers
{
    using Backend.Contracts;
    using Services.DB;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using Services;
    using System;

    class ProductController
    {
        public List<Product> Index()
        {
            DBDriver<Product> db = new FileDriver<Product>();
            List<Product> result = db.GetMany(Product.table);
            result.OrderBy(p => p.Date).ToList();
            return result;
        }

        public List<Product> Search(string query)
        {
            DBDriver<Product> db = new FileDriver<Product>();
            List<Product> productList = db.GetMany(Product.table);

            List<Product> result = productList
                                    .Where(p => p.Name.Contains(query))
                                    .OrderBy(p => p.Date)
                                    .ToList();
            return result;
        }
        public void Add(Product product)
        {
            DBDriver<Product> db = new FileDriver<Product>();

            db.Save(product, Product.table);
        }

        internal bool Remove(string productName)
        {
            DBDriver<Product> db = new FileDriver<Product>();

            Product deleted = db.Remove(productName, "Name", Product.table);

            if (deleted != null)
            {
                return true;
            }
            return false;
        }

        public Product Show(string entry)
        {
            DBDriver<Product> db = new FileDriver<Product>();

            return db.Get(entry, "Name", Product.table);
        }

        public bool Update(string entry)
        {
            DBDriver<Product> db = new FileDriver<Product>();

            Product updated = db.Update(entry, Product.table);

            if (updated != null)
            {
                return true;
            }
            return false;
        }
    }
}
