using CoffeeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManage.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get
            {
                if (instance == null) instance = new FoodDAO();
                return FoodDAO.instance;
            }

            private set
            {
                FoodDAO.instance = value;
            }
        }

        private FoodDAO() { }

        public List<Food> GetFoodByCategoryId(int id)
        {
            List<Food> FoodList = new List<Food>();
            string query = "select * from Food where idCategory = "+id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                FoodList.Add(food);
            }
            return FoodList;
        }

        public List<Food> GetListFood()
        {
            List<Food> FoodList = new List<Food>();
            string query = "select * from Food";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                FoodList.Add(food);
            }
            return FoodList;
        }

        public List<Food> SearchFoodByName(string name)
        {
            List<Food> FoodList = new List<Food>();
            string query =string.Format("select * from Food where name like N'%{0}%'",name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                FoodList.Add(food);
            }
            return FoodList;
        }

        public bool InsertFood(string name, int id, float price)
        {
            string query = string.Format("INSERT dbo.Food ( Name, idCategory, price ) VALUES  ( N'{0}', {1}, {2} )",name,id,price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0; 
        }

        public bool EditFood(int idFood, string name, int id, float price)
        {
            string query = string.Format("UPDATE dbo.Food SET Name = N'{0}', idCategory = {1} , price = {2} WHERE id = {3}", name, id, price,idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteFood(int idFood)
        {
            BillInfoDAO.Instance.DeleteBillByFoodId(idFood);
            string query = string.Format("Delete dbo.Food where id = {0}",idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}

