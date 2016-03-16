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
        private int id;

        public Product()
        {
            
        }
        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
            this.Date = DateTime.Now;

            Random random = new Random();

            this.Id = random.Next(0, int.MaxValue);
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
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
