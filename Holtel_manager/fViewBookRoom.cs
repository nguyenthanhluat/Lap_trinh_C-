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
    public partial class fViewBookRoom : Form
    {
        BindingSource bookRoomList = new BindingSource();
        public fViewBookRoom()
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
            bookRoomList.DataSource =  BookRoomDAO.Instance.GetListBookRoom();
        }

        void LoadListBookRoomByDate(DateTime checkin, DateTime checkout)
        {
            bookRoomList.DataSource = BookRoomDAO.Instance.GetBookRoomListByDate(checkin, checkout);
        }

        private void btnViewBookRoom_Click(object sender, EventArgs e)
        {
            LoadListBookRoom();
        }

        private void btnDeleteBookRoom_Click(object sender, EventArgs e)
        {
            int idBookRoom = Convert.ToInt32(txbidBookRoom.Text);

            if (BookRoomDAO.Instance.DeleteBookRoom(idBookRoom))
            {
                MessageBox.Show("Xóa dữ liệu thành công");
                LoadListBookRoom();
                if (deleteBookRoom != null)
                    deleteBookRoom(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa đặt phòng!");
            }
        }

        private event EventHandler deleteBookRoom;
        public event EventHandler DeleteBookRoom
        {
            add { deleteBookRoom += value; }
            remove { deleteBookRoom -= value; }
        }

        private void btnSearchBookRoom_Click(object sender, EventArgs e)
        {
            LoadListBookRoomByDate(dtpkfromBookRoom.Value, dtpkToBookRoom.Value);
        }
    }
}
