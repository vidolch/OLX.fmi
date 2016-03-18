namespace Client.Renderers
{
    using System;
    using Client.Contracts;
    using Requests;
    using System.Collections.Generic;
    using Client.Models;
    using InputProviders;
    using Constants;
    using Services;

    public class Renderer : IRenderer
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
            this.RenderBackCommand();
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
            MenuHandler menuHandler = new MenuHandler();

            string menuString = "";
            IList<MenuItem> menuItemList = menuHandler.GetMenuItemList();
            foreach (MenuItem item in menuItemList)
            {
                menuString += item.Activator + ") " + item.Text + Environment.NewLine;
            }

            Console.Clear();

            Console.WriteLine(menuString);
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
            this.RenderBackCommand();

            IInputProvider inputProvider = new InputProvider();
            inputProvider.ReadMenuCommand();
        }

        private void RenderBackCommand()
        {
            MenuHandler menuHandler = new MenuHandler();
            MenuItem backCommand = menuHandler.GetBackCommand();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("{0}) {1}", backCommand.Activator, backCommand.Text);
        }
    }
}
