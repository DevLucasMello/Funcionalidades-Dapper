using System.Data.SqlClient;

namespace Aplicacao.Dapper
{
    public static class Database
    {
        private const string CONNECTION_STRING = "Server=localhost;Database=Blog;User ID=sa; Password=Lm@18792;Trusted_Connection=True;MultipleActiveResultSets=true";

        public static SqlConnection Connection = new SqlConnection(CONNECTION_STRING);
    }
}
