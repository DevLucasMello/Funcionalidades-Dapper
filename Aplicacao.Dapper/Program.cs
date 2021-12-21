using Aplicacao.Dapper.Models;
using Aplicacao.Dapper.Repositories;
using System;
using System.Data.SqlClient;

namespace Aplicacao.Dapper
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=localhost;Database=Blog;User ID=sa; Password=Lm@18792;Trusted_Connection=True;MultipleActiveResultSets=true";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            
            ReadUsers(connection);
            ReadRoles(connection);
            ReadTag(connection);
            //ReadUser();
            //CreateUser();
            //UpdateUser();
            //DeleteUser();

            connection.Close();

            //var connection = new SqlConnection(CONNECTION_STRING);
            //connection.Open();

            //Load();

            //Console.ReadKey();
            //connection.Close();
        }

        //private static void Load()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Meu Blog");
        //    Console.WriteLine("-----------------");
        //    Console.WriteLine("O que deseja fazer?");
        //    Console.WriteLine();
        //    Console.WriteLine("1 - Gestão de usuário");
        //    Console.WriteLine("2 - Gestão de perfil");
        //    Console.WriteLine("3 - Gestão de categoria");
        //    Console.WriteLine("4 - Gestão de tag");
        //    Console.WriteLine("5 - Vincular perfil/usuário");
        //    Console.WriteLine("6 - Vincular post/tag");
        //    Console.WriteLine("7 - Relatórios");
        //    Console.WriteLine();
        //    Console.WriteLine();
        //    var option = short.Parse(Console.ReadLine()!);

        //    switch (option)
        //    {
        //        case 4:
        //            MenuTagScreen.Load();
        //            break;
        //        default: Load(); break;
        //    }
        //}

        private static void ReadUsers(SqlConnection connection) 
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();
           
            foreach (var item in items)            
                Console.WriteLine(item.Name);           
        }

        private static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        private static void ReadTag(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

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
