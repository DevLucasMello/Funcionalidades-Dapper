using Aplicacao.Dapper.Models;
using Aplicacao.Dapper.Repositories;
using System;

namespace Aplicacao.Dapper.Screens.PostScreens
{
    public static class CreatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo post");
            Console.WriteLine("-----------------");
            Console.Write("Digite o Id da Category: ");
            var categoryId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o Id do User: ");
            var authorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o Title: ");
            var title = Console.ReadLine();
            Console.Write("Digite o Summary: ");
            var summary = Console.ReadLine();
            Console.Write("Digite o Body: ");
            var body = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();


            Create(new Post { CategoryId = categoryId, AuthorId = authorId, Title = title, Summary = summary, Body = body, Slug = slug, CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now});
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        private static void Create(Post post)
        {
            try
            {
                var repository = new PostRepository(Database.Connection);
                repository.Create(post);
                Console.WriteLine();
                Console.WriteLine("Post cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar o Post");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
