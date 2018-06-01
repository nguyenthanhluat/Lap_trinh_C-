using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DTO
{
    public class TypeRoom
    {
        public TypeRoom(int id, float priceRoom, string nameRoomType,int numBed, int television, int airCondition,int numLight, float deposits)
        {
            this.Id = id;
            this.PriceRoom = priceRoom;
            this.NameTypeRoom = nameRoomType;
            this.NumBed = numBed;
            this.Television = television;
            this.AirCondition = airCondition;
            this.NumLight = numLight;
            this.Deposits = deposits;
        }

        public TypeRoom(DataRow row)
        {
            this.Id = (int)row["id"];
            this.PriceRoom = (float)Convert.ToDouble(row["priceRoom"].ToString());
            this.NameTypeRoom = row["nameTypeRoom"].ToString();
            this.NumBed = (int)row["numBed"];
            this.Television = (int)row["Television"];
            this.AirCondition = (int)row["airCondition"];
            this.NumLight = (int)row["numLight"];
            this.Deposits = (float)Convert.ToDouble(row["deposits"].ToString());
        }

        private int id;
        private float priceRoom;
        private string nameTypeRoom;
        private int numBed;
        private int television;
        private int airCondition;
        private int numLight;
        private float deposits;

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

        public float PriceRoom
        {
            get
            {
                return priceRoom;
            }

            set
            {
                priceRoom = value;
            }
        }

        public string NameTypeRoom
        {
            get
            {
                return nameTypeRoom;
            }

            set
            {
                nameTypeRoom = value;
            }
        }

        public int NumBed
        {
            get
            {
                return numBed;
            }

            set
            {
                numBed = value;
            }
        }

        public int Television
        {
            get
            {
                return television;
            }

            set
            {
                television = value;
            }
        }

        public int AirCondition
        {
            get
            {
                return airCondition;
            }

            set
            {
                airCondition = value;
            }
        }

        public int NumLight
        {
            get
            {
                return numLight;
            }

            set
            {
                numLight = value;
            }
        }

        public float Deposits
        {
            get
            {
                return deposits;
            }

            set
            {
                deposits = value;
            }
        }
    }
}
