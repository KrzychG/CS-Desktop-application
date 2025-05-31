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

        // Przycisk do wczytania pliku SQL
        private Button btnLoadDatabase;

        public MainForm()
        {
            InitializeComponent();

            // Dodaj przycisk dynamicznie (lub dodaj go w Designerze)
            btnLoadDatabase = new Button();
            btnLoadDatabase.Text = "Wczytaj bazę danych (plik SQL)";
            btnLoadDatabase.Width = 250;
            btnLoadDatabase.Top = 10;
            btnLoadDatabase.Left = 10;
            btnLoadDatabase.Click += BtnLoadDatabase_Click;
            this.Controls.Add(btnLoadDatabase);

            AttachEventHandlers();

            // Nie ładuj danych od razu, poczekaj aż użytkownik wczyta bazę
            // LoadEmployees();
            // LoadDevices();
        }

        private void AttachEventHandlers()
        {
            btnAddEmployee.Click += BtnAddEmployee_Click;
            btnEditEmployee.Click += BtnEditEmployee_Click;
            btnDeleteEmployee.Click += BtnDeleteEmployee_Click;

            btnAddDevice.Click += BtnAddDevice_Click;
            btnEditDevice.Click += BtnEditDevice_Click;
            btnDeleteDevice.Click += BtnDeleteDevice_Click;
        }

        private void LoadEmployees()
        {
            try
            {
                employees = dbService.GetEmployees();
                employeesBinding.DataSource = employees;
                dgvEmployees.DataSource = employeesBinding;

                if (dgvEmployees.Columns[nameof(Employee.Id)] != null)
                {
                    dgvEmployees.Columns[nameof(Employee.Id)].HeaderText = "ID";
                    dgvEmployees.Columns[nameof(Employee.Id)].Width = 50;
                }

                if (dgvEmployees.Columns[nameof(Employee.FirstName)] != null)
                    dgvEmployees.Columns[nameof(Employee.FirstName)].HeaderText = "Imię";

                if (dgvEmployees.Columns[nameof(Employee.LastName)] != null)
                    dgvEmployees.Columns[nameof(Employee.LastName)].HeaderText = "Nazwisko";

                if (dgvEmployees.Columns[nameof(Employee.Department)] != null)
                    dgvEmployees.Columns[nameof(Employee.Department)].HeaderText = "Dział";
            }
            catch (PostgresException pgEx)
            {
                MessageBox.Show($"Błąd podczas ładowania pracowników: {pgEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania pracowników: {ex.Message}");
            }
        }

        private void LoadDevices()
        {
            try
            {
                devices = dbService.GetDevices();
                devicesBinding.DataSource = devices;
                dgvDevices.DataSource = devicesBinding;

                if (dgvDevices.Columns[nameof(Device.Id)] != null)
                    dgvDevices.Columns[nameof(Device.Id)].Visible = false;

                if (dgvDevices.Columns[nameof(Device.Name)] != null)
                    dgvDevices.Columns[nameof(Device.Name)].HeaderText = "Nazwa urządzenia";

                if (dgvDevices.Columns[nameof(Device.SerialNumber)] != null)
                    dgvDevices.Columns[nameof(Device.SerialNumber)].HeaderText = "Numer seryjny";

                if (dgvDevices.Columns[nameof(Device.PurchaseDate)] != null)
                    dgvDevices.Columns[nameof(Device.PurchaseDate)].HeaderText = "Data zakupu";

                if (dgvDevices.Columns[nameof(Device.EmployeeId)] != null)
                    dgvDevices.Columns[nameof(Device.EmployeeId)].HeaderText = "ID pracownika";
            }
            catch (PostgresException pgEx)
            {
                MessageBox.Show($"Błąd podczas ładowania urządzeń: {pgEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania urządzeń: {ex.Message}");
            }
        }

        private void BtnLoadDatabase_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
                openFileDialog.Multiselect = true; // można wybrać wiele plików

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
                        MessageBox.Show("Baza danych została pomyślnie utworzona i załadowana.");

                        // Po wczytaniu bazy ładujemy dane do UI
                        LoadEmployees();
                        LoadDevices();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Błąd podczas wczytywania bazy: {ex.Message}");
                    }
                }
            }
        }

        // Eventy przycisków dodawania, edycji, usuwania pracowników i urządzeń
        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            using (var form = new EmployeeForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var newEmployee = form.EmployeeData;
                    dbService.AddEmployee(newEmployee);
                    LoadEmployees();
                }
            }
        }

        private void BtnEditEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("Wybierz pracownika do edycji.");
                return;
            }

            dynamic selected = dgvEmployees.CurrentRow.DataBoundItem;
            int selectedId = selected.Id;

            var selectedEmployee = employees.Find(emp => emp.Id == selectedId);

            if (selectedEmployee == null)
            {
                MessageBox.Show("Nie znaleziono pracownika.");
                return;
            }

            using (var form = new EmployeeForm(selectedEmployee))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var updated = form.EmployeeData;
                    dbService.UpdateEmployee(updated);
                    LoadEmployees();
                }
            }
        }

        private void BtnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show("Wybierz pracownika do usunięcia.");
                return;
            }

            dynamic selected = dgvEmployees.CurrentRow.DataBoundItem;
            int selectedId = selected.Id;

            var selectedEmployee = employees.Find(emp => emp.Id == selectedId);

            if (selectedEmployee == null)
            {
                MessageBox.Show("Nie znaleziono pracownika.");
                return;
            }

            var confirm = MessageBox.Show($"Czy na pewno chcesz usunąć pracownika {selectedEmployee.FirstName} {selectedEmployee.LastName}?", "Potwierdzenie", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                dbService.DeleteEmployee(selectedId);
                LoadEmployees();
            }
        }

        private void BtnAddDevice_Click(object sender, EventArgs e)
        {
            using (var form = new DeviceForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var newDevice = form.DeviceData;
                    dbService.AddDevice(newDevice);
                    LoadDevices();
                }
            }
        }

        private void BtnEditDevice_Click(object sender, EventArgs e)
        {
            if (dgvDevices.CurrentRow == null)
            {
                MessageBox.Show("Wybierz urządzenie do edycji.");
                return;
            }

            dynamic selected = dgvDevices.CurrentRow.DataBoundItem;
            int selectedId = selected.Id;

            var selectedDevice = devices.Find(dev => dev.Id == selectedId);

            if (selectedDevice == null)
            {
                MessageBox.Show("Nie znaleziono urządzenia.");
                return;
            }

            using (var form = new DeviceForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var updated = form.DeviceData;
                    dbService.UpdateDevice(updated);
                    LoadDevices();
                }
            }
        }

        private void BtnDeleteDevice_Click(object sender, EventArgs e)
        {
            if (dgvDevices.CurrentRow == null)
            {
                MessageBox.Show("Wybierz urządzenie do usunięcia.");
                return;
            }

            dynamic selected = dgvDevices.CurrentRow.DataBoundItem;
            int selectedId = selected.Id;

            var selectedDevice = devices.Find(dev => dev.Id == selectedId);

            if (selectedDevice == null)
            {
                MessageBox.Show("Nie znaleziono urządzenia.");
                return;
            }

            var confirm = MessageBox.Show($"Czy na pewno chcesz usunąć urządzenie {selectedDevice.Name}?", "Potwierdzenie", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                dbService.DeleteDevice(selectedId);
                LoadDevices();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
