using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManage.DTO
{
    class Billinfo
    {
        public Billinfo(int id, int idbill, int idfood, int count )
        {
            this.Id = id;
            this.IdBill = idbill;
            this.IdFood = idfood;
            this.Count = count;
        }

        public Billinfo(DataRow row)
        {
            this.Id = (int)row ["id"];
            this.IdBill = (int)row["idbill"];
            this.IdFood = (int)row["idfood"];
            this.Count = (int)row["count"];
        }

        private int id;
        private int idBill;
        private int idFood;
        private int count;

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

        public int IdBill
        {
            get
            {
                return idBill;
            }

            set
            {
                idBill = value;
            }
        }

        public int IdFood
        {
            get
            {
                return idFood;
            }

            set
            {
                idFood = value;
            }
        }

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
    }
}
