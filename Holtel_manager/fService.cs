using Holtel_manager.DAO;
using Holtel_manager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Holtel_manager
{
    public partial class fService : Form
    {
        public fService()
        {
            InitializeComponent();
            LoadRoom();
            loadCatagory();

        }

        #region method
        void LoadRoom()
        {
            flpRoomService.Controls.Clear();
            List<Room> roomList = RoomDAO.Instance.GetListRoomService();
            foreach (Room item in roomList)
            {
                Button btn = new Button() { Width = RoomDAO.Roomwidth, Height = RoomDAO.Roomheight };
                btn.Text = item.Roomname + Environment.NewLine + item.Status;
                btn.ForeColor = Color.Green;
                int newSize = 12;
                btn.Font = new Font(btn.Font.FontFamily, newSize);
                btn.Click += Btn_Click;
                string url = @"D:\Library\Đồ án phân tích thiết kế hệ thống\Project\Data\anh1.jpg";
                btn.Image = Image.FromFile(url);
                btn.Tag = item;
                flpRoomService.Controls.Add(btn);
            }
        }

        void FilterRoomByName(string name)
        {
            flpRoomService.Controls.Clear();
            List<Room> roomList = RoomDAO.Instance.SearchRoomByName(name);
            foreach (Room item in roomList)
            {
                Button btn = new Button() { Width = RoomDAO.Roomwidth, Height = RoomDAO.Roomheight };
                btn.Text = item.Roomname + Environment.NewLine + item.Status;
                btn.ForeColor = Color.Green;
                int newSize = 12;
                btn.Font = new Font(btn.Font.FontFamily, newSize);
                btn.Click += Btn_Click1; ;
                string url = @"D:\Library\Đồ án phân tích thiết kế hệ thống\Project\Data\anh1.jpg";
                btn.Image = Image.FromFile(url);
                btn.Tag = item;
                flpRoomService.Controls.Add(btn);
            }
        }

        void loadCatagory()
        {
            List<TypeService> listCategory = TypeServiceDAO.Instance.GetListTypeService();
            cmbServiceCategory.DataSource = listCategory;
            cmbServiceCategory.DisplayMember = "NameTypeService";
        }

        void loadServiceListListByCategory(int id)
        {
            List<Service> listFood = ServiceDAO.Instance.GetListServiceById(id);
            cmbService.DataSource = listFood;
            cmbService.DisplayMember = "ServiceName";
        }

        void ShowService(int id)
        {
            float totalprice = 0;
            lsvservice.Items.Clear();
            List<DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            foreach (DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.ServiceName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.PriceService.ToString());
                lsvItem.SubItems.Add(item.Totalprice.ToString());
                totalprice += item.Totalprice;
                lsvservice.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;
            txbTotalPrice.Text = totalprice.ToString("c");
        }
        #endregion

        #region event
        private void Btn_Click1(object sender, EventArgs e)
        {
            int TableID = ((sender as Button).Tag as Room).IdRoom;
            lsvservice.Tag = (sender as Button).Tag;
            ShowService(TableID);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int TableID = ((sender as Button).Tag as Room).IdRoom;
            lsvservice.Tag = (sender as Button).Tag;
            ShowService(TableID);
        }
        #endregion

        private void cmbServiceCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            TypeService selected = cb.SelectedItem as TypeService;
            id = selected.Id;
            loadServiceListListByCategory(id);
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            Room room = lsvservice.Tag as Room;
            int idcus = BookRoomDAO.Instance.GetIdcusByIrRoom(room.IdRoom);
            if (room == null)
            {
                MessageBox.Show("Hãy chọn Phòng!");
                return;
            }
            int idBill = BillDAO.Instance.GetUncheckBillIdbyTableId(room.IdRoom);
            int isService = (cmbService.SelectedItem as Service).Id;
            int count = (int)nmService.Value;
            if (idBill == -1)
            {
                BillDAO.Instance.insertBill(room.IdRoom , idcus);
                BillInfoDAO.Instance.insertBillInfo(BillDAO.Instance.GetMaxIdBill(), isService, count);
            }
            else //Bill da ton tai
            {
                BillInfoDAO.Instance.insertBillInfo(idBill, isService, count);
            }
            ShowService(room.IdRoom);

            LoadRoom();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterRoomByName(txbSearchRoom.Text);
        }
    }
}
