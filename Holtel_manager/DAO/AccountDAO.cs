using Holtel_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DAO
{
    public class AccountDAO
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
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, hasPass });
            return result.Rows.Count > 0;
        }

        public Account GetAccountByUsername(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where username = N'" + username + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public List<Account> GetListAccount()
        {
            List<Account> AccountList = new List<Account>();
            string query = "select * from Account";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Account account = new Account(item);
                AccountList.Add(account);
            }
            return AccountList;
        }

        public bool InsertAccount(string DisplayName, string UserName, int TypeAccount)
        {
            string query = string.Format("INSERT INTO dbo.Account( DisplayName ,UserName ,TypeAccount, password)VALUES  ( N'{0}' ,N'{1}' ,{2},{3})", DisplayName, UserName, TypeAccount, "3244185981728979115075721453575112");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool EditAccount(string Username, string Displayname, int TypeAccount)
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{1}' , TypeAccount = {2} WHERE Username = N'{0}'", Username, Displayname, TypeAccount);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAccount(string Username)
        {
            string query = string.Format("DELETE dbo.Account WHERE Username = N'{0}'",Username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool ResetPassword(string name)
        {
            string query = string.Format("update dbo.Account set password = N'3244185981728979115075721453575112' where username = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateAccount(string username, string displayname, string pass, string newpass)
        {
            int results = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @usename , @displayname , @password , @newpassword", new object[] { username, displayname, pass, newpass });
            return results > 0;
        }
    }
}
