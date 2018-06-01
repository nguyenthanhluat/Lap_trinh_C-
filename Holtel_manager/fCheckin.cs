using Holtel_manager.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Holtel_manager
{
    public partial class fCheckin : Form
    {
        BindingSource bookRoomList = new BindingSource();
        public fCheckin()
        {
            InitializeComponent();
            dgvBookRoom.DataSource = bookRoomList;
            LoadListBookRoom();
            AddBookRoomBinding();
        }

        void AddBookRoomBinding()
        {
            txbidBookRoom.DataBindings.Add(new Binding("Text", dgvBookRoom.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txbIdRoomBookRoom.DataBindings.Add(new Binding("Text", dgvBookRoom.DataSource, "IdRoom", true, DataSourceUpdateMode.Never));
            txbNameRoom.DataBindings.Add(new Binding("Text", dgvBookRoom.DataSource, "RoomName", true, DataSourceUpdateMode.Never));
            txbIdCusBookRoom.DataBindings.Add(new Binding("Text", dgvBookRoom.DataSource, "IdCustomer", true, DataSourceUpdateMode.Never));
            txbNameCus.DataBindings.Add(new Binding("Text", dgvBookRoom.DataSource, "CustomerName", true, DataSourceUpdateMode.Never));
            txbPhone.DataBindings.Add(new Binding("Text", dgvBookRoom.DataSource, "Phone", true, DataSourceUpdateMode.Never));
            txbIdentification.DataBindings.Add(new Binding("Text", dgvBookRoom.DataSource, "Identification", true, DataSourceUpdateMode.Never));
            txbTypeCustomer.DataBindings.Add(new Binding("Text", dgvBookRoom.DataSource, "TypeCustomer", true, DataSourceUpdateMode.Never));
            txbDateCheckIn.DataBindings.Add(new Binding("Text", dgvBookRoom.DataSource, "DateCheckIn", true, DataSourceUpdateMode.Never));
            txbDateCheckOut.DataBindings.Add(new Binding("Text", dgvBookRoom.DataSource, "DateCheckOut", true, DataSourceUpdateMode.Never));
        }

        void LoadListBookRoom()
        {
            bookRoomList.DataSource = BookRoomDAO.Instance.GetListCheckIn();
        }

        void LoadListBookRoomByDate(DateTime checkin, DateTime checkout)
        {
            bookRoomList.DataSource = BookRoomDAO.Instance.GetBookRoomListByDate(checkin, checkout);
        }

        void LoadListCheckInByCusName(string name)
        {
            bookRoomList.DataSource = BookRoomDAO.Instance.SearchCheckInByCusName(name);
        }

        private void btnSearchBookRoom_Click(object sender, EventArgs e)
        {
            if(txbSearchCheckIn.Text == "")
            {
                LoadListBookRoomByDate(dtpkfromBookRoom.Value, dtpkToBookRoom.Value);
            }
            else
            {
                string name = txbSearchCheckIn.Text;
                LoadListCheckInByCusName(name);
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            int idRoom = Convert.ToInt32(txbIdRoomBookRoom.Text);
            string statusupdate = "checkin";
            RoomDAO.Instance.UpdateStatusRoom(idRoom, statusupdate);
            if (MessageBox.Show("Check In thành công!", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                fViewCheckIn f = new fViewCheckIn();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
        }
    }
}
