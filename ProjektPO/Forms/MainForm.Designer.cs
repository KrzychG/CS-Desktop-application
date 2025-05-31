using System.Windows.Forms;

namespace SystemZarzadzaniaUrzadzeniami.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblEmployees;
        private Label lblDevices;
        private DataGridView dgvEmployees;
        private DataGridView dgvDevices;
        private Button btnAddEmployee;
        private Button btnEditEmployee;
        private Button btnDeleteEmployee;
        private Button btnAddDevice;
        private Button btnEditDevice;
        private Button btnDeleteDevice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.btnDeleteDevice = new System.Windows.Forms.Button();
            this.btnEditEmployee = new System.Windows.Forms.Button();
            this.btnEditDevice = new System.Windows.Forms.Button();
            this.lblEmployees = new System.Windows.Forms.Label();
            this.lblDevices = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.Location = new System.Drawing.Point(10, 40);
            this.dgvEmployees.MultiSelect = false;
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(400, 300);
            this.dgvEmployees.TabIndex = 2;
            // 
            // dgvDevices
            // 
            this.dgvDevices.Location = new System.Drawing.Point(416, 40);
            this.dgvDevices.MultiSelect = false;
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.ReadOnly = true;
            this.dgvDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevices.Size = new System.Drawing.Size(450, 300);
            this.dgvDevices.TabIndex = 3;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(10, 350);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(120, 23);
            this.btnAddEmployee.TabIndex = 4;
            this.btnAddEmployee.Text = "Dodaj pracownika";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Location = new System.Drawing.Point(416, 350);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(120, 23);
            this.btnAddDevice.TabIndex = 7;
            this.btnAddDevice.Text = "Dodaj urządzenie";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Location = new System.Drawing.Point(270, 350);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(140, 23);
            this.btnDeleteEmployee.TabIndex = 6;
            this.btnDeleteEmployee.Text = "Usuń pracownika";
            this.btnDeleteEmployee.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDevice
            // 
            this.btnDeleteDevice.Location = new System.Drawing.Point(676, 350);
            this.btnDeleteDevice.Name = "btnDeleteDevice";
            this.btnDeleteDevice.Size = new System.Drawing.Size(120, 23);
            this.btnDeleteDevice.TabIndex = 9;
            this.btnDeleteDevice.Text = "Usuń urządzenie";
            this.btnDeleteDevice.UseVisualStyleBackColor = true;
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.Location = new System.Drawing.Point(140, 350);
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Size = new System.Drawing.Size(120, 23);
            this.btnEditEmployee.TabIndex = 5;
            this.btnEditEmployee.Text = "Edytuj pracownika";
            this.btnEditEmployee.UseVisualStyleBackColor = true;
            // 
            // btnEditDevice
            // 
            this.btnEditDevice.Location = new System.Drawing.Point(546, 350);
            this.btnEditDevice.Name = "btnEditDevice";
            this.btnEditDevice.Size = new System.Drawing.Size(120, 23);
            this.btnEditDevice.TabIndex = 8;
            this.btnEditDevice.Text = "Edytuj urządzenie";
            this.btnEditDevice.UseVisualStyleBackColor = true;
            // 
            // lblEmployees
            // 
            this.lblEmployees.Location = new System.Drawing.Point(10, 10);
            this.lblEmployees.Name = "lblEmployees";
            this.lblEmployees.Size = new System.Drawing.Size(100, 23);
            this.lblEmployees.TabIndex = 0;
            this.lblEmployees.Text = "Pracownicy";
            // 
            // lblDevices
            // 
            this.lblDevices.Location = new System.Drawing.Point(416, 10);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(100, 23);
            this.lblDevices.TabIndex = 1;
            this.lblDevices.Text = "Urządzenia";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(880, 400);
            this.Controls.Add(this.lblEmployees);
            this.Controls.Add(this.lblDevices);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.dgvDevices);
            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.btnEditEmployee);
            this.Controls.Add(this.btnDeleteEmployee);
            this.Controls.Add(this.btnAddDevice);
            this.Controls.Add(this.btnEditDevice);
            this.Controls.Add(this.btnDeleteDevice);
            this.Name = "MainForm";
            this.Text = "Panel zarządzania pracownikami i urządzeniami";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.ResumeLayout(false);

        }
    }
}