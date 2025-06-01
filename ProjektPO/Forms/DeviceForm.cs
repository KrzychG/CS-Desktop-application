using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SystemZarzadzaniaUrzadzeniami.Service;

namespace SystemZarzadzaniaUrzadzeniami.Forms
{
    public partial class DeviceForm : Form
    {
        public Device DeviceData { get; private set; }
        private List<Employee> employees;

        public DeviceForm()
        {
            InitializeComponent();
            this.Text = "Dodaj urządzenie";
        }

        public DeviceForm(Device existingDevice) : this()
        {
            this.Text = "Edytuj urządzenie";
            txtName.Text = existingDevice.Name;
            txtSerial.Text = existingDevice.SerialNumber;
            DeviceData = existingDevice;
            dtpPurchaseDate.Value = existingDevice.PurchaseDate;
        }

        private void DeviceForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();

            if (DeviceData != null && DeviceData.EmployeeId.HasValue)
            {
                int index = employees.FindIndex(emp => emp.Id == DeviceData.EmployeeId.Value);
                if (index >= 0)
                    cmbEmployee.SelectedIndex = index + 1;
            }
            else
            {
                cmbEmployee.SelectedIndex = 0;
            }
        }

        private void LoadEmployees()
        {
            var db = new DatabaseService();
            employees = db.GetEmployees();

            cmbEmployee.Items.Clear();
            cmbEmployee.Items.Add("Brak pracownika");

            foreach (var emp in employees)
            {
                cmbEmployee.Items.Add($"{emp.Id} - {emp.FirstName} {emp.LastName}");
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSerial.Text) || cmbEmployee.SelectedIndex < 0)
            {
                MessageBox.Show("Wszystkie pola są wymagane", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DeviceData == null)
            {
                DeviceData = new Device();
            }

            DeviceData.Name = txtName.Text.Trim();
            DeviceData.SerialNumber = txtSerial.Text.Trim();

            if (cmbEmployee.SelectedIndex == 0)
                DeviceData.EmployeeId = null; 
            else
                DeviceData.EmployeeId = employees[cmbEmployee.SelectedIndex - 1].Id;

            DeviceData.PurchaseDate = dtpPurchaseDate.Value.Date;

            DialogResult = DialogResult.OK;
            Close();
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
