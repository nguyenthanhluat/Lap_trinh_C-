using CoffeeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManage.DAO
{
    class MenuDAO
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
            string query = "SELECT f.Name,bi.count,f.price, f.price*bi.count AS totalPrice FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Food AS f WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.status = 0 AND b.idTable = " + id;
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
