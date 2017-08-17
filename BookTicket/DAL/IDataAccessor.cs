using System.Data.SqlClient;

namespace Apttus.MovieTicket.DAL
{
    internal interface IDataAccessor
    {
        SqlDataReader GetMembersDetails();
    }
}