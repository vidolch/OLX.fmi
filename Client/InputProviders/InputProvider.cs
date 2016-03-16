namespace Client.InputProviders
{
    using System;
    using Client.Contracts;
    using Renderers;
    using Constants;

    class InputProvider : IInputProvider
    {
        public void HandleCommand(string command)
        {
            throw new NotImplementedException();
        }

        public void ParseCommand(string command)
        {
            throw new NotImplementedException();
        }

        public void ParseMenuCommand(string command)
        {
            IRenderer renderer = new Renderer();
            switch (command)
            {
                case "1":
                    renderer.Index();
                    break;
                case "2":
                    renderer.Search();
                    break;
                case "3":
                    renderer.Add();
                    break;
                case "0":
                    renderer.RenderMainMenu();
                    break;
                default:
                    renderer.PrintErrorMessage(ErrorMessages.CommandNotFoundError);
                    break;
            }
        }

        public void ReadCommand()
        {
            string input = this.ReadConsoleInput();

            this.ParseCommand(input);
        }

        public void ReadMenuCommand()
        {
            string input = this.ReadConsoleInput();

            this.ParseMenuCommand(input);
        }

        public string ReadSearchCommand()
        {
            string input = this.ReadConsoleInput();

            return input;
        }

        public string ReadConsoleInput()
        {
            string input = Console.ReadLine();
            input = String.IsNullOrEmpty(input) ? "" : input;
            return input;
        }
    }
}
