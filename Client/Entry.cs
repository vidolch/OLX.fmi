namespace Client
{
    using Backend.Models;
    using Renderers;
    using Contracts;
    using InputProviders;

    class Entry
    {
        static void Main(string[] args)
        {
            IRenderer renderer = new Renderer();

            renderer.RenderMainMenu();

            bool stop = false;

            while (!stop)
            {
                IInputProvider inputProvider = new InputProvider();
                inputProvider.ReadMenuCommand();
            }
            
        }
    }
}
