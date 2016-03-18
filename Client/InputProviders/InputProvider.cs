namespace Client.InputProviders
{
    using System;
    using Client.Contracts;
    using Renderers;
    using Constants;
    using Services;

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

            MenuHandler menuHandler = new MenuHandler();
            try
            {
                menuHandler.Call(int.Parse(command));
            }
            catch (FormatException)
            {
                this.ReadMenuCommand();
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
