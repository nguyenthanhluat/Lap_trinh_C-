using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DTO
{
    public class Room
    {
        public Room(int idroom, string roomname, string status, int typeroom)
        {
            this.IdRoom = idRoom;
            this.Roomname = roomname;
            this.Status = status;
            this.TypeRoom = typeroom;
        }

        public Room(DataRow row)
        {
            this.IdRoom = (int)row["id"];
            this.Roomname = row["roomname"].ToString();
            this.Status = row["status"].ToString();
            this.TypeRoom = (int)row["typeroom"];
        }

        private int idRoom;
        private string roomname;
        private string status;
        private int typeRoom;

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

        public string Roomname
        {
            get
            {
                return roomname;
            }

            set
            {
                roomname = value;
            }
        }

        public string Status
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

        public int TypeRoom
        {
            get
            {
                return typeRoom;
            }

            set
            {
                typeRoom = value;
            }
        }
    }
}
