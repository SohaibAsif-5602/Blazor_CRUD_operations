using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClassLibrarymodel;

namespace ClassLibrarydal
{
    public class daluser
    {
        public static void save_user(modeluser u1)
        { 
            SqlConnection conn = dbhelper.Getconnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("save_data", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Name",u1.Name));
            cmd.Parameters.Add(new SqlParameter("@Email",u1.Email));
            cmd.Parameters.Add(new SqlParameter("@Phone",u1.Phone));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void del_user(int id)
        {
            SqlConnection conn = dbhelper.Getconnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("del_data", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@User_id",id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void update_user(modeluser m2)
        {
            SqlConnection conn = dbhelper.Getconnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update_data", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@User_id", m2.User_id));
            cmd.Parameters.Add(new SqlParameter("@Name", m2.Name));
            cmd.Parameters.Add(new SqlParameter("@Email", m2.Email));
            
            cmd.Parameters.Add(new SqlParameter("@Phone", int.Parse(m2.Phone.ToString())));
                cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static List<modeluser> get_user()
        {
            SqlConnection sqlConnection = dbhelper.Getconnection();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("get_data", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<modeluser> modelusers = new List<modeluser>();
            while (reader.Read())
            {
                modeluser user = new modeluser();
                user.User_id = Convert.ToInt32(reader["User_id"]);
                user.Name = reader["Name"].ToString();
                user.Email = reader["Email"].ToString();
                user.Phone = Convert.ToInt32(reader["Phone"]);
                modelusers.Add(user);

            }
            sqlConnection.Close();
            return modelusers;
        }
    }
}
