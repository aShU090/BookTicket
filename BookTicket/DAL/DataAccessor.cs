using System;
using System.Data.SqlClient;

namespace Apttus.MovieTicket.DAL
{
    public class DataAccessor : IDataAccessor
    {
        public SqlDataReader GetMembersDetails()
        {
            try
            {
                string cs =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Data\MovieTicket\TicketDetail\Database.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string query = "select * from Person";
                SqlCommand cmd1 = new SqlCommand(query, con);
                SqlDataReader r = cmd1.ExecuteReader();
                return r;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}