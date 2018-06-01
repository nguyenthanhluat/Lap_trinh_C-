using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DTO
{
    public class Customer
    {
        public Customer(int id, string customerName, string phone, string identification, string typeCustomer)
        {
            this.Id = id;
            this.CustomerName = customerName;
            this.Phone = phone;
            this.Identification = identification;
            this.TypeCustomer = typeCustomer;
        }

        public Customer(DataRow row)
        {
            this.Id = (int)row["id"];
            this.CustomerName = row["customerName"].ToString();
            this.Phone = row["phone"].ToString();
            this.Identification = row["identification"].ToString();
            this.TypeCustomer = row["typeCustomer"].ToString();
        }

        private int id;
        private string customerName;
        private string phone;
        private string identification;
        private string typeCustomer;

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

        public string CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string Identification
        {
            get
            {
                return identification;
            }

            set
            {
                identification = value;
            }
        }

        public string TypeCustomer
        {
            get
            {
                return typeCustomer;
            }

            set
            {
                typeCustomer = value;
            }
        }
    }
}
