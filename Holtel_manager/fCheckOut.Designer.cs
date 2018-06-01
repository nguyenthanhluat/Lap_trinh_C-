namespace Holtel_manager
{
    partial class fCheckOut
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.flpRoomService = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txbSearchRoom = new System.Windows.Forms.TextBox();
            this.btnSearchCheckIn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel6 = new System.Windows.Forms.Panel();
            this.txbTotalPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txbDeposit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txbPriceRoom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txbNameRoom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel39 = new System.Windows.Forms.Panel();
            this.txbNameCus = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel39.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flpRoomService);
            this.panel3.Location = new System.Drawing.Point(2, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(551, 409);
            this.panel3.TabIndex = 12;
            // 
            // flpRoomService
            // 
            this.flpRoomService.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flpRoomService.Location = new System.Drawing.Point(3, 4);
            this.flpRoomService.Name = "flpRoomService";
            this.flpRoomService.Size = new System.Drawing.Size(545, 402);
            this.flpRoomService.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txbSearchRoom);
            this.panel4.Controls.Add(this.btnSearchCheckIn);
            this.panel4.Location = new System.Drawing.Point(2, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(551, 56);
            this.panel4.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "Name Room:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbSearchRoom
            // 
            this.txbSearchRoom.Location = new System.Drawing.Point(150, 20);
            this.txbSearchRoom.Name = "txbSearchRoom";
            this.txbSearchRoom.Size = new System.Drawing.Size(259, 20);
            this.txbSearchRoom.TabIndex = 11;
            // 
            // btnSearchCheckIn
            // 
            this.btnSearchCheckIn.BackColor = System.Drawing.Color.Honeydew;
            this.btnSearchCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchCheckIn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCheckIn.ForeColor = System.Drawing.Color.Blue;
            this.btnSearchCheckIn.Location = new System.Drawing.Point(415, 6);
            this.btnSearchCheckIn.Name = "btnSearchCheckIn";
            this.btnSearchCheckIn.Size = new System.Drawing.Size(133, 45);
            this.btnSearchCheckIn.TabIndex = 3;
            this.btnSearchCheckIn.Text = "Search";
            this.btnSearchCheckIn.UseVisualStyleBackColor = false;
            this.btnSearchCheckIn.Click += new System.EventHandler(this.btnSearchCheckIn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cyan;
            this.panel1.Controls.Add(this.lsvBill);
            this.panel1.Location = new System.Drawing.Point(557, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 212);
            this.panel1.TabIndex = 14;
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lsvBill.GridLines = true;
            this.lsvBill.Location = new System.Drawing.Point(2, 3);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(442, 206);
            this.lsvBill.TabIndex = 1;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tên món";
            this.columnHeader5.Width = 144;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Số lượng";
            this.columnHeader6.Width = 79;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Giá";
            this.columnHeader7.Width = 96;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Thành tiền";
            this.columnHeader8.Width = 119;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Cyan;
            this.panel6.Controls.Add(this.txbTotalPrice);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.btnCheckOut);
            this.panel6.Location = new System.Drawing.Point(557, 429);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(448, 42);
            this.panel6.TabIndex = 15;
            // 
            // txbTotalPrice
            // 
            this.txbTotalPrice.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.txbTotalPrice.Location = new System.Drawing.Point(126, 11);
            this.txbTotalPrice.Name = "txbTotalPrice";
            this.txbTotalPrice.ReadOnly = true;
            this.txbTotalPrice.Size = new System.Drawing.Size(204, 22);
            this.txbTotalPrice.TabIndex = 3;
            this.txbTotalPrice.Text = "0";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Total Bill:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.Honeydew;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCheckOut.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.ForeColor = System.Drawing.Color.Blue;
            this.btnCheckOut.Location = new System.Drawing.Point(336, 3);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(109, 36);
            this.btnCheckOut.TabIndex = 3;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Cyan;
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel39);
            this.panel2.Location = new System.Drawing.Point(557, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 205);
            this.panel2.TabIndex = 16;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel8.Controls.Add(this.txbDeposit);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Location = new System.Drawing.Point(3, 153);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(437, 43);
            this.panel8.TabIndex = 7;
            // 
            // txbDeposit
            // 
            this.txbDeposit.Location = new System.Drawing.Point(164, 12);
            this.txbDeposit.Name = "txbDeposit";
            this.txbDeposit.ReadOnly = true;
            this.txbDeposit.Size = new System.Drawing.Size(270, 20);
            this.txbDeposit.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(9, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Deposit:";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel7.Controls.Add(this.txbPriceRoom);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Location = new System.Drawing.Point(3, 104);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(437, 43);
            this.panel7.TabIndex = 7;
            // 
            // txbPriceRoom
            // 
            this.txbPriceRoom.Location = new System.Drawing.Point(164, 12);
            this.txbPriceRoom.Name = "txbPriceRoom";
            this.txbPriceRoom.ReadOnly = true;
            this.txbPriceRoom.Size = new System.Drawing.Size(270, 20);
            this.txbPriceRoom.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Price Room:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel5.Controls.Add(this.txbNameRoom);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(3, 55);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(437, 43);
            this.panel5.TabIndex = 7;
            // 
            // txbNameRoom
            // 
            this.txbNameRoom.Location = new System.Drawing.Point(164, 12);
            this.txbNameRoom.Name = "txbNameRoom";
            this.txbNameRoom.ReadOnly = true;
            this.txbNameRoom.Size = new System.Drawing.Size(270, 20);
            this.txbNameRoom.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name Room:";
            // 
            // panel39
            // 
            this.panel39.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel39.Controls.Add(this.txbNameCus);
            this.panel39.Controls.Add(this.label23);
            this.panel39.Location = new System.Drawing.Point(3, 6);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(437, 43);
            this.panel39.TabIndex = 7;
            // 
            // txbNameCus
            // 
            this.txbNameCus.Location = new System.Drawing.Point(164, 12);
            this.txbNameCus.Name = "txbNameCus";
            this.txbNameCus.ReadOnly = true;
            this.txbNameCus.Size = new System.Drawing.Size(270, 20);
            this.txbNameCus.TabIndex = 0;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Blue;
            this.label23.Location = new System.Drawing.Point(9, 11);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(138, 19);
            this.label23.TabIndex = 3;
            this.label23.Text = "Name Customer:";
            // 
            // fCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 474);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "fCheckOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fCheckOut";
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel39.ResumeLayout(false);
            this.panel39.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSearchCheckIn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txbTotalPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbSearchRoom;
        private System.Windows.Forms.FlowLayoutPanel flpRoomService;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txbDeposit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txbPriceRoom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txbNameRoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel39;
        private System.Windows.Forms.TextBox txbNameCus;
        private System.Windows.Forms.Label label23;
    }
}