using CoffeeManage.DAO;
using CoffeeManage.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManage
{
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        public Account loginAccount;
        public fAdmin()
        {
            InitializeComponent();
            dgvFood.DataSource = foodList;
            dgvAccount.DataSource = accountList;
            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkDateFrom.Value, dtpkDateTo.Value);
            LoadListFood();
            LoadAccount();
            LoadCategoryIntoCmb(cbCategory);
            AddFoodBinding();
            AddAcountBinding();
        }

        #region methods
        void AddAcountBinding()
        {
            txbAccountName.DataBindings.Add(new Binding("TEXT", dgvAccount.DataSource, "Username", true, DataSourceUpdateMode.Never));
            txbDisplayname.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Displayname", true, DataSourceUpdateMode.Never));
            nmAccount.DataBindings.Add(new Binding("Value", dgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        List<Food> SearchFoodName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);
            return listFood;
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkDateFrom.Value = new DateTime(today.Year, today.Month, 1);
            dtpkDateTo.Value = dtpkDateFrom.Value.AddMonths(1).AddDays(-1);
        }

        void LoadListBillByDate(DateTime checkin, DateTime checkout)
        {
            dgvBill.DataSource =  BillDAO.Instance.GetBillListByDate(checkin, checkout);
        }

        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

        void AddFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "name", true, DataSourceUpdateMode.Never));
            txbFoodId.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "Id", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("value", dgvFood.DataSource, "price", true, DataSourceUpdateMode.Never));
        }

        void LoadCategoryIntoCmb(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "name";
        }

        void AddAccount(string username, string displayname, int type)
        {
            if (AccountDAO.Instance.InsertAccount(username, displayname, type))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm tài khoản!");
            }
            LoadAccount();
        }

        void EditAccount(string username, string displayname, int type)
        {
            if (AccountDAO.Instance.EditAccount(username, displayname, type))
            {
                MessageBox.Show("Cập nhật khoản thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi khi Cập nhật tài khoản!");
            }
            LoadAccount();
        }

        void DeleteAccount(string username)
        {
            if (loginAccount.Username.Equals(username))
            {
                MessageBox.Show("Tài khoản đang đăng nhập, không thể xóa!");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(username))
            {
                MessageBox.Show("Xóa khoản thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa tài khoản!");
            }
            LoadAccount();
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
        #endregion

        #region event
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkDateFrom.Value, dtpkDateTo.Value);
        }
        
        private void btnViewFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void txbFoodId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvFood.SelectedCells.Count > 0)
                {
                    int id = (int)dgvFood.SelectedCells[0].OwningRow.Cells["IdCategory"].Value;

                    Category category = CategoryDAO.Instance.GetCategoryById(id);
                    cbCategory.SelectedItem = category;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbCategory.Items)
                    {
                        if (item.Id == category.Id)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbCategory.SelectedIndex = index;

                }
            }
            catch
            {

            }
            
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryId = (cbCategory.SelectedItem as Category).Id;
            float price = (float)nmFoodPrice.Value;

            if(FoodDAO.Instance.InsertFood(name,categoryId,price))
            {
                MessageBox.Show("Thêm mới dữ liệu thành công");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryId = (cbCategory.SelectedItem as Category).Id;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodId.Text);

            if (FoodDAO.Instance.EditFood(id,name, categoryId, price))
            {
                MessageBox.Show("cập nhật dữ liệu thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi cập nhật thức ăn");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodId.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa dữ liệu thành công");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }

        private event EventHandler insertFood;

        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
           foodList.DataSource = SearchFoodName(txbsearchFoodName.Text);
        }

        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string username = txbAccountName.Text;
            string displayname = txbDisplayname.Text;
            int type = (int)nmAccount.Value;
            AddAccount(username, displayname, type);
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string username = txbAccountName.Text;
            string displayname = txbDisplayname.Text;
            int type = (int)nmAccount.Value;
            EditAccount(username, displayname, type);
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string username = txbAccountName.Text;
            DeleteAccount(username);
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            string username = txbAccountName.Text;
            ResetPass(username);
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'CoffeeManageDataSet.USP_DetListBillByDateforReport' table. You can move, or remove it, as needed.
            this.USP_DetListBillByDateforReportTableAdapter.Fill(this.CoffeeManageDataSet.USP_DetListBillByDateforReport,dtpkDateFrom.Value,dtpkDateTo.Value);

            this.reportViewer1.RefreshReport();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            txbPage.Text = "1";
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkDateFrom.Value, dtpkDateTo.Value);
            int lastPage = sumRecord / 10;
            if (sumRecord % 10 != 0)
                lastPage++;
            txbPage.Text = lastPage.ToString();
        }

        private void txbPage_TextChanged(object sender, EventArgs e)
        {
            dgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkDateFrom.Value, dtpkDateTo.Value, Convert.ToInt32(txbPage.Text));
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPage.Text);
            if (page > 1)
                page--;
            txbPage.Text = page.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPage.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkDateFrom.Value, dtpkDateTo.Value);

            if(page<sumRecord)
                page++;
            txbPage.Text = page.ToString();
        }
        #endregion
    }
}
