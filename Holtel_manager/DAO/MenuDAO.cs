using Holtel_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;
        //private object listMenu;

        public static MenuDAO Instance
        {
            get
            {
                if (instance == null) instance = new MenuDAO();
                return MenuDAO.instance;
            }

            private set
            {
                MenuDAO.instance = value;
            }
        }

        private MenuDAO() { }

        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> MenuList = new List<Menu>();
            string query = "SELECT s.ServiceName,bi.count,s.PriceService, s.PriceService*bi.count AS totalPrice FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Service AS s WHERE bi.idBill = b.id AND bi.IdService = s.id AND b.StatusBill = 0 AND b.IdRoom = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                MenuList.Add(menu);
            }
            return MenuList;
        }
    }
}
