using Holtel_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        internal static BillInfoDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillInfoDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> BillInfoList = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.BillInfo where idBill = " + id);
            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                BillInfoList.Add(info);
            }
            return BillInfoList;
        }

        public void insertBillInfo(int idBill, int idService, int Count)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USB_InsertBillInfo @idBill , @idFood , @count", new object[] { idBill, idService, Count });
        }
    }
}
