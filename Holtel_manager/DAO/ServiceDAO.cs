using Holtel_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DAO
{
    class ServiceDAO
    {
        private static ServiceDAO instance;

        public static ServiceDAO Instance
        {
            get
            {
                if (instance == null) instance = new ServiceDAO();
                return ServiceDAO.instance;
            }

            private set
            {
                ServiceDAO.instance = value;
            }
        }

        private ServiceDAO() { }

        public List<Service> GetListService()
        {
            List<Service> ServiceList = new List<Service>();
            string query = "select * from Service";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Service service = new Service(item);
                ServiceList.Add(service);
            }
            return ServiceList;
        }

        public List<Service> GetListServiceById(int id)
        {
            List<Service> ServiceList = new List<Service>();
            string query = "select * from Service where IdServiceCategory = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Service service = new Service(item);
                ServiceList.Add(service);
            }
            return ServiceList;
        }

        public bool InsertService(string ServiceName , int IdServiceCategory ,float PriceService)
        {
            string query = string.Format("INSERT INTO dbo.Service( ServiceName ,IdServiceCategory ,PriceService)VALUES  ( N'{0}' , {1} , {2} )", ServiceName, IdServiceCategory, PriceService);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool EditService(int idservice, string ServiceName, int IdServiceCategory, float PriceService)
        {
            string query = string.Format("UPDATE dbo.Service SET ServiceName = N'{0}',IdServiceCategory = {1},PriceService= {2} WHERE Id = {3}", ServiceName, IdServiceCategory, PriceService, idservice);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteService(int idservice)
        {
            string query = string.Format("DELETE dbo.Service WHERE Id = {0}", idservice);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public void DeleteServiceByIdTypeService(int id)
        {
            DataProvider.Instance.ExecuteQuery("Delete dbo.Service where IdServiceCategory = " + id);
        }
    }
}
