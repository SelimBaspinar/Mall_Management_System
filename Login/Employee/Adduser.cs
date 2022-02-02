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
    public partial class Adduser : Form
    {
        public Adduser()
        {
            InitializeComponent();
        }
        EmpleyeeProvider islem = new EmpleyeeProvider();
        adminPanel1 adminPanel = Application.OpenForms["adminPanel1"] as adminPanel1;
        UserProvider user = new UserProvider();
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (textBox6.Text.Length == 11)
                {
                    if (textBox4.Text.Contains("@"))
                    {
                        if (user.LoginUser(textBox3.Text, textBox4.Text))
                            MessageBox.Show("Kullanıcı Adı veya Email Mevcut", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            if (islem.InsertEmployee(textBox6.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text, textBox4.Text, "8:00", "16:00"))
                            {
                                try
                                {
                                    DataGridView dw4 = adminPanel.Controls["dataGridView4"] as DataGridView;
                                    dw4.DataSource = islem.getEmployee();
                                    MessageBox.Show("Kullanıcı Eklendi");
                                }
                                catch
                                {
                                    MessageBox.Show("Kullanıcı Eklendi");

                                }
                            }
                            else
                                MessageBox.Show("Bu Kullanıcı Var!");
                        }
                    }else
                        MessageBox.Show("Geçersiz Email!");
                }
                else
                    MessageBox.Show("Geçersiz TC!");
            }
        }

        private void Adduser_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textBox5.PasswordChar = '\0';
            else
                textBox5.PasswordChar = '*';
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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
