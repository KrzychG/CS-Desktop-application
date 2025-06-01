namespace SystemZarzadzaniaUrzadzeniami.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.Label lblEmployees;
        private System.Windows.Forms.Label lblDevices;

        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnEditEmployee;
        private System.Windows.Forms.Button btnDeleteEmployee;

        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.Button btnEditDevice;
        private System.Windows.Forms.Button btnDeleteDevice;

        private System.Windows.Forms.Button btnLoadDatabase;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.lblEmployees = new System.Windows.Forms.Label();
            this.lblDevices = new System.Windows.Forms.Label();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnEditEmployee = new System.Windows.Forms.Button();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.btnEditDevice = new System.Windows.Forms.Button();
            this.btnDeleteDevice = new System.Windows.Forms.Button();
            this.btnLoadDatabase = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.SuspendLayout();
            //
            // dgvEmployees
            //
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(10, 40);
            this.dgvEmployees.Size = new System.Drawing.Size(400, 400);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.TabIndex = 0;
            //
            // dgvDevices
            //
            this.dgvDevices.AllowUserToAddRows = false;
            this.dgvDevices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Location = new System.Drawing.Point(430, 40);
            this.dgvDevices.Size = new System.Drawing.Size(400, 400);
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.TabIndex = 1;
            //
            // lblEmployees
            //
            this.lblEmployees.AutoSize = true;
            this.lblEmployees.Location = new System.Drawing.Point(10, 15);
            this.lblEmployees.Name = "lblEmployees";
            this.lblEmployees.Size = new System.Drawing.Size(95, 13);
            this.lblEmployees.Text = "Lista pracowników";
            //
            // lblDevices
            //
            this.lblDevices.AutoSize = true;
            this.lblDevices.Location = new System.Drawing.Point(430, 15);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(75, 13);
            this.lblDevices.Text = "Lista urządzeń";
            //
            // btnAddEmployee
            //
            this.btnAddEmployee.Location = new System.Drawing.Point(10, 460);
            this.btnAddEmployee.Size = new System.Drawing.Size(130, 25);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Text = "Dodaj pracownika";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.BtnAddEmployee_Click);
            //
            // btnEditEmployee
            //
            this.btnEditEmployee.Location = new System.Drawing.Point(150, 460);
            this.btnEditEmployee.Size = new System.Drawing.Size(130, 25);
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Text = "Edytuj pracownika";
            this.btnEditEmployee.UseVisualStyleBackColor = true;
            this.btnEditEmployee.Click += new System.EventHandler(this.BtnEditEmployee_Click);
            //
            // btnDeleteEmployee
            //
            this.btnDeleteEmployee.Location = new System.Drawing.Point(290, 460);
            this.btnDeleteEmployee.Size = new System.Drawing.Size(130, 25);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Text = "Usuń pracownika";
            this.btnDeleteEmployee.UseVisualStyleBackColor = true;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.BtnDeleteEmployee_Click);
            //
            // btnAddDevice
            //
            this.btnAddDevice.Location = new System.Drawing.Point(430, 460);
            this.btnAddDevice.Size = new System.Drawing.Size(130, 25);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Text = "Dodaj urządzenie";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.BtnAddDevice_Click);
            //
            // btnEditDevice
            //
            this.btnEditDevice.Location = new System.Drawing.Point(570, 460);
            this.btnEditDevice.Size = new System.Drawing.Size(130, 25);
            this.btnEditDevice.Name = "btnEditDevice";
            this.btnEditDevice.Text = "Edytuj urządzenie";
            this.btnEditDevice.UseVisualStyleBackColor = true;
            this.btnEditDevice.Click += new System.EventHandler(this.BtnEditDevice_Click);
            //
            // btnDeleteDevice
            //
            this.btnDeleteDevice.Location = new System.Drawing.Point(710, 460);
            this.btnDeleteDevice.Size = new System.Drawing.Size(130, 25);
            this.btnDeleteDevice.Name = "btnDeleteDevice";
            this.btnDeleteDevice.Text = "Usuń urządzenie";
            this.btnDeleteDevice.UseVisualStyleBackColor = true;
            this.btnDeleteDevice.Click += new System.EventHandler(this.BtnDeleteDevice_Click);
            //
            // btnLoadDatabase
            //
            this.btnLoadDatabase.Location = new System.Drawing.Point(220, 10);
            this.btnLoadDatabase.Size = new System.Drawing.Size(130, 25);
            this.btnLoadDatabase.Name = "btnLoadDatabase";
            this.btnLoadDatabase.Text = "Załaduj bazę danych";
            this.btnLoadDatabase.UseVisualStyleBackColor = true;
            this.btnLoadDatabase.Click += new System.EventHandler(this.BtnLoadDatabase_Click);
            //
            // MainForm
            //
            this.ClientSize = new System.Drawing.Size(844, 511);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.dgvDevices);
            this.Controls.Add(this.lblEmployees);
            this.Controls.Add(this.lblDevices);
            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.btnEditEmployee);
            this.Controls.Add(this.btnDeleteEmployee);
            this.Controls.Add(this.btnAddDevice);
            this.Controls.Add(this.btnEditDevice);
            this.Controls.Add(this.btnDeleteDevice);
            this.Controls.Add(this.btnLoadDatabase);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.Text = "System Zarządzania Urządzeniami";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
