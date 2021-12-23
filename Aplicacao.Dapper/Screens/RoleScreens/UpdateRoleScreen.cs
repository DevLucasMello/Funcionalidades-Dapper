using Aplicacao.Dapper.Models;
using Aplicacao.Dapper.Repositories;
using System;

namespace Aplicacao.Dapper.Screens.RoleScreens
{
    public static class UpdateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando um perfil");
            Console.WriteLine("-----------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();
            Console.Write("Name: ");
            var name = Console.ReadLine();            
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Update(new Role { Id = int.Parse(id), Name = name, Slug = slug });
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        private static void Update(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Update(role);
                Console.WriteLine();
                Console.WriteLine("Perfil atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o Perfil");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
