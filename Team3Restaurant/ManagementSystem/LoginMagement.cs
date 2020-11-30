using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3Restaurant.ManagementSystem.Login
{
    public class LoginMagement
    {
        private string _userName;
        private string _password;
        //to indicate whether user login the system
        public static string _stuffID;
        public LoginMagement(string user, string password)
        {
            this.UserName = user;
            this.Password = password;
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string StuffID
        {
            get { return _stuffID; }
            set { _stuffID = value; }
        }
        public bool UserVerification()
        {
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();
            bool result = false;
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                command.Connection = connection;

                string commandString = DatabaseUtil.GetUserVerificationQuery(UserName, Password);

                command.CommandText = commandString;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StuffID = reader["stuff_id"].ToString().Trim();
                    }
                    result = true;
                }

                reader.Close();
            }
            return result;
        }
        public static void Logout()
        {
            _stuffID = null;
        }
        public static bool IsLogin()
        {
            return !(_stuffID == null);
        }
    }
}
