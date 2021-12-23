using Aplicacao.Dapper.Models;
using Aplicacao.Dapper.Repositories;
using System;

namespace Aplicacao.Dapper.Screens.PostScreens
{
    public static class DeletePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um post");
            Console.WriteLine("-----------------");
            Console.Write("Qual o Id do post que deseja excluir: ");
            var id = Console.ReadLine();            

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new PostRepository(Database.Connection);
                repository.Delete(id);
                Console.WriteLine();
                Console.WriteLine("Post excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o Post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
