using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int idBill, int idService, int count)
        {
            this.Id = id;
            this.IdBill = idBill;
            this.IdService = idService;
            this.Count = count;
        }

        public BillInfo(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdBill = (int)row["idBill"];
            this.IdService = (int)row["idService"];
            this.Count = (int)row["count"];
        }

        private int id;
        private int idBill;
        private int idService;
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

        public int IdService
        {
            get
            {
                return idService;
            }

            set
            {
                idService = value;
            }
        }
    }
}
