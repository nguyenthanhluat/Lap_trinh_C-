using Holtel_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DAO
{
    public class TypeServiceDAO
    {
        private static TypeServiceDAO instance;

        public static TypeServiceDAO Instance
        {
            get
            {
                if (instance == null) instance = new TypeServiceDAO();
                return TypeServiceDAO.instance;
            }

            private set
            {
                TypeServiceDAO.instance = value;
            }
        }

        private TypeServiceDAO() { }

        public List<TypeService> GetListTypeService()
        {
            List<TypeService> TypeServiceList = new List<TypeService>();
            string query = "select * from ServiceCategory";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TypeService typesrvice = new TypeService(item);
                TypeServiceList.Add(typesrvice);
            }
            return TypeServiceList;
        }

        public bool InsertTypeService(string ServiceCategoryName)
        {
            string query = string.Format("INSERT INTO dbo.ServiceCategory( ServiceCategoryName )VALUES  ( N'{0}')", ServiceCategoryName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool EditTypeService(int idTypeservice, string TypeServiceName)
        {
            string query = string.Format("UPDATE dbo.ServiceCategory SET ServiceCategoryName = N'{0}'WHERE Id = {1}", TypeServiceName, idTypeservice);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTypeService(int idTypeservice)
        {
            ServiceDAO.Instance.DeleteServiceByIdTypeService(idTypeservice);
            string query = string.Format("DELETE dbo.ServiceCategory WHERE Id = {0}", idTypeservice);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public TypeService GetTypeServiceById(int id)
        {
            TypeService typeservice = null;
            string query = "select * from ServiceCategory where id= " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                typeservice = new TypeService(item);
                return typeservice;
            }
            return typeservice;
        }
    }
}
