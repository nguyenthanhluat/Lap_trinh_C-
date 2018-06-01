using Holtel_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        internal static BillDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private BillDAO() { }

        public DataTable GetBillListByDate(DateTime checkin, DateTime checkout)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDate @checkin , @checkout", new object[] { checkin, checkout });
        }

        public List<Bill> GetListBill()
        {
            List<Bill> BillList = new List<Bill>();
            string query = "select * from Bill";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Bill bill = new Bill(item);
                BillList.Add(bill);
            }
            return BillList;
        }

        public int GetUncheckBillIdbyTableId(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.Bill where idRoom = " + id + " and statusBill = 0");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }
            return -1;
        } 

        public void insertBill(int idRoom , int idcus)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idRoom , @idcus", new object[] { idRoom , idcus});
        }

        public int GetMaxIdBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }

        public void checkout(int id, float totalPrice)
        {
            string query = "update dbo.Bill set statusBill = 1,DateCheckout = getDate(), Totalprice =" + totalPrice + " where id =" + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public int GetNumBillListByDate(DateTime checkin, DateTime checkout)
        {
            return (int)DataProvider.Instance.ExecuteScalar("exec USP_GetNumListBillByDate @checkin , @checkout", new object[] { checkin, checkout });
        }

        public DataTable GetBillListByDateAndPage(DateTime checkin, DateTime checkout, int page)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDateAndPage @checkin , @checkout , @page", new object[] { checkin, checkout, page });
        }
    }
}
