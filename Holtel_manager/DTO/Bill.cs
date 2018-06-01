using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? dateCheckOut, DateTime? dateCheckIn, int idRoom, int idCustomer, int statusBill)
        {
            this.Id = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.IdRoom = idRoom;
            this.IdCustomer = idCustomer;
            this.StatusBill = statusBill;
        }

        public Bill(DataRow row)
        {
            this.Id = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["dateCheckIn"];
            this.DateCheckOut = (DateTime?)row["dateCheckOut"];
            this.IdRoom = (int)row["idRoom"];
            this.IdCustomer = (int)row["idCustomer"];
            this.StatusBill = (int)row["statusBill"];
        }

        private int id;
        private DateTime? dateCheckOut;
        private DateTime? dateCheckIn;
        private int idRoom;
        private int idCustomer;
        private int statusBill;

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

        public DateTime? DateCheckOut
        {
            get
            {
                return dateCheckOut;
            }

            set
            {
                dateCheckOut = value;
            }
        }

        public DateTime? DateCheckIn
        {
            get
            {
                return dateCheckIn;
            }

            set
            {
                dateCheckIn = value;
            }
        }

        public int IdRoom
        {
            get
            {
                return idRoom;
            }

            set
            {
                idRoom = value;
            }
        }

        public int IdCustomer
        {
            get
            {
                return idCustomer;
            }

            set
            {
                idCustomer = value;
            }
        }

        public int StatusBill
        {
            get
            {
                return statusBill;
            }

            set
            {
                statusBill = value;
            }
        }
    }
}
