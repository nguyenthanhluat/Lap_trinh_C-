using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DTO
{
    public class Account
    {
        public Account(string username, string displayname, int type, string password = null)
        {
            this.Username = username;
            this.Displayname = displayname;
            this.Type = type;
            this.Password = password;
        }
        public Account(DataRow row)
        {
            this.Username = row["UserName"].ToString();
            this.Displayname = row["DisplayName"].ToString();
            this.Type = (int)row["TypeAccount"];
            this.Password = row["Password"].ToString();
        }
        private string username;
        private string displayname;
        private string password;
        private int type;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Displayname
        {
            get
            {
                return displayname;
            }

            set
            {
                displayname = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
    }
}
