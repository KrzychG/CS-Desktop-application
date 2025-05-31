using System;
using System.Windows.Forms;


namespace SystemZarzadzaniaUrzadzeniami.Forms
{
    public partial class EmployeeForm : Form
    {
        public Employee EmployeeData { get; private set; }

        public EmployeeForm()
        {
            InitializeComponent();
            this.Text = "Dodaj pracownika";
        }

        public EmployeeForm(Employee existingEmployee) : this()
        {
            this.Text = "Edytuj pracownika";
            txtFirstName.Text = existingEmployee.FirstName;
            txtLastName.Text = existingEmployee.LastName;
            txtDepartment.Text = existingEmployee.Department;
            EmployeeData = existingEmployee;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtDepartment.Text))
            {
                MessageBox.Show("Wszystkie pola są wymagane.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EmployeeData == null)
            {
                EmployeeData = new Employee();
            }

            EmployeeData.FirstName = txtFirstName.Text.Trim();
            EmployeeData.LastName = txtLastName.Text.Trim();
            EmployeeData.Department = txtDepartment.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
