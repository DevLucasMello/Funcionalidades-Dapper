using Aplicacao.Dapper.Repositories;
using System;

namespace Aplicacao.Dapper.Screens.RelatorioScreen
{
    public static class ListaPostsCategorias
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Categorias e Posts");
            Console.WriteLine("-----------------");
            List();
            Console.ReadKey();
            RelatorioScreen.Load();
        }

        private static void List()
        {
            var repository = new CategoryRepository(Database.Connection);
            var categories = repository.ReadWithPost();

            foreach (var item in categories)
            {
                Console.Write($"{item.Name} - ");
                foreach (var post in item.Posts)
                {
                    if (post != null) Console.Write($"{post.Title}, ");
                    else Console.Write($" não possui posts");
                }
                Console.WriteLine();
            }
        }
    }
}
