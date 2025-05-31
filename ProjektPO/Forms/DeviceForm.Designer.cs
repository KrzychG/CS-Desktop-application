using System.Windows.Forms;

namespace SystemZarzadzaniaUrzadzeniami.Forms
{
    partial class DeviceForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label lblPurchaseDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblSerial = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(12, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(120, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nazwa urządzenia:";
            this.lblName.Anchor = AnchorStyles.Top | AnchorStyles.Right;  // <-- dodane
                                                                          //
                                                                          // txtName
                                                                          //
            this.txtName.Location = new System.Drawing.Point(140, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //
            // lblSerial
            //
            this.lblSerial.Location = new System.Drawing.Point(12, 45);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(120, 23);
            this.lblSerial.TabIndex = 2;
            this.lblSerial.Text = "Numer seryjny:";
            this.lblSerial.Anchor = AnchorStyles.Top | AnchorStyles.Right;  // <-- dodane
                                                                            //
                                                                            // txtSerial
                                                                            //
            this.txtSerial.Location = new System.Drawing.Point(140, 42);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(200, 20);
            this.txtSerial.TabIndex = 3;
            this.txtSerial.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //
            // lblEmployee
            //
            this.lblEmployee.Location = new System.Drawing.Point(12, 75);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(120, 23);
            this.lblEmployee.TabIndex = 6;
            this.lblEmployee.Text = "Pracownik:";
            this.lblEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;  // <-- dodane
                                                                              //
                                                                              // cmbEmployee
                                                                              //
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.Location = new System.Drawing.Point(140, 72);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(200, 21);
            this.cmbEmployee.TabIndex = 7;
            this.cmbEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //
            // lblPurchaseDate
            //
            this.lblPurchaseDate.Location = new System.Drawing.Point(12, 105);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(120, 23);
            this.lblPurchaseDate.TabIndex = 8;
            this.lblPurchaseDate.Text = "Data zakupu:";
            this.lblPurchaseDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;  // <-- dodane
                                                                                  //
                                                                                  // dtpPurchaseDate
                                                                                  //
            this.dtpPurchaseDate.Location = new System.Drawing.Point(140, 102);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(200, 20);
            this.dtpPurchaseDate.TabIndex = 9;
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchaseDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(185, 135);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            this.btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(265, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            //
            // DeviceForm
            //
            this.ClientSize = new System.Drawing.Size(360, 180);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.lblPurchaseDate);
            this.Controls.Add(this.dtpPurchaseDate);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.MinimumSize = new System.Drawing.Size(380, 220);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Name = "DeviceForm";
            this.Load += new System.EventHandler(this.DeviceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
