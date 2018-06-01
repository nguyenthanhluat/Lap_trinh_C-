using Holtel_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DAO
{
    public class TypeAccountDAO
    {
        private static TypeAccountDAO instance;

        internal static TypeAccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new TypeAccountDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private TypeAccountDAO() { }

        public List<TypeAccount> GetListTypeAccount()
        {
            List<TypeAccount> TypeAccountList = new List<TypeAccount>();
            string query = "select * from TypeAccount";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TypeAccount typeaccount = new TypeAccount(item);
                TypeAccountList.Add(typeaccount);
            }
            return TypeAccountList;
        }

        public TypeAccount GetTypeAccountById(int id)
        {
            TypeAccount typeaccount = null;
            string query = "select * from TypeAccount where id= " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                typeaccount = new TypeAccount(item);
                return typeaccount;
            }
            return typeaccount;
        }
    }
}
