using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DTO
{
    class Service
    {
        public Service(int id, string servicename, int idservicecategory, float priceservice)
        {
            this.Id = id;
            this.ServiceName = serviceName;
            this.IdServiceCategory = idservicecategory;
            this.PriceService = priceservice;
        }

        public Service(DataRow row)
        {
            this.Id = (int)row["id"];
            this.ServiceName = row["serviceName"].ToString();
            this.IdServiceCategory = (int)row["idservicecategory"];
            this.PriceService = (float)Convert.ToDouble(row["priceservice"]);
        }

        private int id;
        private string serviceName;
        private int idServiceCategory;
        private float priceService;

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

        public string ServiceName
        {
            get
            {
                return serviceName;
            }

            set
            {
                serviceName = value;
            }
        }

        public int IdServiceCategory
        {
            get
            {
                return idServiceCategory;
            }

            set
            {
                idServiceCategory = value;
            }
        }

        public float PriceService
        {
            get
            {
                return priceService;
            }

            set
            {
                priceService = value;
            }
        }
    }
}
