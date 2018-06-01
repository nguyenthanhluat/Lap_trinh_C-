using Holtel_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DAO
{
    public class BookRoomDAO
    {
        private static BookRoomDAO instance;

        internal static BookRoomDAO Instance
        {
            get
            {
                if (instance == null) instance = new BookRoomDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private BookRoomDAO() { }

        public DataTable GetListBookRoom()
        {
            string query = "SELECT b.Id,b.IdRoom, c.CustomerName,b.IdCustomer,c.Phone,c.Identification,c.TypeCustomer, r.RoomName, b.DateCheckIn, b.DateCheckOut FROM dbo.BookRoom AS b INNER JOIN dbo.Room AS r ON r.Id = b.IdRoom INNER JOIN dbo.Customer AS c  ON  b.IdCustomer = c.Id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { } );
        }

        public DataTable SearchCheckInByCusName(string name)
        {
            string query = string.Format("SELECT b.Id,b.IdRoom, c.CustomerName,b.IdCustomer,c.Phone,c.Identification,c.TypeCustomer, r.RoomName, b.DateCheckIn, b.DateCheckOut FROM dbo.BookRoom AS b INNER JOIN dbo.Room AS r ON r.Id = b.IdRoom INNER JOIN dbo.Customer AS c  ON  b.IdCustomer = c.Id where r.Status = N'checkin' and c.CustomerName like N'%{0}%'", name);
            return DataProvider.Instance.ExecuteQuery(query, new object[] { });
        }

        public DataTable SearchCheckInByCusName1(string name)
        {
            string query = string.Format("SELECT b.Id,b.IdRoom, c.CustomerName,b.IdCustomer,c.Phone,c.Identification,c.TypeCustomer, r.RoomName, b.DateCheckIn, b.DateCheckOut FROM dbo.BookRoom AS b INNER JOIN dbo.Room AS r ON r.Id = b.IdRoom INNER JOIN dbo.Customer AS c  ON  b.IdCustomer = c.Id where c.CustomerName like N'%{0}%'", name);
            return DataProvider.Instance.ExecuteQuery(query, new object[] { });
        }

        public int GetIdcusByIrRoom(int id)
        {
            //string query = string.Format("SELECT BookRoom.IdCustomer FROM dbo.BookRoom INNER JOIN dbo.Room ON Room.Id = BookRoom.IdRoom WHERE dbo.Room.status = N'checkin' AND BookRoom.IdRoom = ", id);
            //int idcus = Convert.ToInt32(DataProvider.Instance.ExecuteQuery("SELECT BookRoom.IdCustomer FROM dbo.BookRoom INNER JOIN dbo.Room ON Room.Id = BookRoom.IdRoom WHERE dbo.Room.status = N'checkin' AND BookRoom.IdRoom = " + id));
            return (int)DataProvider.Instance.ExecuteScalar("SELECT BookRoom.IdCustomer FROM dbo.BookRoom INNER JOIN dbo.Room ON Room.Id = BookRoom.IdRoom WHERE dbo.Room.status = N'checkin' AND BookRoom.IdRoom = " + id);
        }

        public DataTable GetListCheckInList()
        {
            string query = "SELECT b.Id, b.IdRoom, c.CustomerName,b.IdCustomer,c.Phone,c.Identification,c.TypeCustomer, r.RoomName, b.DateCheckIn, b.DateCheckOut FROM dbo.BookRoom AS b INNER JOIN dbo.Room AS r ON r.Id = b.IdRoom INNER JOIN dbo.Customer AS c  ON  b.IdCustomer = c.Id where r.Status = N'checkin'";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { });
        }

        public DataTable GetListCheckInList1()
        {
            string query = "SELECT b.Id, b.IdRoom, c.CustomerName,b.IdCustomer,c.Phone,c.Identification,c.TypeCustomer, r.RoomName, b.DateCheckIn, b.DateCheckOut FROM dbo.BookRoom AS b INNER JOIN dbo.Room AS r ON r.Id = b.IdRoom INNER JOIN dbo.Customer AS c  ON  b.IdCustomer = c.Id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { });
        }

        public DataTable GetListCheckIn()
        {
            string query = "SELECT b.Id,b.IdRoom, c.CustomerName,b.IdCustomer,c.Phone,c.Identification,c.TypeCustomer, r.RoomName, b.DateCheckIn, b.DateCheckOut FROM dbo.BookRoom AS b INNER JOIN dbo.Room AS r ON r.Id = b.IdRoom INNER JOIN dbo.Customer AS c  ON  b.IdCustomer = c.Id where r.Status = N'book'";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { });
        }

        public bool InsertBookRoom(int idRoom, int idCustomer, DateTime DateCheckIn, DateTime DateCheckOut)
        {
            string query = string.Format("INSERT INTO dbo.BookRoom( IdRoom ,IdCustomer ,DateCheckIn, DateCheckOut)VALUES  ( {0} ,{1} ,N'{2}',N'{3}')", idRoom, idCustomer, DateCheckIn, DateCheckOut);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteBookRoom(int idBookRoom)
        {
            string query = string.Format("Delete dbo.BookRoom where id = {0}", idBookRoom);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public DataTable GetBookRoomListByDate(DateTime checkin, DateTime checkout)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListCheckInByDate @checkin , @checkout", new object[] { checkin, checkout });
        }
    }
}
