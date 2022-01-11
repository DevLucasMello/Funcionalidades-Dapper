using Aplicacao.Dapper.Repositories;
using System;

namespace Aplicacao.Dapper.Screens.RelatorioScreen
{
    public static class ListPostCategoria
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Posts contidos na categoria");
            Console.WriteLine("-----------------");
            Console.Write("Digite o Id da Categoria: ");
            var categoryId = Convert.ToInt32(Console.ReadLine());
            List(categoryId);
            Console.ReadKey();
            RelatorioScreen.Load();
        }

        private static void List(int categoryId)
        {
            var repository = new CategoryRepository(Database.Connection);
            var categories = repository.ReadPostsWithCategory(categoryId);

            foreach (var item in categories)
            {
                Console.Write($"{item.Name} - ");
                foreach (var post in item.Posts)
                {
                    if (post != null) Console.Write($"{post.Title}, ");
                    else Console.WriteLine($" não possui posts");
                }
                Console.WriteLine();
            }
        }
    }
}
