namespace Client.Constants
{
    static class Menus
    {
        public static string[,] MenuItems = new string[,] {
                { "List all products;",       "Client.Renderers@Renderer@Index" },
                { "Search for products;",     "Client.Renderers@Renderer@Search" },
                { "Add new product;",         "Client.Renderers@Renderer@Add" },
                { "Delete existing product;", "Client.Renderers@Renderer@RenderMainMenu" },

                // Last one is reserved for back command
                { "Back to main menu;", "Client.Renderers@Renderer@RenderMainMenu" }
        };

        public static int BackActivator = 0;
    }
}
