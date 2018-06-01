using Holtel_manager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DAO
{
    public class TypeRoomDAO
    {
        private static TypeRoomDAO instance;

        public static TypeRoomDAO Instance
        {
            get
            {
                if (instance == null) instance = new TypeRoomDAO();
                return TypeRoomDAO.instance;
            }

            private set
            {
                TypeRoomDAO.instance = value;
            }
        }

        private TypeRoomDAO() { }

        public List<TypeRoom> GetListTypeRoom()
        {
            List<TypeRoom> TypeRoomList = new List<TypeRoom>();
            string query = "select * from TypeRoom";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TypeRoom typeroom = new TypeRoom(item);
                TypeRoomList.Add(typeroom);
            }
            return TypeRoomList;
        }

        public bool InsertTypeRoom(float priceroom, string nametyperoom, int numbed, int television, int aircondition, int numlight, float deposits)
        {
            string query = string.Format("INSERT INTO dbo.TypeRoom(PriceRoom ,NameTypeRoom ,NumBed ,Television ,AirCondition ,NumLight ,Deposits)VALUES ({0} ,N'{1}' ,{2} ,{3} ,{4} ,{5} ,{6})",priceroom,nametyperoom,numbed,television,aircondition,numlight,deposits);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool EditTypeRoom(int idTypeRoom, float priceroom, string nametyperoom, int numbed, int television, int aircondition, int numlight, float deposits)
        {
            string query = string.Format("UPDATE dbo.TypeRoom SET PriceRoom = {0}, NameTypeRoom = N'{1}',NumBed = {2},Television = {3}, AirCondition = {4}, NumLight = {5}, Deposits = {6} WHERE Id = {7}", priceroom, nametyperoom, numbed, television,aircondition,numlight,deposits,idTypeRoom);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTypeRoom(int idTypeRoom)
        {
            RoomDAO.Instance.DeleteRoomByIdTypeRoom(idTypeRoom);
            string query = string.Format("DELETE dbo.TypeRoom WHERE Id = {0}", idTypeRoom);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public TypeRoom GetTypeRoomById(int id)
        {
            TypeRoom typeRoom = null;
            string query = "select * from TypeRoom where id= " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                typeRoom = new TypeRoom(item);
                return typeRoom;
            }
            return typeRoom;
        }
    }
}
