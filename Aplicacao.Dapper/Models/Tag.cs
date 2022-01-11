using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Aplicacao.Dapper.Models
{
    [Table("[Tag]")]
    public class Tag
    {
        public Tag()
        {
            Posts = new List<Post>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        [Write(false)]
        public List<Post> Posts { get; set; }
    }
}
