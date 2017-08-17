using Apttus.Assignment.MovieTicket;
using Apttus.Assignment.MovieTicket.Enum;
using Apttus.MovieTicket.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Apttus.MovieTicket.TicketDetail
{
    public class TicketInformation
    {
        private static void Main(string[] args)
        {
            Ticket ticket = new Ticket();
            List<Persons> value = new List<Persons>();
            List<Persons> personList = new List<Persons>();
            DataAccessor data = new DataAccessor();
            string p_name = "";
            int p_age = 0;
            Gender p_gender;
            int ticketprice;
            string y = "y";

            // list of member in family
            Dictionary<string, Persons> person = new Dictionary<string, Persons>();
            Console.WriteLine("Member in the family ");
            Console.WriteLine("");
            Console.WriteLine("{0}\t {1}\t {2}", "Name", "Age", "Gender");
            Console.WriteLine("------------------------------------------------------");
            SqlDataReader r = data.GetMembersDetails();
            while (r.Read())
            {
                p_name = r.GetString(0);
                p_age = r.GetInt32(1);
                var test = r.GetInt32(2);
                p_gender = (Gender)r.GetInt32(2);
                personList.Add(new Persons { Name = p_name, Age = p_age, gender = p_gender });
                Console.WriteLine("{0}\t {1}\t {2}", p_name, p_age, p_gender);
            }

            for (int j = 0; j < personList.Count; j++)
            {
                person.Add(personList[j].Name, personList[j]);
            }
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("How many ticket you want:");
            var member = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < member; i++)
            {
                Console.WriteLine("Enter the member name");
                var fetch = Console.ReadLine();
                value.Add(person[fetch]);
            }

            // check for discount
            Console.WriteLine("do you want discount y or n");
            if (Console.ReadLine() == y)
            {
                ticketprice = ticket.GetTotalCost(value);
            }
            else
            {
                ticketprice = ticket.GetTotalCost(value);
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Total cost of ticket is: " + ticketprice);
            Console.ReadLine();
        }
    }
}