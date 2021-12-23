﻿using Aplicacao.Dapper.Models;
using Aplicacao.Dapper.Repositories;
using System;

namespace Aplicacao.Dapper.Screens.TagScreens
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova tag");
            Console.WriteLine("-----------------");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();
            Create(new Tag { Name = name, Slug = slug});
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void Create(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Create(tag);
                Console.WriteLine();
                Console.WriteLine("Tag cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a Tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
