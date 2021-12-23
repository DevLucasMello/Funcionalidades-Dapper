using Aplicacao.Dapper.Models;
using Aplicacao.Dapper.Repositories;
using System;

namespace Aplicacao.Dapper.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um user");
            Console.WriteLine("-----------------");
            Console.Write("Qual o Id do user que deseja excluir: ");
            var id = Console.ReadLine();           
            Delete(int.Parse(id));
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine();
                Console.WriteLine("User excluída com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o User");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
