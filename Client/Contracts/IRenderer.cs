namespace Client.Contracts
{
    interface IRenderer
    {
        void RenderMainMenu();
        void PrintErrorMessage(string error);
        void Index();
        void Search();
        void Add();
    }
}
