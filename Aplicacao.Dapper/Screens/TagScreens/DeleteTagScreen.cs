using Aplicacao.Dapper.Models;
using Aplicacao.Dapper.Repositories;
using System;

namespace Aplicacao.Dapper.Screens.TagScreens
{
    public static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma tag");
            Console.WriteLine("-----------------");
            Console.Write("Qual o Id da tag que deseja excluir: ");
            var id = Console.ReadLine();           
            Delete(int.Parse(id));
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine();
                Console.WriteLine("Tag excluída com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir a Tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
