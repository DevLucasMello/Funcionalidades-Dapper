using Aplicacao.Dapper.Models;
using Aplicacao.Dapper.Repositories;
using System;

namespace Aplicacao.Dapper.Screens.RoleScreens
{
    public static class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um perfil");
            Console.WriteLine("-----------------");
            Console.Write("Qual o Id do perfil que deseja excluir: ");
            var id = Console.ReadLine();           
            Delete(int.Parse(id));
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine();
                Console.WriteLine("Perfil excluída com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o Perfil");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
