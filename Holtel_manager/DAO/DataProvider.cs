using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DAO
{
    class DataProvider
    {
        //Single tonge
        private static DataProvider instance;

        private string connectionSTR = @"Data Source=DESKTOP-J8QS6E0\SQLEXPRESS;Initial Catalog=Holtel_manager;Integrated Security=True"; //đường dẫn kết nối database

        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        //Data provider
        private DataProvider() { }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {

            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))//Ket noi client voi server
            {
                connection.Open(); //mo connection
                SqlCommand command = new SqlCommand(query, connection); //Cau truy van can thuc thi

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command); //Trung gian thuc hien cau truy van lay giu lieu
                adapter.Fill(data); //do data vao adapter
                connection.Close();
            }//using tu duoc giai phong
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))//Ket noi client voi server
            {
                connection.Open(); //mo connection
                SqlCommand command = new SqlCommand(query, connection); //Cau truy van can thuc thi

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }//using tu duoc giai phong
            return data;
        }//tra lai so dong thuc hien thanh cong

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))//Ket noi client voi server
            {
                connection.Open(); //mo connection
                SqlCommand command = new SqlCommand(query, connection); //Cau truy van can thuc thi

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }//using tu duoc giai phong
            return data;
        }//select count
    }
}
