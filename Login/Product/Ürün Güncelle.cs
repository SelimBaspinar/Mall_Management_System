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
    public partial class Ürün_Güncelle : Form
    {
        public Ürün_Güncelle()
        {
            InitializeComponent();
        }
        ProductProvider product = new ProductProvider();
        adminPanel1 adminPanel = Application.OpenForms["adminPanel1"] as adminPanel1;
        string Count;
        int i;

        DataGridView dw1;
        DataGridView dw2;
        private void button1_Click(object sender, EventArgs e)
        {

            dw1 = adminPanel.Controls["dataGridView1"] as DataGridView;
            dw2 = adminPanel.Controls["dataGridView2"] as DataGridView;
            for (i = 0; i < dw1.Rows.Count - 1; i++) { 
           if(textBox1.Text == dw1.Rows[i].Cells[0].Value.ToString())
                {
                    Count = dw1.Rows[i].Cells[2].Value.ToString();
                }
            }

            if (product.ContainsProduct(textBox1.Text))
                {
                    product.updateProduct(textBox1.Text, textBox2.Text, Count);
                    product.updateStat(textBox1.Text, textBox2.Text);
                    
                    dw1.DataSource = product.getProduct();
                    dw2.DataSource = product.getStat();
                }
                else
                {
                    MessageBox.Show("Ürün Bulunamadı", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar < 48 || (int)e.KeyChar > 57)
            {
                if ((int)e.KeyChar ==8)
                { 
                }
                else
                {
                    
                    MessageBox.Show("Lütfen Sadece Sayı Giriniz", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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

        private void Ürün_Güncelle_Load(object sender, EventArgs e)
        {

        }
    }
}
