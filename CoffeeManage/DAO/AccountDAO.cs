using CoffeeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManage.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        internal static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            string query = "USP_Login @username , @password";
            //string query = "Select * from dbo.Account where UserName = N'"+username+"' And PassWord = N'"+password+"'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query,new object[] {username, hasPass });
            return result.Rows.Count>0;
        }

        public bool UpdateAccount(string username , string displayname, string pass, string newpass)
        {
            int results = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @usename , @displayname , @password , @newpassword",new object[] { username,displayname,pass,newpass});
            return results > 0;
        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("select username, displayname, type from Account");
        }

        public Account GetAccountByUsername(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where username ='" + username+ "'");
            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public bool InsertAccount(string name, string displayname, int type)
        {
            string query = string.Format("INSERT dbo.Account ( Username, Displayname, type, password ) VALUES  ( N'{0}', N'{1}', {2},{3} )", name, displayname, type, "3244185981728979115075721453575112");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool EditAccount(string name, string displayname, int type)
        {
            string query = string.Format("UPDATE dbo.Account SET Displayname = N'{1}' , type = {2} WHERE Username = N'{0}'", name, displayname, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete dbo.Account where username = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool ResetPassword(string name)
        {
            string query = string.Format("update dbo.Account set password = N'3244185981728979115075721453575112' where username = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
