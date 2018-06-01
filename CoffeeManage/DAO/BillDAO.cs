using CoffeeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManage.DAO
{
    class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillDAO();
                return BillDAO.instance;
            }

            private set
            {
                BillDAO.instance = value;
            }
        }
        
        private BillDAO() { }

        //Thanh cong: Bill Id
        //That bai: -1
        public int GetUncheckBillIdbyTableId(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.Bill where idTable = "+id+" and status = 0");
            if(data.Rows.Count>0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }
            return -1;
        }

        public void checkout(int id, int discount, float totalPrice)
        {
            string query = "update dbo.Bill set status = 1,dateCheckOut = getDate(), "+"discount ="+discount+", totalPrice ="+totalPrice+" where id ="+id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void insertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[] { id });
        }

        public DataTable GetBillListByDate(DateTime checkin , DateTime checkout)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_DetListBillByDate @checkin , @checkout", new object[] { checkin, checkout });
        }

        public DataTable GetBillListByDateAndPage(DateTime checkin, DateTime checkout , int page)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDateAndPage @checkin , @checkout , @page", new object[] { checkin, checkout, page });

        }

        public int GetNumBillListByDate(DateTime checkin, DateTime checkout)
        {
            return (int)DataProvider.Instance.ExecuteScalar("exec USP_GetNumListBillByDate @checkin , @checkout", new object[] { checkin, checkout });

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
    }
}
