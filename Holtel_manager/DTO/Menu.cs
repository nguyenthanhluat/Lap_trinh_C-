using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DTO
{
    public class Menu
    {
        public Menu(string serviceName, int count, float priceService, float totalPrice = 0)
        {
            this.ServiceName = serviceName;
            this.Count = count;
            this.PriceService = priceService;
            this.Totalprice = totalprice;
        }

        public Menu(DataRow row)
        {
            this.ServiceName = row["serviceName"].ToString();
            this.Count = (int)row["count"];
            this.PriceService = (float)Convert.ToDouble(row["priceService"].ToString());
            this.Totalprice = (float)Convert.ToDouble(row["totalprice"].ToString());
        }

        private string serviceName;
        private int count;
        private float priceService;
        private float totalprice;

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        public float Totalprice
        {
            get
            {
                return totalprice;
            }

            set
            {
                totalprice = value;
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
