namespace Client.Renderers
{
    using System;
    using Client.Contracts;
    using Requests;
    using System.Collections.Generic;
    using Client.Models;
    using InputProviders;
    using Constants;

    class Renderer : IRenderer
    {
        public void Add()
        {
            string nameText = "Enter product name:" + Environment.NewLine;
            string priceText = "Enter product price in following format XX.XX: " + Environment.NewLine;
            Console.Clear();

            IInputProvider inputProvider = new InputProvider();
            Console.WriteLine(nameText);
            string name = inputProvider.ReadConsoleInput();

            Console.WriteLine(priceText);

            double price = ParsePrice(inputProvider);

            IRequestHandler requestHandler = new RequestHandler();

            requestHandler.Add(name, price);
            Console.WriteLine("Your entry was successfully added!");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("0) to back in Main menu.");
        }

        private double ParsePrice(IInputProvider inputProvider)
        {
            double price;
            try
            {
                price = double.Parse(inputProvider.ReadConsoleInput());
            }
            catch (FormatException)
            {
                this.PrintErrorMessage(ErrorMessages.InvalidValueFormat);
                price = this.ParsePrice(inputProvider);
            }

            return price;
        }

        public void Index()
        {
            IRequestHandler request = new RequestHandler();

            List<Product> products = request.Index();

            this.PrintProducts(products);
        }

        public void PrintErrorMessage(string error)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;

            Console.WriteLine("##### {0} #####", error);

            Console.ResetColor();
        }

        public void RenderMainMenu()
        {
            string menu = "1) List all products;" + Environment.NewLine;
            menu += "2) Search for products;" + Environment.NewLine;
            menu += "3) Add new product;" + Environment.NewLine;

            Console.Clear();

            Console.WriteLine(menu);
        }

        public void Search()
        {
            string text = "Type product name to search for it:"  + Environment.NewLine;
            Console.Clear();

            Console.WriteLine(text);

            IInputProvider inputProvider = new InputProvider();
            string input = inputProvider.ReadSearchCommand();

            IRequestHandler requesyHandler = new RequestHandler();
            List<Product> products =  requesyHandler.Search(input);

            this.PrintProducts(products);
        }

        public void PrintProducts(List<Product> products)
        {
            Console.Clear();
            string text = "";

            foreach (var product in products)
            {
                text += product.Name + " - " + product.Price + Environment.NewLine;
            }

            Console.WriteLine(text);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("0) to back in Main menu.");

            IInputProvider inputProvider = new InputProvider();
            inputProvider.ReadMenuCommand();
        }
    }
}
