using Aplicacao.Dapper.Repositories;
using System;

namespace Aplicacao.Dapper.Screens.PostScreens
{
    public static class ListPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de posts");
            Console.WriteLine("-----------------");
            List();            
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        private static void List()
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.ReadWithTag();

            foreach (var item in posts) 
            {
                Console.Write($"{item.Id} - {item.CategoryId} - {item.AuthorId} - ({item.Slug})");
                foreach (var tag in item.Tags)
                {
                    Console.WriteLine($" - {tag?.Name}");
                }
            }
        }
    }
}