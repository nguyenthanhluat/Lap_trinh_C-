namespace Holtel_manager
{
    partial class fReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.USP_GetListBillByDateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Holtel_managerDataSet = new Holtel_manager.Holtel_managerDataSet();
            this.USP_GetListRoomForReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Holtel_managerDataSet1 = new Holtel_manager.Holtel_managerDataSet1();
            this.USP_GetListServiceForReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Holtel_managerDataSet2 = new Holtel_manager.Holtel_managerDataSet2();
            this.USP_GetListCustomerForReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Holtel_managerDataSet3 = new Holtel_manager.Holtel_managerDataSet3();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.reportViewer4 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.USP_GetListBillByDateTableAdapter = new Holtel_manager.Holtel_managerDataSetTableAdapters.USP_GetListBillByDateTableAdapter();
            this.USP_GetListRoomForReportTableAdapter = new Holtel_manager.Holtel_managerDataSet1TableAdapters.USP_GetListRoomForReportTableAdapter();
            this.USP_GetListServiceForReportTableAdapter = new Holtel_manager.Holtel_managerDataSet2TableAdapters.USP_GetListServiceForReportTableAdapter();
            this.USP_GetListCustomerForReportTableAdapter = new Holtel_manager.Holtel_managerDataSet3TableAdapters.USP_GetListCustomerForReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Holtel_managerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListRoomForReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Holtel_managerDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListServiceForReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Holtel_managerDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListCustomerForReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Holtel_managerDataSet3)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // USP_GetListBillByDateBindingSource
            // 
            this.USP_GetListBillByDateBindingSource.DataMember = "USP_GetListBillByDate";
            this.USP_GetListBillByDateBindingSource.DataSource = this.Holtel_managerDataSet;
            // 
            // Holtel_managerDataSet
            // 
            this.Holtel_managerDataSet.DataSetName = "Holtel_managerDataSet";
            this.Holtel_managerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_GetListRoomForReportBindingSource
            // 
            this.USP_GetListRoomForReportBindingSource.DataMember = "USP_GetListRoomForReport";
            this.USP_GetListRoomForReportBindingSource.DataSource = this.Holtel_managerDataSet1;
            // 
            // Holtel_managerDataSet1
            // 
            this.Holtel_managerDataSet1.DataSetName = "Holtel_managerDataSet1";
            this.Holtel_managerDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_GetListServiceForReportBindingSource
            // 
            this.USP_GetListServiceForReportBindingSource.DataMember = "USP_GetListServiceForReport";
            this.USP_GetListServiceForReportBindingSource.DataSource = this.Holtel_managerDataSet2;
            // 
            // Holtel_managerDataSet2
            // 
            this.Holtel_managerDataSet2.DataSetName = "Holtel_managerDataSet2";
            this.Holtel_managerDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_GetListCustomerForReportBindingSource
            // 
            this.USP_GetListCustomerForReportBindingSource.DataMember = "USP_GetListCustomerForReport";
            this.USP_GetListCustomerForReportBindingSource.DataSource = this.Holtel_managerDataSet3;
            // 
            // Holtel_managerDataSet3
            // 
            this.Holtel_managerDataSet3.DataSetName = "Holtel_managerDataSet3";
            this.Holtel_managerDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(1, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 466);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reportViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Report Revenue";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_GetListBillByDateBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Holtel_manager.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1000, 440);
            this.reportViewer1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1000, 440);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Report Room";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reportViewer2
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.USP_GetListRoomForReportBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Holtel_manager.Report2.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(1000, 440);
            this.reportViewer2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.reportViewer3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1000, 440);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Report Service";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // reportViewer3
            // 
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.USP_GetListServiceForReportBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "Holtel_manager.Report3.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(4, 4);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(993, 433);
            this.reportViewer3.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.reportViewer4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1000, 440);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Report Customer";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // reportViewer4
            // 
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.USP_GetListCustomerForReportBindingSource;
            this.reportViewer4.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer4.LocalReport.ReportEmbeddedResource = "Holtel_manager.Report4.rdlc";
            this.reportViewer4.Location = new System.Drawing.Point(4, 4);
            this.reportViewer4.Name = "reportViewer4";
            this.reportViewer4.Size = new System.Drawing.Size(993, 433);
            this.reportViewer4.TabIndex = 0;
            // 
            // USP_GetListBillByDateTableAdapter
            // 
            this.USP_GetListBillByDateTableAdapter.ClearBeforeFill = true;
            // 
            // USP_GetListRoomForReportTableAdapter
            // 
            this.USP_GetListRoomForReportTableAdapter.ClearBeforeFill = true;
            // 
            // USP_GetListServiceForReportTableAdapter
            // 
            this.USP_GetListServiceForReportTableAdapter.ClearBeforeFill = true;
            // 
            // USP_GetListCustomerForReportTableAdapter
            // 
            this.USP_GetListCustomerForReportTableAdapter.ClearBeforeFill = true;
            // 
            // fReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 470);
            this.Controls.Add(this.tabControl1);
            this.Name = "fReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.fReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Holtel_managerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListRoomForReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Holtel_managerDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListServiceForReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Holtel_managerDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListCustomerForReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Holtel_managerDataSet3)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_GetListBillByDateBindingSource;
        private Holtel_managerDataSet Holtel_managerDataSet;
        private Holtel_managerDataSetTableAdapters.USP_GetListBillByDateTableAdapter USP_GetListBillByDateTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource USP_GetListRoomForReportBindingSource;
        private Holtel_managerDataSet1 Holtel_managerDataSet1;
        private Holtel_managerDataSet1TableAdapters.USP_GetListRoomForReportTableAdapter USP_GetListRoomForReportTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.BindingSource USP_GetListServiceForReportBindingSource;
        private Holtel_managerDataSet2 Holtel_managerDataSet2;
        private Holtel_managerDataSet2TableAdapters.USP_GetListServiceForReportTableAdapter USP_GetListServiceForReportTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer4;
        private System.Windows.Forms.BindingSource USP_GetListCustomerForReportBindingSource;
        private Holtel_managerDataSet3 Holtel_managerDataSet3;
        private Holtel_managerDataSet3TableAdapters.USP_GetListCustomerForReportTableAdapter USP_GetListCustomerForReportTableAdapter;
    }
}