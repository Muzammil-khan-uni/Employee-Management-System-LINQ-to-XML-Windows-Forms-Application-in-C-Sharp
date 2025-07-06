using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LinqToXmlExample
{
    public partial class Form1 : Form
    {
        private XDocument xdoc;
        private string xmlFilePath = "employees.xml";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadXml_Click(object sender, EventArgs e)
        {
            try
            {
                xdoc = XDocument.Load(xmlFilePath);
            }
            catch
            {
                // If file doesn't exist, create a new XDocument
                xdoc = new XDocument(new XElement("employees"));
                xdoc.Save(xmlFilePath);
            }

            BindData();
        }

        private void BindData()
        {
            var query = from employee in xdoc.Descendants("Employee")
                        select new
                        {
                            ID = (int)employee.Element("ID"),
                            Name = (string)employee.Element("Name"),
                            Age = (int)employee.Element("Age"),
                            Salary= (string)employee.Element("Salary"),
                            Designation= (string)employee.Element("Designation"),
                            Company = (string)employee.Element("Company")
                        };

            dataGridView1.DataSource = query.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                XElement newEmployee = new XElement("Employee",
                    new XElement("ID", int.Parse(txtID.Text)),
                    new XElement("Name", txtName.Text),
                    new XElement("Age", int.Parse(txtAge.Text)),
                    new XElement("Salary", txtSalary.Text),
                    new XElement("Designation", txtDesignation.Text),
                    new XElement("Company", txtCompany.Text)
                );

                xdoc.Root.Add(newEmployee);
                xdoc.Save(xmlFilePath);
                BindData();
                MessageBox.Show("Employee data Added Successfully.");
                ClearInputFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                XElement employee = xdoc.Descendants("Employee")
                    .Where(s => (int)s.Element("ID") == int.Parse(txtID.Text))
                    .FirstOrDefault();

                if (employee != null)
                {
                    employee.SetElementValue("Name", txtName.Text);
                    employee.SetElementValue("Age", int.Parse(txtAge.Text));
                    employee.SetElementValue("Salary", txtSalary.Text);
                    employee.SetElementValue("Designation", txtDesignation.Text);
                    employee.SetElementValue("Company", txtCompany.Text);

                    xdoc.Save(xmlFilePath);
                    BindData();
                    MessageBox.Show("Employee data Updated Successfully.");
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Employee not found for updating.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(txtID.Text, out id))
            {
                XElement employee = xdoc.Descendants("Employee")
                    .Where(s => (int)s.Element("ID") == id)
                    .FirstOrDefault();

                if (employee != null)
                {
                    employee.Remove();
                    xdoc.Save(xmlFilePath);
                    BindData();
                    MessageBox.Show("Employee data Deleted Successfully.");
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Employee not found for deletion.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID to delete.");
            }
        }

        private bool ValidateInput()
        {
            int id, age;
            if (!int.TryParse(txtID.Text, out id))
            {
                MessageBox.Show("Please enter a valid ID.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a Name.");
                return false;
            }
            if (!int.TryParse(txtAge.Text, out age))
            {
                MessageBox.Show("Please enter a valid Age.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSalary.Text))
            {
                MessageBox.Show("Please enter a Salary.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDesignation.Text))
            {
                MessageBox.Show("Please enter a Designation.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCompany.Text))
            {
                MessageBox.Show("Please enter a Company.");
                return false;
            }

            return true;
        }

        private void ClearInputFields()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            txtSalary.Text = "";
            txtDesignation.Text = "";
            txtCompany.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Populate input fields when a row is selected
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtAge.Text = row.Cells["Age"].Value.ToString();
                txtSalary.Text = row.Cells["Salary"].Value.ToString();
                txtDesignation.Text = row.Cells["Designation"].Value.ToString();
                txtCompany.Text = row.Cells["Company"].Value.ToString();
            }
        }

        private void btnSaveXml_Click(object sender, EventArgs e)
        {
            xdoc.Save(xmlFilePath);
            MessageBox.Show("XML file saved successfully.");
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            txtSalary.Text = "";
            txtDesignation.Text = "";
            txtCompany.Text = "";
        }
    }
}
