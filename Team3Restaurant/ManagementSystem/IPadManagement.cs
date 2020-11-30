using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3Restaurant.ManagementSystem
{
    public class IPadManagement
    {
        public List<IPadDetail> GetIPadDetail()
        {
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();

            List<IPadDetail> iPads = new List<IPadDetail>();
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                command.Connection = connection;
                string commandString = "select ipad_id, menu_id from ipad";

                command.CommandText = commandString;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IPadDetail row = new IPadDetail();
                        row.IPad = reader["ipad_id"].ToString().Trim();
                        row.Menu = reader["menu_id"].ToString().Trim();
                        iPads.Add(row);
                    }
                }

                reader.Close();
            }
            return iPads;
        }
        public List<MenuID> GetAllIMenus()
        {
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = DatabaseUtil.GetCommand();

            List<MenuID> menus = new List<MenuID>();
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                command.Connection = connection;
                string commandString = "select distinct menu_id from menu";

                command.CommandText = commandString;

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MenuID row = new MenuID();
                        row.Menu = reader["menu_id"].ToString().Trim();
                        menus.Add(row);
                    }
                }

                reader.Close();
            }
            return menus;
        }
        public int UpdateMenuToIPad(string ipadID, string menuID)
        {
            DbConnection connection = DatabaseUtil.GetConnection();
            DbCommand command = null;


            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command = DatabaseUtil.GetCommand();
                command.Connection = connection;


                string commandString = "update ipad set menu_id = '" + menuID + "' where ipad_id = '" + ipadID + "'";


                command.CommandText = commandString;



                return command.ExecuteNonQuery();

            }
        }


        public class IPadDetail
        {
            private string _ipadID;
            private string _menuID;

            public string IPad
            {
                set { _ipadID = value; }
                get { return _ipadID; }
            }
            public string Menu
            {
                set { _menuID = value; }
                get { return _menuID; }
            }
                
        }
        public class MenuID
        {
            private string _menuID;
            public string Menu
            {
                set { _menuID = value; }
                get { return _menuID; }
            }
        }
    }
}
