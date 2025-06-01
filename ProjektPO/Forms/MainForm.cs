using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SystemZarzadzaniaUrzadzeniami.Service;
using Npgsql;

namespace SystemZarzadzaniaUrzadzeniami.Forms
{
    public partial class MainForm : Form
    {
        private DatabaseService dbService = new DatabaseService();
        private BindingSource employeesBinding = new BindingSource();
        private BindingSource devicesBinding = new BindingSource();

        private List<Employee> employees = new List<Employee>();
        private List<Device> devices = new List<Device>();

        public MainForm()
        {
            InitializeComponent();
            this.Load += (s, e) => InitializeData();
            this.Resize += (s, e) => AdjustLayout();
        }

        private void InitializeData()
        {
            LoadEmployees();
            LoadDevices();
            AdjustLayout();
        }

        private void BtnLoadDatabase_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var conn = new NpgsqlConnection(dbService.ConnectionString))
                        {
                            conn.Open();
                            foreach (var file in openFileDialog.FileNames)
                            {
                                string sql = System.IO.File.ReadAllText(file);
                                using (var cmd = new NpgsqlCommand(sql, conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        MessageBox.Show("Baza danych została pomyślnie załadowana.");
                        LoadEmployees();
                        LoadDevices();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd podczas ładowania bazy: " + ex.Message);
                    }
                }
            }
        }

        private void LoadEmployees()
        {
            try
            {
                employees = dbService.GetEmployees();
                employeesBinding.DataSource = employees;
                dgvEmployees.DataSource = employeesBinding;
                dgvEmployees.AllowUserToAddRows = false;

                if (dgvEmployees.Columns[nameof(Employee.Id)] != null)
                    dgvEmployees.Columns[nameof(Employee.Id)].HeaderText = "ID";
                if (dgvEmployees.Columns[nameof(Employee.FirstName)] != null)
                    dgvEmployees.Columns[nameof(Employee.FirstName)].HeaderText = "Imię";
                if (dgvEmployees.Columns[nameof(Employee.LastName)] != null)
                    dgvEmployees.Columns[nameof(Employee.LastName)].HeaderText = "Nazwisko";
                if (dgvEmployees.Columns[nameof(Employee.Department)] != null)
                    dgvEmployees.Columns[nameof(Employee.Department)].HeaderText = "Dział";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania pracowników: " + ex.Message);
            }
        }

        private void LoadDevices()
        {
            try
            {
                devices = dbService.GetDevices();
                devicesBinding.DataSource = devices;
                dgvDevices.DataSource = devicesBinding;
                dgvDevices.AllowUserToAddRows = false;

                if (dgvDevices.Columns[nameof(Device.Id)] != null)
                    dgvDevices.Columns[nameof(Device.Id)].Visible = false;
                if (dgvDevices.Columns[nameof(Device.Name)] != null)
                    dgvDevices.Columns[nameof(Device.Name)].HeaderText = "Nazwa";
                if (dgvDevices.Columns[nameof(Device.SerialNumber)] != null)
                    dgvDevices.Columns[nameof(Device.SerialNumber)].HeaderText = "Numer seryjny";
                if (dgvDevices.Columns[nameof(Device.PurchaseDate)] != null)
                    dgvDevices.Columns[nameof(Device.PurchaseDate)].HeaderText = "Data zakupu";
                if (dgvDevices.Columns[nameof(Device.EmployeeId)] != null)
                    dgvDevices.Columns[nameof(Device.EmployeeId)].HeaderText = "Pracownik ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania urządzeń: " + ex.Message);
            }
        }

        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            using (var form = new EmployeeForm())
            {

                form.StartPosition = FormStartPosition.Manual;
                form.Location = new System.Drawing.Point(
                    this.Location.X + (this.Width - form.Width) / 2,
                    this.Location.Y + (this.Height - form.Height) / 2
                );

                if (form.ShowDialog() == DialogResult.OK)
                {
                    dbService.AddEmployee(form.EmployeeData);
                    LoadEmployees();
                }
            }
        }

        private void BtnEditEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("Wybierz pracownika.");
                return;
            }

            var employee = (Employee)dgvEmployees.CurrentRow.DataBoundItem;

            using (var form = new EmployeeForm(employee))
            {

                form.StartPosition = FormStartPosition.Manual;
                form.Location = new System.Drawing.Point(
                    this.Location.X + (this.Width - form.Width) / 2,
                    this.Location.Y + (this.Height - form.Height) / 2
                );

                if (form.ShowDialog() == DialogResult.OK)
                {
                    dbService.UpdateEmployee(form.EmployeeData);
                    LoadEmployees();
                }
            }
        }

        private void BtnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("Wybierz pracownika.");
                return;
            }

            var employee = (Employee)dgvEmployees.CurrentRow.DataBoundItem;

            if (MessageBox.Show("Usunąć " + employee.FirstName + " " + employee.LastName + "?", "Potwierdź", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dbService.DeleteEmployee(employee.Id);
                LoadEmployees();
                LoadDevices();
            }
        }

        private void BtnAddDevice_Click(object sender, EventArgs e)
        {
            using (var form = new DeviceForm())
            {

                form.StartPosition = FormStartPosition.Manual;
                form.Location = new System.Drawing.Point(
                    this.Location.X + (this.Width - form.Width) / 2,
                    this.Location.Y + (this.Height - form.Height) / 2
                );

                if (form.ShowDialog() == DialogResult.OK)
                {
                    dbService.AddDevice(form.DeviceData);
                    LoadDevices();
                }
            }
        }

        private void BtnEditDevice_Click(object sender, EventArgs e)
        {
            if (dgvDevices.CurrentRow == null)
            {
                MessageBox.Show("Wybierz urządzenie.");
                return;
            }

            var device = (Device)dgvDevices.CurrentRow.DataBoundItem;

            using (var form = new DeviceForm(device))
            {

                form.StartPosition = FormStartPosition.Manual;
                form.Location = new System.Drawing.Point(
                    this.Location.X + (this.Width - form.Width) / 2,
                    this.Location.Y + (this.Height - form.Height) / 2
                );

                if (form.ShowDialog() == DialogResult.OK)
                {
                    dbService.UpdateDevice(form.DeviceData);
                    LoadDevices();
                }
            }
        }

        private void BtnDeleteDevice_Click(object sender, EventArgs e)
        {
            if (dgvDevices.CurrentRow == null)
            {
                MessageBox.Show("Wybierz urządzenie.");
                return;
            }

            var device = (Device)dgvDevices.CurrentRow.DataBoundItem;

            if (MessageBox.Show("Usunąć urządzenie " + device.Name + "?", "Potwierdź", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dbService.DeleteDevice(device.Id);
                LoadDevices();
            }
        }

        private void AdjustLayout()
        {
            int margin = 10;
            int width = ClientSize.Width;
            int height = ClientSize.Height;

            int dgvWidth = (width - 3 * margin) / 2;
            int dgvHeight = height - 130;

            dgvEmployees.SetBounds(margin, 40, dgvWidth, dgvHeight);
            dgvDevices.SetBounds(margin * 2 + dgvWidth, 40, dgvWidth, dgvHeight);

            lblEmployees.Location = new System.Drawing.Point(margin, 10);
            lblDevices.Location = new System.Drawing.Point(margin * 2 + dgvWidth, 10);

            int btnWidth = 130;
            int btnHeight = 25;
            int btnTop = 40 + dgvHeight + margin;

            SetButtonRow(btnTop, margin, btnWidth, btnHeight, btnAddEmployee, btnEditEmployee, btnDeleteEmployee);
            SetButtonRow(btnTop, margin * 2 + dgvWidth, btnWidth, btnHeight, btnAddDevice, btnEditDevice, btnDeleteDevice);

            btnLoadDatabase.SetBounds(lblEmployees.Right + 10, lblEmployees.Top - 3, btnWidth, btnHeight);
        }

        private void SetButtonRow(int top, int leftStart, int width, int height, params Button[] buttons)
        {
            int margin = 10;
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetBounds(leftStart + i * (width + margin), top, width, height);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
