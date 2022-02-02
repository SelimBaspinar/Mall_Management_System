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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        ProductProvider islem = new ProductProvider();
        DataTable data = new DataTable();
        adminPanel1 adminPanel = Application.OpenForms["adminPanel1"] as adminPanel1;
        DataGridView dw;
        DataGridView dw2;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                dw = adminPanel.Controls["dataGridView1"] as DataGridView;
                dw2 = adminPanel.Controls["dataGridView2"] as DataGridView;
                if (islem.InsertProduct(textBox1.Text, textBox2.Text, textBox3.Text))
                {
                    dw.DataSource = islem.getProduct();
                    islem.InsertStat(textBox1.Text, textBox2.Text, "0", "0");
                    dw2.DataSource = islem.getStat();
                    MessageBox.Show("The product has been added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The product with " + textBox1.Text + " has already been added.");
                }

            }
           
        }

    

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void AddProduct_Load_1(object sender, EventArgs e)
        {

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
