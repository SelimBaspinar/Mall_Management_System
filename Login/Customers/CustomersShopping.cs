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
    public partial class CustomersShopping : Form
    {
        public CustomersShopping()
        {
            InitializeComponent();
        }
        CustomersProvider customers = new CustomersProvider();
        ProductProvider product = new ProductProvider();

        adminPanel1 adminPanel = Application.OpenForms["adminPanel1"] as adminPanel1;
        PersonalPanel personal = Application.OpenForms["PersonalPanel"] as PersonalPanel;
        string date = DateTime.Now.ToShortDateString();
        string Sstat;
        string scount;
        string pcount;
        string tsale;
        DataGridView dw3;
        DataGridView dw1;
        DataGridView dw2;

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            try
            {
                dw3 = adminPanel.Controls["dataGridView3"] as DataGridView;
                dw1 = adminPanel.Controls["dataGridView1"] as DataGridView;
                dw2 = adminPanel.Controls["dataGridView2"] as DataGridView;
            }
            catch {
                dw3 = personal.Controls["dataGridView3"] as DataGridView;
                dw1 = personal.Controls["dataGridView1"] as DataGridView;
                dw2 = personal.Controls["dataGridView2"] as DataGridView;
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (textBox1.Text.Length != 10)
                    MessageBox.Show("Telefon Numarası Geçersiz", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    for (i = 0; i < dw3.Rows.Count - 1; i++)
                    {
                        if (textBox1.Text == dw3.Rows[i].Cells[0].Value.ToString())
                        {
                            Sstat = dw3.Rows[i].Cells[7].Value.ToString();
                            scount = dw3.Rows[i].Cells[6].Value.ToString();
                            break;
                        }
                    }
                    for (i = 0; i < dw1.Rows.Count - 1; i++)
                    {
                        if (textBox2.Text == dw1.Rows[i].Cells[0].Value.ToString())
                        {
                            pcount = dw1.Rows[i].Cells[2].Value.ToString();
                            tsale = dw2.Rows[i].Cells[2].Value.ToString();
                            break;
                        }
                    }
  
                        if (customers.ContainsCustomers(textBox1.Text))
                        {
                        if (product.ContainsProduct(textBox2.Text))
                        {
                            if (Convert.ToInt32(pcount) < Convert.ToInt32(textBox3.Text))
                                MessageBox.Show("Yeterli Ürün Mevcut Değiş", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else { 
                                scount = (Convert.ToInt32(scount) + Convert.ToInt32(textBox3.Text)).ToString();
                                tsale = (Convert.ToInt32(tsale) + Convert.ToInt32(textBox3.Text)).ToString();
                                pcount = (Convert.ToInt32(pcount) - Convert.ToInt32(textBox3.Text)).ToString();
                                dw1.DataSource = product.updateProduct(textBox2.Text, pcount);
                                dw2.DataSource = product.updateStattsale(textBox2.Text, tsale);
                                dw3.DataSource = customers.updateScount(textBox1.Text, date, scount, Sstat);
                                MessageBox.Show("Satış Gerçekleştirildi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            } 
                        }
                        else
                            MessageBox.Show("Ürün Bulunamadı", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Müşteri Bulunamadı", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
    }
}
