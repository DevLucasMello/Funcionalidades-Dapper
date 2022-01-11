using Aplicacao.Dapper.Repositories;
using System;

namespace Aplicacao.Dapper.Screens.RelatorioScreen
{
    public static class ListaTagsPosts
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Tags e Posts");
            Console.WriteLine("-----------------");
            List();
            Console.ReadKey();
            RelatorioScreen.Load();
        }

        private static void List()
        {
            var repository = new TagRepository(Database.Connection);
            var tags = repository.ReadWithPost();

            foreach (var item in tags)
            {
                Console.Write($"{item.Name} - ");
                if (item.Posts[0] != null) Console.WriteLine($"possui {item.Posts.Count} posts");
                else Console.WriteLine($" não possui posts");
            }
        }
    }
}
