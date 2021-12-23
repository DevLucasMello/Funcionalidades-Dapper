using Aplicacao.Dapper.Models;
using Aplicacao.Dapper.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;
using System;

namespace Aplicacao.Dapper.Screens.UserRoleScreens
{
    public static class CreateUserRoleScreen
    {
        private static string confirmUser;
        private static string confirmRole;
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo perfil usuario");
            Console.WriteLine("-----------------");
            string idUser;
            string idRole;

            do
            {
                Console.Write("Digite o Id User: ");
                idUser = Console.ReadLine();
                GetUser(idUser);
            } while (ConfirmacaoAcao(confirmUser.ToUpper()));


            do
            {
                Console.Write("Id Perfil: ");
                idRole = Console.ReadLine();
                GetRole(idRole);
            } while (ConfirmacaoAcao(confirmRole.ToUpper()));

            var userRole = new { UserId = Convert.ToInt32(idUser), RoleId = Convert.ToInt32(idRole) };

            Create(userRole);

            Console.ReadKey();            
        }

        private static void GetUser(string id)
        {
            try
            {                
                var respositoryUser = new UserRepository(Database.Connection);
                var user = respositoryUser.Get(id);
                Console.WriteLine();
                Console.Write($"Confirme o User {user.Name} [S] - Sim ou [N] - Não: ");
                confirmUser = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível obter o User");
                Console.WriteLine(ex.Message);                
            }
        }

        private static void GetRole(string id)
        {
            try
            {
                var respositoryUser = new Repository<Role>(Database.Connection);
                var role = respositoryUser.Get(id);
                Console.WriteLine();
                Console.Write($"Confirme o Perfil {role.Name} [S] - Sim ou [N] - Não: ");
                confirmRole = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível obter o Perfil");
                Console.WriteLine(ex.Message);
            }
        }

        private static bool ConfirmacaoAcao(string acao)
        {
            if (acao == "S") return false;
            return true;
        }

        private static void Create(object roleUser)
        {
            try
            {
                var query = @"INSERT INTO [UserRole] ([UserId],[RoleId])
                            VALUES(@UserId,@RoleId)";
                Database.Connection.Execute(query, roleUser);
                Console.WriteLine();
                Console.WriteLine($"Perfil associado ao User com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível associar o Perfil ao User");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
