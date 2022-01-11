﻿using Aplicacao.Dapper.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Aplicacao.Dapper.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        private readonly SqlConnection _connection;

        public TagRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public List<Tag> ReadWithPost()
        {
            var query = @"
                SELECT
                    [Tag].*,
                    [Post].*
                FROM
                    [Tag]
	                LEFT JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id]
                    LEFT JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]";

            var tags = new List<Tag>();
            var items = _connection.Query<Tag, Post, Tag>(
                query,
                (tag, post) =>
                {
                    var tg = tags.FirstOrDefault(x => x.Id == tag.Id);
                    if (tg == null)
                    {
                        tg = tag;
                        tg.Posts.Add(post);
                        tags.Add(tg);
                    }
                    else
                        tg.Posts.Add(post);

                    return tag;
                }, splitOn: "Id");
            return tags;
        }
    }
}
