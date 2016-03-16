namespace Client.Contracts
{
    interface IInputProvider
    {
        void ReadCommand();
        void ParseCommand(string command);
        void HandleCommand(string command);
        void ReadMenuCommand();
        void ParseMenuCommand(string command);
        string ReadSearchCommand();
        string ReadConsoleInput();
    }
}
