using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace db実験
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var con = new MySqlConnection("server=hoge;user=hoge;password=xxxx;database=hoge;"))
            {
                con.Open();
                var command = new MySqlCommand("select name, address from person;", con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("| {0} | {1} |", reader["name"], reader["address"]);
                }
            }
            Console.WriteLine("-----------------------");
            Console.ReadLine();
        }
    }
}