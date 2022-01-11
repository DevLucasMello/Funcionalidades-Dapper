using Aplicacao.Dapper.Screens.CategoryScreens;
using Aplicacao.Dapper.Screens.RelatorioScreen;
using Aplicacao.Dapper.Screens.PostScreens;
using Aplicacao.Dapper.Screens.PostTagScreens;
using Aplicacao.Dapper.Screens.RoleScreens;
using Aplicacao.Dapper.Screens.TagScreens;
using Aplicacao.Dapper.Screens.UserRoleScreens;
using Aplicacao.Dapper.Screens.UserScreens;
using System;

namespace Aplicacao.Dapper
{
    public class Program
    {        
        static void Main(string[] args)
        {
            //var connection = new SqlConnection(CONNECTION_STRING);
            //connection.Open();
            //ReadUsers(connection);
            //CreateUser(connection);
            //ReadRoles(connection);
            //ReadTag(connection);
            //ReadUser();
            //CreateUser();
            //UpdateUser();
            //DeleteUser();
            //ReadUsers(connection);
            //connection.Close();
            
            Database.Connection.Open();

            Load();

            Console.ReadKey();
            Database.Connection.Close();
        }

        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("-----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de usuário");
            Console.WriteLine("2 - Gestão de perfil");
            Console.WriteLine("3 - Gestão de categoria");
            Console.WriteLine("4 - Gestão de tag");
            Console.WriteLine("5 - Gestão de post");
            Console.WriteLine("6 - Vincular perfil/usuário");
            Console.WriteLine("7 - Vincular post/tag");
            Console.WriteLine("8 - Relatórios");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:
                    MenuRoleScreen.Load();
                    break;
                case 3:
                    MenuCategoryScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 5:
                    MenuPostScreen.Load();
                    break;
                case 6:
                    MenuUserRoleScreen.Load();
                    break;
                case 7:
                    MenuPostTagScreen.Load();
                    break;
                case 8:
                    RelatorioScreen.Load();
                    break;
                default: Load(); break;
            }
        }

        //private static void ReadUsers(SqlConnection connection) 
        //{
        //    var repository = new UserRepository(connection);
        //    var items = repository.ReadWithRole();

        //    foreach (var item in items) 
        //    {
        //        Console.Write(item.Name);
        //        foreach (var role in item.Roles)
        //        {
        //            Console.WriteLine($" - {role?.Name}");
        //        }
        //    }
        //}

        //private static void CreateUser(SqlConnection connection)
        //{
        //    var user = new User()
        //    {
        //        Bio = "Lucas Santos",
        //        Email = "lucasdemello.18@gmail.com",
        //        Image = "https://...",
        //        Name = "Lucas Santos",
        //        PasswordHash = "HASH",
        //        Slug = "lucas-web"
        //    };

        //    var repository = new Repository<User>(connection);
        //    repository.Create(user);            
        //}

        //private static void ReadRoles(SqlConnection connection)
        //{
        //    var repository = new Repository<Role>(connection);
        //    var items = repository.Get();

        //    foreach (var item in items)
        //        Console.WriteLine(item.Name);
        //}

        //private static void ReadTag(SqlConnection connection)
        //{
        //    var repository = new Repository<Tag>(connection);
        //    var items = repository.Get();

        //    foreach (var item in items)
        //        Console.WriteLine(item.Name);
        //}

        //private static void ReadUser()
        //{
        //    using (var connection = new SqlConnection(CONNECTION_STRING))
        //    {
        //        var user = connection.Get<User>(1);

        //        Console.WriteLine(user.Name);                
        //    }
        //}

        //private static void CreateUser()
        //{
        //    var user = new User()
        //    {
        //        Bio = "Lucas Santos",
        //        Email = "lucasdemello.18@gmail.com",
        //        Image = "https://...",
        //        Name = "Lucas Santos",
        //        PasswordHash = "HASH",
        //        Slug = "lucas-web"
        //    };

        //    using (var connection = new SqlConnection(CONNECTION_STRING))
        //    {
        //        var rows = connection.Insert<User>(user);
        //        Console.WriteLine(rows + " linhas afetadas");

        //    }
        //}

        //private static void UpdateUser()
        //{
        //    var user = new User()
        //    {
        //        Id = 2,
        //        Bio = "Lucas - Santos",
        //        Email = "lucasdemello.18@gmail.com",
        //        Image = "https://...",
        //        Name = "Lucas Santos",
        //        PasswordHash = "HASH",
        //        Slug = "lucas-web"
        //    };

        //    using (var connection = new SqlConnection(CONNECTION_STRING))
        //    {
        //        var rows = connection.Update<User>(user);
        //        Console.WriteLine(rows + " linhas afetadas");

        //    }
        //}

        //private static void DeleteUser()
        //{            
        //    using (var connection = new SqlConnection(CONNECTION_STRING))
        //    {
        //        var user = connection.Get<User>(2);
        //        var rows = connection.Delete<User>(user);
        //        Console.WriteLine(rows + " linhas afetadas");

        //    }
        //}
    }    
}
