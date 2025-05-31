using System;
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
            this.dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.dgvDevices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            // MainForm - minimalny rozmiar i tytuł
            // 
            this.ClientSize = new System.Drawing.Size(880, 450);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "MainForm";
            this.Text = "Panel zarządzania pracownikami i urządzeniami";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
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
            this.lblDevices.Location = new System.Drawing.Point(450, 10);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(100, 23);
            this.lblDevices.TabIndex = 1;
            this.lblDevices.Text = "Urządzenia";
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.Location = new System.Drawing.Point(10, 40);
            this.dgvEmployees.MultiSelect = false;
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.TabIndex = 2;
            // 
            // dgvDevices
            // 
            this.dgvDevices.Location = new System.Drawing.Point(450, 40);
            this.dgvDevices.MultiSelect = false;
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.ReadOnly = true;
            this.dgvDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevices.TabIndex = 3;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.TabIndex = 4;
            this.btnAddEmployee.Text = "Dodaj pracownika";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.TabIndex = 5;
            this.btnEditEmployee.Text = "Edytuj pracownika";
            this.btnEditEmployee.UseVisualStyleBackColor = true;
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.TabIndex = 6;
            this.btnDeleteEmployee.Text = "Usuń pracownika";
            this.btnDeleteEmployee.UseVisualStyleBackColor = true;
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.TabIndex = 7;
            this.btnAddDevice.Text = "Dodaj urządzenie";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            // 
            // btnEditDevice
            // 
            this.btnEditDevice.Name = "btnEditDevice";
            this.btnEditDevice.TabIndex = 8;
            this.btnEditDevice.Text = "Edytuj urządzenie";
            this.btnEditDevice.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDevice
            // 
            this.btnDeleteDevice.Name = "btnDeleteDevice";
            this.btnDeleteDevice.TabIndex = 9;
            this.btnDeleteDevice.Text = "Usuń urządzenie";
            this.btnDeleteDevice.UseVisualStyleBackColor = true;

            // Dodaj kontrolki
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

            this.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.ResumeLayout(false);

            // Ustaw początkowe rozmiary i pozycje
            AdjustLayout();
        }

        // Event handler Resize
        private void MainForm_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        // Metoda do dynamicznego układu kontrolek
        private void AdjustLayout()
        {
            int margin = 10;
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            // szerokość każdej DataGridView: połowa szerokości okna minus marginesy
            int dgvWidth = (width - 3 * margin) / 2;
            int dgvHeight = height - 90; // zostawiamy miejsce na labelki i przyciski

            // Pozycja i rozmiar DataGridViews
            dgvEmployees.SetBounds(margin, 40, dgvWidth, dgvHeight);
            dgvDevices.SetBounds(margin * 2 + dgvWidth, 40, dgvWidth, dgvHeight);

            // Labelki nad DataGridView
            lblEmployees.Location = new System.Drawing.Point(margin, 10);
            lblDevices.Location = new System.Drawing.Point(margin * 2 + dgvWidth, 10);

            // Przycisk pracownicy - pod dgvEmployees
            int btnWidth = 120;
            int btnHeight = 23;
            int btnTop = 40 + dgvHeight + margin;

            btnAddEmployee.SetBounds(margin, btnTop, btnWidth, btnHeight);
            btnEditEmployee.SetBounds(margin + btnWidth + margin, btnTop, btnWidth, btnHeight);
            btnDeleteEmployee.SetBounds(margin + 2 * (btnWidth + margin), btnTop, btnWidth, btnHeight);

            // Przycisk urządzenia - pod dgvDevices
            int deviceBtnLeft = margin * 2 + dgvWidth;

            btnAddDevice.SetBounds(deviceBtnLeft, btnTop, btnWidth, btnHeight);
            btnEditDevice.SetBounds(deviceBtnLeft + btnWidth + margin, btnTop, btnWidth, btnHeight);
            btnDeleteDevice.SetBounds(deviceBtnLeft + 2 * (btnWidth + margin), btnTop, btnWidth, btnHeight);
        }
    }
}