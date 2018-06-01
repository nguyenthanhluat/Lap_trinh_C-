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
    public partial class fAdmin : Form
    {
        BindingSource customerList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource roomList = new BindingSource();
        BindingSource serviceList = new BindingSource();
        BindingSource typeRoomList = new BindingSource();
        BindingSource typeServiceList = new BindingSource();
        public fAdmin()
        {
            InitializeComponent();

            dgvAccount.DataSource = accountList;
            dgvRoom.DataSource = roomList;
            dgvTypeRoom.DataSource = typeRoomList;
            dgvTypeService.DataSource = typeServiceList;
            dgvService.DataSource = serviceList;
            LoadListTypeRoom();
            AddTypeRoomBinding();
            LoadListRoom();
            AddRoomBinding();
            LoadListTypeService();
            AddTypeServiceBinding();
            LoadListService();
            AddServiceBinding();
            LoadListAccount();
            AddAccountBinding();
            LoadDateTimePickerBill();
            LoadAccountTypeIntoCmb(cbTypeAccount);
            LoadServiceTypeIntoCmb(cbTypeService);
            LoadRoomTypeIntoCmb(cbTypeRoom);
            LoadListBillByDate(dpkDateFrom.Value, dpkDateTo.Value);
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

            if (CustomerDAO.Instance.InsertCustomer(nameCustomer, phone, identificatin, typeCustomer))
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

            if (CustomerDAO.Instance.EditCustomer(id, nameCustomer, phone, identificatin, typeCustomer))
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
            if (MessageBox.Show("Đặt Phòng thành công!", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
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

        void LoadListService()
        {
            serviceList.DataSource = ServiceDAO.Instance.GetListService();
        }

        void LoadListTypeRoom()
        {
            typeRoomList.DataSource = TypeRoomDAO.Instance.GetListTypeRoom();
        }

        void LoadListRoom()
        {
            roomList.DataSource = RoomDAO.Instance.GetListRoom();
        }

        void LoadListTypeService()
        {
            typeServiceList.DataSource = TypeServiceDAO.Instance.GetListTypeService();
        }

        void LoadListAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void AddServiceBinding()
        {
            txbService.DataBindings.Add(new Binding("Text", dgvService.DataSource, "ServiceName", true, DataSourceUpdateMode.Never));
            txbPriceService.DataBindings.Add(new Binding("Text", dgvService.DataSource, "priceservice", true, DataSourceUpdateMode.Never));
            txbIdService.DataBindings.Add(new Binding("Text", dgvService.DataSource, "id", true, DataSourceUpdateMode.Never));
        }

        void AddTypeRoomBinding()
        {
            txbNameTypeRoom.DataBindings.Add(new Binding("Text", dgvTypeRoom.DataSource, "nametyperoom", true, DataSourceUpdateMode.Never));
            txbPriceRoom.DataBindings.Add(new Binding("Text", dgvTypeRoom.DataSource, "priceroom", true, DataSourceUpdateMode.Never));
            txbNumberBed.DataBindings.Add(new Binding("Text", dgvTypeRoom.DataSource, "numbed", true, DataSourceUpdateMode.Never));
            txbNumberLight.DataBindings.Add(new Binding("Text", dgvTypeRoom.DataSource, "numlight", true, DataSourceUpdateMode.Never));
            txbAirCondition.DataBindings.Add(new Binding("Text", dgvTypeRoom.DataSource, "aircondition", true, DataSourceUpdateMode.Never));
            txbDeposits.DataBindings.Add(new Binding("Text", dgvTypeRoom.DataSource, "deposits", true, DataSourceUpdateMode.Never));
            txbTelevision.DataBindings.Add(new Binding("Text", dgvTypeRoom.DataSource, "television", true, DataSourceUpdateMode.Never));
            txbIdTypeRoom.DataBindings.Add(new Binding("Text", dgvTypeRoom.DataSource, "id", true, DataSourceUpdateMode.Never));
        }

        void AddRoomBinding()
        {
            txbRoomName.DataBindings.Add(new Binding("Text", dgvRoom.DataSource, "roomname", true, DataSourceUpdateMode.Never));
            txbStatus.DataBindings.Add(new Binding("Text", dgvRoom.DataSource, "status", true, DataSourceUpdateMode.Never));
            txbRoomID.DataBindings.Add(new Binding("Text", dgvRoom.DataSource, "IdRoom", true, DataSourceUpdateMode.Never));
        }

        void AddAccountBinding()
        {
            txbNameAccount.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Username", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Displayname", true, DataSourceUpdateMode.Never));
        }

        void LoadAccountTypeIntoCmb(ComboBox cb)
        {
            cb.DataSource = TypeAccountDAO.Instance.GetListTypeAccount();
            cb.DisplayMember = "nameType";
        }

        void LoadServiceTypeIntoCmb(ComboBox cb)
        {
            cb.DataSource = TypeServiceDAO.Instance.GetListTypeService();
            cb.DisplayMember = "NameTypeService";
        }

        void LoadRoomTypeIntoCmb(ComboBox cb)
        {
            cb.DataSource = TypeRoomDAO.Instance.GetListTypeRoom();
            cb.DisplayMember = "NameTypeRoom";
            txbStatus.Items.Add("null");
            txbStatus.Items.Add("book");
            txbStatus.Items.Add("checkin");
        }

        void AddTypeServiceBinding()
        {
            txbIdTypeService.DataBindings.Add(new Binding("Text", dgvTypeService.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txbTypeServiceName.DataBindings.Add(new Binding("Text", dgvTypeService.DataSource, "NameTypeService", true, DataSourceUpdateMode.Never));
        }

        private void btnViewTypeRoom_Click(object sender, EventArgs e)
        {
            LoadListTypeRoom();
        }

        private void btnViewRoom_Click(object sender, EventArgs e)
        {
            LoadListRoom();
        }

        private void btnViewTypeService_Click(object sender, EventArgs e)
        {
            LoadListTypeService();
        }

        private void btnViewService_Click(object sender, EventArgs e)
        {
            LoadListService();
        }

        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }

        private void btnAddTypeRoom_Click(object sender, EventArgs e)
        {
            float priceroom = (float)Convert.ToDouble(txbPriceRoom.Text);
            string nametyperoom = txbNameTypeRoom.Text;
            int numbed = Convert.ToInt32(txbNumberBed.Text);
            int television = Convert.ToInt32(txbTelevision.Text);
            int aircondition = Convert.ToInt32(txbAirCondition.Text);
            int numlight = Convert.ToInt32(txbNumberLight.Text);
            float deposits = (float)Convert.ToDouble(txbDeposits.Text);

            if (TypeRoomDAO.Instance.InsertTypeRoom(priceroom, nametyperoom, numbed, television, aircondition, numlight, deposits))
            {
                MessageBox.Show("Thêm loại phòng thành công!");
                LoadListTypeRoom();
                if (insertTypeRoom != null)
                    insertTypeRoom(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm loại phòng!");
            }
        }

        private event EventHandler insertTypeRoom;

        public event EventHandler InsertTypeRoom
        {
            add { insertTypeRoom += value; }
            remove { insertTypeRoom -= value; }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            string RoomName = txbRoomName.Text;
            string status = txbStatus.Text;
            int TypeRoom = (cbTypeRoom.SelectedItem as Holtel_manager.DTO.TypeRoom).Id;

            if (RoomDAO.Instance.InsertRoom(RoomName, status, TypeRoom))
            {
                MessageBox.Show("Thêm phòng thành công!");
                LoadListRoom();
                if (insertRoom != null)
                    insertRoom(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm phòng!");
            }
        }

        private event EventHandler insertRoom;

        public event EventHandler InsertRoom
        {
            add { insertRoom += value; }
            remove { insertRoom -= value; }
        }

        private void btnAddTypeService_Click(object sender, EventArgs e)
        {
            string ServiceCategoryName = txbTypeServiceName.Text;
            
            if (TypeServiceDAO.Instance.InsertTypeService(ServiceCategoryName))
            {
                MessageBox.Show("Thêm danh mục dịch vụ thành công!");
                LoadListTypeService();
                if (insertTypeService != null)
                    insertTypeService(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục dịch vụ!");
            }
        }

        private event EventHandler insertTypeService;

        public event EventHandler InsertTypeService
        {
            add { insertTypeService += value; }
            remove { insertTypeService -= value; }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            float PriceService = (float)Convert.ToDouble(txbPriceService.Text);
            string Service = txbService.Text;
            int TypeService = (cbTypeService.SelectedItem as Holtel_manager.DTO.TypeService).Id;

            if (ServiceDAO.Instance.InsertService(Service, TypeService, PriceService))
            {
                MessageBox.Show("Thêm dịch vụ thành công!");
                LoadListService();
                if (insertService != null)
                    insertService(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm dịch vụ!");
            }
        }

        private event EventHandler insertService;

        public event EventHandler InsertService
        {
            add { insertService += value; }
            remove { insertService -= value; }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string DisplayName = txbDisplayName.Text;
            string UserName = txbNameAccount.Text;
            int TypeAccount = (cbTypeAccount.SelectedItem as Holtel_manager.DTO.TypeAccount).Id;

            if (AccountDAO .Instance.InsertAccount(DisplayName, UserName, TypeAccount))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
                LoadListAccount();
                if (insertAccount != null)
                    insertAccount(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm tài khoản!");
            }
        }

        private event EventHandler insertAccount;

        public event EventHandler InsertAccount
        {
            add { insertAccount += value; }
            remove { insertAccount -= value; }
        }

        private void btnEditTypeRoom_Click(object sender, EventArgs e)
        {
            int idTypeRoom = Convert.ToInt32(txbIdTypeRoom.Text);
            float priceroom = (float)Convert.ToDouble(txbPriceRoom.Text);
            string nametyperoom = txbNameTypeRoom.Text;
            int numbed = Convert.ToInt32(txbNumberBed.Text);
            int television = Convert.ToInt32(txbTelevision.Text);
            int aircondition = Convert.ToInt32(txbAirCondition.Text);
            int numlight = Convert.ToInt32(txbNumberLight.Text);
            float deposits = (float)Convert.ToDouble(txbDeposits.Text);

            if (TypeRoomDAO.Instance.EditTypeRoom(idTypeRoom, priceroom, nametyperoom, numbed, television, aircondition, numlight, deposits))
            {
                MessageBox.Show("cập nhật dữ liệu thành công");
                LoadListTypeRoom();
                if (updateTypeRoom != null)
                    updateTypeRoom(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật thức ăn");
            }
        }

        private event EventHandler updateTypeRoom;
        public event EventHandler UpdateTypeRoom
        {
            add { updateTypeRoom += value; }
            remove { updateTypeRoom -= value; }
        }

        private void btnDeleteTypeRoom_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbIdTypeRoom.Text);

            if (TypeRoomDAO.Instance.DeleteTypeRoom(id))
            {
                MessageBox.Show("Xóa dữ liệu thành công");
                LoadListTypeRoom();
                if (deleteTypeRoom != null)
                    deleteTypeRoom(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }

        private event EventHandler deleteTypeRoom;
        public event EventHandler DeleteTypeRoom
        {
            add { deleteTypeRoom += value; }
            remove { deleteTypeRoom -= value; }
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            string RoomName = txbRoomName.Text;
            string status = txbStatus.Text;
            int TypeRoom = (cbTypeRoom.SelectedItem as Holtel_manager.DTO.TypeRoom).Id;
            int Id = Convert.ToInt32(txbRoomID.Text);

            if (RoomDAO.Instance.EditRoom(Id, RoomName, status, TypeRoom))
            {
                MessageBox.Show("Cập nhật phòng thành công!");
                LoadListRoom();
                if (updateRoom != null)
                    updateRoom(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật phòng!");
            }
        }

        private event EventHandler updateRoom;
        public event EventHandler UpdateRoom
        {
            add { updateRoom += value; }
            remove { updateRoom -= value; }
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbRoomID.Text);

            if (RoomDAO.Instance.DeleteRoom(id))
            {
                MessageBox.Show("Xóa dữ liệu thành công");
                LoadListRoom();
                if (deleteRoom != null)
                    deleteRoom(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }

        private event EventHandler deleteRoom;
        public event EventHandler DeleteRoom
        {
            add { deleteRoom += value; }
            remove { deleteRoom -= value; }
        }

        private void btnEditTypeService_Click(object sender, EventArgs e)
        {
            string TypeServiceName = txbTypeServiceName.Text;
            int idTypeservice = Convert.ToInt32(txbIdTypeService.Text);

            if (TypeServiceDAO.Instance.EditTypeService(idTypeservice, TypeServiceName))
            {
                MessageBox.Show("Cập nhật danh mục dịch vụ thành công!");
                LoadListTypeService();
                if (updateTypeService != null)
                    updateTypeService(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật danh mục dịch vụ!");
            }
        }

        private event EventHandler updateTypeService;
        public event EventHandler UpdateTypeService
        {
            add { updateTypeService += value; }
            remove { updateTypeService -= value; }
        }

        private void btnDeleteTypeService_Click(object sender, EventArgs e)
        {
            int idTypeservice = Convert.ToInt32(txbIdTypeService.Text);

            if (TypeServiceDAO.Instance.DeleteTypeService(idTypeservice))
            {
                MessageBox.Show("Xóa dữ liệu thành công");
                LoadListTypeService();
                if (deleteTypeService != null)
                    deleteTypeService(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa danh mục dịch vụ");
            }
        }

        private event EventHandler deleteTypeService;
        public event EventHandler DeleteTypeService
        {
            add { deleteTypeService += value; }
            remove { deleteTypeService -= value; }
        }

        private void btnEditService_Click(object sender, EventArgs e)
        {
            float PriceService = (float)Convert.ToDouble(txbPriceService.Text);
            string Service = txbService.Text;
            int TypeService = (cbTypeService.SelectedItem as Holtel_manager.DTO.TypeService).Id;
            int Idservice = Convert.ToInt32(txbIdService.Text);

            if (ServiceDAO.Instance.EditService(Idservice, Service, TypeService, PriceService))
            {
                MessageBox.Show("Cập nhậtdịch vụ thành công!");
                LoadListService();
                if (updateService != null)
                    updateService(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật dịch vụ!");
            }
        }

        private event EventHandler updateService;
        public event EventHandler UpdateService
        {
            add { updateService += value; }
            remove { updateService -= value; }
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            int idservice = Convert.ToInt32(txbIdService.Text);

            if (ServiceDAO.Instance.DeleteService(idservice))
            {
                MessageBox.Show("Xóa dữ liệu thành công");
                LoadListService();
                if (deleteService != null)
                    deleteService(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa dịch vụ");
            }
        }

        private event EventHandler deleteService;
        public event EventHandler DeleteService
        {
            add { deleteService += value; }
            remove { deleteService -= value; }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string DisplayName = txbDisplayName.Text;
            string UserName = txbNameAccount.Text;
            int TypeAccount = (cbTypeAccount.SelectedItem as Holtel_manager.DTO.TypeAccount).Id;
            if (AccountDAO.Instance.EditAccount(UserName, DisplayName, TypeAccount))
            {
                MessageBox.Show("Cập nhật tài khoản thành công!");
                LoadListAccount();
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật tài khoản!");
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string UserName = txbNameAccount.Text;

            if (AccountDAO.Instance.DeleteAccount(UserName))
            {
                MessageBox.Show("Xóa dữ liệu thành công");
                LoadListAccount();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa tài khoản");
            }
        }

        private void txbNameAccount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccount.SelectedCells.Count > 0)
                {
                    int id = (int)dgvAccount.SelectedCells[0].OwningRow.Cells["Type"].Value;

                    TypeAccount typeaccount = TypeAccountDAO.Instance.GetTypeAccountById(id);
                    cbTypeAccount.SelectedItem = typeaccount;

                    int index = -1;
                    int i = 0;
                    foreach (TypeAccount item in cbTypeAccount.Items)
                    {
                        if (item.Id == typeaccount.Id)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbTypeAccount.SelectedIndex = index;
                }
            }
            catch
            {

            }
        }

        private void txbIdService_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvService.SelectedCells.Count > 0)
                {
                    int id = (int)dgvService.SelectedCells[0].OwningRow.Cells["IdServiceCategory"].Value;

                    TypeService typeservice = TypeServiceDAO.Instance.GetTypeServiceById(id);
                    cbTypeService.SelectedItem = typeservice;

                    int index = -1;
                    int i = 0;
                    foreach (TypeService item in cbTypeService.Items)
                    {
                        if (item.Id == typeservice.Id)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbTypeService.SelectedIndex = index;
                }
            }
            catch
            {

            }
        }

        private void txbRoomID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvRoom.SelectedCells.Count > 0)
                {
                    int id = (int)dgvRoom.SelectedCells[0].OwningRow.Cells["TypeRoom"].Value;

                    TypeRoom typeroom = TypeRoomDAO.Instance.GetTypeRoomById(id);
                    cbTypeRoom.SelectedItem = typeroom;

                    int index = -1;
                    int i = 0;
                    foreach (TypeRoom item in cbTypeRoom.Items)
                    {
                        if (item.Id == typeroom.Id)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbTypeRoom.SelectedIndex = index;
                }
            }
            catch
            {

            }
        }

        void LoadListBillByDate(DateTime checkin, DateTime checkout)
        {
            dgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkin, checkout);
        }

        private void btnStatisfic_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dpkDateFrom.Value, dpkDateTo.Value);
        }

        private void btnPrivious_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPage.Text);
            if (page > 1)
                page--;
            txbPage.Text = page.ToString();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            txbPage.Text = "1";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPage.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dpkDateFrom.Value, dpkDateTo.Value);

            if (page < sumRecord)
                page++;
            txbPage.Text = page.ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dpkDateFrom.Value, dpkDateTo.Value);
            int lastPage = sumRecord / 10;
            if (sumRecord % 10 != 0)
                lastPage++;
            txbPage.Text = lastPage.ToString();
        }

        private void txbPage_TextChanged(object sender, EventArgs e)
        {
            dgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dpkDateFrom.Value, dpkDateTo.Value, Convert.ToInt32(txbPage.Text));
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dpkDateFrom.Value = new DateTime(today.Year, today.Month, 1);
            dpkDateTo.Value = dpkDateFrom.Value.AddMonths(1).AddDays(-1);
        }

        void ResetPass(string name)
        {
            if (AccountDAO.Instance.ResetPassword(name))
            {
                MessageBox.Show("Reset pass thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi khi reset pass!");
            }
        }

        private void txbResetPass_Click(object sender, EventArgs e)
        {
            string username = txbNameAccount.Text;
            ResetPass(username);
        }

        private void btnReportRevenue_Click(object sender, EventArgs e)
        {
            fReport f = new fReport(1);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fReport f = new fReport(2);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fReport f = new fReport(3);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fReport f = new fReport(4);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
