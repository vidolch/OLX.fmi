namespace Backend.Models
{
    using Backend.Contracts;
    using System;

    public class Product : IProduct
    {
        public static string table = "products";
        private string name;
        private double price;
        private DateTime date;
        private ulong id;

        public Product()
        {
            
        }
        public Product(string name, double price, ulong id = 0)
        {
            this.Name = name;
            this.Price = price;
            this.Date = DateTime.Now;

            Random random = new Random();
            if(id != 0)
            {
                this.Id = Convert.ToUInt64(random.Next(1, int.MaxValue));
            }
            else
            {
                this.Id = id;
            }
            
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        
        public ulong Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
