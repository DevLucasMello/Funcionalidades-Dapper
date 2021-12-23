using System;

namespace Aplicacao.Dapper.Screens.PostTagScreens
{
    public static class MenuPostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vincular post/tag");
            Console.WriteLine("-----------------");
            CreatePostTagScreen.Load();           
            Program.Load();            
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
