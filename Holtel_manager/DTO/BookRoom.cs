using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DTO
{
    public class BookRoom
    {
        public BookRoom (int id, int idRoom, int idCustomer, DateTime dateCheckIn, DateTime dateCheckOut)
        {
            this.Id = id;
            this.IdRoom = idRoom;
            this.IdCustomer = idCustomer;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
        }

        public BookRoom(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdRoom = (int)row["idRoom"];
            this.IdCustomer = (int)row["idCustomer"];
            this.DateCheckIn = (DateTime?)row["dateCheckIn"];
            this.DateCheckOut = (DateTime?)row["dateCheckOut"];
        }

        private int id;
        private int idRoom;
        private int idCustomer;
        private DateTime? dateCheckOut;
        private DateTime? dateCheckIn;

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
    }
}
