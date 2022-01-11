using Aplicacao.Dapper.Repositories;
using System;

namespace Aplicacao.Dapper.Screens.RelatorioScreen
{
    public static class ListaUsuariosPerfis
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de users");
            Console.WriteLine("-----------------");
            List();
            Console.ReadKey();
            RelatorioScreen.Load();
        }

        private static void List()
        {
            var repository = new UserRepository(Database.Connection);
            var users = repository.ReadWithRole();

            foreach (var item in users)
            {
                Console.Write($"{item.Name} - {item.Email} - ");
                foreach (var role in item.Roles)
                {
                    Console.Write($"{role?.Name}, ");
                }
                Console.WriteLine();
            }
        }
    }
}
