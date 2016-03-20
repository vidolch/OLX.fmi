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
			string nameText = "Enter unique product name:" + Environment.NewLine;
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

		public void Index()
        {
            Console.Clear();
            IRequestHandler request = new RequestHandler();

			List<Product> products = request.Index();

			this.PrintProducts(products);

            this.RenderBackCommand();

            IInputProvider inputProvider = new InputProvider();
            inputProvider.ReadMenuCommand();
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

            if (products.Count > 0)
            {
                this.PrintProducts(products);
            }
			else
            {
                this.PrintErrorMessage(ErrorMessages.ProductNotFound);
            }

            this.RenderBackCommand();
        }

		public void Remove()
        {
            Console.Clear();

            IRequestHandler request = new RequestHandler();

            List<Product> products = request.Index();

            this.PrintProducts(products);

            this.ReadRemoveInput();

        }

        public void Update()
        {
            Console.Clear();

            IRequestHandler request = new RequestHandler();

            List<Product> products = request.Index();

            this.PrintProducts(products);

            this.ReadUpdateInput();
        }

        private void ReadRemoveInput()
        {
            string text = "Type the name of the product you want to delete:" + Environment.NewLine;

            Console.WriteLine(text);

            IInputProvider inputProvider = new InputProvider();

            string input = inputProvider.ReadSearchCommand();

            IRequestHandler requestHandler = new RequestHandler();

            bool delete = requestHandler.Remove(input);

            if (delete)
            {
                text = "Your entry was successfully removed." + Environment.NewLine;
                Console.WriteLine(text);

                this.RenderBackCommand();
            }
            else
            {
                this.PrintErrorMessage(ErrorMessages.ProductNotFoundError);

                this.ReadRemoveInput();
            }
        }

        private void ReadUpdateInput()
        {
            string text = "Type the name of the product you want to update:" + Environment.NewLine;

            Console.WriteLine(text);

            IInputProvider inputProvider = new InputProvider();

            string input = inputProvider.ReadSearchCommand();

            IRequestHandler requestHandler = new RequestHandler();

            Product oldProduct = requestHandler.Show(input);

            if (oldProduct != null)
            {
                text = "Old name = " + oldProduct.Name + Environment.NewLine;
                text += "Enter product new name: " + Environment.NewLine;
                Console.WriteLine(text);

                string newName = inputProvider.ReadConsoleInput();

                text = "Old price = " + oldProduct.Price + Environment.NewLine;
                text += "Enter product new price: ";
                Console.WriteLine(text);

                double newPrice = double.Parse(inputProvider.ReadConsoleInput());

                bool updated = requestHandler.Update(newName, newPrice, oldProduct.Id);

                if (!updated)
                {
                    this.PrintErrorMessage(ErrorMessages.UnableToUpdateProductError);
                }
                else
                {
                    Console.WriteLine(SuccessMessages.SuccessfullyUpdated);
                }
                this.RenderBackCommand();
            }
            else
            {
                this.PrintErrorMessage(ErrorMessages.ProductNotFoundError);

                this.ReadUpdateInput();
            }
        }

        public void PrintErrorMessage(string error)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Red;

			Console.WriteLine("##### {0} #####", error);

			Console.ResetColor();
		}

		public void PrintProducts(List<Product> products)
		{
			string text = "";

			foreach (var product in products)
			{
				text += product.Name + " - " + product.Price + Environment.NewLine;
			}

			Console.WriteLine(text);

			IInputProvider inputProvider = new InputProvider();
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

		private void RenderBackCommand()
		{
			MenuHandler menuHandler = new MenuHandler();
			MenuItem backCommand = menuHandler.GetBackCommand();

			Console.WriteLine(Environment.NewLine);
			Console.WriteLine("{0}) {1}", backCommand.Activator, backCommand.Text);
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
	}
}
