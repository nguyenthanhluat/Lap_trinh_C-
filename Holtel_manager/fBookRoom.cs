using Holtel_manager.DAO;
using Holtel_manager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Holtel_manager.fAccount;

namespace Holtel_manager
{
    public partial class fBookRoom : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get
            {
                return loginAccount;
            }

            set
            {
                loginAccount = value;
                ChangeAccount(loginAccount.Type);
            }
        }

        public fBookRoom(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            LoadRoom();
        }

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 0;
            thôngTinCáNhânToolStripMenuItem.Text += " (" + LoginAccount.Displayname + ")";
        }

        #region method
        void Filter(DateTime DateCheckin, DateTime DateCheckout, int NumBed, int Numlight, int Television, int AirCondition)
        {
            flpRoomCheckin.Controls.Clear();
            List<Room> roomList = RoomDAO.Instance.FilterRoom(DateCheckin, DateCheckout, NumBed, Numlight, Television, AirCondition);
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
                switch (item.Status)
                {
                    case "null":
                        btn.BackColor = Color.Green;
                        btn.ForeColor = Color.Green;
                        break;
                    case "book":
                        btn.BackColor = Color.Blue;
                        btn.ForeColor = Color.Blue;
                        break;
                    case "checkin":
                        btn.BackColor = Color.DarkCyan;
                        btn.ForeColor = Color.DarkCyan;
                        break;
                    default:
                        break;
                }
                flpRoomCheckin.Controls.Add(btn);
            }
        }

        void LoadRoom()
        {
            flpRoomCheckin.Controls.Clear();
            List<Room> roomList = RoomDAO.Instance.GetListRoom();
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
                switch (item.Status)
                {
                    case "null":
                        btn.BackColor = Color.Green;
                        btn.ForeColor = Color.Green;
                        break;
                    case "book":
                        btn.BackColor = Color.Blue;
                        btn.ForeColor = Color.Blue;
                        break;
                    case "checkin":
                        btn.BackColor = Color.DarkCyan;
                        btn.ForeColor = Color.DarkCyan;
                        break;
                    default:
                        break;
                }
                flpRoomCheckin.Controls.Add(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            txbIdRoom.Text = ((sender as Button).Tag as Room).IdRoom.ToString();
            txbRoomName.Text = ((sender as Button).Tag as Room).Roomname;
            TypeRoom typeroom = TypeRoomDAO.Instance.GetTypeRoomById(((sender as Button).Tag as Room).TypeRoom);
            txbPriceRoom.Text = typeroom.PriceRoom.ToString();
            txbNumBed.Text = typeroom.NumBed.ToString();
            txbNumLight.Text = typeroom.NumLight.ToString();
            txbTelevision.Text = typeroom.Television.ToString();
            txbAir.Text = typeroom.AirCondition.ToString();
            txbNameType.Text = typeroom.NameTypeRoom;
            txbDeposits.Text = typeroom.Deposits.ToString();
            RoomDAO.RoomChoose = Convert.ToInt32(txbIdRoom.Text);
            RoomDAO.DateCheckIn = dtpCheckin.Value;
            RoomDAO.DateCheckOut = dtpCheckout.Value;
        }

        private void Btn_Click1(object sender, EventArgs e)
        {
            txbIdRoom.Text = ((sender as Button).Tag as Room).IdRoom.ToString();
            txbRoomName.Text = ((sender as Button).Tag as Room).Roomname;
            TypeRoom typeroom = TypeRoomDAO.Instance.GetTypeRoomById(((sender as Button).Tag as Room).TypeRoom);
            txbPriceRoom.Text = typeroom.PriceRoom.ToString();
            txbNumBed.Text = typeroom.NumBed.ToString();
            txbNumLight.Text = typeroom.NumLight.ToString();
            txbTelevision.Text = typeroom.Television.ToString();
            txbAir.Text = typeroom.AirCondition.ToString();
            txbNameType.Text = typeroom.NameTypeRoom;
            txbDeposits.Text = typeroom.Deposits.ToString();
            RoomDAO.RoomChoose = Convert.ToInt32(txbIdRoom.Text);
            RoomDAO.DateCheckIn = dtpCheckin.Value;
            RoomDAO.DateCheckOut = dtpCheckout.Value;
        }
        #endregion

        #region event
        private void btnFilter_Click(object sender, EventArgs e)
        {
            Filter(dtpCheckin.Value, dtpCheckout.Value, (int)nmBed.Value, (int)nmLight.Value, (int)nmTelevision.Value, (int)nmAir.Value);
        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            fCustomer f = new fCustomer();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fService f = new fService();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void thôngTinCáNhânToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fAccount f = new fAccount(LoginAccount);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
        }

        private void f_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinCáNhânToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.Displayname + ")";
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLogin f = new fLogin();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCheckin f = new fCheckin();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void viewCheckInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fViewBookRoom f = new fViewBookRoom();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCustomer f = new fCustomer();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void viewCheckInToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fViewCheckIn f = new fViewCheckIn();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        #endregion

        private void checkOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fCheckOut f = new fCheckOut();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void bookRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCustomer f = new fCustomer();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void viewCheckInToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            fViewCheckIn f = new fViewCheckIn();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void viewBookRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fViewBookRoom f = new fViewBookRoom();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void viewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCustomer f = new fCustomer();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
