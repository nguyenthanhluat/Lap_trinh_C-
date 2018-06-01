using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManage.DTO
{
    class Bill
    {
        public Bill(int id, DateTime? datecheckin, DateTime? datecheckout, int status, int discount =0)
        {
            this.Id = id;
            this.DateCheckIn = datecheckin;
            this.DateCheckOut = datecheckout;
            this.Status = status;
            this.Discount = discount;
        }

        public Bill(DataRow row)
        {
            this.Id = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["datecheckin"];
            var datecheckouttemp = row["datecheckout"];
            if(datecheckouttemp.ToString() != "" )
            this.DateCheckOut = (DateTime?)datecheckouttemp;
            this.Status = (int)row["status"];
            if(row["discount"].ToString() != "")
                this.Discount = (int)row["discount"];
        }

        private int status;
        private DateTime? dateCheckOut;
        private DateTime? dateCheckIn;
        private int id;
        private int discount;

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

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
            }
        }
    }
}
