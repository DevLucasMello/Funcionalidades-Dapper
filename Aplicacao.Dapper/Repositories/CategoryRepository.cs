using Aplicacao.Dapper.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Aplicacao.Dapper.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        private readonly SqlConnection _connection;

        public CategoryRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public List<Category> ReadWithPost()
        {
            var query = @"
                SELECT
                    [Category].*,
                    [Post].*
                FROM
                    [Category]    
                    LEFT JOIN [Post] ON [Post].[CategoryId] = [Category].[Id]";

            var categories = new List<Category>();
            var items = _connection.Query<Category, Post, Category>(
                query,
                (category, post) =>
                {
                    var ct = categories.FirstOrDefault(x => x.Id == category.Id);
                    if (ct == null)
                    {
                        ct = category;
                        ct.Posts.Add(post);
                        categories.Add(ct);
                    }
                    else
                        ct.Posts.Add(post);

                    return category;
                }, splitOn: "Id");
            return categories;
        }

        public List<Category> ReadPostsWithCategory(int categoryId)
        {
            var query = @"
                SELECT
                    [Category].*,
                    [Post].*
                FROM
                    [Category]    
                    LEFT JOIN [Post] ON [Post].[CategoryId] = [Category].[Id]
                WHERE [Category].[Id] = @Id";

            var categories = new List<Category>();
            var items = _connection.Query<Category, Post, Category>(
                query,
                (category, post) =>
                {
                    var ct = categories.FirstOrDefault(x => x.Id == category.Id);
                    if (ct == null)
                    {
                        ct = category;
                        ct.Posts.Add(post);
                        categories.Add(ct);
                    }
                    else
                        ct.Posts.Add(post);

                    return category;
                }, new { Id = categoryId }, splitOn: "Id");
            return categories;
        }
    }
}
