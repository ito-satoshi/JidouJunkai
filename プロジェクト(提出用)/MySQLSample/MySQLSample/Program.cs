using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySQLSample
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var con = new MySqlConnection("server=localhost;user=fsst;password=2455;database=jjdb;"))
            {
                con.Open();
                var command = new MySqlCommand("select acquisition_interval, create_date from acquisition_interval;", con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("| {0} | {1} |", reader["acquisition_interval"], reader["create_date"]);
                }
            }
            Console.WriteLine("-----------------------");
            Console.ReadLine();
        }
    }
}