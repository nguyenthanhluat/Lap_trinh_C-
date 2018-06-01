using Holtel_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DAO
{
    public class RoomDAO
    {
        public static int Roomwidth = 115;
        public static int Roomheight = 115;
        public static int RoomChoose;
        public static int CusChoose;
        public static DateTime DateCheckIn;
        public static DateTime DateCheckOut;

        private static RoomDAO instance;

        public static RoomDAO Instance
        {
            get
            {
                if (instance == null) instance = new RoomDAO();
                return RoomDAO.instance;
            }

            private set
            {
                RoomDAO.instance = value;
            }
        }

        private RoomDAO() { }

        public List<Room> GetListRoom()
        {
            List<Room> RoomList = new List<Room>();
            string query = "select * from Room";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                RoomList.Add(room);
            }
            return RoomList;
        }

        public List<Room> GetListRoomService()
        {
            List<Room> RoomList = new List<Room>();
            string query = "select * from Room where status = N'checkin'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                RoomList.Add(room);
            }
            return RoomList;
        }

        public List<Room> FilterRoom(DateTime DateCheckin, DateTime DateCheckout, int NumBed, int Numlight, int Television, int AirCondition)
        {
            List<Room> RoomList = new List<Room>();
            string query = string.Format("EXEC dbo.USP_GetRoomListByWhere @DateCheckin = N'{0}', @DateCheckout = N'{1}', @numBed = {2}, @numlight = {3}, @television = {4}, @aircondition = {5}",DateCheckin,DateCheckout,NumBed,Numlight,Television,AirCondition);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                RoomList.Add(room);
            }
            return RoomList;
        }

        public bool UpdateStatusRoom(int idRoom,string status)
        {
            string query = string.Format("UPDATE dbo.Room SET status = N'{0}' WHERE Id = {1}", status, idRoom);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool InsertRoom(string RoomName, string status, int TypeRoom)
        {
            string query = string.Format("INSERT INTO dbo.Room( RoomName, status, TypeRoom )VALUES  ( N'{0}', N'{1}', {2})", RoomName, status, TypeRoom);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool EditRoom(int idRoom, string RoomName, string status, int TypeRoom)
        {
            string query = string.Format("UPDATE dbo.Room SET RoomName = N'{0}', status = N'{1}',TypeRoom = {2} WHERE Id = {3}", RoomName, status, TypeRoom, idRoom);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteRoom(int idRoom)
        {
            string query = string.Format("DELETE dbo.Room WHERE Id = {0}", idRoom);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public void DeleteRoomByIdTypeRoom(int id)
        {
            DataProvider.Instance.ExecuteQuery("Delete dbo.Room where TypeRoom = " + id);
        }

        public List<Room> SearchRoomByName(string name)
        {
            List<Room> RoomList = new List<Room>();
            string query = string.Format("select * from Room where status = N'checkin' and Roomname like N'%{0}%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                RoomList.Add(room);
            }
            return RoomList;
        }
    }
}
