using Aplicacao.Dapper.Models;
using Aplicacao.Dapper.Repositories;
using Dapper;
using System;

namespace Aplicacao.Dapper.Screens.PostTagScreens
{
    public static class CreatePostTagScreen
    {
        private static string confirmPost;
        private static string confirmTag;
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo post tag");
            Console.WriteLine("-----------------");
            string idPost;
            string idTag;

            do
            {
                Console.Write("Digite o Id do Post: ");
                idPost = Console.ReadLine();
                GetUser(idPost);
            } while (ConfirmacaoAcao(confirmPost.ToUpper()));


            do
            {
                Console.Write("Digite o Id da Tag: ");
                idTag = Console.ReadLine();
                GetRole(idTag);
            } while (ConfirmacaoAcao(confirmTag.ToUpper()));

            var postTag = new { PostId = Convert.ToInt32(idPost), TagId = Convert.ToInt32(idTag) };

            Create(postTag);

            Console.ReadKey();            
        }

        private static void GetUser(string id)
        {
            try
            {                
                var respositoryPost = new Repository<Post>(Database.Connection);
                var post = respositoryPost.Get(id);
                Console.WriteLine();
                Console.Write($"Confirme o Post {post.Title} [S] - Sim ou [N] - Não: ");
                confirmPost = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível obter o Post");
                Console.WriteLine(ex.Message);                
            }
        }

        private static void GetRole(string id)
        {
            try
            {
                var respositoryTag = new Repository<Tag>(Database.Connection);
                var tag = respositoryTag.Get(id);
                Console.WriteLine();
                Console.Write($"Confirme a Tag {tag.Name} [S] - Sim ou [N] - Não: ");
                confirmTag = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível obter a Tag");
                Console.WriteLine(ex.Message);
            }
        }

        private static bool ConfirmacaoAcao(string acao)
        {
            if (acao == "S") return false;
            return true;
        }

        private static void Create(object postTag)
        {
            try
            {
                var query = @"INSERT INTO [PostTag] ([PostId],[TagId])
                            VALUES(@PostId,@TagId)";
                Database.Connection.Execute(query, postTag);
                Console.WriteLine();
                Console.WriteLine($"Post associado a Tag com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível associar o Post a Tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
