using Holtel_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;

        internal static CustomerDAO Instance
        {
            get
            {
                if (instance == null) instance = new CustomerDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private CustomerDAO() { }

        public List<Customer> GetListCustomer()
        {
            List<Customer> CustomerList = new List<Customer>();
            string query = "select * from Customer";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Customer customer = new Customer(item);
                CustomerList.Add(customer);
            }
            return CustomerList;
        }

        public bool InsertCustomer(string nameCustomer, string phone, string identyfication, string typeCustomer)
        {
            string query = string.Format("INSERT dbo.Customer ( CustomerName, Phone, Identification,TypeCustomer ) VALUES  ( N'{0}',N'{1}',N'{2}',N'{3}' )", nameCustomer, phone, identyfication,typeCustomer);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool EditCustomer(int idCustomer, string nameCustomer, string phone, string identyfication, string typeCustomer)
        {
            string query = string.Format("UPDATE dbo.Customer SET CustomerName = N'{0}', Phone = N'{1}' , Identification = N'{2}', TypeCustomer = N'{3}' WHERE id = {4}", nameCustomer, phone, identyfication, typeCustomer,idCustomer);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteCustomer(int idCustomer)
        {
            string query = string.Format("Delete dbo.Customer where id = {0}", idCustomer);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<Customer> SearchCustomerByName(string name)
        {
            List<Customer> CustomerList = new List<Customer>();
            string query = string.Format("select * from Customer where CustomerName like N'%{0}%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Customer customer = new Customer(item);
                CustomerList.Add(customer);
            }
            return CustomerList;
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = null;
            string query = "select * from Customer where id= " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                customer = new Customer(item);
                return customer;
            }
            return customer;
        }
    }
}
