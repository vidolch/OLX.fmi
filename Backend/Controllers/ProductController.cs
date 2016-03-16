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
            return db.Get(Product.table);
        }

        public List<Product> Search(string query)
        {
            DBDriver<Product> db = new FileDriver<Product>();
            List<Product> productList = db.Get(Product.table);

            List<Product> result = productList
                                    .Where(p => p.Name.Contains(query))
                                    .ToList();
            return result;
        }
        public void Add(Product product)
        {
            DBDriver<Product> db = new FileDriver<Product>();

            db.Save(product, Product.table);
        }
    }
}
