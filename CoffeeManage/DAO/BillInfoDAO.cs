using CoffeeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManage.DAO
{
    class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillInfoDAO();
                return BillInfoDAO.instance;
            }

            private set
            {
                BillInfoDAO.instance = value;
            }
        }

        private BillInfoDAO() { }

        public void DeleteBillByFoodId(int id)
        {
            DataProvider.Instance.ExecuteQuery("Delete dbo.BillInfo where idFood = " + id);
        }

        public List<Billinfo> GetListBillInfo(int id)
        {
            List<Billinfo> BillInfoList = new List<Billinfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.BillInfo where idBill = "+ id);
            foreach (DataRow item in data.Rows)
            {
                Billinfo info = new Billinfo(item);
                BillInfoList.Add(info);
            }
            return BillInfoList;
        }
        public void insertBillInfo(int idBill, int idFood, int Count)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USB_InsertBillInfo @idBill , @idFood , @count", new object[] { idBill,idFood,Count});
        }
    }
}
