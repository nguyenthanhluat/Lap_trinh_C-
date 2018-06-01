using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holtel_manager.DTO
{
    public class TypeService
    {
        public TypeService(int id, string nameTypeService)
        {
            this.Id = id;
            this.NameTypeService = nameTypeService;
        }

        public TypeService(DataRow row)
        {
            this.Id = (int)row["id"];
            this.NameTypeService = row["ServiceCategoryName"].ToString();
        }

        private int id;
        private string nameTypeService;

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

        public string NameTypeService
        {
            get
            {
                return nameTypeService;
            }

            set
            {
                nameTypeService = value;
            }
        }
    }
}
