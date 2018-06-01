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
    public partial class fCheckOut : Form
    {
        public fCheckOut()
        {
            InitializeComponent();
            LoadRoom();
        }

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
                btn.Click += Btn_Click1;
                string url = @"D:\Library\Đồ án phân tích thiết kế hệ thống\Project\Data\anh1.jpg";
                btn.Image = Image.FromFile(url);
                btn.Tag = item;
                flpRoomService.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            Room room = lsvBill.Tag as Room;
            txbNameRoom.Text = room.Roomname;
            TypeRoom roomtype = TypeRoomDAO.Instance.GetTypeRoomById(room.TypeRoom);
            txbPriceRoom.Text = roomtype.PriceRoom.ToString();
            txbDeposit.Text = (roomtype.Deposits* roomtype.PriceRoom/100).ToString();
            float totalprice = roomtype.PriceRoom - roomtype.PriceRoom * roomtype.Deposits /100;
            int idcus = BookRoomDAO.Instance.GetIdcusByIrRoom(room.IdRoom);
            Customer cus = CustomerDAO.Instance.GetCustomerById(idcus);
            txbNameCus.Text = cus.CustomerName;
            List<DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            foreach (DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.ServiceName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.PriceService.ToString());
                lsvItem.SubItems.Add(item.Totalprice.ToString());
                totalprice += item.Totalprice;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;
            txbTotalPrice.Text = totalprice.ToString("c");
        }

        private void Btn_Click1(object sender, EventArgs e)
        {
            int TableID = ((sender as Button).Tag as Room).IdRoom;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(TableID);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int TableID = ((sender as Button).Tag as Room).IdRoom;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(TableID);
        }

        private void btnSearchCheckIn_Click(object sender, EventArgs e)
        {
            FilterRoomByName(txbSearchRoom.Text);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Room room = lsvBill.Tag as Room;
            int idBill = BillDAO.Instance.GetUncheckBillIdbyTableId(room.IdRoom);
            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]);
            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0} \n Tổng tiền = {1} ", room.Roomname, totalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    string statusupdate = "null";
                    BillDAO.Instance.checkout(idBill, (float)totalPrice);
                    RoomDAO.Instance.UpdateStatusRoom(room.IdRoom,statusupdate);
                    LoadRoom();
                    //ShowBill(room.IdRoom);
                }
            }
        }
    }
}
