using Aplicacao.Dapper.Models;
using Aplicacao.Dapper.Screens.TagScreens;
using Dapper.Contrib.Extensions;
using System;
using System.Data.SqlClient;

namespace Aplicacao.Dapper
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=localhost;Database=Blog;User ID=sa; Password=Lm@18792;Trusted_Connection=True;MultipleActiveResultSets=true";
        static void Main(string[] args)
        {
            ReadUsers();
            
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

        private static void ReadUsers() 
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();

                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
            }
        }
    }    
}
