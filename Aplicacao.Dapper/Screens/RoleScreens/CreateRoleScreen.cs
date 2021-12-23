using Aplicacao.Dapper.Models;
using Aplicacao.Dapper.Repositories;
using System;

namespace Aplicacao.Dapper.Screens.RoleScreens
{
    public static class CreateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo perfil");
            Console.WriteLine("-----------------");
            Console.Write("Name: ");
            var name = Console.ReadLine();            
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Create(new Role { Name = name, Slug = slug});
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        private static void Create(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Create(role);
                Console.WriteLine();
                Console.WriteLine("Perfil cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar o Perfil");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
