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
    public partial class fAccount : Form
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
                ChangeAccount(loginAccount);
            }
        }

        public fAccount(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        #region method
        void ChangeAccount(Account acc)
        {
            txbUserName.Text = LoginAccount.Username;
            txbDisplayName.Text = LoginAccount.Displayname;
        }

        void UpdateAcountInfo()
        {
            string displayname = txbDisplayName.Text;
            string password = txbPassword.Text;
            string newpass = txbNewPassword.Text;
            string reenterPass = txbRePassword.Text;
            string username = txbUserName.Text;

            if (!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(username, displayname, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUsername(username)));
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu!");
                }
            }
        }
        #endregion

        #region event
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private event EventHandler<AccountEvent> updateAccount;

        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAcountInfo();
        }
        #endregion

        public class AccountEvent:EventArgs
        {
            private Account acc;

            public Account Acc
            {
                get
                {
                    return acc;
                }

                set
                {
                    acc = value;
                }
            }
            public AccountEvent(Account acc)
            {
                this.Acc = acc;
            }
        }
    }
}
