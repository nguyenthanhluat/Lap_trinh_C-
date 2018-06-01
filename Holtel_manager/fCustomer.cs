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

namespace Holtel_manager
{
    public partial class fCustomer : Form
    {
        BindingSource customerList = new BindingSource();
        public fCustomer()
        {
            InitializeComponent();
            dgvCustomer.DataSource = customerList;
            LoadCustomer();
            AddCustomerBinding();
            LoadTypeCusIntoCmb(cbTypeCus);
        }

        void LoadCustomer()
        {
            customerList.DataSource = CustomerDAO.Instance.GetListCustomer();
        }

        void AddCustomerBinding()
        {
            txbIdCus.DataBindings.Add(new Binding("TEXT", dgvCustomer.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txbNameCustomer.DataBindings.Add(new Binding("TEXT", dgvCustomer.DataSource, "CustomerName", true, DataSourceUpdateMode.Never));
            txbPhoneCustomer.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "Phone", true, DataSourceUpdateMode.Never));
            txbTdetification.DataBindings.Add(new Binding("TEXT", dgvCustomer.DataSource, "Identification", true, DataSourceUpdateMode.Never));
            cbTypeCus.DataBindings.Add(new Binding("TEXT", dgvCustomer.DataSource, "TypeCustomer", true, DataSourceUpdateMode.Never));
        }

        void LoadTypeCusIntoCmb(ComboBox cb)
        {
            cb.Items.Add("VIP");
            cb.Items.Add("Normal");
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string nameCustomer = txbNameCustomer.Text;
            string phone = txbPhoneCustomer.Text;
            string identificatin = txbTdetification.Text;
            string typeCustomer = cbTypeCus.SelectedItem.ToString();

            if (CustomerDAO.Instance.InsertCustomer(nameCustomer, phone, identificatin,typeCustomer))
            {
                MessageBox.Show("Thêm mới dữ liệu thành công");
                LoadCustomer();
                if (insertCustomer != null)
                    insertCustomer(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm khách hàng!");
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            string nameCustomer = txbNameCustomer.Text;
            string phone = txbPhoneCustomer.Text;
            string identificatin = txbTdetification.Text;
            string typeCustomer = cbTypeCus.SelectedItem.ToString();
            int id = Convert.ToInt32(txbIdCus.Text);

            if (CustomerDAO.Instance.EditCustomer(id, nameCustomer, phone, identificatin,typeCustomer))
            {
                MessageBox.Show("cập nhật dữ liệu thành công");
                LoadCustomer();
                if (updateCustomer != null)
                    updateCustomer(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật Customer");
            }
        }

        List<Customer> SearchCustomerName(string name)
        {
            List<Customer> listCustomer = CustomerDAO.Instance.SearchCustomerByName(name);
            return listCustomer;
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbIdCus.Text);

            if (CustomerDAO.Instance.DeleteCustomer(id))
            {
                MessageBox.Show("Xóa dữ liệu thành công");
                LoadCustomer();
                if (deleteCustomer != null)
                    deleteCustomer(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa khách hàng!");
            }
        }

        private event EventHandler insertCustomer;

        public event EventHandler InsertCustomer
        {
            add { insertCustomer += value; }
            remove { insertCustomer -= value; }
        }

        private event EventHandler deleteCustomer;
        public event EventHandler DeleteCustomer
        {
            add { deleteCustomer += value; }
            remove { deleteCustomer -= value; }
        }

        private event EventHandler updateCustomer;
        public event EventHandler UpdateCustomer
        {
            add { updateCustomer += value; }
            remove { updateCustomer -= value; }
        }

        private void btnViewCustomer_Click(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void btnBookRoomCus_Click(object sender, EventArgs e)
        {
            string statusupdate = "book";
            int idRoom = RoomDAO.RoomChoose;
            int idCustomer = Convert.ToInt32(txbIdCus.Text);
            DateTime Datecheckin = RoomDAO.DateCheckIn;
            DateTime DateCheckout = RoomDAO.DateCheckOut;
            BookRoomDAO.Instance.InsertBookRoom(idRoom, idCustomer, Datecheckin, DateCheckout);
            RoomDAO.Instance.UpdateStatusRoom(idRoom, statusupdate);
            RoomDAO.CusChoose = Convert.ToInt32(txbIdCus.Text);
            if (MessageBox.Show("Đặt Phòng thành công! Bạn có muốn in phiếu?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                fBill f = new fBill();
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                fViewBookRoom f = new fViewBookRoom();
                this.Hide();
                f.ShowDialog();
            }
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            customerList.DataSource = SearchCustomerName(txbSearchCustomer.Text);
        }
    }
}
