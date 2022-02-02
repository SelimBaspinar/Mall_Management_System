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
    public partial class Sale : Form
    {
        public Sale()
        {
            InitializeComponent();
        }
        ProductProvider productProvider = new ProductProvider();
        
        string name;
        int i;
        string tsale;
        string count;
        private void button1_Click(object sender, EventArgs e)
        {
            adminPanel1 adminPanel = Application.OpenForms["adminPanel1"] as adminPanel1;
            DataGridView dw1 = adminPanel.Controls["dataGridView1"] as DataGridView;
            DataGridView dw2 = adminPanel.Controls["dataGridView2"] as DataGridView;
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                for (i = 0; i < dw1.Rows.Count - 1; i++)
                {
                    if (textBox1.Text == dw1.Rows[i].Cells[0].Value.ToString())
                    {
                        name = dw1.Rows[i].Cells[1].Value.ToString();
                        count = dw1.Rows[i].Cells[2].Value.ToString();
                        tsale = dw2.Rows[i].Cells[2].Value.ToString();
                        break;
                    }

                }
                if (Convert.ToInt32(count) < Convert.ToInt32(textBox2.Text))
                    MessageBox.Show("Yeterli Ürün Yok", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    if (productProvider.ContainsProduct(textBox1.Text))
                    {
                        tsale = (Convert.ToInt32(tsale) + Convert.ToInt32(textBox2.Text)).ToString();
                        if (Convert.ToInt32(textBox2.Text) > Convert.ToInt32(count))
                        {
                            MessageBox.Show("Yeterli Stok Yok", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            count = (Convert.ToInt32(count) - Convert.ToInt32(textBox2.Text)).ToString();
                            dw1.DataSource = productProvider.updateProduct(textBox1.Text, name, count);
                            dw2.DataSource = productProvider.updateStattsale(textBox1.Text, tsale);
                            MessageBox.Show("Satış Gerçekleştirildi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Ürün Bulunamadı", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
 

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Sale_Load(object sender, EventArgs e)
        {

        }
    }
}
