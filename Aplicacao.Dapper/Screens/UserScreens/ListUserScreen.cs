using Aplicacao.Dapper.Repositories;
using System;

namespace Aplicacao.Dapper.Screens.UserScreens
{
    public static class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de users");
            Console.WriteLine("-----------------");
            List();            
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void List()
        {
            var repository = new UserRepository(Database.Connection);
            var users = repository.ReadWithRole();

            foreach (var item in users) 
            {
                Console.Write($"{item.Id} - {item.Name} - {item.Bio} ({item.Slug})");
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($" - {role?.Name}");
                }
            }
        }
    }
}
