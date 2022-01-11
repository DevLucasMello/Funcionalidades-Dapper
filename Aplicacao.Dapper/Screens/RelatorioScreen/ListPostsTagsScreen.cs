using Aplicacao.Dapper.Repositories;
using System;

namespace Aplicacao.Dapper.Screens.RelatorioScreen
{
    public static class ListPostsTagsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de posts com suas tags");
            Console.WriteLine("-----------------");
            ListPostsTags();
            Console.ReadKey();
            RelatorioScreen.Load();
        }       

        private static void ListPostsTags()
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.ReadWithTag();

            foreach (var item in posts)
            {
                Console.Write($"{item.Title} - ");
                foreach (var tag in item.Tags)
                {
                    Console.Write($"{tag?.Name}, ");
                }
                Console.WriteLine();
            }
        }
    }
}