using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Club.model;
using MySql.Data.MySqlClient;

namespace Club.data_access
{
    class ClubDAO
    {
        public ClubDAO()
        {

        }

        public bool Save(ClubModel p)
        {
            bool result = false;

            MySqlConnection conn = new MySqlConnection("server= localhost; uid=root; database= swimming_club");

            try
            {
                string cmdText = $"INSERT INTO swimmingclub(id, name, phone )" +
                 $" VALUES({p.Id},'{p.Name}', '{p.Phone}' )";

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = cmdText;
                cmd.Connection = conn;

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    result = true;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = false;
            }

            return result;
        }

        public ClubModel SearchById(int id)
        {
            ClubModel p = new ClubModel();
            try
            {
                MySqlConnection conn = new MySqlConnection("server= localhost; uid=root; database= swimming_club");

                string cmdText = $"SELECT name, phone  FROM swimmingclub WHERE id = {id}";

                MySqlCommand cmd = new MySqlCommand(cmdText, conn);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {

                    p = null;
                }

                while (reader.Read())
                {
                    p = new ClubModel();


                    p.Name = reader.GetString("name");

                    p.Phone = reader.GetString("phone");
                }


                conn.Close();

                return p;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public bool Update(ClubModel p)
        {
            bool result = false;

            MySqlConnection conn = new MySqlConnection("server= localhost; uid=root; database= swimming_club");

            try
            {
                string cmdText = $"UPDATE swimmingclub SET name='{p.Name}',phone='{p.Phone}' WHERE id= {p.Id}";

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = cmdText;
                cmd.Connection = conn;

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    result = true;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = false;
            }

            return result;

        }

        public bool Delete(int id)
        {
            bool result = false;

            MySqlConnection conn = new MySqlConnection("server= localhost; uid=root; database= swimming_club");

            try
            {
                string cmdText = $"DELETE FROM Swimmingclub WHERE id= {id}";

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = cmdText;
                cmd.Connection = conn;

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    result = true;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = false;
            }

            return result;

        }

    }
}
