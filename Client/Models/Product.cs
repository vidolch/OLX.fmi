namespace Client.Models
{
    using System;
    class Product
    {
        private string name;
        private double price;
        private DateTime date;

        public Product()
        {

        }

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
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
    }
}
