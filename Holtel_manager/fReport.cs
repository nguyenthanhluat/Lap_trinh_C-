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
    public partial class fReport : Form
    {
        public fReport(int abc)
        {
            InitializeComponent();
            change(abc);
        }

        void change(int abc)
        {
            if(abc == 1)
            {
                tabControl1.SelectedIndex = 0;
                reportViewer2.Enabled = false;
                reportViewer3.Enabled = false;
                reportViewer4.Enabled = false;
            }
            else if(abc == 2)
            {
                tabControl1.SelectedIndex = 1;
                reportViewer1.Enabled = false;
                reportViewer3.Enabled = false;
                reportViewer4.Enabled = false;
            }
            else if(abc == 3)
            {
                tabControl1.SelectedIndex = 2;
                reportViewer1.Enabled = false;
                reportViewer2.Enabled = false;
                reportViewer4.Enabled = false;
            }
            else
            {
                tabControl1.SelectedIndex = 3;
                reportViewer1.Enabled = false;
                reportViewer2.Enabled = false;
                reportViewer3.Enabled = false;
            }
        }

        private void fReport_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            DateTime datefrom = new DateTime(today.Year, today.Month, 1);
            DateTime dateto = datefrom.AddMonths(1).AddDays(-1);

            // TODO: This line of code loads data into the 'Holtel_managerDataSet3.USP_GetListCustomerForReport' table. You can move, or remove it, as needed.
            this.USP_GetListCustomerForReportTableAdapter.Fill(this.Holtel_managerDataSet3.USP_GetListCustomerForReport, datefrom, dateto);

            // TODO: This line of code loads data into the 'Holtel_managerDataSet2.USP_GetListServiceForReport' table. You can move, or remove it, as needed.
            this.USP_GetListServiceForReportTableAdapter.Fill(this.Holtel_managerDataSet2.USP_GetListServiceForReport, datefrom, dateto);

            // TODO: This line of code loads data into the 'Holtel_managerDataSet1.USP_GetListRoomForReport' table. You can move, or remove it, as needed.
            this.USP_GetListRoomForReportTableAdapter.Fill(this.Holtel_managerDataSet1.USP_GetListRoomForReport,datefrom,dateto);
            
            // TODO: This line of code loads data into the 'Holtel_managerDataSet.USP_GetListBillByDate' table. You can move, or remove it, as needed.
            this.USP_GetListBillByDateTableAdapter.Fill(this.Holtel_managerDataSet.USP_GetListBillByDate, datefrom, dateto);

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
            this.reportViewer4.RefreshReport();
        }
    }
}
