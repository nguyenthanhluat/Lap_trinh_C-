using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DTO
{
    public class TypeAccount
    {
        public TypeAccount(int id, string nameType)
        {
            this.Id = id;
            this.NameType = nameType;
        }

        public TypeAccount(DataRow row)
        {
            this.Id = (int)row["id"];
            this.NameType = row["nameType"].ToString();
        }

        int id;
        string nameType;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string NameType
        {
            get
            {
                return nameType;
            }

            set
            {
                nameType = value;
            }
        }
    }
}
