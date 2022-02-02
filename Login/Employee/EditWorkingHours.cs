using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class EditWorkingHours : Form
    {
        public EditWorkingHours()
        {
            InitializeComponent();
        }
        EmpleyeeProvider islem1 = new EmpleyeeProvider();
        adminPanel1 adminPanel = Application.OpenForms["adminPanel1"] as adminPanel1;
        private void button1_Click(object sender, EventArgs e)
        {

            if (islem1.ContainsEmployee(textBox1.Text))
            {
                islem1.updateEmployee(textBox1.Text, dateTimePicker1.Text, dateTimePicker2.Text);
                

                DataGridView dw4 = adminPanel.Controls["dataGridView4"] as DataGridView;
                dw4.DataSource = islem1.getEmployee();
            }
            else
            {
                MessageBox.Show("Çalışan Bulunamadı", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar < 48 || (int)e.KeyChar > 57)
            {
                if ((int)e.KeyChar == 8)
                {
                }
                else
                {

                    MessageBox.Show("Lütfen Sadece Sayı Giriniz", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
