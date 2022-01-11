using System;

namespace Aplicacao.Dapper.Screens.RelatorioScreen
{
    public static class RelatorioScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Relatórios");
            Console.WriteLine("-----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar usuários");
            Console.WriteLine("2 - Listar categorias com quantidade de posts");
            Console.WriteLine("3 - Listar tags com quantidade de posts");
            Console.WriteLine("4 - Listar posts de uma categoria");
            Console.WriteLine("5 - Listar todos os posts por sua categoria");
            Console.WriteLine("6 - Listar os posts com as tags");
            Console.WriteLine("7 - Voltar ao menu principal");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListaUsuariosPerfis.Load();
                    break;
                case 2:
                    ListaCategoriasPosts.Load();
                    break;
                case 3:
                    ListaTagsPosts.Load();
                    break;
                case 4:
                    ListPostCategoria.Load();
                    break;
                case 5:
                    ListaPostsCategorias.Load();
                    break;
                case 6:
                    ListPostsTagsScreen.Load();
                    break;
                case 7:
                    Program.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}
