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
    public partial class AddCustomers : Form
    {
        public AddCustomers()
        {
            InitializeComponent();
        }
        CustomersProvider customers = new CustomersProvider();
        ProductProvider productProvider = new ProductProvider();
        adminPanel1 adminPanel = Application.OpenForms["adminPanel1"] as adminPanel1;
        PersonalPanel personal = Application.OpenForms["PersonalPanel"] as PersonalPanel;
        DataGridView dw3;
        DataGridView dw2;
        DataGridView dw1;
        string date = DateTime.Now.ToShortDateString();
        DialogResult dialog = new DialogResult();
        bool foundstat = true;
        string scount;
        string Sstat;
        string tsale;
        string count;
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

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                dw1 = adminPanel.Controls["dataGridView1"] as DataGridView;
                dw2 = adminPanel.Controls["dataGridView2"] as DataGridView;
                dw3 = adminPanel.Controls["dataGridView3"] as DataGridView;
            }
            catch
            {

                dw1 = personal.Controls["dataGridView1"] as DataGridView;
                dw2 = personal.Controls["dataGridView2"] as DataGridView;
                dw3 = personal.Controls["dataGridView3"] as DataGridView;
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (textBox1.Text.Length==10) {
                    if (checkBox1.Checked == true)
                    {

                        for (i = 0; i < dw1.Rows.Count - 1; i++)
                        {
                            if (textBox4.Text == dw1.Rows[i].Cells[0].Value.ToString())
                            {
                                count = dw1.Rows[i].Cells[2].Value.ToString();
                                tsale = dw2.Rows[i].Cells[2].Value.ToString();
                                break;
                            }

                        }
                        if (Convert.ToInt32(count) > 0)
                        {
                            tsale = (Convert.ToInt32(tsale) + Convert.ToInt32(1)).ToString();
                            count = (Convert.ToInt32(count) - Convert.ToInt32(1)).ToString();
                            if (productProvider.ContainsProduct(textBox4.Text))
                            {
                                productProvider.updateStattsale(textBox4.Text, tsale);
                                productProvider.updateProduct(textBox4.Text, count);
                                dw1.DataSource = productProvider.getProduct();
                                dw2.DataSource = productProvider.getStat();
                                MessageBox.Show("Satış Gerçekleştirildi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                foundstat = true;
                            }
                            else
                            {
                                MessageBox.Show("Ürün Bulunamadı", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                foundstat = false;
                            }
                        i = 0;
                        for (i = 0; i < dw3.Rows.Count - 1; i++)
                        {
                            if (textBox1.Text == dw3.Rows[i].Cells[0].Value.ToString())
                            {
                                scount = dw3.Rows[i].Cells[6].Value.ToString();
                                Sstat = dw3.Rows[i].Cells[7].Value.ToString();
                            }
                        }
                        if (customers.InsertCustomers(textBox1.Text, textBox2.Text, textBox3.Text, date, "0", date, "1"))
                        {
                            dw3.DataSource = customers.getCustomers();
                            MessageBox.Show("Ekleme Gerçekleştirildi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            if (foundstat == true)
                            {
                                dialog = MessageBox.Show("Müşteri Zaten Mevcut Bir Satın Alım Eklendi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                scount = (Convert.ToInt32(scount) + 1).ToString();
                                customers.updateScount(textBox1.Text, date, scount, Sstat);
                                dw3.DataSource = customers.getCustomers();
                                MessageBox.Show("Satın Alım Gerçekleştirildi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                dialog = MessageBox.Show("Müşteri Zaten Mevcut", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        }else
                          MessageBox.Show("Yeterli Ürün Yok", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (customers.InsertCustomers(textBox1.Text, textBox2.Text, textBox3.Text, date, "0", "0", "0"))
                        {
                            dw3.DataSource = customers.getCustomers();
                            MessageBox.Show("Ekleme Gerçekleştirildi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Müşteri Zaten Mevcut", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }else
                    MessageBox.Show("Telefon Geçersiz", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox4.Enabled = true;
            }
            else {
                textBox4.Enabled = false;
            }
        }
    }
}

