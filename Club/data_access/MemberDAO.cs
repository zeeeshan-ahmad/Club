using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Club.model;
using MySql.Data.MySqlClient;

namespace Club.data_access
{
    class MemberDAO
    {
        public MemberDAO()
        {

        }

        public bool Save(Member M) 
        {
            bool result = false;

            MySqlConnection conn = new MySqlConnection("server= localhost; uid=root; database= swimming_club");

            try
            {
                string cmdText = $"INSERT INTO members(id, club_id, phone, address, email, gender)" +
                 $" VALUES({M.Id},{M.Club_Id}, '{M.Phone}','{M.Address}', '{M.Email}','{M.Gender}' )";
                Console.WriteLine(cmdText);

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

        public Member SearchById(int id)
        {
            Member M = new Member();
            try
            {
                MySqlConnection conn = new MySqlConnection("server= localhost; uid=root; database= swimming_club");

                string cmdText = $"SELECT phone, address, email, gender, club_id  FROM members WHERE id = {id}";

                MySqlCommand cmd = new MySqlCommand(cmdText, conn);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine(cmdText, reader);

                if (!reader.HasRows)
                {

                    M = null;
                }

                while (reader.Read())
                {
                    M = new Member();


                    M.Club_Id = reader.GetInt32("club_id");
                    M.Address =reader.GetString("address");
                    M.Phone = reader.GetString("phone");
                    M.Email =reader.GetString("email");
                    M.Gender = reader.GetChar("gender");
                }


                conn.Close();

                return M;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public bool Update(Member M)
        {
            bool result = false;

            MySqlConnection conn = new MySqlConnection("server= localhost; uid=root; database= swimming_club");

            try
            {
                string cmdText = $"UPDATE members SET club_id={M.Club_Id}, phone='{M.Phone}',address='{M.Address}',email= '{M.Email}',gender ='{M.Gender}' WHERE id = {M.Id}";
                Console.WriteLine(cmdText);

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
                string cmdText = $"DELETE FROM members WHERE id = {id}";
                Console.WriteLine(cmdText);

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
